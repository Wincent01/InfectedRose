namespace InfectedRose.Database.Concepts.Tables
{
    public class JetPackPadComponentTable

    {
        public JetPackPadComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float xDistance
        {
            get => (float) Column["xDistance"].Value;

            set => Column["xDistance"].Value = value;
        }

        public float yDistance
        {
            get => (float) Column["yDistance"].Value;

            set => Column["yDistance"].Value = value;
        }

        public float warnDistance
        {
            get => (float) Column["warnDistance"].Value;

            set => Column["warnDistance"].Value = value;
        }

        public int lotBlocker
        {
            get => (int) Column["lotBlocker"].Value;

            set => Column["lotBlocker"].Value = value;
        }

        public int lotWarningVolume
        {
            get => (int) Column["lotWarningVolume"].Value;

            set => Column["lotWarningVolume"].Value = value;
        }
    }
}