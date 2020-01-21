namespace InfectedRose.Database.Concepts.Tables
{
    public class RarityTableTable

    {
        public RarityTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float randmax
        {
            get => (float) Column["randmax"].Value;

            set => Column["randmax"].Value = value;
        }

        public int rarity
        {
            get => (int) Column["rarity"].Value;

            set => Column["rarity"].Value = value;
        }

        public int RarityTableIndex
        {
            get => (int) Column["RarityTableIndex"].Value;

            set => Column["RarityTableIndex"].Value = value;
        }
    }
}