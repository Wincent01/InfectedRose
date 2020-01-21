namespace InfectedRose.Database.Concepts.Tables
{
    public class ModelBehaviorTable

    {
        public ModelBehaviorTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string definitionXMLfilename
        {
            get => (string) Column["definitionXMLfilename"].Value;

            set => Column["definitionXMLfilename"].Value = value;
        }
    }
}