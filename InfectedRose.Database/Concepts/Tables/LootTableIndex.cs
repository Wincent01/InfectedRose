namespace InfectedRose.Database.Concepts.Tables
{
    public class LootTableIndexTable

    {
        public LootTableIndexTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LootTableIndex
        {
            get => (int) Column["LootTableIndex"].Value;

            set => Column["LootTableIndex"].Value = value;
        }
    }
}