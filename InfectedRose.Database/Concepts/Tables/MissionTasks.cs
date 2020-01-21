namespace InfectedRose.Database.Concepts.Tables
{
    public class MissionTasksTable

    {
        public MissionTasksTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public int taskType
        {
            get => (int) Column["taskType"].Value;

            set => Column["taskType"].Value = value;
        }

        public int target
        {
            get => (int) Column["target"].Value;

            set => Column["target"].Value = value;
        }

        public string targetGroup
        {
            get => (string) Column["targetGroup"].Value;

            set => Column["targetGroup"].Value = value;
        }

        public int targetValue
        {
            get => (int) Column["targetValue"].Value;

            set => Column["targetValue"].Value = value;
        }

        public string taskParam1
        {
            get => (string) Column["taskParam1"].Value;

            set => Column["taskParam1"].Value = value;
        }

        public string largeTaskIcon
        {
            get => (string) Column["largeTaskIcon"].Value;

            set => Column["largeTaskIcon"].Value = value;
        }

        public int IconID
        {
            get => (int) Column["IconID"].Value;

            set => Column["IconID"].Value = value;
        }

        public int uid
        {
            get => (int) Column["uid"].Value;

            set => Column["uid"].Value = value;
        }

        public int largeTaskIconID
        {
            get => (int) Column["largeTaskIconID"].Value;

            set => Column["largeTaskIconID"].Value = value;
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
    }
}