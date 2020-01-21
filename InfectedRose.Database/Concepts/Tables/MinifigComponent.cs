namespace InfectedRose.Database.Concepts.Tables
{
    public class MinifigComponentTable

    {
        public MinifigComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int head
        {
            get => (int) Column["head"].Value;

            set => Column["head"].Value = value;
        }

        public int chest
        {
            get => (int) Column["chest"].Value;

            set => Column["chest"].Value = value;
        }

        public int legs
        {
            get => (int) Column["legs"].Value;

            set => Column["legs"].Value = value;
        }

        public int hairstyle
        {
            get => (int) Column["hairstyle"].Value;

            set => Column["hairstyle"].Value = value;
        }

        public int haircolor
        {
            get => (int) Column["haircolor"].Value;

            set => Column["haircolor"].Value = value;
        }

        public int chestdecal
        {
            get => (int) Column["chestdecal"].Value;

            set => Column["chestdecal"].Value = value;
        }

        public int headcolor
        {
            get => (int) Column["headcolor"].Value;

            set => Column["headcolor"].Value = value;
        }

        public int lefthand
        {
            get => (int) Column["lefthand"].Value;

            set => Column["lefthand"].Value = value;
        }

        public int righthand
        {
            get => (int) Column["righthand"].Value;

            set => Column["righthand"].Value = value;
        }

        public int eyebrowstyle
        {
            get => (int) Column["eyebrowstyle"].Value;

            set => Column["eyebrowstyle"].Value = value;
        }

        public int eyesstyle
        {
            get => (int) Column["eyesstyle"].Value;

            set => Column["eyesstyle"].Value = value;
        }

        public int mouthstyle
        {
            get => (int) Column["mouthstyle"].Value;

            set => Column["mouthstyle"].Value = value;
        }
    }
}