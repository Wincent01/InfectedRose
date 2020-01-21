namespace InfectedRose.Database.Concepts.Tables
{
    public class AnimationIndexTable

    {
        public AnimationIndexTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int animationGroupID
        {
            get => (int) Column["animationGroupID"].Value;

            set => Column["animationGroupID"].Value = value;
        }

        public string description
        {
            get => (string) Column["description"].Value;

            set => Column["description"].Value = value;
        }

        public string groupType
        {
            get => (string) Column["groupType"].Value;

            set => Column["groupType"].Value = value;
        }
    }
}