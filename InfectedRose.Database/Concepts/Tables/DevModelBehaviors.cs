namespace InfectedRose.Database.Concepts.Tables
{
    public class DevModelBehaviorsTable

    {
        public DevModelBehaviorsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ModelID
        {
            get => (int) Column["ModelID"].Value;

            set => Column["ModelID"].Value = value;
        }

        public int BehaviorID
        {
            get => (int) Column["BehaviorID"].Value;

            set => Column["BehaviorID"].Value = value;
        }
    }
}