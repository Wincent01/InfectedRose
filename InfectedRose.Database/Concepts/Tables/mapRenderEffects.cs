namespace InfectedRose.Database.Concepts.Tables
{
    public class mapRenderEffectsTable

    {
        public mapRenderEffectsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int gameID
        {
            get => (int) Column["gameID"].Value;

            set => Column["gameID"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }
    }
}