namespace InfectedRose.Database.Concepts.Tables
{
    public class BehaviorTemplateNameTable

    {
        public BehaviorTemplateNameTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int templateID
        {
            get => (int) Column["templateID"].Value;

            set => Column["templateID"].Value = value;
        }

        public string name
        {
            get => (string) Column["name"].Value;

            set => Column["name"].Value = value;
        }
    }
}