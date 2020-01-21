namespace InfectedRose.Database.Concepts.Tables
{
    public class ExhibitComponentTable

    {
        public ExhibitComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float length
        {
            get => (float) Column["length"].Value;

            set => Column["length"].Value = value;
        }

        public float width
        {
            get => (float) Column["width"].Value;

            set => Column["width"].Value = value;
        }

        public float height
        {
            get => (float) Column["height"].Value;

            set => Column["height"].Value = value;
        }

        public float offsetX
        {
            get => (float) Column["offsetX"].Value;

            set => Column["offsetX"].Value = value;
        }

        public float offsetY
        {
            get => (float) Column["offsetY"].Value;

            set => Column["offsetY"].Value = value;
        }

        public float offsetZ
        {
            get => (float) Column["offsetZ"].Value;

            set => Column["offsetZ"].Value = value;
        }

        public float fReputationSizeMultiplier
        {
            get => (float) Column["fReputationSizeMultiplier"].Value;

            set => Column["fReputationSizeMultiplier"].Value = value;
        }

        public float fImaginationCost
        {
            get => (float) Column["fImaginationCost"].Value;

            set => Column["fImaginationCost"].Value = value;
        }
    }
}