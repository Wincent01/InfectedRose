namespace InfectedRose.Database.Concepts.Tables
{
    public class TextLanguageTable

    {
        public TextLanguageTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int TextID
        {
            get => (int) Column["TextID"].Value;

            set => Column["TextID"].Value = value;
        }

        public int LanguageID
        {
            get => (int) Column["LanguageID"].Value;

            set => Column["LanguageID"].Value = value;
        }

        public string Text
        {
            get => (string) Column["Text"].Value;

            set => Column["Text"].Value = value;
        }
    }
}