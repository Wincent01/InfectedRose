namespace InfectedRose.Database.Concepts.Tables
{
    public class InventoryComponentTable

    {
        public InventoryComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int itemid
        {
            get => (int) Column["itemid"].Value;

            set => Column["itemid"].Value = value;
        }

        public int count
        {
            get => (int) Column["count"].Value;

            set => Column["count"].Value = value;
        }

        public bool equip
        {
            get => (bool) Column["equip"].Value;

            set => Column["equip"].Value = value;
        }
    }
}