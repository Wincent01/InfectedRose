namespace InfectedRose.Database.Concepts.Tables
{
    public class LootMatrixTable

    {
        public LootMatrixTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LootMatrixIndex
        {
            get => (int) Column["LootMatrixIndex"].Value;

            set => Column["LootMatrixIndex"].Value = value;
        }

        public int LootTableIndex
        {
            get => (int) Column["LootTableIndex"].Value;

            set => Column["LootTableIndex"].Value = value;
        }

        public int RarityTableIndex
        {
            get => (int) Column["RarityTableIndex"].Value;

            set => Column["RarityTableIndex"].Value = value;
        }

        public float percent
        {
            get => (float) Column["percent"].Value;

            set => Column["percent"].Value = value;
        }

        public int minToDrop
        {
            get => (int) Column["minToDrop"].Value;

            set => Column["minToDrop"].Value = value;
        }

        public int maxToDrop
        {
            get => (int) Column["maxToDrop"].Value;

            set => Column["maxToDrop"].Value = value;
        }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int flagID
        {
            get => (int) Column["flagID"].Value;

            set => Column["flagID"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }
    }
}