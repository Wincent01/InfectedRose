using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfectedRose.Database.Fdb;
using InfectedRose.Database.Sql;

namespace InfectedRose.Database
{
    public class Table : IList<Row>
    {
        internal Table(FdbColumnHeader info, FdbRowBucket data, AccessDatabase database)
        {
            Info = info;
            Data = data;
            Database = database;
            TableInfo = new TableInfo(this);
        }

        internal FdbColumnHeader Info { get; }

        internal FdbRowBucket Data { get; }

        internal AccessDatabase Database { get; }

        internal List<int> ClaimedKeys { get; set; } = new List<int>();
        
        public uint Buckets => (uint) Data.RowHeader.RowInfos.Length;
        
        public string Name
        {
            get => Info.TableName;
            set => Info.TableName = new FdbString
            {
                Value = value
            };
        }

        public TableInfo TableInfo { get; }

        private List<Row> Fields
        {
            get
            {
                var columns = new List<Row>();

                foreach (var info in Data.RowHeader.RowInfos)
                {
                    var linked = info;

                    while (linked != default)
                    {
                        columns.Add(new Row(linked, this));

                        linked = linked.Linked;
                    }
                }

                return columns;
            }
        }

        public IEnumerator<Row> GetEnumerator()
        {
            return Fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Row item)
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

        public bool Contains(Row item)
        {
            return Fields.Contains(item);
        }

        public void CopyTo(Row[] array, int arrayIndex)
        {
            Fields.CopyTo(array, arrayIndex);
        }

