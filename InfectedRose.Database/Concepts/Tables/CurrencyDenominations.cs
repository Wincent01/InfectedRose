namespace InfectedRose.Database.Concepts.Tables
{
    public class CurrencyDenominationsTable

    {
        public CurrencyDenominationsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int value
        {
            get => (int) Column["value"].Value;

            set => Column["value"].Value = value;
        }

        public int objectid
        {
            get => (int) Column["objectid"].Value;

            set => Column["objectid"].Value = value;
        }
    }
}