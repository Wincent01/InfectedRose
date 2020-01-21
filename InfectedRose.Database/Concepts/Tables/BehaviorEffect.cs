namespace InfectedRose.Database.Concepts.Tables
{
    public class BehaviorEffectTable

    {
        public BehaviorEffectTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int effectID
        {
            get => (int) Column["effectID"].Value;

            set => Column["effectID"].Value = value;
        }

        public string effectType
        {
            get => (string) Column["effectType"].Value;

            set => Column["effectType"].Value = value;
        }

        public string effectName
        {
            get => (string) Column["effectName"].Value;

            set => Column["effectName"].Value = value;
        }

        public int trailID
        {
            get => (int) Column["trailID"].Value;

            set => Column["trailID"].Value = value;
        }

        public float pcreateDuration
        {
            get => (float) Column["pcreateDuration"].Value;

            set => Column["pcreateDuration"].Value = value;
        }

        public string animationName
        {
            get => (string) Column["animationName"].Value;

            set => Column["animationName"].Value = value;
        }

        public bool attachToObject
        {
            get => (bool) Column["attachToObject"].Value;

            set => Column["attachToObject"].Value = value;
        }

        public string boneName
        {
            get => (string) Column["boneName"].Value;

            set => Column["boneName"].Value = value;
        }

        public bool useSecondary
        {
            get => (bool) Column["useSecondary"].Value;

            set => Column["useSecondary"].Value = value;
        }

        public int cameraEffectType
        {
            get => (int) Column["cameraEffectType"].Value;

            set => Column["cameraEffectType"].Value = value;
        }

        public float cameraDuration
        {
            get => (float) Column["cameraDuration"].Value;

            set => Column["cameraDuration"].Value = value;
        }

        public float cameraFrequency
        {
            get => (float) Column["cameraFrequency"].Value;

            set => Column["cameraFrequency"].Value = value;
        }

        public float cameraXAmp
        {
            get => (float) Column["cameraXAmp"].Value;

            set => Column["cameraXAmp"].Value = value;
        }

        public float cameraYAmp
        {
            get => (float) Column["cameraYAmp"].Value;

            set => Column["cameraYAmp"].Value = value;
        }

        public float cameraZAmp
        {
            get => (float) Column["cameraZAmp"].Value;

            set => Column["cameraZAmp"].Value = value;
        }

        public float cameraRotFrequency
        {
            get => (float) Column["cameraRotFrequency"].Value;

            set => Column["cameraRotFrequency"].Value = value;
        }

        public float cameraRoll
        {
            get => (float) Column["cameraRoll"].Value;

            set => Column["cameraRoll"].Value = value;
        }

        public float cameraPitch
        {
            get => (float) Column["cameraPitch"].Value;

            set => Column["cameraPitch"].Value = value;
        }

        public float cameraYaw
        {
            get => (float) Column["cameraYaw"].Value;

            set => Column["cameraYaw"].Value = value;
        }

        public string AudioEventGUID
        {
            get => (string) Column["AudioEventGUID"].Value;

            set => Column["AudioEventGUID"].Value = value;
        }

        public int renderEffectType
        {
            get => (int) Column["renderEffectType"].Value;

            set => Column["renderEffectType"].Value = value;
        }

        public float renderEffectTime
        {
            get => (float) Column["renderEffectTime"].Value;

            set => Column["renderEffectTime"].Value = value;
        }

        public float renderStartVal
        {
            get => (float) Column["renderStartVal"].Value;

            set => Column["renderStartVal"].Value = value;
        }

        public float renderEndVal
        {
            get => (float) Column["renderEndVal"].Value;

            set => Column["renderEndVal"].Value = value;
        }

        public float renderDelayVal
        {
            get => (float) Column["renderDelayVal"].Value;

            set => Column["renderDelayVal"].Value = value;
        }

        public float renderValue1
        {
            get => (float) Column["renderValue1"].Value;

            set => Column["renderValue1"].Value = value;
        }

        public float renderValue2
        {
            get => (float) Column["renderValue2"].Value;

            set => Column["renderValue2"].Value = value;
        }

        public float renderValue3
        {
            get => (float) Column["renderValue3"].Value;

            set => Column["renderValue3"].Value = value;
        }

        public string renderRGBA
        {
            get => (string) Column["renderRGBA"].Value;

            set => Column["renderRGBA"].Value = value;
        }

        public int renderShaderVal
        {
            get => (int) Column["renderShaderVal"].Value;

            set => Column["renderShaderVal"].Value = value;
        }

        public int motionID
        {
            get => (int) Column["motionID"].Value;

            set => Column["motionID"].Value = value;
        }

        public int meshID
        {
            get => (int) Column["meshID"].Value;

            set => Column["meshID"].Value = value;
        }

        public float meshDuration
        {
            get => (float) Column["meshDuration"].Value;

            set => Column["meshDuration"].Value = value;
        }

        public string meshLockedNode
        {
            get => (string) Column["meshLockedNode"].Value;

            set => Column["meshLockedNode"].Value = value;
        }
    }
}