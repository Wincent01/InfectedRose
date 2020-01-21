namespace InfectedRose.Database.Concepts.Tables
{
    public class RenderComponentFlashTable

    {
        public RenderComponentFlashTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public bool interactive
        {
            get => (bool) Column["interactive"].Value;

            set => Column["interactive"].Value = value;
        }

        public bool animated
        {
            get => (bool) Column["animated"].Value;

            set => Column["animated"].Value = value;
        }

        public string nodeName
        {
            get => (string) Column["nodeName"].Value;

            set => Column["nodeName"].Value = value;
        }

        public string flashPath
        {
            get => (string) Column["flashPath"].Value;

            set => Column["flashPath"].Value = value;
        }

        public string elementName
        {
            get => (string) Column["elementName"].Value;

            set => Column["elementName"].Value = value;
        }

        public int _uid
        {
            get => (int) Column["_uid"].Value;

            set => Column["_uid"].Value = value;
        }
    }
}