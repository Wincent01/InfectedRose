namespace InfectedRose.Database.Concepts.Tables
{
    public class ItemFoodDataTable

    {
        public ItemFoodDataTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int element_1
        {
            get => (int) Column["element_1"].Value;

            set => Column["element_1"].Value = value;
        }

        public int element_1_amount
        {
            get => (int) Column["element_1_amount"].Value;

            set => Column["element_1_amount"].Value = value;
        }

        public int element_2
        {
            get => (int) Column["element_2"].Value;

            set => Column["element_2"].Value = value;
        }

        public int element_2_amount
        {
            get => (int) Column["element_2_amount"].Value;

            set => Column["element_2_amount"].Value = value;
        }

        public int element_3
        {
            get => (int) Column["element_3"].Value;

            set => Column["element_3"].Value = value;
        }

        public int element_3_amount
        {
            get => (int) Column["element_3_amount"].Value;

            set => Column["element_3_amount"].Value = value;
        }

        public int element_4
        {
            get => (int) Column["element_4"].Value;

            set => Column["element_4"].Value = value;
        }

        public int element_4_amount
        {
            get => (int) Column["element_4_amount"].Value;

            set => Column["element_4_amount"].Value = value;
        }
    }
}