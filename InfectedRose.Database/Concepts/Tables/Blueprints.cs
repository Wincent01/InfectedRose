namespace InfectedRose.Database.Concepts.Tables
{
    public class BlueprintsTable

    {
        public BlueprintsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public long id
        {
            get => (long) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string name
        {
            get => (string) Column["name"].Value;

            set => Column["name"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public long accountid
        {
            get => (long) Column["accountid"].Value;

            set => Column["accountid"].Value = value;
        }

        public long characterid
        {
            get => (long) Column["characterid"].Value;

            set => Column["characterid"].Value = value;
        }

        public int price
        {
            get => (int) Column["price"].Value;

            set => Column["price"].Value = value;
        }

        public int rating
        {
            get => (int) Column["rating"].Value;

            set => Column["rating"].Value = value;
        }

        public int categoryid
        {
            get => (int) Column["categoryid"].Value;

            set => Column["categoryid"].Value = value;
        }

        public string lxfpath
        {
            get => (string) Column["lxfpath"].Value;

            set => Column["lxfpath"].Value = value;
        }

        public bool deleted
        {
            get => (bool) Column["deleted"].Value;

            set => Column["deleted"].Value = value;
        }

        public long created
        {
            get => (long) Column["created"].Value;

            set => Column["created"].Value = value;
        }

        public long modified
        {
            get => (long) Column["modified"].Value;

            set => Column["modified"].Value = value;
        }
    }
}