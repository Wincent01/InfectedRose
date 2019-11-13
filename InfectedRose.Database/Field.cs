namespace InfectedRose.Database
{
    public class Field
    {
        internal FdbRowData Data { get; private set; }
        
        internal int Index { get; private set; }

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
            get => Data.Fields[Index].value;
            set
            {
                var dataField = Data.Fields[Index];

                value = value switch
                {
                    string str => new FdbString {Value = str},
                    long lon => new FdbBitInt {Value = lon},
                    _ => value
                };

                dataField.value = value;

                Data.Fields[Index] = dataField;
            }
        }
        
        internal Field(FdbRowData data, int index, Table table)
        {
            Data = data;
            Index = index;
        }
    }
}