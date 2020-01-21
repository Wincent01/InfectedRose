namespace InfectedRose.Database.Concepts.Tables
{
    public class ChoiceBuildComponentTable

    {
        public ChoiceBuildComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string selections
        {
            get => (string) Column["selections"].Value;

            set => Column["selections"].Value = value;
        }

        public int imaginationOverride
        {
            get => (int) Column["imaginationOverride"].Value;

            set => Column["imaginationOverride"].Value = value;
        }
    }
}