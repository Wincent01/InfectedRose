namespace InfectedRose.Database.Concepts.Tables
{
    public class RenderIconAssetsTable

    {
        public RenderIconAssetsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string icon_asset
        {
            get => (string) Column["icon_asset"].Value;

            set => Column["icon_asset"].Value = value;
        }

        public string blank_column
        {
            get => (string) Column["blank_column"].Value;

            set => Column["blank_column"].Value = value;
        }
    }
}