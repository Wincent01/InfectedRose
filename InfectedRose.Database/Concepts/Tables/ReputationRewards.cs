namespace InfectedRose.Database.Concepts.Tables
{
    public class ReputationRewardsTable

    {
        public ReputationRewardsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int repLevel
        {
            get => (int) Column["repLevel"].Value;

            set => Column["repLevel"].Value = value;
        }

        public int sublevel
        {
            get => (int) Column["sublevel"].Value;

            set => Column["sublevel"].Value = value;
        }

        public float reputation
        {
            get => (float) Column["reputation"].Value;

            set => Column["reputation"].Value = value;
        }
    }
}