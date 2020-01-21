namespace InfectedRose.Database.Concepts.Tables
{
    public class mapShadersTable

    {
        public mapShadersTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string label
        {
            get => (string) Column["label"].Value;

            set => Column["label"].Value = value;
        }

        public int gameValue
        {
            get => (int) Column["gameValue"].Value;

            set => Column["gameValue"].Value = value;
        }

        public int priority
        {
            get => (int) Column["priority"].Value;

            set => Column["priority"].Value = value;
        }
    }
}