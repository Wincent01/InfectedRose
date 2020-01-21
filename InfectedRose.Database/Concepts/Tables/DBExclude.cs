namespace InfectedRose.Database.Concepts.Tables
{
    public class DBExcludeTable

    {
        public DBExcludeTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public string table
        {
            get => (string) Column["table"].Value;

            set => Column["table"].Value = value;
        }

        public string column
        {
            get => (string) Column["column"].Value;

            set => Column["column"].Value = value;
        }
    }
}