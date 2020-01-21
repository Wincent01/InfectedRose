namespace InfectedRose.Database.Concepts.Tables
{
    public class ZoneTableTable

    {
        public ZoneTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int zoneID
        {
            get => (int) Column["zoneID"].Value;

            set => Column["zoneID"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public string zoneName
        {
            get => (string) Column["zoneName"].Value;

            set => Column["zoneName"].Value = value;
        }

        public int scriptID
        {
            get => (int) Column["scriptID"].Value;

            set => Column["scriptID"].Value = value;
        }

        public float ghostdistance_min
        {
            get => (float) Column["ghostdistance_min"].Value;

            set => Column["ghostdistance_min"].Value = value;
        }

        public float ghostdistance
        {
            get => (float) Column["ghostdistance"].Value;

            set => Column["ghostdistance"].Value = value;
        }

        public int population_soft_cap
        {
            get => (int) Column["population_soft_cap"].Value;

            set => Column["population_soft_cap"].Value = value;
        }

        public int population_hard_cap
        {
            get => (int) Column["population_hard_cap"].Value;

            set => Column["population_hard_cap"].Value = value;
        }

        public string DisplayDescription
        {
            get => (string) Column["DisplayDescription"].Value;

            set => Column["DisplayDescription"].Value = value;
        }

        public string mapFolder
        {
            get => (string) Column["mapFolder"].Value;

            set => Column["mapFolder"].Value = value;
        }

        public float smashableMinDistance
        {
            get => (float) Column["smashableMinDistance"].Value;

            set => Column["smashableMinDistance"].Value = value;
        }

        public float smashableMaxDistance
        {
            get => (float) Column["smashableMaxDistance"].Value;

            set => Column["smashableMaxDistance"].Value = value;
        }

        public string mixerProgram
        {
            get => (string) Column["mixerProgram"].Value;

            set => Column["mixerProgram"].Value = value;
        }

        public string clientPhysicsFramerate
        {
            get => (string) Column["clientPhysicsFramerate"].Value;

            set => Column["clientPhysicsFramerate"].Value = value;
        }

        public string serverPhysicsFramerate
        {
            get => (string) Column["serverPhysicsFramerate"].Value;

            set => Column["serverPhysicsFramerate"].Value = value;
        }

        public int zoneControlTemplate
        {
            get => (int) Column["zoneControlTemplate"].Value;

            set => Column["zoneControlTemplate"].Value = value;
        }

        public int widthInChunks
        {
            get => (int) Column["widthInChunks"].Value;

            set => Column["widthInChunks"].Value = value;
        }

        public int heightInChunks
        {
            get => (int) Column["heightInChunks"].Value;

            set => Column["heightInChunks"].Value = value;
        }

        public bool petsAllowed
        {
            get => (bool) Column["petsAllowed"].Value;

            set => Column["petsAllowed"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public float fZoneWeight
        {
            get => (float) Column["fZoneWeight"].Value;

            set => Column["fZoneWeight"].Value = value;
        }

        public string thumbnail
        {
            get => (string) Column["thumbnail"].Value;

            set => Column["thumbnail"].Value = value;
        }

        public bool PlayerLoseCoinsOnDeath
        {
            get => (bool) Column["PlayerLoseCoinsOnDeath"].Value;

            set => Column["PlayerLoseCoinsOnDeath"].Value = value;
        }

        public bool disableSaveLoc
        {
            get => (bool) Column["disableSaveLoc"].Value;

            set => Column["disableSaveLoc"].Value = value;
        }

        public float teamRadius
        {
            get => (float) Column["teamRadius"].Value;

            set => Column["teamRadius"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public bool mountsAllowed
        {
            get => (bool) Column["mountsAllowed"].Value;

            set => Column["mountsAllowed"].Value = value;
        }
    }
}