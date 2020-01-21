namespace InfectedRose.Database.Concepts.Tables
{
    public class RebuildSectionsTable

    {
        public RebuildSectionsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int rebuildID
        {
            get => (int) Column["rebuildID"].Value;

            set => Column["rebuildID"].Value = value;
        }

        public int objectID
        {
            get => (int) Column["objectID"].Value;

            set => Column["objectID"].Value = value;
        }

        public float offset_x
        {
            get => (float) Column["offset_x"].Value;

            set => Column["offset_x"].Value = value;
        }

        public float offset_y
        {
            get => (float) Column["offset_y"].Value;

            set => Column["offset_y"].Value = value;
        }

        public float offset_z
        {
            get => (float) Column["offset_z"].Value;

            set => Column["offset_z"].Value = value;
        }

        public float fall_angle_x
        {
            get => (float) Column["fall_angle_x"].Value;

            set => Column["fall_angle_x"].Value = value;
        }

        public float fall_angle_y
        {
            get => (float) Column["fall_angle_y"].Value;

            set => Column["fall_angle_y"].Value = value;
        }

        public float fall_angle_z
        {
            get => (float) Column["fall_angle_z"].Value;

            set => Column["fall_angle_z"].Value = value;
        }

        public float fall_height
        {
            get => (float) Column["fall_height"].Value;

            set => Column["fall_height"].Value = value;
        }

        public string requires_list
        {
            get => (string) Column["requires_list"].Value;

            set => Column["requires_list"].Value = value;
        }

        public int size
        {
            get => (int) Column["size"].Value;

            set => Column["size"].Value = value;
        }

        public bool bPlaced
        {
            get => (bool) Column["bPlaced"].Value;

            set => Column["bPlaced"].Value = value;
        }
    }
}