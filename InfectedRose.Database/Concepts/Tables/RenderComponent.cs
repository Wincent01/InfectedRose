namespace InfectedRose.Database.Concepts.Tables
{
    public class RenderComponentTable

    {
        public RenderComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string render_asset
        {
            get => (string) Column["render_asset"].Value;

            set => Column["render_asset"].Value = value;
        }

        public string icon_asset
        {
            get => (string) Column["icon_asset"].Value;

            set => Column["icon_asset"].Value = value;
        }

        public int IconID
        {
            get => (int) Column["IconID"].Value;

            set => Column["IconID"].Value = value;
        }

        public int shader_id
        {
            get => (int) Column["shader_id"].Value;

            set => Column["shader_id"].Value = value;
        }

        public int effect1
        {
            get => (int) Column["effect1"].Value;

            set => Column["effect1"].Value = value;
        }

        public int effect2
        {
            get => (int) Column["effect2"].Value;

            set => Column["effect2"].Value = value;
        }

        public int effect3
        {
            get => (int) Column["effect3"].Value;

            set => Column["effect3"].Value = value;
        }

        public int effect4
        {
            get => (int) Column["effect4"].Value;

            set => Column["effect4"].Value = value;
        }

        public int effect5
        {
            get => (int) Column["effect5"].Value;

            set => Column["effect5"].Value = value;
        }

        public int effect6
        {
            get => (int) Column["effect6"].Value;

            set => Column["effect6"].Value = value;
        }

        public string animationGroupIDs
        {
            get => (string) Column["animationGroupIDs"].Value;

            set => Column["animationGroupIDs"].Value = value;
        }

        public bool fade
        {
            get => (bool) Column["fade"].Value;

            set => Column["fade"].Value = value;
        }

        public bool usedropshadow
        {
            get => (bool) Column["usedropshadow"].Value;

            set => Column["usedropshadow"].Value = value;
        }

        public bool preloadAnimations
        {
            get => (bool) Column["preloadAnimations"].Value;

            set => Column["preloadAnimations"].Value = value;
        }

        public float fadeInTime
        {
            get => (float) Column["fadeInTime"].Value;

            set => Column["fadeInTime"].Value = value;
        }

        public float maxShadowDistance
        {
            get => (float) Column["maxShadowDistance"].Value;

            set => Column["maxShadowDistance"].Value = value;
        }

        public bool ignoreCameraCollision
        {
            get => (bool) Column["ignoreCameraCollision"].Value;

            set => Column["ignoreCameraCollision"].Value = value;
        }

        public int renderComponentLOD1
        {
            get => (int) Column["renderComponentLOD1"].Value;

            set => Column["renderComponentLOD1"].Value = value;
        }

        public int renderComponentLOD2
        {
            get => (int) Column["renderComponentLOD2"].Value;

            set => Column["renderComponentLOD2"].Value = value;
        }

        public bool gradualSnap
        {
            get => (bool) Column["gradualSnap"].Value;

            set => Column["gradualSnap"].Value = value;
        }

        public int animationFlag
        {
            get => (int) Column["animationFlag"].Value;

            set => Column["animationFlag"].Value = value;
        }

        public string AudioMetaEventSet
        {
            get => (string) Column["AudioMetaEventSet"].Value;

            set => Column["AudioMetaEventSet"].Value = value;
        }

        public float billboardHeight
        {
            get => (float) Column["billboardHeight"].Value;

            set => Column["billboardHeight"].Value = value;
        }

        public float chatBubbleOffset
        {
            get => (float) Column["chatBubbleOffset"].Value;

            set => Column["chatBubbleOffset"].Value = value;
        }

        public bool staticBillboard
        {
            get => (bool) Column["staticBillboard"].Value;

            set => Column["staticBillboard"].Value = value;
        }

        public string LXFMLFolder
        {
            get => (string) Column["LXFMLFolder"].Value;

            set => Column["LXFMLFolder"].Value = value;
        }

        public bool attachIndicatorsToNode
        {
            get => (bool) Column["attachIndicatorsToNode"].Value;

            set => Column["attachIndicatorsToNode"].Value = value;
        }
    }
}