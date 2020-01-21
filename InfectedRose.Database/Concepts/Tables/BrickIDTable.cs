namespace InfectedRose.Database.Concepts.Tables
{
    public class BrickIDTableTable

    {
        public BrickIDTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int NDObjectID
        {
            get => (int) Column["NDObjectID"].Value;

            set => Column["NDObjectID"].Value = value;
        }

        public int LEGOBrickID
        {
            get => (int) Column["LEGOBrickID"].Value;

            set => Column["LEGOBrickID"].Value = value;
        }
    }
}