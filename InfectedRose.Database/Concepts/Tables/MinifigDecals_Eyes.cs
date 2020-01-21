namespace InfectedRose.Database.Concepts.Tables
{
    public class MinifigDecals_EyesTable

    {
        public MinifigDecals_EyesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int ID
        {
            get => (int) Column["ID"].Value;

            set => Column["ID"].Value = value;
        }

        public string High_path
        {
            get => (string) Column["High_path"].Value;

            set => Column["High_path"].Value = value;
        }

        public string Low_path
        {
            get => (string) Column["Low_path"].Value;

            set => Column["Low_path"].Value = value;
        }

        public bool CharacterCreateValid
        {
            get => (bool) Column["CharacterCreateValid"].Value;

            set => Column["CharacterCreateValid"].Value = value;
        }

        public bool male
        {
            get => (bool) Column["male"].Value;

            set => Column["male"].Value = value;
        }

        public bool female
        {
            get => (bool) Column["female"].Value;

            set => Column["female"].Value = value;
        }
    }
}