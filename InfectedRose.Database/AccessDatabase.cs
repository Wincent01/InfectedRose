using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    public class AccessDatabase : IList<Table>
    {
        public event Action<string> OnSql;
        
        public DatabaseFile Source { get; private set; }

        public AccessDatabase(DatabaseFile source)
        {
            Source = source;
        }

        public static async Task<AccessDatabase> OpenAsync(string file)
        {
            await using var stream = File.OpenRead(file);

            using var reader = new BitReader(stream);
            
            var source = new DatabaseFile();

            source.Deserialize(reader);

            return new AccessDatabase(source);
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

        /*
        public void FixRows()
        {
            foreach (var table in this)
            {
                var current = 0;
                
                var num = FdbRowBucket.NextPowerOf2(table.Count);
                
                var list = new List<(int, List<int>)>();

                foreach (var row in table.Data.RowHeader.RowInfos)
                {
                    var ids = new List<int>();

                    var linked = row;

                    while (linked != default)
                    {
                        var key = linked.DataHeader.Data.Fields[0].value;

                        int index;

                        switch (key)
                        {
                            case int keyInt:
                                index = keyInt;
                                break;
                            case string val:
                                index = (int) Hash(val.Select(k => (byte) k).ToArray());
                                break;
                            case FdbString keyStr:
                                index = (int) Hash(keyStr.Value.Select(k => (byte) k).ToArray());
                                break;
                            case long lon:
                                index = (int) lon;
                                break;
                            case FdbBitInt bitInt:
                                index = (int) bitInt.Value;
                                break;
                            default:
                                throw new ArgumentException($"Invalid primary key: [{key.GetType()}] {key}");
                        }
                        
                        ids.Add(index);

                        linked = linked.Linked;

                        current++;
                    }

                    list.Add((current, ids));

                    current = 0;
                }

                var max = 0;
                
                foreach (var row in table)
                {
                    var key = row[0].Value;

                    int index;

                    switch (key)
                    {
                        case int keyInt:
                            index = keyInt;
                            break;
                        case string val:
                            index = (int) Hash(val.Select(k => (byte) k).ToArray());
                            break;
                        case FdbString keyStr:
                            index = (int) Hash(keyStr.Value.Select(k => (byte) k).ToArray());
                            break;
                        case long lon:
                            index = (int) lon;
                            break;
                        case FdbBitInt bitInt:
                            index = (int) bitInt.Value;
                            break;
                        default:
                            throw new ArgumentException($"Invalid primary key: [{key.GetType()}] {key}");
                    }

                    index = (int) (index % num);

                    if (index > max)
                    {
                        max = index;
                    }
                }

                var count = table.Data.RowHeader.RowInfos.Length;
                
                Console.WriteLine($"LEN: {list.Count} {FdbRowBucket.NextPowerOf2(max)}");

                Console.ReadKey();
                
                Console.WriteLine($"{table.Name} {num}");

                for (var i = 0; i < num; i++)
                {
                    var correct = 0;

                    var ids = new List<int>();

                    for (var j = 0; j < table.Count; j++)
                    {
                        var key = table[j][0].Value;

                        int index;

                        switch (key)
                        {
                            case int keyInt:
                                index = keyInt;
                                break;
                            case string keyStr:
                                index = (int) Hash(keyStr.Select(k => (byte) k).ToArray());
                                break;
                            default:
                                throw new ArgumentException($"Invalid primary key: {key}");
                        }

                        var og = index;

                        Console.Write($"INDEX {(index % count)}\n");
                        
                        if (i % num == index % count)
                        {
                            correct++;

                            ids.Add(og);
                        }
                    }

                    if (list.Count > i + 1)
                    {
                        Console.Write($"{list[i].Item1} [{string.Join(";", list[i].Item2)}]");

                        Console.Write($" -> {correct} [{string.Join(";", ids)}]\n");
                    }
                }
            }

            Console.WriteLine("DONE");
        }
        */

        public async Task RecalculateRows()
        {
            var tasks = new Task[Count];

            var completed = 0;
            
            for (var index = 0; index < Count; index++)
            {
                var savedIndex = index;
                
                tasks[index] = Task.Run(async () =>
                {
                    var table = this[savedIndex];
                    
                    await table.RecalculateRows();
                    
                    Console.WriteLine($"{table.Name} '{table.Count}' [{++completed}/{Count}]");
                });
            }

            await Task.WhenAll(tasks);
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

        public Table this[string name]
        {
            get
            {
                foreach (var (info, data) in Source.TableHeader.Tables)
                {
                    if (info.TableName == name)
                        return new Table(info, data, this);
                }

                return default;
            }
        }

        internal void RegisterSql(string sql)
        {
            OnSql?.Invoke(sql);
        }
    }
}