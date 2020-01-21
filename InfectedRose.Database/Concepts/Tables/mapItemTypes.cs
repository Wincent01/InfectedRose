namespace InfectedRose.Database.Concepts.Tables
{
    public class mapItemTypesTable

    {
        public mapItemTypesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public string equipLocation
        {
            get => (string) Column["equipLocation"].Value;

            set => Column["equipLocation"].Value = value;
        }
    }
}