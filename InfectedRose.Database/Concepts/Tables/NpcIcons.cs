namespace InfectedRose.Database.Concepts.Tables
{
    public class NpcIconsTable

    {
        public NpcIconsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int color
        {
            get => (int) Column["color"].Value;

            set => Column["color"].Value = value;
        }

        public float offset
        {
            get => (float) Column["offset"].Value;

            set => Column["offset"].Value = value;
        }

        public int LOT
        {
            get => (int) Column["LOT"].Value;

            set => Column["LOT"].Value = value;
        }

        public string Texture
        {
            get => (string) Column["Texture"].Value;

            set => Column["Texture"].Value = value;
        }

        public bool isClickable
        {
            get => (bool) Column["isClickable"].Value;

            set => Column["isClickable"].Value = value;
        }

        public float scale
        {
            get => (float) Column["scale"].Value;

            set => Column["scale"].Value = value;
        }

        public bool rotateToFace
        {
            get => (bool) Column["rotateToFace"].Value;

            set => Column["rotateToFace"].Value = value;
        }

        public float compositeHorizOffset
        {
            get => (float) Column["compositeHorizOffset"].Value;

            set => Column["compositeHorizOffset"].Value = value;
        }

        public float compositeVertOffset
        {
            get => (float) Column["compositeVertOffset"].Value;

            set => Column["compositeVertOffset"].Value = value;
        }

        public float compositeScale
        {
            get => (float) Column["compositeScale"].Value;

            set => Column["compositeScale"].Value = value;
        }

        public string compositeConnectionNode
        {
            get => (string) Column["compositeConnectionNode"].Value;

            set => Column["compositeConnectionNode"].Value = value;
        }

        public int compositeLOTMultiMission
        {
            get => (int) Column["compositeLOTMultiMission"].Value;

            set => Column["compositeLOTMultiMission"].Value = value;
        }

        public int compositeLOTMultiMissionVentor
        {
            get => (int) Column["compositeLOTMultiMissionVentor"].Value;

            set => Column["compositeLOTMultiMissionVentor"].Value = value;
        }

        public string compositeIconTexture
        {
            get => (string) Column["compositeIconTexture"].Value;

            set => Column["compositeIconTexture"].Value = value;
        }
    }
}