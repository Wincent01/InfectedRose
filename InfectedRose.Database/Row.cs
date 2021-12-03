using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InfectedRose.Database.Fdb;

namespace InfectedRose.Database
{
    public class Row : IList<Field>
    {
        internal Row(FdbRowInfo data, Table table)
        {
            Data = data;
            Table = table;
        }

        internal FdbRowInfo Data { get; }

        internal Table Table { get; }

        public int Key
        {
            get
            {
                var key = this[0].Value;

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
        }

        public Field this[string name]
        {
            get
            {
                var index = -1;

                for (var i = 0; i < Table.TableInfo.Count; i++)
                {
                    var column = Table.TableInfo[i];

                    if (column.Name == name) index = i;
                }

                if (index == -1)
                {
                    throw new KeyNotFoundException(
                        $"The given field key of {name} does not exist in the {Table.Name} table"
                    );
                }

                return new Field(Data.DataHeader.Data, index, Table, this);
            }
        }

        public IEnumerator<Field> GetEnumerator()
        {
            int index = default;

            return Data.DataHeader.Data.Fields.Select(
                field => new Field(Data.DataHeader.Data, index++, Table, this)
            ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Field item)
        {
            throw new NotSupportedException(
                "Fields should fallow the table structure, and their signature should not be changed.");
        }

        public void Clear()
        {
            throw new NotSupportedException(
                "Fields should fallow the table structure, and their signature should not be changed.");
        }

        public bool Contains(Field item)
        {
            if (item == default) return false;

            int index = default;

            var list = Data.DataHeader.Data.Fields.Select(
                field => new Field(Data.DataHeader.Data, index++, Table, this)
            ).ToList();

            return list.Any(c => c.Data == item.Data && c.Index == item.Index);
        }

        public void CopyTo(Field[] array, int arrayIndex)
        {
            int index = default;

            var list = Data.DataHeader.Data.Fields.Select(
                field => new Field(Data.DataHeader.Data, index++, Table, this)
            ).ToList();

            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Field item)
        {
            throw new NotSupportedException(
                "Fields should fallow the table structure, and their signature should not be changed.");
        }

        public int Count => Data.DataHeader.Data.Fields.Length;

        public bool IsReadOnly => false;

        public int IndexOf(Field item)
        {
            return item?.Index ?? -1;
        }

        public void Insert(int index, Field item)
        {
            throw new NotSupportedException(
                "Fields should fallow the table structure, and their signature should not be changed.");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException(
                "Fields should fallow the table structure, and their signature should not be changed.");
        }

        public Field this[int index]
        {
            get => new Field(Data.DataHeader.Data, index, Table, this);
            set => throw new NotSupportedException(
                "Fields should fallow the table structure, and their signature should not be changed.");
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
    }
}