        public bool Remove(Row item)
        {
            if (item == default) return false;

            Database.RegisterSql(item.SqlDelete());

            for (var index = 0; index < Data.RowHeader.RowInfos.Length; index++)
            {
                var info = Data.RowHeader.RowInfos[index];

                var linked = info;

                if (linked == default) continue;

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

        public int IndexOf(Row item)
        {
            return Fields.IndexOf(item);
        }

        public void Insert(int index, Row item)
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

        public Row this[int index]
        {
            get => Fields[index];
            set => throw new NotSupportedException();
        }

        public bool ContainsKey(int key)
        {
            var index = (uint) key % (uint) Data.RowHeader.RowInfos.Length;
            
            var bucket = Data.RowHeader.RowInfos[index];

            while (bucket != null)
            {
                if ((int) bucket.DataHeader.Data.Fields[0].value == key)
                    return true;
                
                bucket = bucket.Linked;
            }

            return false;
        }

        /// <summary>
        ///     Seek a row
        /// </summary>
        /// <remarks>
        ///     This is the same principle used the access rows when the database is in use
        /// </remarks>
        /// <param name="key">The key of the row you seek</param>
        /// <param name="row">The column found for this key</param>
        /// <returns>If the key was found in this table</returns>
        public bool Seek(int key, out Row row)
        {
            var index = (uint) key % (uint) Data.RowHeader.RowInfos.Length;
            
            var bucket = Data.RowHeader.RowInfos[index];

            while (bucket != null)
            {
                if ((int) bucket.DataHeader.Data.Fields[0].value == key)
                    break;
                
                bucket = bucket.Linked;
            }

            if (bucket != null)
            {
                row = new Row(bucket, this);

                return true;
            }

            row = null;

            return false;
        }

        public IEnumerable<Row> SeekMultiple(int key)
        {
            var index = (uint) key % (uint) Data.RowHeader.RowInfos.Length;
            
            var bucket = Data.RowHeader.RowInfos[index];

            while (bucket != null)
            {
                var value = bucket.DataHeader.Data.Fields[0].value;

                if (!(value is int))
                {
                    if (value is FdbBitInt b) value = (int)b.Value;
                    if (value is FdbString s) value = Hash(s.Value.Select(s => (byte)s).ToArray());
                    if (value is uint u) value = (int) u;
                }
                
                if ((int) value == key)
                {
                    yield return new Row(bucket, this);
                }
                
                bucket = bucket.Linked;
            }
        }

        public int ClaimKey(int min)
        {
            if (TableInfo[0].Type != DataType.Integer)
                throw new NotSupportedException("AccessDatabase can only generate primary keys for Int32 types.");

            var max = Count > 0 ? this.Max(c => c.Key) : 0;

            for (var i = min; i < max; i++)
            {
                if (ContainsKey(i) || ClaimedKeys.Contains(i)) continue;
                
                ClaimedKeys.Add(i);

                return i;
            }

            ClaimedKeys.Add(max + 1);

            return max + 1;
        }
        
        public Row Create()
        {
            if (TableInfo[0].Type != DataType.Integer)
                throw new NotSupportedException("AccessDatabase can only generate primary keys for Int32 types.");

            var max = Count > 0 ? this.Max(c => c.Key) : 0;

            for (var i = 1; i < max; i++)
            {
                if (!ContainsKey(i) && !ClaimedKeys.Contains(i))
                {
                    return Create(i);
                }
            }
            
            return Create(max + 1);
        }
        
        public Row CreateMin(int minKey)
        {
            if (TableInfo[0].Type != DataType.Integer)
                throw new NotSupportedException("AccessDatabase can only generate primary keys for Int32 types.");

            var max = Count > 0 ? this.Max(c => c.Key) : 0;

            for (var i = minKey; i < max; i++)
            {
                if (!ContainsKey(i) && !ClaimedKeys.Contains(i))
                {
                    return Create(i);
                }
            }
            
            return Create(max + 1);
        }
        
        public Row CreateWithFilter(ICollection<int> exclude)
        {
            if (TableInfo[0].Type != DataType.Integer)
                throw new NotSupportedException("AccessDatabase can only generate primary keys for Int32 types.");
            
            var max = Count > 0 ? this.Max(c => c.Key) : 0;

            for (var i = 1; i < max; i++)
            {
                if (!exclude.Contains(i) && !ContainsKey(i) && !ClaimedKeys.Contains(i))
                {
                    return Create(i);
                }
            }

            return Create(max + 1);
        }

        public Row Create(object key, object values = null)
        {
            var list = Data.RowHeader.RowInfos;

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

                DataType newType;

                switch (type)
                {
                    case DataType.Nothing:
                        newType = DataType.Nothing;
                        break;
                    case DataType.Integer:
                        newType = DataType.Integer;
                        break;
                    case DataType.Unknown1:
                        newType = DataType.Integer;
                        break;
                    case DataType.Float:
                        newType = DataType.Float;
                        break;
                    case DataType.Text:
                        newType = DataType.Nothing;
                        break;
                    case DataType.Boolean:
                        newType = DataType.Boolean;
                        break;
                    case DataType.Bigint:
                        newType = DataType.Nothing;
                        break;
                    case DataType.Unknown2:
                        newType = DataType.Integer;
                        break;
                    case DataType.Varchar:
                        newType = DataType.Nothing;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                column.DataHeader.Data.Fields[i] = (newType, GetDefault(type));
            }

            if (list.Length > 0)
            {
                var primaryKey = GetKey(key) % list.Length;
                
                if (primaryKey < 0) primaryKey = -primaryKey;

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
            
            Array.Resize(ref list, list.Length + 1);
            
            Console.WriteLine("Resized row list to " + list.Length);

            list[^1] = column;

            found:

            column.DataHeader.Data.Fields[0].value = key;

            //Data.RowHeader.RowInfos = list.ToArray();

            var col = new Row(column, this);

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

            return new Row(column, this);
        }

        public void Recalculate() => Recalculate(0);

        public void Recalculate(int bucketSize)
        {
            var taken = new List<int>();

            foreach (var row in this)
            {
                if (taken.Contains(row.Key)) continue;

                taken.Add(row.Key);
            }

            var buckets = FdbRowBucket.NextPowerOf2(bucketSize == default ? taken.Count : bucketSize);

            var hierarchy = new Dictionary<uint, List<FdbRowInfo>>();

            var data = this.ToArray();

            if (bucketSize == 1)
            {
                var sorter = data.ToList();

                sorter.Sort((column, column1) => column.Key - column1.Key);

                data = sorter.ToArray();
            }

            foreach (var column in data) column.Data.Linked = default;

            foreach (var column in data)
            {
                var index = (uint) column.Key;

                var key = index % buckets;

                if (hierarchy.TryGetValue(key, out var list))
                {
                    list.Add(column.Data);
                }
                else
                {
                    hierarchy[key] = new List<FdbRowInfo>
                    {
                        column.Data
                    };
                }
            }
            
            var final = new FdbRowInfo[buckets];

            foreach (var pair in hierarchy)
            {
                var key = pair.Key;
                var values = pair.Value;
                
                var root = values[0];

                var current = root;

                values.RemoveAt(0);

                foreach (var value in values)
                {
                    current.Linked = value;

                    current = value;
                }

                final[key] = root;
            }
            
            Data.RowHeader.RowInfos = final.ToArray();
        }

        public static int GetKey(object key)
        {
            var index = key switch
            {
                uint keyUint => (int) keyUint,
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
                    hash ^= (uint) dataToHash[currentIndex + 2] << 18;
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
                DataType.Varchar => null,
                DataType.Text => null,
                DataType.Bigint => null,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}