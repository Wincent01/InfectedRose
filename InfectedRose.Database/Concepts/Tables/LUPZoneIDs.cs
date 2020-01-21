namespace InfectedRose.Database.Concepts.Tables
{
    public class LUPZoneIDsTable

    {
        public LUPZoneIDsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int zoneID
        {
            get => (int) Column["zoneID"].Value;

            set => Column["zoneID"].Value = value;
        }
    }
}