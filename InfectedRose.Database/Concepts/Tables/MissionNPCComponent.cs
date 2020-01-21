namespace InfectedRose.Database.Concepts.Tables
{
    public class MissionNPCComponentTable

    {
        public MissionNPCComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int missionID
        {
            get => (int) Column["missionID"].Value;

            set => Column["missionID"].Value = value;
        }

        public bool offersMission
        {
            get => (bool) Column["offersMission"].Value;

            set => Column["offersMission"].Value = value;
        }

        public bool acceptsMission
        {
            get => (bool) Column["acceptsMission"].Value;

            set => Column["acceptsMission"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }
    }
}