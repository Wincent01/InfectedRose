namespace InfectedRose.Database.Concepts.Tables
{
    public class LUPExhibitComponentTable

    {
        public LUPExhibitComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
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

        public float offsetX
        {
            get => (float) Column["offsetX"].Value;

            set => Column["offsetX"].Value = value;
        }

        public float offsetY
        {
            get => (float) Column["offsetY"].Value;

            set => Column["offsetY"].Value = value;
        }

        public float offsetZ
        {
            get => (float) Column["offsetZ"].Value;

            set => Column["offsetZ"].Value = value;
        }
    }
}