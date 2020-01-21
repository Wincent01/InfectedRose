namespace InfectedRose.Database.Concepts.Tables
{
    public class LUPExhibitModelDataTable

    {
        public LUPExhibitModelDataTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LOT
        {
            get => (int) Column["LOT"].Value;

            set => Column["LOT"].Value = value;
        }

        public float minXZ
        {
            get => (float) Column["minXZ"].Value;

            set => Column["minXZ"].Value = value;
        }

        public float maxXZ
        {
            get => (float) Column["maxXZ"].Value;

            set => Column["maxXZ"].Value = value;
        }

        public float maxY
        {
            get => (float) Column["maxY"].Value;

            set => Column["maxY"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public string owner
        {
            get => (string) Column["owner"].Value;

            set => Column["owner"].Value = value;
        }
    }
}