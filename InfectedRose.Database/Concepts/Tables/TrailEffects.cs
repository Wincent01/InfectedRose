namespace InfectedRose.Database.Concepts.Tables
{
    public class TrailEffectsTable

    {
        public TrailEffectsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int trailID
        {
            get => (int) Column["trailID"].Value;

            set => Column["trailID"].Value = value;
        }

        public string textureName
        {
            get => (string) Column["textureName"].Value;

            set => Column["textureName"].Value = value;
        }

        public int blendmode
        {
            get => (int) Column["blendmode"].Value;

            set => Column["blendmode"].Value = value;
        }

        public float cardlifetime
        {
            get => (float) Column["cardlifetime"].Value;

            set => Column["cardlifetime"].Value = value;
        }

        public float colorlifetime
        {
            get => (float) Column["colorlifetime"].Value;

            set => Column["colorlifetime"].Value = value;
        }

        public float minTailFade
        {
            get => (float) Column["minTailFade"].Value;

            set => Column["minTailFade"].Value = value;
        }

        public float tailFade
        {
            get => (float) Column["tailFade"].Value;

            set => Column["tailFade"].Value = value;
        }

        public int max_particles
        {
            get => (int) Column["max_particles"].Value;

            set => Column["max_particles"].Value = value;
        }

        public float birthDelay
        {
            get => (float) Column["birthDelay"].Value;

            set => Column["birthDelay"].Value = value;
        }

        public float deathDelay
        {
            get => (float) Column["deathDelay"].Value;

            set => Column["deathDelay"].Value = value;
        }

        public string bone1
        {
            get => (string) Column["bone1"].Value;

            set => Column["bone1"].Value = value;
        }

        public string bone2
        {
            get => (string) Column["bone2"].Value;

            set => Column["bone2"].Value = value;
        }

        public float texLength
        {
            get => (float) Column["texLength"].Value;

            set => Column["texLength"].Value = value;
        }

        public float texWidth
        {
            get => (float) Column["texWidth"].Value;

            set => Column["texWidth"].Value = value;
        }

        public float startColorR
        {
            get => (float) Column["startColorR"].Value;

            set => Column["startColorR"].Value = value;
        }

        public float startColorG
        {
            get => (float) Column["startColorG"].Value;

            set => Column["startColorG"].Value = value;
        }

        public float startColorB
        {
            get => (float) Column["startColorB"].Value;

            set => Column["startColorB"].Value = value;
        }

        public float startColorA
        {
            get => (float) Column["startColorA"].Value;

            set => Column["startColorA"].Value = value;
        }

        public float middleColorR
        {
            get => (float) Column["middleColorR"].Value;

            set => Column["middleColorR"].Value = value;
        }

        public float middleColorG
        {
            get => (float) Column["middleColorG"].Value;

            set => Column["middleColorG"].Value = value;
        }

        public float middleColorB
        {
            get => (float) Column["middleColorB"].Value;

            set => Column["middleColorB"].Value = value;
        }

        public float middleColorA
        {
            get => (float) Column["middleColorA"].Value;

            set => Column["middleColorA"].Value = value;
        }

        public float endColorR
        {
            get => (float) Column["endColorR"].Value;

            set => Column["endColorR"].Value = value;
        }

        public float endColorG
        {
            get => (float) Column["endColorG"].Value;

            set => Column["endColorG"].Value = value;
        }

        public float endColorB
        {
            get => (float) Column["endColorB"].Value;

            set => Column["endColorB"].Value = value;
        }

        public float endColorA
        {
            get => (float) Column["endColorA"].Value;

            set => Column["endColorA"].Value = value;
        }
    }
}