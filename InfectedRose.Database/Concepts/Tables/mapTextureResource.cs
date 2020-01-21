namespace InfectedRose.Database.Concepts.Tables
{
    public class mapTextureResourceTable

    {
        public mapTextureResourceTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string texturepath
        {
            get => (string) Column["texturepath"].Value;

            set => Column["texturepath"].Value = value;
        }

        public int SurfaceType
        {
            get => (int) Column["SurfaceType"].Value;

            set => Column["SurfaceType"].Value = value;
        }
    }
}