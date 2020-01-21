namespace InfectedRose.Database.Concepts.Tables
{
    public class PhysicsComponentTable

    {
        public PhysicsComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float Static
        {
            get => (float) Column["static"].Value;

            set => Column["static"].Value = value;
        }

        public string physics_asset
        {
            get => (string) Column["physics_asset"].Value;

            set => Column["physics_asset"].Value = value;
        }

        public float jump
        {
            get => (float) Column["jump"].Value;

            set => Column["jump"].Value = value;
        }

        public float doublejump
        {
            get => (float) Column["doublejump"].Value;

            set => Column["doublejump"].Value = value;
        }

        public float speed
        {
            get => (float) Column["speed"].Value;

            set => Column["speed"].Value = value;
        }

        public float rotSpeed
        {
            get => (float) Column["rotSpeed"].Value;

            set => Column["rotSpeed"].Value = value;
        }

        public float playerHeight
        {
            get => (float) Column["playerHeight"].Value;

            set => Column["playerHeight"].Value = value;
        }

        public float playerRadius
        {
            get => (float) Column["playerRadius"].Value;

            set => Column["playerRadius"].Value = value;
        }

        public int pcShapeType
        {
            get => (int) Column["pcShapeType"].Value;

            set => Column["pcShapeType"].Value = value;
        }

        public int collisionGroup
        {
            get => (int) Column["collisionGroup"].Value;

            set => Column["collisionGroup"].Value = value;
        }

        public float airSpeed
        {
            get => (float) Column["airSpeed"].Value;

            set => Column["airSpeed"].Value = value;
        }

        public string boundaryAsset
        {
            get => (string) Column["boundaryAsset"].Value;

            set => Column["boundaryAsset"].Value = value;
        }

        public float jumpAirSpeed
        {
            get => (float) Column["jumpAirSpeed"].Value;

            set => Column["jumpAirSpeed"].Value = value;
        }

        public float friction
        {
            get => (float) Column["friction"].Value;

            set => Column["friction"].Value = value;
        }

        public string gravityVolumeAsset
        {
            get => (string) Column["gravityVolumeAsset"].Value;

            set => Column["gravityVolumeAsset"].Value = value;
        }
    }
}