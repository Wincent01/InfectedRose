namespace InfectedRose.Database.Concepts.Tables
{
    public class ComponentsRegistryTable

    {
        public ComponentsRegistryTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int component_type
        {
            get => (int) Column["component_type"].Value;

            set => Column["component_type"].Value = value;
        }

        public int component_id
        {
            get => (int) Column["component_id"].Value;

            set => Column["component_id"].Value = value;
        }
    }
}