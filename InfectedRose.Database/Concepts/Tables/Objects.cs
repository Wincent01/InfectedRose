namespace InfectedRose.Database.Concepts.Tables
{
    public class ObjectsTable

    {
        public ObjectsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string name
        {
            get => (string) Column["name"].Value;

            set => Column["name"].Value = value;
        }

        public bool placeable
        {
            get => (bool) Column["placeable"].Value;

            set => Column["placeable"].Value = value;
        }

        public string type
        {
            get => (string) Column["type"].Value;

            set => Column["type"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public int npcTemplateID
        {
            get => (int) Column["npcTemplateID"].Value;

            set => Column["npcTemplateID"].Value = value;
        }

        public string displayName
        {
            get => (string) Column["displayName"].Value;

            set => Column["displayName"].Value = value;
        }

        public float interactionDistance
        {
            get => (float) Column["interactionDistance"].Value;

            set => Column["interactionDistance"].Value = value;
        }

        public bool nametag
        {
            get => (bool) Column["nametag"].Value;

            set => Column["nametag"].Value = value;
        }

        public string _internalNotes
        {
            get => (string) Column["_internalNotes"].Value;

            set => Column["_internalNotes"].Value = value;
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

        public bool HQ_valid
        {
            get => (bool) Column["HQ_valid"].Value;

            set => Column["HQ_valid"].Value = value;
        }
    }
}