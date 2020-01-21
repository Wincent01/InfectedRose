namespace InfectedRose.Database.Concepts.Tables
{
    public class ProximityTypesTable

    {
        public ProximityTypesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string Name
        {
            get => (string) Column["Name"].Value;

            set => Column["Name"].Value = value;
        }

        public int Radius
        {
            get => (int) Column["Radius"].Value;

            set => Column["Radius"].Value = value;
        }

        public int CollisionGroup
        {
            get => (int) Column["CollisionGroup"].Value;

            set => Column["CollisionGroup"].Value = value;
        }

        public bool PassiveChecks
        {
            get => (bool) Column["PassiveChecks"].Value;

            set => Column["PassiveChecks"].Value = value;
        }

        public int IconID
        {
            get => (int) Column["IconID"].Value;

            set => Column["IconID"].Value = value;
        }

        public bool LoadOnClient
        {
            get => (bool) Column["LoadOnClient"].Value;

            set => Column["LoadOnClient"].Value = value;
        }

        public bool LoadOnServer
        {
            get => (bool) Column["LoadOnServer"].Value;

            set => Column["LoadOnServer"].Value = value;
        }
    }
}