namespace InfectedRose.Database.Concepts.Tables
{
    public class ItemEggDataTable

    {
        public ItemEggDataTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int chassie_type_id
        {
            get => (int) Column["chassie_type_id"].Value;

            set => Column["chassie_type_id"].Value = value;
        }
    }
}