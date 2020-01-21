namespace InfectedRose.Database.Concepts.Tables
{
    public class ObjectBehaviorsTable

    {
        public ObjectBehaviorsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public long BehaviorID
        {
            get => (long) Column["BehaviorID"].Value;

            set => Column["BehaviorID"].Value = value;
        }

        public string xmldata
        {
            get => (string) Column["xmldata"].Value;

            set => Column["xmldata"].Value = value;
        }
    }
}