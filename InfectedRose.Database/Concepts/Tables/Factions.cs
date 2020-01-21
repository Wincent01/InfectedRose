namespace InfectedRose.Database.Concepts.Tables
{
    public class FactionsTable

    {
        public FactionsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int faction
        {
            get => (int) Column["faction"].Value;

            set => Column["faction"].Value = value;
        }

        public string factionList
        {
            get => (string) Column["factionList"].Value;

            set => Column["factionList"].Value = value;
        }

        public bool factionListFriendly
        {
            get => (bool) Column["factionListFriendly"].Value;

            set => Column["factionListFriendly"].Value = value;
        }

        public string friendList
        {
            get => (string) Column["friendList"].Value;

            set => Column["friendList"].Value = value;
        }

        public string enemyList
        {
            get => (string) Column["enemyList"].Value;

            set => Column["enemyList"].Value = value;
        }
    }
}