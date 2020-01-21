namespace InfectedRose.Database.Concepts.Tables
{
    public class RenderComponentWrapperTable

    {
        public RenderComponentWrapperTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string defaultWrapperAsset
        {
            get => (string) Column["defaultWrapperAsset"].Value;

            set => Column["defaultWrapperAsset"].Value = value;
        }
    }
}