namespace InfectedRose.Database.Concepts.Tables
{
    public class SmashableChainTable

    {
        public SmashableChainTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int chainIndex
        {
            get => (int) Column["chainIndex"].Value;

            set => Column["chainIndex"].Value = value;
        }

        public int chainLevel
        {
            get => (int) Column["chainLevel"].Value;

            set => Column["chainLevel"].Value = value;
        }

        public int lootMatrixID
        {
            get => (int) Column["lootMatrixID"].Value;

            set => Column["lootMatrixID"].Value = value;
        }

        public int rarityTableIndex
        {
            get => (int) Column["rarityTableIndex"].Value;

            set => Column["rarityTableIndex"].Value = value;
        }

        public int currencyIndex
        {
            get => (int) Column["currencyIndex"].Value;

            set => Column["currencyIndex"].Value = value;
        }

        public int currencyLevel
        {
            get => (int) Column["currencyLevel"].Value;

            set => Column["currencyLevel"].Value = value;
        }

        public int smashCount
        {
            get => (int) Column["smashCount"].Value;

            set => Column["smashCount"].Value = value;
        }

        public int timeLimit
        {
            get => (int) Column["timeLimit"].Value;

            set => Column["timeLimit"].Value = value;
        }

        public int chainStepID
        {
            get => (int) Column["chainStepID"].Value;

            set => Column["chainStepID"].Value = value;
        }
    }
}