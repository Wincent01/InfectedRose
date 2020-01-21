namespace InfectedRose.Database.Concepts.Tables
{
    public class IconsTable

    {
        public IconsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int IconID
        {
            get => (int) Column["IconID"].Value;

            set => Column["IconID"].Value = value;
        }

        public string IconPath
        {
            get => (string) Column["IconPath"].Value;

            set => Column["IconPath"].Value = value;
        }

        public string IconName
        {
            get => (string) Column["IconName"].Value;

            set => Column["IconName"].Value = value;
        }
    }
}