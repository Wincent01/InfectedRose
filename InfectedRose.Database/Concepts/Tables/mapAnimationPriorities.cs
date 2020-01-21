namespace InfectedRose.Database.Concepts.Tables
{
    public class mapAnimationPrioritiesTable

    {
        public mapAnimationPrioritiesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string name
        {
            get => (string) Column["name"].Value;

            set => Column["name"].Value = value;
        }

        public float priority
        {
            get => (float) Column["priority"].Value;

            set => Column["priority"].Value = value;
        }
    }
}