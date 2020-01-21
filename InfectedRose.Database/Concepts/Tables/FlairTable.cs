namespace InfectedRose.Database.Concepts.Tables
{
    public class FlairTableTable

    {
        public FlairTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string asset
        {
            get => (string) Column["asset"].Value;

            set => Column["asset"].Value = value;
        }
    }
}