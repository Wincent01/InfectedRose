namespace InfectedRose.Database.Concepts.Tables
{
    public class SmashableChainIndexTable

    {
        public SmashableChainIndexTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string targetGroup
        {
            get => (string) Column["targetGroup"].Value;

            set => Column["targetGroup"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public int continuous
        {
            get => (int) Column["continuous"].Value;

            set => Column["continuous"].Value = value;
        }
    }
}