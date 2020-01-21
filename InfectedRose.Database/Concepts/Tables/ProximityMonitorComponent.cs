namespace InfectedRose.Database.Concepts.Tables
{
    public class ProximityMonitorComponentTable

    {
        public ProximityMonitorComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string Proximities
        {
            get => (string) Column["Proximities"].Value;

            set => Column["Proximities"].Value = value;
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