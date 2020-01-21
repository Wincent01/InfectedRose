namespace InfectedRose.Database.Concepts.Tables
{
    public class SmashableComponentTable

    {
        public SmashableComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int LootMatrixIndex
        {
            get => (int) Column["LootMatrixIndex"].Value;

            set => Column["LootMatrixIndex"].Value = value;
        }
    }
}