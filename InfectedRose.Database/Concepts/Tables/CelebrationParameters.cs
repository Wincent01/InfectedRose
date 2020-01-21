namespace InfectedRose.Database.Concepts.Tables
{
    public class CelebrationParametersTable

    {
        public CelebrationParametersTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string animation
        {
            get => (string) Column["animation"].Value;

            set => Column["animation"].Value = value;
        }

        public int backgroundObject
        {
            get => (int) Column["backgroundObject"].Value;

            set => Column["backgroundObject"].Value = value;
        }

        public float duration
        {
            get => (float) Column["duration"].Value;

            set => Column["duration"].Value = value;
        }

        public string subText
        {
            get => (string) Column["subText"].Value;

            set => Column["subText"].Value = value;
        }

        public string mainText
        {
            get => (string) Column["mainText"].Value;

            set => Column["mainText"].Value = value;
        }

        public int iconID
        {
            get => (int) Column["iconID"].Value;

            set => Column["iconID"].Value = value;
        }

        public float celeLeadIn
        {
            get => (float) Column["celeLeadIn"].Value;

            set => Column["celeLeadIn"].Value = value;
        }

        public float celeLeadOut
        {
            get => (float) Column["celeLeadOut"].Value;

            set => Column["celeLeadOut"].Value = value;
        }

        public int cameraPathLOT
        {
            get => (int) Column["cameraPathLOT"].Value;

            set => Column["cameraPathLOT"].Value = value;
        }

        public string pathNodeName
        {
            get => (string) Column["pathNodeName"].Value;

            set => Column["pathNodeName"].Value = value;
        }

        public float ambientR
        {
            get => (float) Column["ambientR"].Value;

            set => Column["ambientR"].Value = value;
        }

        public float ambientG
        {
            get => (float) Column["ambientG"].Value;

            set => Column["ambientG"].Value = value;
        }

        public float ambientB
        {
            get => (float) Column["ambientB"].Value;

            set => Column["ambientB"].Value = value;
        }

        public float directionalR
        {
            get => (float) Column["directionalR"].Value;

            set => Column["directionalR"].Value = value;
        }

        public float directionalG
        {
            get => (float) Column["directionalG"].Value;

            set => Column["directionalG"].Value = value;
        }

        public float directionalB
        {
            get => (float) Column["directionalB"].Value;

            set => Column["directionalB"].Value = value;
        }

        public float specularR
        {
            get => (float) Column["specularR"].Value;

            set => Column["specularR"].Value = value;
        }

        public float specularG
        {
            get => (float) Column["specularG"].Value;

            set => Column["specularG"].Value = value;
        }

        public float specularB
        {
            get => (float) Column["specularB"].Value;

            set => Column["specularB"].Value = value;
        }

        public float lightPositionX
        {
            get => (float) Column["lightPositionX"].Value;

            set => Column["lightPositionX"].Value = value;
        }

        public float lightPositionY
        {
            get => (float) Column["lightPositionY"].Value;

            set => Column["lightPositionY"].Value = value;
        }

        public float lightPositionZ
        {
            get => (float) Column["lightPositionZ"].Value;

            set => Column["lightPositionZ"].Value = value;
        }

        public float blendTime
        {
            get => (float) Column["blendTime"].Value;

            set => Column["blendTime"].Value = value;
        }

        public float fogColorR
        {
            get => (float) Column["fogColorR"].Value;

            set => Column["fogColorR"].Value = value;
        }

        public float fogColorG
        {
            get => (float) Column["fogColorG"].Value;

            set => Column["fogColorG"].Value = value;
        }

        public float fogColorB
        {
            get => (float) Column["fogColorB"].Value;

            set => Column["fogColorB"].Value = value;
        }

        public string musicCue
        {
            get => (string) Column["musicCue"].Value;

            set => Column["musicCue"].Value = value;
        }

        public string soundGUID
        {
            get => (string) Column["soundGUID"].Value;

            set => Column["soundGUID"].Value = value;
        }

        public string mixerProgram
        {
            get => (string) Column["mixerProgram"].Value;

            set => Column["mixerProgram"].Value = value;
        }
    }
}