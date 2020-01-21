namespace InfectedRose.Database.Concepts.Tables
{
    public class EmotesTable

    {
        public EmotesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string animationName
        {
            get => (string) Column["animationName"].Value;

            set => Column["animationName"].Value = value;
        }

        public string iconFilename
        {
            get => (string) Column["iconFilename"].Value;

            set => Column["iconFilename"].Value = value;
        }

        public string channel
        {
            get => (string) Column["channel"].Value;

            set => Column["channel"].Value = value;
        }

        public string command
        {
            get => (string) Column["command"].Value;

            set => Column["command"].Value = value;
        }

        public bool locked
        {
            get => (bool) Column["locked"].Value;

            set => Column["locked"].Value = value;
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