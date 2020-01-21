namespace InfectedRose.Database.Concepts.Tables
{
    public class ItemSetsTable

    {
        public ItemSetsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int setID
        {
            get => (int) Column["setID"].Value;

            set => Column["setID"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public string itemIDs
        {
            get => (string) Column["itemIDs"].Value;

            set => Column["itemIDs"].Value = value;
        }

        public int kitType
        {
            get => (int) Column["kitType"].Value;

            set => Column["kitType"].Value = value;
        }

        public int kitRank
        {
            get => (int) Column["kitRank"].Value;

            set => Column["kitRank"].Value = value;
        }

        public int kitImage
        {
            get => (int) Column["kitImage"].Value;

            set => Column["kitImage"].Value = value;
        }

        public int skillSetWith2
        {
            get => (int) Column["skillSetWith2"].Value;

            set => Column["skillSetWith2"].Value = value;
        }

        public int skillSetWith3
        {
            get => (int) Column["skillSetWith3"].Value;

            set => Column["skillSetWith3"].Value = value;
        }

        public int skillSetWith4
        {
            get => (int) Column["skillSetWith4"].Value;

            set => Column["skillSetWith4"].Value = value;
        }

        public int skillSetWith5
        {
            get => (int) Column["skillSetWith5"].Value;

            set => Column["skillSetWith5"].Value = value;
        }

        public int skillSetWith6
        {
            get => (int) Column["skillSetWith6"].Value;

            set => Column["skillSetWith6"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public int kitID
        {
            get => (int) Column["kitID"].Value;

            set => Column["kitID"].Value = value;
        }

        public float priority
        {
            get => (float) Column["priority"].Value;

            set => Column["priority"].Value = value;
        }
    }
}