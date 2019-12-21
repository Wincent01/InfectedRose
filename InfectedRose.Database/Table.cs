using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using InfectedRose.Database.Sql;

namespace InfectedRose.Database
{
    public class Table : IList<Column>
    {
        internal FdbColumnHeader Info { get; private set; }
        
        internal FdbRowBucket Data { get; private set; }
        
        internal AccessDatabase Database { get; private set; }

        public string Name
        {
            get => Info.TableName;
            set => Info.TableName = new FdbString
            {
                Value = value
            };
        }

        public TableInfo TableInfo => new TableInfo(this);
        
        internal Table(FdbColumnHeader info, FdbRowBucket data, AccessDatabase database)
        {
            Info = info;
            Data = data;
            Database = database;
        }

        private List<Column> Fields
        {
            get
            {
                var columns = new List<Column>();

                foreach (var info in Data.RowHeader.RowInfos)
                {
                    var linked = info;

                    while (linked != default)
                    {
                        columns.Add(new Column(linked, this));

                        linked = linked.Linked;
                    }
                }

                return columns;
            }
        }
        
        public IEnumerator<Column> GetEnumerator()
        {
            return Fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Column item)
        {
            if (item == default) return;
            
            var list = Data.RowHeader.RowInfos.ToList();
            
            list.Add(item.Data);

            Data.RowHeader.RowInfos = list.ToArray();
        }

        public void Clear()
        {
            Data.RowHeader.RowInfos = new FdbRowInfo[0];
        }

        public bool Contains(Column item)
        {
            return Fields.Contains(item);
        }

        public void CopyTo(Column[] array, int arrayIndex)
        {
            Fields.CopyTo(array, arrayIndex);
        }

        public bool Remove(Column item)
        {
            if (item == default) return false;

            for (var index = 0; index < Data.RowHeader.RowInfos.Length; index++)
            {
                var info = Data.RowHeader.RowInfos[index];
                
                var linked = info;

                if (linked == default)
                {
                    continue;
                }

                if (linked == item.Data)
                {
                    var keep = linked.Linked;

                    Data.RowHeader.RowInfos[index] = keep;

                    return true;
                }
                
                while (linked != default)
                {
                    if (linked.Linked == item.Data)
                    {
                        var keep = linked.Linked.Linked;

                        linked.Linked = keep;

                        return true;
                    }

                    linked = linked.Linked;
                }
            }

            return false;
        }

        public int Count => Fields.Count;

        public bool IsReadOnly => false;
        
        public int IndexOf(Column item)
        {
            return Fields.IndexOf(item);
        }

        public void Insert(int index, Column item)
        {
            if (item == default) return;
            
            var list = Data.RowHeader.RowInfos.ToList();
            
            list.Insert(index, item.Data);

            Data.RowHeader.RowInfos = list.ToArray();
        }

        public void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        public Column this[int index]
        {
            get => Fields[index];
            set => throw new NotSupportedException();
        }

        public Column Create()
        {
            if (TableInfo[0].Type != DataType.Integer)
            {
                throw new NotSupportedException("AccessDatabase can only generate primary keys for Int32 types.");
            }

            var max = Count > 0 ? this.Max(c => c.Key) : 0;

            for (var i = 1; i < max; i++)
            {
                if (this.All(c => c.Key != i))
                {
                    return Create(i);
                }
            }

            return Create(max + 1);
        }
        
        public Column Create(object key) => Create(key, null);
        
