namespace InfectedRose.Database.Concepts.Tables
{
    public class SurfaceTypeTable

    {
        public SurfaceTypeTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int SurfaceType
        {
            get => (int) Column["SurfaceType"].Value;

            set => Column["SurfaceType"].Value = value;
        }

        public string FootstepNDAudioMetaEventSetName
        {
            get => (string) Column["FootstepNDAudioMetaEventSetName"].Value;

            set => Column["FootstepNDAudioMetaEventSetName"].Value = value;
        }
    }
}