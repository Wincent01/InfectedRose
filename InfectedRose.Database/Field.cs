using InfectedRose.Database.Sql;

namespace InfectedRose.Database
{
    public class Field
    {
        internal FdbRowData Data { get; private set; }
        
        internal int Index { get; private set; }

        internal Table Table { get; private set; }
        
        internal Column Column { get; private set; }

        public string Name => Table.TableInfo[Index].Name;
        
        public DataType Type
        {
            get => Data.Fields[Index].type;
            set
            {
                var dataField = Data.Fields[Index];

                dataField.type = value;

                Data.Fields[Index] = dataField;
            }
        }
        
        public object Value
        {
            get
            {
                var data = Data.Fields[Index].value;

                data = data switch
                {
                    FdbString str => str.Value,
                    FdbBitInt lon => lon.Value,
                    _ => data
                };

                return data;
            }
            set
            {
                var where = Column.WhereSegment();
                
                var dataField = Data.Fields[Index];

                value = value switch
                {
                    string str => new FdbString {Value = str},
                    long lon => new FdbBitInt {Value = lon},
                    _ => value
                };
                
                dataField.value = value;

                Data.Fields[Index] = dataField;
                
                Table.Database.RegisterSql(this.SqlUpdate(where));
            }
        }

        public override string ToString() => Name;

        internal Field(FdbRowData data, int index, Table table, Column column)
        {
            Data = data;
            Index = index;
            Table = table;
            Column = column;
        }
    }
}