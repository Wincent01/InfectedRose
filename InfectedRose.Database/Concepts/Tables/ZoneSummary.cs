namespace InfectedRose.Database.Concepts.Tables
{
    public class ZoneSummaryTable

    {
        public ZoneSummaryTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int zoneID
        {
            get => (int) Column["zoneID"].Value;

            set => Column["zoneID"].Value = value;
        }

        public int type
        {
            get => (int) Column["type"].Value;

            set => Column["type"].Value = value;
        }

        public int value
        {
            get => (int) Column["value"].Value;

            set => Column["value"].Value = value;
        }

        public int _uniqueID
        {
            get => (int) Column["_uniqueID"].Value;

            set => Column["_uniqueID"].Value = value;
        }
    }
}