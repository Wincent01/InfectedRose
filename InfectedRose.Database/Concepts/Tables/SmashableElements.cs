namespace InfectedRose.Database.Concepts.Tables
{
    public class SmashableElementsTable

    {
        public SmashableElementsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int elementID
        {
            get => (int) Column["elementID"].Value;

            set => Column["elementID"].Value = value;
        }

        public int dropWeight
        {
            get => (int) Column["dropWeight"].Value;

            set => Column["dropWeight"].Value = value;
        }
    }
}