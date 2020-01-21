namespace InfectedRose.Database.Concepts.Tables
{
    public class CurrencyTableTable

    {
        public CurrencyTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int currencyIndex
        {
            get => (int) Column["currencyIndex"].Value;

            set => Column["currencyIndex"].Value = value;
        }

        public int npcminlevel
        {
            get => (int) Column["npcminlevel"].Value;

            set => Column["npcminlevel"].Value = value;
        }

        public int minvalue
        {
            get => (int) Column["minvalue"].Value;

            set => Column["minvalue"].Value = value;
        }

        public int maxvalue
        {
            get => (int) Column["maxvalue"].Value;

            set => Column["maxvalue"].Value = value;
        }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }
    }
}