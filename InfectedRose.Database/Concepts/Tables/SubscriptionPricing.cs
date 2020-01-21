namespace InfectedRose.Database.Concepts.Tables
{
    public class SubscriptionPricingTable

    {
        public SubscriptionPricingTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string countryCode
        {
            get => (string) Column["countryCode"].Value;

            set => Column["countryCode"].Value = value;
        }

        public string monthlyFeeGold
        {
            get => (string) Column["monthlyFeeGold"].Value;

            set => Column["monthlyFeeGold"].Value = value;
        }

        public string monthlyFeeSilver
        {
            get => (string) Column["monthlyFeeSilver"].Value;

            set => Column["monthlyFeeSilver"].Value = value;
        }

        public string monthlyFeeBronze
        {
            get => (string) Column["monthlyFeeBronze"].Value;

            set => Column["monthlyFeeBronze"].Value = value;
        }

        public int monetarySymbol
        {
            get => (int) Column["monetarySymbol"].Value;

            set => Column["monetarySymbol"].Value = value;
        }

        public bool symbolIsAppended
        {
            get => (bool) Column["symbolIsAppended"].Value;

            set => Column["symbolIsAppended"].Value = value;
        }
    }
}