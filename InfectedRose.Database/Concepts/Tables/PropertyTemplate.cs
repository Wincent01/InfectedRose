namespace InfectedRose.Database.Concepts.Tables
{
    public class PropertyTemplateTable

    {
        public PropertyTemplateTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int mapID
        {
            get => (int) Column["mapID"].Value;

            set => Column["mapID"].Value = value;
        }

        public int vendorMapID
        {
            get => (int) Column["vendorMapID"].Value;

            set => Column["vendorMapID"].Value = value;
        }

        public string spawnName
        {
            get => (string) Column["spawnName"].Value;

            set => Column["spawnName"].Value = value;
        }

        public int type
        {
            get => (int) Column["type"].Value;

            set => Column["type"].Value = value;
        }

        public int sizecode
        {
            get => (int) Column["sizecode"].Value;

            set => Column["sizecode"].Value = value;
        }

        public int minimumPrice
        {
            get => (int) Column["minimumPrice"].Value;

            set => Column["minimumPrice"].Value = value;
        }

        public int rentDuration
        {
            get => (int) Column["rentDuration"].Value;

            set => Column["rentDuration"].Value = value;
        }

        public string path
        {
            get => (string) Column["path"].Value;

            set => Column["path"].Value = value;
        }

        public int cloneLimit
        {
            get => (int) Column["cloneLimit"].Value;

            set => Column["cloneLimit"].Value = value;
        }

        public int durationType
        {
            get => (int) Column["durationType"].Value;

            set => Column["durationType"].Value = value;
        }

        public int achievementRequired
        {
            get => (int) Column["achievementRequired"].Value;

            set => Column["achievementRequired"].Value = value;
        }

        public float zoneX
        {
            get => (float) Column["zoneX"].Value;

            set => Column["zoneX"].Value = value;
        }

        public float zoneY
        {
            get => (float) Column["zoneY"].Value;

            set => Column["zoneY"].Value = value;
        }

        public float zoneZ
        {
            get => (float) Column["zoneZ"].Value;

            set => Column["zoneZ"].Value = value;
        }

        public float maxBuildHeight
        {
            get => (float) Column["maxBuildHeight"].Value;

            set => Column["maxBuildHeight"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public int reputationPerMinute
        {
            get => (int) Column["reputationPerMinute"].Value;

            set => Column["reputationPerMinute"].Value = value;
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