namespace InfectedRose.Database.Concepts.Tables
{
    public class PlayerStatisticsTable

    {
        public PlayerStatisticsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int statID
        {
            get => (int) Column["statID"].Value;

            set => Column["statID"].Value = value;
        }

        public int sortOrder
        {
            get => (int) Column["sortOrder"].Value;

            set => Column["sortOrder"].Value = value;
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