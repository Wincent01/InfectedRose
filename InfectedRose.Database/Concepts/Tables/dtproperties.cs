namespace InfectedRose.Database.Concepts.Tables
{
    public class dtpropertiesTable

    {
        public dtpropertiesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int objectid
        {
            get => (int) Column["objectid"].Value;

            set => Column["objectid"].Value = value;
        }

        public string property
        {
            get => (string) Column["property"].Value;

            set => Column["property"].Value = value;
        }

        public string value
        {
            get => (string) Column["value"].Value;

            set => Column["value"].Value = value;
        }

        public string uvalue
        {
            get => (string) Column["uvalue"].Value;

            set => Column["uvalue"].Value = value;
        }

        public int lvalue
        {
            get => (int) Column["lvalue"].Value;

            set => Column["lvalue"].Value = value;
        }

        public int version
        {
            get => (int) Column["version"].Value;

            set => Column["version"].Value = value;
        }
    }
}