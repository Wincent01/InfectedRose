using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfectedRose.Database.Fdb;
using RakDotNet.IO;
using Microsoft.Data.Sqlite;

namespace InfectedRose.Database
{
    public class AccessDatabase : IList<Table>
    {
        public DatabaseFile Source { get; }

        public event Action<string> OnSql;
        
        public List<string> AccessedTables { get; } = new List<string>();

        public AccessDatabase(DatabaseFile source)
        {
            Source = source;
        }

        public Table this[string name]
        {
            get
            {
                foreach (var (info, data) in Source.TableHeader.Tables)
                {
                    if (info.TableName != name) continue;

                    if (!AccessedTables.Contains(name))
                    {
                        AccessedTables.Add(name);
                    }

                    return new Table(info, data, this);
                }

                return default;
            }
        }

        public IEnumerator<Table> GetEnumerator()
        {
            return Source.TableHeader.Tables.Select(t => new Table(t.info, t.data, this)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Table item)
        {
            if (item == default) return;

            var list = Source.TableHeader.Tables.ToList();
            list.Add((item.Info, item.Data));
            Source.TableHeader.Tables = list.ToArray();
        }

        public void Clear()
        {
            Source.TableHeader.Tables = new (FdbColumnHeader info, FdbRowBucket data)[0];
        }

        public bool Contains(Table item)
        {
            return this.Any(value => value == item);
        }

        public void CopyTo(Table[] array, int arrayIndex)
        {
            var list = Source.TableHeader.Tables.Select(t => new Table(t.info, t.data, this)).ToList();
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Table item)
        {
            if (item == default) return false;

            var removal = Source.TableHeader.Tables.FirstOrDefault(t => t.info == item.Info && t.data == item.Data);

            if (removal == default) return false;

            var list = Source.TableHeader.Tables.ToList();
            list.Remove(removal);
            Source.TableHeader.Tables = list.ToArray();

            return true;
        }

        public int Count => Source.TableHeader.Tables.Length;

        public bool IsReadOnly => false;

        public int IndexOf(Table item)
        {
            if (item == default) return -1;

            return Source.TableHeader.Tables.ToList().IndexOf(
                Source.TableHeader.Tables.First(t => t.info == item.Info && t.data == item.Data)
            );
        }

        public void Insert(int index, Table item)
        {
            if (item == default) return;

            var list = Source.TableHeader.Tables.ToList();
            list.Insert(index, (item.Info, item.Data));
            Source.TableHeader.Tables = list.ToArray();
        }

        public void RemoveAt(int index)
        {
            var list = Source.TableHeader.Tables.ToList();
            list.RemoveAt(index);
            Source.TableHeader.Tables = list.ToArray();
        }

        public Table Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} cannot be null or whitespace", nameof(name));

            var columnHeader = new FdbColumnHeader
            {
                TableName = new FdbString
                {
                    Value = name
                }
            };

            var header = new FdbRowBucket
            {
                RowHeader = new FdbRowHeader(0)
            };
            
            var list = Source.TableHeader.Tables.ToList();
            list.Add((columnHeader, header));
            Source.TableHeader.Tables = list.ToArray();

            return new Table(columnHeader, header, this);
        }

        public Table this[int index]
        {
            get
            {
                var (info, data) = Source.TableHeader.Tables[index];

                return new Table(info, data, this);
            }
            set => Source.TableHeader.Tables[index] = (value.Info, value.Data);
        }

        public static AccessDatabase Open(string file)
        {
            using var stream = File.OpenRead(file);

            using var reader = new ByteReader(stream);

            var source = new DatabaseFile();

            source.Deserialize(reader);

            return new AccessDatabase(source);
        }
        
        public static async Task<AccessDatabase> OpenAsync(string file)
        {
            using var stream = File.OpenRead(file);

            using var reader = new ByteReader(stream);

            var source = new DatabaseFile();

            source.Deserialize(reader);

            return new AccessDatabase(source);
        }

        public void Save(string file)
        {
            using var stream = File.Create(file);

            using var reader = new BitWriter(stream);

            Source.Serialize(reader);
        }
        
        public async Task SaveAsync(string file)
        {
            using var stream = File.Create(file);

            using var reader = new BitWriter(stream);
            Source.Serialize(reader);
        }

        public static void OpenEmpty()
        {
            var source = new DatabaseFile { TableHeader = new FdbTableHeader(0) };
        }

        public void SaveSqlite(SqliteConnection connection)
        {
            // For each table, create a sql table
            foreach (var table in this)
            {
                var tableName = table.Name;

                var createTable = $"CREATE TABLE {tableName} (";

                foreach (var column in table.TableInfo)
                {
                    var columnName = column.Name;

                    string columnType;
                    switch (column.Type)
                    {
                        case DataType.Integer:
                            columnType = "INT32";
                            break;
                        case DataType.Float:
                            columnType = "REAL";
                            break;
                        case DataType.Text:
                            columnType = "TEXT_4";
                            break;
                        case DataType.Boolean:
                            columnType = "INT_BOOL";
                            break;
                        case DataType.Bigint:
                            columnType = "INTEGER";
                            break;
                        case DataType.Varchar:
                            columnType = "TEXT_4";
                            break;
                        default:
                            columnType = "TEXT_4";
                            break;
                    }
                    
                    createTable += $"\"{columnName}\" {columnType} NULL,";
                }

                createTable = createTable.TrimEnd(',');
                createTable += ");";

                var command = new SqliteCommand(createTable, connection);
                command.ExecuteNonQuery();

                var count = table.Count;
                
                if (count <= 0) continue;
                
                // Create one query to insert all the rows
                var insertQuery = new StringBuilder(count * table.TableInfo.Count * 8);

                insertQuery.Append($"INSERT INTO {tableName} (");

                foreach (var column in table.TableInfo)
                {
                    insertQuery.Append($"\"{column.Name}\",");
                }

                insertQuery.Length--;

                insertQuery.Append(") VALUES ");

                foreach (var row in table.Data.RowHeader.RowInfos)
                {
                    var linked = row;

                    while (linked != null)
                    {
                        insertQuery.Append('(');

                        foreach (var (type, value) in linked.DataHeader.Data.Fields)
                        {
                            if (type == DataType.Nothing)
                            {
                                insertQuery.Append("null,");
                            }
                            else if (type == DataType.Text || type == DataType.Varchar)
                            {
                                insertQuery.Append($"'{(value.ToString().Replace("'", "''"))}',");
                            }
                            else
                            {
                                insertQuery.Append($"{value},");
                            }
                        }

                        insertQuery.Length--;

                        linked = linked.Linked;

                        insertQuery.Append("),");
                    }
                }

                insertQuery.Length--;

                insertQuery.Append(';');

                var query = insertQuery.ToString();

                command = new SqliteCommand(query, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(query);
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        internal void RegisterSql(string sql)
        {
            OnSql?.Invoke(sql);
        }
    }
}