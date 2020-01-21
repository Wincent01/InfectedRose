namespace InfectedRose.Database.Concepts.Tables
{
    public class brickAttributesTable

    {
        public brickAttributesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ID
        {
            get => (int) Column["ID"].Value;

            set => Column["ID"].Value = value;
        }

        public string icon_asset
        {
            get => (string) Column["icon_asset"].Value;

            set => Column["icon_asset"].Value = value;
        }

        public int display_order
        {
            get => (int) Column["display_order"].Value;

            set => Column["display_order"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }
    }
}