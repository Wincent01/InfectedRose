namespace InfectedRose.Database.Concepts.Tables
{
    public class LanguageTypeTable

    {
        public LanguageTypeTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LanguageID
        {
            get => (int) Column["LanguageID"].Value;

            set => Column["LanguageID"].Value = value;
        }

        public string LanguageDescription
        {
            get => (string) Column["LanguageDescription"].Value;

            set => Column["LanguageDescription"].Value = value;
        }
    }
}