namespace InfectedRose.Database.Concepts.Tables
{
    public class mapAssetTypeTable

    {
        public mapAssetTypeTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string label
        {
            get => (string) Column["label"].Value;

            set => Column["label"].Value = value;
        }

        public string pathdir
        {
            get => (string) Column["pathdir"].Value;

            set => Column["pathdir"].Value = value;
        }

        public string typelabel
        {
            get => (string) Column["typelabel"].Value;

            set => Column["typelabel"].Value = value;
        }
    }
}