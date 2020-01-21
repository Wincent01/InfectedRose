namespace InfectedRose.Database.Concepts.Tables
{
    public class ScriptComponentTable

    {
        public ScriptComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string script_name
        {
            get => (string) Column["script_name"].Value;

            set => Column["script_name"].Value = value;
        }

        public string client_script_name
        {
            get => (string) Column["client_script_name"].Value;

            set => Column["client_script_name"].Value = value;
        }
    }
}