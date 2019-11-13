using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InfectedRose.Database
{
    public class Table : IList<Column>
    {
        internal FdbColumnHeader Info { get; private set; }
        
        internal FdbRowBucket Data { get; private set; }

        public string Name
        {
            get => Info.TableName;
            set => Info.TableName = new FdbString
            {
                Value = value
            };
        }

        public TableInfo TableInfo => new TableInfo(this);
        
        internal Table(FdbColumnHeader info, FdbRowBucket data)
        {
            Info = info;
            Data = data;
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
            
            foreach (var info in Data.RowHeader.RowInfos)
            {
                var linked = info;

                if (linked == item.Data)
                {
                    var fields = Data.RowHeader.RowInfos.ToList();

                    fields.Remove(linked);

                    Data.RowHeader.RowInfos = fields.ToArray();

                    return true;
                }

                while (linked != default)
                {
                    if (linked.Linked == item.Data)
                    {
                        linked.Linked = default;

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

        public Column Create() => Create(out _);
        
        public Column Create(out int index)
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

            index = list.Count;
            
            list.Add(column);

            Data.RowHeader.RowInfos = list.ToArray();

            return new Column(column, this);
        }

        private object GetDefault(DataType type)
        {
            return type switch
            {
                DataType.Nothing => (object) 0,
                DataType.Integer => 0,
                DataType.Unknown1 => 0,
                DataType.Float => 0,
                DataType.Boolean => 0,
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