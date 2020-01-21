namespace InfectedRose.Database.Concepts.Tables
{
    public class sysdiagramsTable

    {
        public sysdiagramsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public string name
        {
            get => (string) Column["name"].Value;

            set => Column["name"].Value = value;
        }

        public int principal_id
        {
            get => (int) Column["principal_id"].Value;

            set => Column["principal_id"].Value = value;
        }

        public int diagram_id
        {
            get => (int) Column["diagram_id"].Value;

            set => Column["diagram_id"].Value = value;
        }

        public int version
        {
            get => (int) Column["version"].Value;

            set => Column["version"].Value = value;
        }

        public string definition
        {
            get => (string) Column["definition"].Value;

            set => Column["definition"].Value = value;
        }
    }
}