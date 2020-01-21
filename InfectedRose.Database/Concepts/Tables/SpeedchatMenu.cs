namespace InfectedRose.Database.Concepts.Tables
{
    public class SpeedchatMenuTable

    {
        public SpeedchatMenuTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int parentId
        {
            get => (int) Column["parentId"].Value;

            set => Column["parentId"].Value = value;
        }

        public int emoteId
        {
            get => (int) Column["emoteId"].Value;

            set => Column["emoteId"].Value = value;
        }

        public string imageName
        {
            get => (string) Column["imageName"].Value;

            set => Column["imageName"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
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