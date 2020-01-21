namespace InfectedRose.Database.Concepts.Tables
{
    public class RarityTableIndexTable

    {
        public RarityTableIndexTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int RarityTableIndex
        {
            get => (int) Column["RarityTableIndex"].Value;

            set => Column["RarityTableIndex"].Value = value;
        }
    }
}