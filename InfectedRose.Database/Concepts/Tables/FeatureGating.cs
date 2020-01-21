namespace InfectedRose.Database.Concepts.Tables
{
    public class FeatureGatingTable

    {
        public FeatureGatingTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public string featureName
        {
            get => (string) Column["featureName"].Value;

            set => Column["featureName"].Value = value;
        }

        public int major
        {
            get => (int) Column["major"].Value;

            set => Column["major"].Value = value;
        }

        public int current
        {
            get => (int) Column["current"].Value;

            set => Column["current"].Value = value;
        }

        public int minor
        {
            get => (int) Column["minor"].Value;

            set => Column["minor"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }
    }
}