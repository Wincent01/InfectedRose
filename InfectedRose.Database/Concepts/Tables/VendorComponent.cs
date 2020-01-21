namespace InfectedRose.Database.Concepts.Tables
{
    public class VendorComponentTable

    {
        public VendorComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float buyScalar
        {
            get => (float) Column["buyScalar"].Value;

            set => Column["buyScalar"].Value = value;
        }

        public float sellScalar
        {
            get => (float) Column["sellScalar"].Value;

            set => Column["sellScalar"].Value = value;
        }

        public float refreshTimeSeconds
        {
            get => (float) Column["refreshTimeSeconds"].Value;

            set => Column["refreshTimeSeconds"].Value = value;
        }

        public int LootMatrixIndex
        {
            get => (int) Column["LootMatrixIndex"].Value;

            set => Column["LootMatrixIndex"].Value = value;
        }
    }
}