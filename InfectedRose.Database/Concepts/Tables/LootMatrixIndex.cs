namespace InfectedRose.Database.Concepts.Tables
{
    public class LootMatrixIndexTable

    {
        public LootMatrixIndexTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LootMatrixIndex
        {
            get => (int) Column["LootMatrixIndex"].Value;

            set => Column["LootMatrixIndex"].Value = value;
        }

        public bool inNpcEditor
        {
            get => (bool) Column["inNpcEditor"].Value;

            set => Column["inNpcEditor"].Value = value;
        }
    }
}