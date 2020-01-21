namespace InfectedRose.Database.Concepts.Tables
{
    public class Release_VersionTable

    {
        public Release_VersionTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public string ReleaseVersion
        {
            get => (string) Column["ReleaseVersion"].Value;

            set => Column["ReleaseVersion"].Value = value;
        }

        public long ReleaseDate
        {
            get => (long) Column["ReleaseDate"].Value;

            set => Column["ReleaseDate"].Value = value;
        }
    }
}