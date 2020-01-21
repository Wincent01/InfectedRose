namespace InfectedRose.Database.Concepts.Tables
{
    public class MissionEmailTable

    {
        public MissionEmailTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ID
        {
            get => (int) Column["ID"].Value;

            set => Column["ID"].Value = value;
        }

        public int messageType
        {
            get => (int) Column["messageType"].Value;

            set => Column["messageType"].Value = value;
        }

        public int notificationGroup
        {
            get => (int) Column["notificationGroup"].Value;

            set => Column["notificationGroup"].Value = value;
        }

        public int missionID
        {
            get => (int) Column["missionID"].Value;

            set => Column["missionID"].Value = value;
        }

        public int attachmentLOT
        {
            get => (int) Column["attachmentLOT"].Value;

            set => Column["attachmentLOT"].Value = value;
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