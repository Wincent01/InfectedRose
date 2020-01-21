namespace InfectedRose.Database.Concepts.Tables
{
    public class MovingPlatformsTable

    {
        public MovingPlatformsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public bool platformIsSimpleMover
        {
            get => (bool) Column["platformIsSimpleMover"].Value;

            set => Column["platformIsSimpleMover"].Value = value;
        }

        public float platformMoveX
        {
            get => (float) Column["platformMoveX"].Value;

            set => Column["platformMoveX"].Value = value;
        }

        public float platformMoveY
        {
            get => (float) Column["platformMoveY"].Value;

            set => Column["platformMoveY"].Value = value;
        }

        public float platformMoveZ
        {
            get => (float) Column["platformMoveZ"].Value;

            set => Column["platformMoveZ"].Value = value;
        }

        public float platformMoveTime
        {
            get => (float) Column["platformMoveTime"].Value;

            set => Column["platformMoveTime"].Value = value;
        }

        public bool platformStartAtEnd
        {
            get => (bool) Column["platformStartAtEnd"].Value;

            set => Column["platformStartAtEnd"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }
    }
}