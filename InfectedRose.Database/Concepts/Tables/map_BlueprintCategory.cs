namespace InfectedRose.Database.Concepts.Tables
{
    public class map_BlueprintCategoryTable

    {
        public map_BlueprintCategoryTable(Column column)

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

        public bool enabled
        {
            get => (bool) Column["enabled"].Value;

            set => Column["enabled"].Value = value;
        }
    }
}