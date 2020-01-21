namespace InfectedRose.Database.Concepts.Tables
{
    public class PreconditionsTable

    {
        public PreconditionsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int type
        {
            get => (int) Column["type"].Value;

            set => Column["type"].Value = value;
        }

        public string targetLOT
        {
            get => (string) Column["targetLOT"].Value;

            set => Column["targetLOT"].Value = value;
        }

        public string targetGroup
        {
            get => (string) Column["targetGroup"].Value;

            set => Column["targetGroup"].Value = value;
        }

        public int targetCount
        {
            get => (int) Column["targetCount"].Value;

            set => Column["targetCount"].Value = value;
        }

        public int iconID
        {
            get => (int) Column["iconID"].Value;

            set => Column["iconID"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public long validContexts
        {
            get => (long) Column["validContexts"].Value;

            set => Column["validContexts"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }
    }
}