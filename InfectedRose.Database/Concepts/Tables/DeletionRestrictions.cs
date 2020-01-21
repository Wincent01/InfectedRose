namespace InfectedRose.Database.Concepts.Tables
{
    public class DeletionRestrictionsTable

    {
        public DeletionRestrictionsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public bool restricted
        {
            get => (bool) Column["restricted"].Value;

            set => Column["restricted"].Value = value;
        }

        public string ids
        {
            get => (string) Column["ids"].Value;

            set => Column["ids"].Value = value;
        }

        public int checkType
        {
            get => (int) Column["checkType"].Value;

            set => Column["checkType"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }
    }
}