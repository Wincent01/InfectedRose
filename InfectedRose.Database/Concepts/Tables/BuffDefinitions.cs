namespace InfectedRose.Database.Concepts.Tables
{
    public class BuffDefinitionsTable

    {
        public BuffDefinitionsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ID
        {
            get => (int) Column["ID"].Value;

            set => Column["ID"].Value = value;
        }

        public float Priority
        {
            get => (float) Column["Priority"].Value;

            set => Column["Priority"].Value = value;
        }

        public string UIIcon
        {
            get => (string) Column["UIIcon"].Value;

            set => Column["UIIcon"].Value = value;
        }
    }
}