namespace InfectedRose.Database.Concepts.Tables
{
    public class ActivityTextTable

    {
        public ActivityTextTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int activityID
        {
            get => (int) Column["activityID"].Value;

            set => Column["activityID"].Value = value;
        }

        public string type
        {
            get => (string) Column["type"].Value;

            set => Column["type"].Value = value;
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