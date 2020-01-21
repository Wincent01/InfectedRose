namespace InfectedRose.Database.Concepts.Tables
{
    public class BehaviorTemplateTable

    {
        public BehaviorTemplateTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int behaviorID
        {
            get => (int) Column["behaviorID"].Value;

            set => Column["behaviorID"].Value = value;
        }

        public int templateID
        {
            get => (int) Column["templateID"].Value;

            set => Column["templateID"].Value = value;
        }

        public int effectID
        {
            get => (int) Column["effectID"].Value;

            set => Column["effectID"].Value = value;
        }

        public string effectHandle
        {
            get => (string) Column["effectHandle"].Value;

            set => Column["effectHandle"].Value = value;
        }
    }
}