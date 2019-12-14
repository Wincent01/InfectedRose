using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using InfectedRose.Database.Generic;

namespace InfectedRose.Database
{
    public class AccessDatabase : IList<Table>
    {
        public DatabaseFile File { get; private set; }

        public AccessDatabase(DatabaseFile file)
        {
            File = file;
        }

        public IEnumerator<Table> GetEnumerator()
        {
            return File.TableHeader.Tables.Select(t => new Table(t.info, t.data)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Table item)
        {
            if (item == default) return;

            var list = File.TableHeader.Tables.ToList();
            list.Add((item.Info, item.Data));
            File.TableHeader.Tables = list.ToArray();
        }

        public void Clear()
        {
            File.TableHeader.Tables = new (FdbColumnHeader info, FdbRowBucket data)[0];
        }

        public bool Contains(Table item)
        {
            return this.Any(value => value == item);
        }

        public void CopyTo(Table[] array, int arrayIndex)
        {
            var list = File.TableHeader.Tables.Select(t => new Table(t.info, t.data)).ToList();
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Table item)
        {
            if (item == default) return false;

            var removal = File.TableHeader.Tables.FirstOrDefault(t => t.info == item.Info && t.data == item.Data);

            if (removal == default) return false;

            var list = File.TableHeader.Tables.ToList();
            list.Remove(removal);
            File.TableHeader.Tables = list.ToArray();

            return true;
        }

        public int Count => File.TableHeader.Tables.Length;

        public bool IsReadOnly => false;

        public int IndexOf(Table item)
        {
            if (item == default) return -1;

            return File.TableHeader.Tables.ToList().IndexOf(
                File.TableHeader.Tables.First(t => t.info == item.Info && t.data == item.Data)
            );
        }

        public void Insert(int index, Table item)
        {
            if (item == default) return;

            var list = File.TableHeader.Tables.ToList();
            list.Insert(index, (item.Info, item.Data));
            File.TableHeader.Tables = list.ToArray();
        }

        public void RemoveAt(int index)
        {
            var list = File.TableHeader.Tables.ToList();
            list.RemoveAt(index);
            File.TableHeader.Tables = list.ToArray();
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

                        if (i % num == index % list.Count)
                        {
                            correct++;

                            ids.Add(og);
                        }
                    }

                    if (list.Count > i + 1)
                    {
                        if (list[i].Item1 != correct || list[i].Item2.Any(i1 => !ids.Contains(i1)))
                        {
                            Console.Write($"{list[i].Item1} [{string.Join(";", list[i].Item2)}]");

                            Console.Write($" -> {correct} [{string.Join(";", ids)}]\n");
                        }
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

        private static uint Hash(byte[] dataToHash)
        {
            var dataLength = dataToHash.Length;
            if (dataLength == 0)
                return 0;

            var hash = Convert.ToUInt32(dataLength);
            var remainingBytes = dataLength & 3; // mod 4
            var numberOfLoops = dataLength >> 2; // div 4
            var currentIndex = 0;
            while (numberOfLoops > 0)
            {
                hash += BitConverter.ToUInt16(dataToHash, currentIndex);
                var tmp = (uint) (BitConverter.ToUInt16(dataToHash, currentIndex + 2) << 11) ^ hash;
                hash = (hash << 16) ^ tmp;
                hash += hash >> 11;
                currentIndex += 4;
                numberOfLoops--;
            }

            switch (remainingBytes)
            {
                case 3:
                    hash += BitConverter.ToUInt16(dataToHash, currentIndex);
                    hash ^= hash << 16;
                    hash ^= ((uint) dataToHash[currentIndex + 2]) << 18;
                    hash += hash >> 11;
                    break;
                case 2:
                    hash += BitConverter.ToUInt16(dataToHash, currentIndex);
                    hash ^= hash << 11;
                    hash += hash >> 17;
                    break;
                case 1:
                    hash += dataToHash[currentIndex];
                    hash ^= hash << 10;
                    hash += hash >> 1;
                    break;
                default:
                    break;
            }

            hash ^= hash << 3;
            hash += hash >> 5;
            hash ^= hash << 4;
            hash += hash >> 17;
            hash ^= hash << 25;
            hash += hash >> 6;

            return hash;
        }

        public Table this[int index]
        {
            get
            {
                var (info, data) = File.TableHeader.Tables[index];

                return new Table(info, data);
            }
            set => File.TableHeader.Tables[index] = (value.Info, value.Data);
        }

        public Table this[string name]
        {
            get
            {
                foreach (var (info, data) in File.TableHeader.Tables)
                {
                    if (info.TableName == name)
                        return new Table(info, data);
                }

                return default;
            }
        }
    }
}