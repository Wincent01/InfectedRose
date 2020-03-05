using System.Collections;
using System.Collections.Generic;
using System.Linq;
using InfectedRose.Database.Fdb;

namespace InfectedRose.Database
{
    public class TableInfo : IList<ColumnInfo>
    {
        internal TableInfo(Table table)
        {
            Table = table;
        }

        internal Table Table { get; }

        public IEnumerator<ColumnInfo> GetEnumerator()
        {
            int index = default;

            return Table.Info.Data.Fields.Select(
                field => new ColumnInfo(Table, index++)
            ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ColumnInfo item)
        {
            if (item == default) return;

            var list = Table.Info.Data.Fields.ToList();

            list.Add((item.Type, new FdbString
            {
                Value = item.Name
            }));

            Table.Info.Data.Fields = list.ToArray();
        }

        public void Create(string name, DataType type)
        {
            var list = Table.Info.Data.Fields.ToList();

            list.Add((type, new FdbString
            {
                Value = name
            }));

            Table.Info.Data.Fields = list.ToArray();
        }

        public void Clear()
        {
            Table.Info.Data.Fields = new (DataType type, FdbString name)[0];
        }

        public bool Contains(ColumnInfo item)
        {
            return item != default && Table.Info.Data.Fields.Any(f => f.name == item.Name);
        }

        public void CopyTo(ColumnInfo[] array, int arrayIndex)
        {
            int index = default;

            var list = Table.Info.Data.Fields.Select(field => new ColumnInfo(Table, index++)).ToList();

            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ColumnInfo item)
        {
            if (item == default) return false;

            var list = Table.Info.Data.Fields.ToList();

            list.Remove(list.First(l => l.name == item.Name));

            Table.Info.Data.Fields = list.ToArray();

            return true;
        }

        public int Count => Table.Info.Data.Fields.Length;

        public bool IsReadOnly => false;

        public int IndexOf(ColumnInfo item)
        {
            return item?.Index ?? -1;
        }

        public void Insert(int index, ColumnInfo item)
        {
            if (item == default) return;

            var list = Table.Info.Data.Fields.ToList();

            list.Insert(index, (item.Type, new FdbString
            {
                Value = item.Name
            }));

            Table.Info.Data.Fields = list.ToArray();
        }

        public void RemoveAt(int index)
        {
            Remove(this[index]);
        }

        public ColumnInfo this[int index]
        {
            get => new ColumnInfo(Table, index);
            set
            {
                var list = Table.Info.Data.Fields.ToList();

                list[index] = (value.Type, new FdbString
                {
                    Value = value.Name
                });

                Table.Info.Data.Fields = list.ToArray();
            }
        }
    }
}