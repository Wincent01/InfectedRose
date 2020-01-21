namespace InfectedRose.Database.Concepts.Tables
{
    public class RocketLaunchpadControlComponentTable

    {
        public RocketLaunchpadControlComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int targetZone
        {
            get => (int) Column["targetZone"].Value;

            set => Column["targetZone"].Value = value;
        }

        public int defaultZoneID
        {
            get => (int) Column["defaultZoneID"].Value;

            set => Column["defaultZoneID"].Value = value;
        }

        public string targetScene
        {
            get => (string) Column["targetScene"].Value;

            set => Column["targetScene"].Value = value;
        }

        public int gmLevel
        {
            get => (int) Column["gmLevel"].Value;

            set => Column["gmLevel"].Value = value;
        }

        public string playerAnimation
        {
            get => (string) Column["playerAnimation"].Value;

            set => Column["playerAnimation"].Value = value;
        }

        public string rocketAnimation
        {
            get => (string) Column["rocketAnimation"].Value;

            set => Column["rocketAnimation"].Value = value;
        }

        public string launchMusic
        {
            get => (string) Column["launchMusic"].Value;

            set => Column["launchMusic"].Value = value;
        }

        public bool useLaunchPrecondition
        {
            get => (bool) Column["useLaunchPrecondition"].Value;

            set => Column["useLaunchPrecondition"].Value = value;
        }

        public bool useAltLandingPrecondition
        {
            get => (bool) Column["useAltLandingPrecondition"].Value;

            set => Column["useAltLandingPrecondition"].Value = value;
        }

        public string launchPrecondition
        {
            get => (string) Column["launchPrecondition"].Value;

            set => Column["launchPrecondition"].Value = value;
        }

        public string altLandingPrecondition
        {
            get => (string) Column["altLandingPrecondition"].Value;

            set => Column["altLandingPrecondition"].Value = value;
        }

        public string altLandingSpawnPointName
        {
            get => (string) Column["altLandingSpawnPointName"].Value;

            set => Column["altLandingSpawnPointName"].Value = value;
        }
    }
}