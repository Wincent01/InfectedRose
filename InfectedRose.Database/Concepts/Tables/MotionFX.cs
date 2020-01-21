namespace InfectedRose.Database.Concepts.Tables
{
    public class MotionFXTable

    {
        public MotionFXTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int typeID
        {
            get => (int) Column["typeID"].Value;

            set => Column["typeID"].Value = value;
        }

        public float slamVelocity
        {
            get => (float) Column["slamVelocity"].Value;

            set => Column["slamVelocity"].Value = value;
        }

        public float addVelocity
        {
            get => (float) Column["addVelocity"].Value;

            set => Column["addVelocity"].Value = value;
        }

        public float duration
        {
            get => (float) Column["duration"].Value;

            set => Column["duration"].Value = value;
        }

        public string destGroupName
        {
            get => (string) Column["destGroupName"].Value;

            set => Column["destGroupName"].Value = value;
        }

        public float startScale
        {
            get => (float) Column["startScale"].Value;

            set => Column["startScale"].Value = value;
        }

        public float endScale
        {
            get => (float) Column["endScale"].Value;

            set => Column["endScale"].Value = value;
        }

        public float velocity
        {
            get => (float) Column["velocity"].Value;

            set => Column["velocity"].Value = value;
        }

        public float distance
        {
            get => (float) Column["distance"].Value;

            set => Column["distance"].Value = value;
        }
    }
}