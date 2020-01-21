namespace InfectedRose.Database.Concepts.Tables
{
    public class AccessoryDefaultLocTable

    {
        public AccessoryDefaultLocTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int GroupID
        {
            get => (int) Column["GroupID"].Value;

            set => Column["GroupID"].Value = value;
        }

        public string Description
        {
            get => (string) Column["Description"].Value;

            set => Column["Description"].Value = value;
        }

        public float Pos_X
        {
            get => (float) Column["Pos_X"].Value;

            set => Column["Pos_X"].Value = value;
        }

        public float Pos_Y
        {
            get => (float) Column["Pos_Y"].Value;

            set => Column["Pos_Y"].Value = value;
        }

        public float Pos_Z
        {
            get => (float) Column["Pos_Z"].Value;

            set => Column["Pos_Z"].Value = value;
        }

        public float Rot_X
        {
            get => (float) Column["Rot_X"].Value;

            set => Column["Rot_X"].Value = value;
        }

        public float Rot_Y
        {
            get => (float) Column["Rot_Y"].Value;

            set => Column["Rot_Y"].Value = value;
        }

        public float Rot_Z
        {
            get => (float) Column["Rot_Z"].Value;

            set => Column["Rot_Z"].Value = value;
        }
    }
}