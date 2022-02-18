using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using InfectedRose.Database.Fdb;
using InfectedRose.Interface;
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
            using var stream = new MemoryStream(40 * 1000 * 1024);
            
            using var reader = new ByteWriter(stream);

            Source.Serialize(reader);

            using var fileStream = File.Create(file);

            stream.WriteTo(fileStream);
        }

        public static AccessDatabase OpenEmpty()
        {
            var source = new DatabaseFile { TableHeader = new FdbTableHeader(0) };
            
            return new AccessDatabase(source);
        }

        public static AccessDatabase OpenXml(AccessDatabase constraints, XmlDatabase xmlDatabase)
        {
            var source = new DatabaseFile { TableHeader = new FdbTableHeader(0) };
            
            var list = new List<(FdbColumnHeader info, FdbRowBucket data)>();

            foreach (var table in constraints)
            {
                var xmlTable = xmlDatabase.Tables.FirstOrDefault(t => t.Name == table.Name);

                if (xmlTable == null)
                {
                    list.Add((table.Info, table.Data));
                    
                    continue;
                }

                var header = new FdbRowInfo();
                var root = header;

                var (info, data) = (new FdbColumnHeader
                {
                                Data = new FdbColumnData((uint) table.TableInfo.Count)
                                {
                                                Fields = table.TableInfo.Select(
                                                                c => (c.Type, new FdbString {Value = c.Name})
                                                ).ToArray()
                                },
                                TableName = new FdbString {Value = table.Name}
                }, new FdbRowBucket
                {
                                RowHeader = new FdbRowHeader(1)
                                {
                                                RowInfos = new FdbRowInfo[1]
                                                {
                                                                root
                                                }
                                }
                });

                if (xmlTable.Rows.Rows == null)
                {
                    data.RowHeader.RowInfos = new FdbRowInfo[0];

                    continue;
                }

                FdbRowInfo prev = null;

                foreach (var xmlRow in xmlTable.Rows.Rows)
                {
                    header.DataHeader = new FdbRowDataHeader
                    {
                                    Data = new FdbRowData((uint) table.TableInfo.Count)
                    };

                    for (var i = 0; i < table.TableInfo.Count; i++)
                    {
                        var column = table.TableInfo[i];
                        if (!xmlRow.Attributes.TryGetValue(column.Name, out var value))
                        {
                            header.DataHeader.Data.Fields[i] = (DataType.Nothing, null);

                            continue;
                        }

                        switch (column.Type)
                        {
                            case DataType.Integer:
                                header.DataHeader.Data.Fields[i] = (column.Type, Convert.ToInt32(value));
                                break;
                            case DataType.Float:
                                header.DataHeader.Data.Fields[i] = (column.Type, Convert.ToSingle(value));
                                break;
                            case DataType.Varchar:
                            case DataType.Text:
                                header.DataHeader.Data.Fields[i] = (column.Type, new FdbString(Convert.ToString(value)));
                                break;
                            case DataType.Boolean:
                                header.DataHeader.Data.Fields[i] = (column.Type, Convert.ToInt32(value) > 0);
                                break;
                            case DataType.Bigint:
                                header.DataHeader.Data.Fields[i] = (column.Type, new FdbBitInt(Convert.ToInt64(value)));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    var linked = new FdbRowInfo();
                    header.Linked = linked;
                    prev = header;
                    header = linked;
                }
                    
                list.Add((info, data));

                if (prev != null)
                {
                    prev.Linked = null;
                }
            }

            source.TableHeader.Tables = list.ToArray();

            return new AccessDatabase(source);
        }
        
        public static AccessDatabase OpenXml(XmlDatabase xmlDatabase)
        {
            var source = new DatabaseFile { TableHeader = new FdbTableHeader(0) };
            
            source.TableHeader.Tables = new (FdbColumnHeader info, FdbRowBucket data)[xmlDatabase.Tables.Count];

            for (var index = 0; index < xmlDatabase.Tables.Count; index++)
            {
                var table = xmlDatabase.Tables[index];
                
                var header = new FdbRowInfo();
                var root = header;
                
                source.TableHeader.Tables[index] = (new FdbColumnHeader
                {
                                Data = new FdbColumnData((uint) table.Columns.Columns.Count)
                                {
                                                Fields = table.Columns.Columns.Select(
                                                                c => (c.Type, new FdbString {Value = c.Name})
                                                ).ToArray()
                                },
                                TableName = new FdbString {Value = table.Name}
                }, new FdbRowBucket
                {
                                RowHeader = new FdbRowHeader(1)
                                {
                                                RowInfos = new FdbRowInfo[1]
                                                {
                                                                root
                                                }
                                }
                });

                if (xmlDatabase.Tables[index].Rows.Rows == null)
                {
                    source.TableHeader.Tables[index].data.RowHeader.RowInfos = new FdbRowInfo[0];
                    
                    continue;
                }

                FdbRowInfo prev = null;
                
                foreach (var xmlRow in xmlDatabase.Tables[index].Rows.Rows)
                {
                    header.DataHeader = new FdbRowDataHeader
                    {
                                    Data = new FdbRowData((uint) table.Columns.Columns.Count)
                    };

                    for (var i = 0; i < table.Columns.Columns.Count; i++)
                    {
                        var column = table.Columns.Columns[i];
                        if (!xmlRow.Attributes.TryGetValue(column.Name, out var value))
                        {
                            header.DataHeader.Data.Fields[i] = (DataType.Nothing, null);
                            
                            continue;
                        }

                        switch (column.Type)
                        {
                            case DataType.Integer:
                                header.DataHeader.Data.Fields[i] = (column.Type, Convert.ToInt32(value));
                                break;
                            case DataType.Float:
                                header.DataHeader.Data.Fields[i] = (column.Type, Convert.ToSingle(value));
                                break;
                            case DataType.Varchar:
                            case DataType.Text:
                                header.DataHeader.Data.Fields[i] = (column.Type, new FdbString(Convert.ToString(value)));
                                break;
                            case DataType.Boolean:
                                header.DataHeader.Data.Fields[i] = (column.Type, Convert.ToInt32(value) > 0);
                                break;
                            case DataType.Bigint:
                                header.DataHeader.Data.Fields[i] = (column.Type, new FdbBitInt(Convert.ToInt64(value)));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    var linked = new FdbRowInfo();
                    header.Linked = linked;
                    prev = header;
                    header = linked;
                }

                if (prev != null)
                {
                    prev.Linked = null;
                }
            }

            return new AccessDatabase(source);
        }

        public XmlDatabase ToXml()
        {
            var xml = new XmlDatabase
            {
                Tables = new List<XmlTable>(Count)
            };

            for (var i = 0; i < Count; i++)
            {
                var table = Source.TableHeader.Tables[i];
                var xmlTable = new XmlTable
                {
                    Name = table.info.TableName.Value,
                    Columns = new XmlColumns
                    {
                        Columns = new List<XmlColumn>(table.info.Data.Fields.Length)
                    }
                };

                for (var j = 0; j < table.info.Data.Fields.Length; j++)
                {
                    var column = table.info.Data.Fields[j];
                    xmlTable.Columns.Columns.Add(new XmlColumn
                    {
                        Name = column.name,
                        Type = column.type
                    });
                }

                xml.Tables.Add(xmlTable);
                
                if (table.data.RowHeader.RowInfos.Length == 0)
                {
                    continue;
                }

                var managedTable = this[table.info.TableName];
                var xmlRows = new List<XmlRow>();

                foreach (var row in managedTable)
                {
                    var xmlRow = new XmlRow();

                    for (var k = 0; k < row.Count; k++)
                    {
                        var field = row[k];
                        if (field.Value == null) continue;
                        xmlRow.Attributes[field.Name] = field.Value;
                    }
                    
                    xmlRows.Add(xmlRow);
                }
                
                var rows = new XmlRows
                {
                    Rows = xmlRows
                };

                xml.Tables[i].Rows = rows;
            }

            return xml;
        }

        public void SaveXml(string path)
        {
            var xml = ToXml();
            var serializer = new XmlSerializer(typeof(XmlDatabase));
            // Serialize with proper indentation
            var writer = new StringWriter();
            serializer.Serialize(writer, xml);
            var doc = XDocument.Parse(writer.ToString());
            File.WriteAllText(path, doc.ToString());
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