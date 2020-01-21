namespace InfectedRose.Database.Concepts.Tables
{
    public class MinifigDecals_LegsTable

    {
        public MinifigDecals_LegsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ID
        {
            get => (int) Column["ID"].Value;

            set => Column["ID"].Value = value;
        }

        public string High_path
        {
            get => (string) Column["High_path"].Value;

            set => Column["High_path"].Value = value;
        }
    }
}