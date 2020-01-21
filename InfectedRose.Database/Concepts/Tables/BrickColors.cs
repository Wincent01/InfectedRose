namespace InfectedRose.Database.Concepts.Tables
{
    public class BrickColorsTable

    {
        public BrickColorsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float red
        {
            get => (float) Column["red"].Value;

            set => Column["red"].Value = value;
        }

        public float green
        {
            get => (float) Column["green"].Value;

            set => Column["green"].Value = value;
        }

        public float blue
        {
            get => (float) Column["blue"].Value;

            set => Column["blue"].Value = value;
        }

        public float alpha
        {
            get => (float) Column["alpha"].Value;

            set => Column["alpha"].Value = value;
        }

        public int legopaletteid
        {
            get => (int) Column["legopaletteid"].Value;

            set => Column["legopaletteid"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public int validTypes
        {
            get => (int) Column["validTypes"].Value;

            set => Column["validTypes"].Value = value;
        }

        public int validCharacters
        {
            get => (int) Column["validCharacters"].Value;

            set => Column["validCharacters"].Value = value;
        }

        public bool factoryValid
        {
            get => (bool) Column["factoryValid"].Value;

            set => Column["factoryValid"].Value = value;
        }
    }
}