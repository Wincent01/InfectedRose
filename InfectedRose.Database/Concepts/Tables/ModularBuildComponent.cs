namespace InfectedRose.Database.Concepts.Tables
{
    public class ModularBuildComponentTable

    {
        public ModularBuildComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int buildType
        {
            get => (int) Column["buildType"].Value;

            set => Column["buildType"].Value = value;
        }

        public string xml
        {
            get => (string) Column["xml"].Value;

            set => Column["xml"].Value = value;
        }

        public int createdLOT
        {
            get => (int) Column["createdLOT"].Value;

            set => Column["createdLOT"].Value = value;
        }

        public int createdPhysicsID
        {
            get => (int) Column["createdPhysicsID"].Value;

            set => Column["createdPhysicsID"].Value = value;
        }

        public string AudioEventGUID_Snap
        {
            get => (string) Column["AudioEventGUID_Snap"].Value;

            set => Column["AudioEventGUID_Snap"].Value = value;
        }

        public string AudioEventGUID_Complete
        {
            get => (string) Column["AudioEventGUID_Complete"].Value;

            set => Column["AudioEventGUID_Complete"].Value = value;
        }

        public string AudioEventGUID_Present
        {
            get => (string) Column["AudioEventGUID_Present"].Value;

            set => Column["AudioEventGUID_Present"].Value = value;
        }
    }
}