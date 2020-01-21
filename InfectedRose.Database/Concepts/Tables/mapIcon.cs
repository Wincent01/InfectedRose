namespace InfectedRose.Database.Concepts.Tables
{
    public class mapIconTable

    {
        public mapIconTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LOT
        {
            get => (int) Column["LOT"].Value;

            set => Column["LOT"].Value = value;
        }

        public int iconID
        {
            get => (int) Column["iconID"].Value;

            set => Column["iconID"].Value = value;
        }

        public int iconState
        {
            get => (int) Column["iconState"].Value;

            set => Column["iconState"].Value = value;
        }
    }
}