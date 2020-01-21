namespace InfectedRose.Database.Concepts.Tables
{
    public class SceneTableTable

    {
        public SceneTableTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int sceneID
        {
            get => (int) Column["sceneID"].Value;

            set => Column["sceneID"].Value = value;
        }

        public string sceneName
        {
            get => (string) Column["sceneName"].Value;

            set => Column["sceneName"].Value = value;
        }
    }
}