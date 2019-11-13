namespace InfectedRose.Database
{
    public class ColumnInfo
    {
        internal Table Table { get; private set; }
        
        internal int Index { get; private set; }

        public DataType Type
        {
            get => Table.Info.Data.Fields[Index].type;
            set
            {
                var dataField = Table.Info.Data.Fields[Index];

                dataField.type = value;

                Table.Info.Data.Fields[Index] = dataField;
            }
        }
        
        public string Name
        {
            get => Table.Info.Data.Fields[Index].name;
            set
            {
                var dataField = Table.Info.Data.Fields[Index];

                dataField.name = new FdbString
                {
                    Value = value
                };

                Table.Info.Data.Fields[Index] = dataField;
            }
        }
        
        internal ColumnInfo(Table table, int index)
        {
            Table = table;
            Index = index;
        }
    }
}