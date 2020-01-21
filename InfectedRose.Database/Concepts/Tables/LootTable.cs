namespace InfectedRose.Database.Concepts.Tables
{
    public class LootTableTable

    {
        public LootTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int itemid
        {
            get => (int) Column["itemid"].Value;

            set => Column["itemid"].Value = value;
        }

        public int LootTableIndex
        {
            get => (int) Column["LootTableIndex"].Value;

            set => Column["LootTableIndex"].Value = value;
        }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public bool MissionDrop
        {
            get => (bool) Column["MissionDrop"].Value;

            set => Column["MissionDrop"].Value = value;
        }

        public int sortPriority
        {
            get => (int) Column["sortPriority"].Value;

            set => Column["sortPriority"].Value = value;
        }
    }
}