namespace InfectedRose.Database.Concepts.Tables
{
    public class ModuleComponentTable

    {
        public ModuleComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int partCode
        {
            get => (int) Column["partCode"].Value;

            set => Column["partCode"].Value = value;
        }

        public int buildType
        {
            get => (int) Column["buildType"].Value;

            set => Column["buildType"].Value = value;
        }

        public string xml
        {
            get => (string) Column["xml"].Value;

            set => Column["xml"].Value = value;
        }

        public string primarySoundGUID
        {
            get => (string) Column["primarySoundGUID"].Value;

            set => Column["primarySoundGUID"].Value = value;
        }

        public int assembledEffectID
        {
            get => (int) Column["assembledEffectID"].Value;

            set => Column["assembledEffectID"].Value = value;
        }
    }
}