namespace InfectedRose.Database.Concepts.Tables
{
    public class LevelProgressionLookupTable

    {
        public LevelProgressionLookupTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int requiredUScore
        {
            get => (int) Column["requiredUScore"].Value;

            set => Column["requiredUScore"].Value = value;
        }

        public string BehaviorEffect
        {
            get => (string) Column["BehaviorEffect"].Value;

            set => Column["BehaviorEffect"].Value = value;
        }
    }
}