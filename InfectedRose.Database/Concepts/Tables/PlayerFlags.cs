namespace InfectedRose.Database.Concepts.Tables
{
    public class PlayerFlagsTable

    {
        public PlayerFlagsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public bool SessionOnly
        {
            get => (bool) Column["SessionOnly"].Value;

            set => Column["SessionOnly"].Value = value;
        }

        public bool OnlySetByServer
        {
            get => (bool) Column["OnlySetByServer"].Value;

            set => Column["OnlySetByServer"].Value = value;
        }

        public bool SessionZoneOnly
        {
            get => (bool) Column["SessionZoneOnly"].Value;

            set => Column["SessionZoneOnly"].Value = value;
        }
    }
}