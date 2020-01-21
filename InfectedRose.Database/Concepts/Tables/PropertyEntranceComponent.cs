namespace InfectedRose.Database.Concepts.Tables
{
    public class PropertyEntranceComponentTable

    {
        public PropertyEntranceComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int mapID
        {
            get => (int) Column["mapID"].Value;

            set => Column["mapID"].Value = value;
        }

        public string propertyName
        {
            get => (string) Column["propertyName"].Value;

            set => Column["propertyName"].Value = value;
        }

        public bool isOnProperty
        {
            get => (bool) Column["isOnProperty"].Value;

            set => Column["isOnProperty"].Value = value;
        }

        public string groupType
        {
            get => (string) Column["groupType"].Value;

            set => Column["groupType"].Value = value;
        }
    }
}