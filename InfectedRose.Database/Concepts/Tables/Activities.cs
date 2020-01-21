namespace InfectedRose.Database.Concepts.Tables
{
    public class ActivitiesTable

    {
        public ActivitiesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ActivityID
        {
            get => (int) Column["ActivityID"].Value;

            set => Column["ActivityID"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public int instanceMapID
        {
            get => (int) Column["instanceMapID"].Value;

            set => Column["instanceMapID"].Value = value;
        }

        public int minTeams
        {
            get => (int) Column["minTeams"].Value;

            set => Column["minTeams"].Value = value;
        }

        public int maxTeams
        {
            get => (int) Column["maxTeams"].Value;

            set => Column["maxTeams"].Value = value;
        }

        public int minTeamSize
        {
            get => (int) Column["minTeamSize"].Value;

            set => Column["minTeamSize"].Value = value;
        }

        public int maxTeamSize
        {
            get => (int) Column["maxTeamSize"].Value;

            set => Column["maxTeamSize"].Value = value;
        }

        public int waitTime
        {
            get => (int) Column["waitTime"].Value;

            set => Column["waitTime"].Value = value;
        }

        public int startDelay
        {
            get => (int) Column["startDelay"].Value;

            set => Column["startDelay"].Value = value;
        }

        public bool requiresUniqueData
        {
            get => (bool) Column["requiresUniqueData"].Value;

            set => Column["requiresUniqueData"].Value = value;
        }

        public int leaderboardType
        {
            get => (int) Column["leaderboardType"].Value;

            set => Column["leaderboardType"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public int optionalCostLOT
        {
            get => (int) Column["optionalCostLOT"].Value;

            set => Column["optionalCostLOT"].Value = value;
        }

        public int optionalCostCount
        {
            get => (int) Column["optionalCostCount"].Value;

            set => Column["optionalCostCount"].Value = value;
        }

        public bool showUIRewards
        {
            get => (bool) Column["showUIRewards"].Value;

            set => Column["showUIRewards"].Value = value;
        }

        public int CommunityActivityFlagID
        {
            get => (int) Column["CommunityActivityFlagID"].Value;

            set => Column["CommunityActivityFlagID"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public bool noTeamLootOnDeath
        {
            get => (bool) Column["noTeamLootOnDeath"].Value;

            set => Column["noTeamLootOnDeath"].Value = value;
        }

        public float optionalPercentage
        {
            get => (float) Column["optionalPercentage"].Value;

            set => Column["optionalPercentage"].Value = value;
        }
    }
}