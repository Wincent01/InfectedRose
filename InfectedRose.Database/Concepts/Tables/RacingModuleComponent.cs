namespace InfectedRose.Database.Concepts.Tables
{
    public class RacingModuleComponentTable

    {
        public RacingModuleComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float topSpeed
        {
            get => (float) Column["topSpeed"].Value;

            set => Column["topSpeed"].Value = value;
        }

        public float acceleration
        {
            get => (float) Column["acceleration"].Value;

            set => Column["acceleration"].Value = value;
        }

        public float handling
        {
            get => (float) Column["handling"].Value;

            set => Column["handling"].Value = value;
        }

        public float stability
        {
            get => (float) Column["stability"].Value;

            set => Column["stability"].Value = value;
        }

        public float imagination
        {
            get => (float) Column["imagination"].Value;

            set => Column["imagination"].Value = value;
        }
    }
}