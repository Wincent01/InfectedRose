namespace InfectedRose.Database.Concepts.Tables
{
    public class MovementAIComponentTable

    {
        public MovementAIComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string MovementType
        {
            get => (string) Column["MovementType"].Value;

            set => Column["MovementType"].Value = value;
        }

        public float WanderChance
        {
            get => (float) Column["WanderChance"].Value;

            set => Column["WanderChance"].Value = value;
        }

        public float WanderDelayMin
        {
            get => (float) Column["WanderDelayMin"].Value;

            set => Column["WanderDelayMin"].Value = value;
        }

        public float WanderDelayMax
        {
            get => (float) Column["WanderDelayMax"].Value;

            set => Column["WanderDelayMax"].Value = value;
        }

        public float WanderSpeed
        {
            get => (float) Column["WanderSpeed"].Value;

            set => Column["WanderSpeed"].Value = value;
        }

        public float WanderRadius
        {
            get => (float) Column["WanderRadius"].Value;

            set => Column["WanderRadius"].Value = value;
        }

        public string attachedPath
        {
            get => (string) Column["attachedPath"].Value;

            set => Column["attachedPath"].Value = value;
        }
    }
}