namespace InfectedRose.Database.Concepts.Tables
{
    public class BehaviorParameterTable

    {
        public BehaviorParameterTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int behaviorID
        {
            get => (int) Column["behaviorID"].Value;

            set => Column["behaviorID"].Value = value;
        }

        public string parameterID
        {
            get => (string) Column["parameterID"].Value;

            set => Column["parameterID"].Value = value;
        }

        public float value
        {
            get => (float) Column["value"].Value;

            set => Column["value"].Value = value;
        }
    }
}