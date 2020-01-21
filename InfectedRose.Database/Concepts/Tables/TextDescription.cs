namespace InfectedRose.Database.Concepts.Tables
{
    public class TextDescriptionTable

    {
        public TextDescriptionTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int TextID
        {
            get => (int) Column["TextID"].Value;

            set => Column["TextID"].Value = value;
        }

        public string TestDescription
        {
            get => (string) Column["TestDescription"].Value;

            set => Column["TestDescription"].Value = value;
        }
    }
}