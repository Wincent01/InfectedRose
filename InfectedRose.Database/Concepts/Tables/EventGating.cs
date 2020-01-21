namespace InfectedRose.Database.Concepts.Tables
{
    public class EventGatingTable

    {
        public EventGatingTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public string eventName
        {
            get => (string) Column["eventName"].Value;

            set => Column["eventName"].Value = value;
        }

        public long date_start
        {
            get => (long) Column["date_start"].Value;

            set => Column["date_start"].Value = value;
        }

        public long date_end
        {
            get => (long) Column["date_end"].Value;

            set => Column["date_end"].Value = value;
        }
    }
}