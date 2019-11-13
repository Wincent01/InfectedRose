using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InfectedRose.Database
{
    public class Column : IList<Field>
    {
        internal FdbRowInfo Data { get; private set; }
        
        internal Table Table { get; private set; }
        
        internal Column(FdbRowInfo data, Table table)
        {
            Data = data;
            Table = table;
        }

        public IEnumerator<Field> GetEnumerator()
        {
            int index = default;

            return Data.DataHeader.Data.Fields.Select(
                field => new Field(Data.DataHeader.Data, index++, Table)
            ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Field item)
        {
            throw new NotSupportedException("Fields should fallow the table structure, and their signature should not be changed.");
        }

        public void Clear()
        {
            throw new NotSupportedException("Fields should fallow the table structure, and their signature should not be changed.");
        }

        public bool Contains(Field item)
        {
            if (item == default) return false;
            
            int index = default;
            
            var list = Data.DataHeader.Data.Fields.Select(
                field => new Field(Data.DataHeader.Data, index++, Table)
            ).ToList();

            return list.Any(c => c.Data == item.Data && c.Index == item.Index);
        }

        public void CopyTo(Field[] array, int arrayIndex)
        {
            int index = default;
            
            var list = Data.DataHeader.Data.Fields.Select(
                field => new Field(Data.DataHeader.Data, index++, Table)
            ).ToList();

            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Field item)
        {
            throw new NotSupportedException("Fields should fallow the table structure, and their signature should not be changed.");
        }

        public int Count => Data.DataHeader.Data.Fields.Length;

        public bool IsReadOnly => false;
        
        public int IndexOf(Field item)
        {
            return item?.Index ?? -1;
        }

        public void Insert(int index, Field item)
        {
            throw new NotSupportedException("Fields should fallow the table structure, and their signature should not be changed.");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("Fields should fallow the table structure, and their signature should not be changed.");
        }

        public Field this[int index]
        {
            get => new Field(Data.DataHeader.Data, index, Table);
            set => throw new NotSupportedException("Fields should fallow the table structure, and their signature should not be changed.");
        }

        public Field this[string name]
        {
            get
            {
                int index = default;

                for (var i = 0; i < Table.TableInfo.Count; i++)
                {
                    var column = Table.TableInfo[i];

                    if (column.Name == name) index = i;
                }

                return new Field(Data.DataHeader.Data, index, Table);
            }
        }
    }
}