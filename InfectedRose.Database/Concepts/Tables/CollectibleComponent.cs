namespace InfectedRose.Database.Concepts.Tables
{
    public class CollectibleComponentTable

    {
        public CollectibleComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int requirement_mission
        {
            get => (int) Column["requirement_mission"].Value;

            set => Column["requirement_mission"].Value = value;
        }
    }
}