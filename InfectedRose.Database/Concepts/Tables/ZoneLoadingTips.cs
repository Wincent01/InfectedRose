namespace InfectedRose.Database.Concepts.Tables
{
    public class ZoneLoadingTipsTable

    {
        public ZoneLoadingTipsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int zoneid
        {
            get => (int) Column["zoneid"].Value;

            set => Column["zoneid"].Value = value;
        }

        public string imagelocation
        {
            get => (string) Column["imagelocation"].Value;

            set => Column["imagelocation"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public int weight
        {
            get => (int) Column["weight"].Value;

            set => Column["weight"].Value = value;
        }

        public string targetVersion
        {
            get => (string) Column["targetVersion"].Value;

            set => Column["targetVersion"].Value = value;
        }
    }
}