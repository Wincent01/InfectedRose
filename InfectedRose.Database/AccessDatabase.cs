using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Database.Fdb;
using RakDotNet.IO;

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

        public static async Task<AccessDatabase> OpenAsync(string file)
        {
            await using var stream = File.OpenRead(file);

            using var reader = new BitReader(stream);

            var source = new DatabaseFile();

            source.Deserialize(reader);

            return new AccessDatabase(source);
        }

        public async Task SaveAsync(string file, Action<int> callback = null)
        {
            callback ??= i => { };

            var bytes = Source.Compile(callback);

            File.WriteAllBytes(file, bytes);
        }

        public static async Task OpenEmptyAsync()
        {
            var source = new DatabaseFile();

            source.TableHeader = new FdbTableHeader(0);
        }

        internal void RegisterSql(string sql)
        {
            OnSql?.Invoke(sql);
        }
    }
}