        public Column Create(object key, object values)
        {
            var list = Data.RowHeader.RowInfos.ToList();

            var column = new FdbRowInfo
            {
                DataHeader = new FdbRowDataHeader
                {
                    Data = new FdbRowData((uint) Info.Data.Fields.Length)
                }
            };

            for (var i = 0; i < Info.Data.Fields.Length; i++)
            {
                var type = Info.Data.Fields[i].type;

                column.DataHeader.Data.Fields[i] = (type, GetDefault(type));
            }

            var primaryKey = GetKey(key) % (list.Count > 0 ? list.Count : 1);
            
            if (list.Count > 0)
            {
                var bucket = list[primaryKey];

                if (bucket == default)
                {
                    list[primaryKey] = column;
                    
                    goto found;
                }

                while (true)
                {
                    if (bucket.Linked == default)
                    {
                        bucket.Linked = column;
                        
                        goto found;
                    }

                    bucket = bucket.Linked;
                }
            }
            
            list.Add(column);
            
            found:

            column.DataHeader.Data.Fields[0].value = key;
            
            Data.RowHeader.RowInfos = list.ToArray();
            
            var col = new Column(column, this);

            Database.RegisterSql(col.SqlInsert());

            if (values == default) return col;

            foreach (var property in values.GetType().GetProperties())
            {
                var id = property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name;

                var value = property.GetValue(values);

                if (value is null)
                {
                    col[id].Type = DataType.Nothing;

                    value = 0;
                }

                col[id].Value = value;
            }

            return new Column(column, this);
        }

        /// <summary>
        ///     Warning! Work in progress, might brake table.
        /// </summary>
        /// <returns></returns>
        public async Task RecalculateRows()
        {
            var taken = new List<int>();
            
            var all = new Dictionary<int, int>();

            foreach (var row in this)
            {
                if (!all.ContainsKey(row.Key))
                {
                    all[row.Key] = 0;
                }
                
                all[row.Key] += 1;
                
                if (taken.Contains(row.Key)) continue;

                taken.Add(row.Key);
            }

            var buckets = (int) FdbRowBucket.NextPowerOf2(taken.Count);
            
            var num = FdbRowBucket.NextPowerOf2(buckets);

            var final = new FdbRowInfo[num];

            var data = this.ToArray();

            foreach (var column in data)
            {
                column.Data.Linked = default;
            }
            
            for (var i = 0; i < num; i++)
            {
                /*
                var correct = 0;

                var ids = new List<int>();
                */

                for (var j = 0; j < data.Length; j++)
                {
                    var index = data[j].Key;
                    
                    var og = index;

                    if (i % num == index % buckets)
                    {
                        //correct++;

                        var bucket = final[index % buckets];
                        
                        if (bucket != default)
                        {
                            var linked = bucket;

                            while (linked.Linked != default)
                            {
                                linked = linked.Linked;
                            }

                            linked.Linked = data[j].Data;
                        }
                        else
                        {
                            final[index % buckets] = data[j].Data;
                        }
                        
                        //ids.Add(og);
                    }
                }
                
                //Console.Write($"{list[i].Item1} [{string.Join(";", list[i].Item2)}]");

                //Console.Write($"{compare[i]} -> {correct} [{string.Join(";", ids)}]\n");
            }
            
            Data.RowHeader.RowInfos = final.ToArray();
            
            //Console.WriteLine($"\n\n\nNEW:\n\n\n");

            /*
            foreach (var info in Data.RowHeader.RowInfos)
            {
                var count = 0;
                
                var top = info;

                while (top != default)
                {
                    top = top.Linked;

                    count++;
                }
                
                //Console.WriteLine($"{count}");
            }
            */
        }

        private static int GetKey(object key)
        {
            var index = key switch
            {
                int keyInt => keyInt,
                string val => (int) Hash(val.Select(k => (byte) k).ToArray()),
                FdbString keyStr => (int) Hash(keyStr.Value.Select(k => (byte) k).ToArray()),
                long lon => (int) lon,
                FdbBitInt bitInt => (int) bitInt.Value,
                _ => throw new ArgumentException($"Invalid primary key: [{key.GetType()}] {key}")
            };

            return index;
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
        
        private object GetDefault(DataType type)
        {
            return type switch
            {
                DataType.Nothing => (object) 0,
                DataType.Integer => 0,
                DataType.Unknown1 => 0,
                DataType.Float => 0,
                DataType.Boolean => false,
                DataType.Unknown2 => 0,
                DataType.Varchar => new FdbString(),
                DataType.Text => new FdbString(),
                DataType.Bigint => new FdbBitInt(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}