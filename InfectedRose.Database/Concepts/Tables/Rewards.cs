namespace InfectedRose.Database.Concepts.Tables
{
    public class RewardsTable

    {
        public RewardsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int LevelID
        {
            get => (int) Column["LevelID"].Value;

            set => Column["LevelID"].Value = value;
        }

        public int MissionID
        {
            get => (int) Column["MissionID"].Value;

            set => Column["MissionID"].Value = value;
        }

        public int RewardType
        {
            get => (int) Column["RewardType"].Value;

            set => Column["RewardType"].Value = value;
        }

        public int value
        {
            get => (int) Column["value"].Value;

            set => Column["value"].Value = value;
        }

        public int count
        {
            get => (int) Column["count"].Value;

            set => Column["count"].Value = value;
        }
    }
}