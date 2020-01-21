namespace InfectedRose.Database.Concepts.Tables
{
    public class ActivityRewardsTable

    {
        public ActivityRewardsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int objectTemplate
        {
            get => (int) Column["objectTemplate"].Value;

            set => Column["objectTemplate"].Value = value;
        }

        public int ActivityRewardIndex
        {
            get => (int) Column["ActivityRewardIndex"].Value;

            set => Column["ActivityRewardIndex"].Value = value;
        }

        public int activityRating
        {
            get => (int) Column["activityRating"].Value;

            set => Column["activityRating"].Value = value;
        }

        public int LootMatrixIndex
        {
            get => (int) Column["LootMatrixIndex"].Value;

            set => Column["LootMatrixIndex"].Value = value;
        }

        public int CurrencyIndex
        {
            get => (int) Column["CurrencyIndex"].Value;

            set => Column["CurrencyIndex"].Value = value;
        }

        public int ChallengeRating
        {
            get => (int) Column["ChallengeRating"].Value;

            set => Column["ChallengeRating"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }
    }
}