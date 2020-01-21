namespace InfectedRose.Database.Concepts.Tables
{
    public class RailActivatorComponentTable

    {
        public RailActivatorComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string startAnim
        {
            get => (string) Column["startAnim"].Value;

            set => Column["startAnim"].Value = value;
        }

        public string loopAnim
        {
            get => (string) Column["loopAnim"].Value;

            set => Column["loopAnim"].Value = value;
        }

        public string stopAnim
        {
            get => (string) Column["stopAnim"].Value;

            set => Column["stopAnim"].Value = value;
        }

        public string startSound
        {
            get => (string) Column["startSound"].Value;

            set => Column["startSound"].Value = value;
        }

        public string loopSound
        {
            get => (string) Column["loopSound"].Value;

            set => Column["loopSound"].Value = value;
        }

        public string stopSound
        {
            get => (string) Column["stopSound"].Value;

            set => Column["stopSound"].Value = value;
        }

        public string effectIDs
        {
            get => (string) Column["effectIDs"].Value;

            set => Column["effectIDs"].Value = value;
        }

        public string preconditions
        {
            get => (string) Column["preconditions"].Value;

            set => Column["preconditions"].Value = value;
        }

        public bool playerCollision
        {
            get => (bool) Column["playerCollision"].Value;

            set => Column["playerCollision"].Value = value;
        }

        public bool cameraLocked
        {
            get => (bool) Column["cameraLocked"].Value;

            set => Column["cameraLocked"].Value = value;
        }

        public string StartEffectID
        {
            get => (string) Column["StartEffectID"].Value;

            set => Column["StartEffectID"].Value = value;
        }

        public string StopEffectID
        {
            get => (string) Column["StopEffectID"].Value;

            set => Column["StopEffectID"].Value = value;
        }

        public bool DamageImmune
        {
            get => (bool) Column["DamageImmune"].Value;

            set => Column["DamageImmune"].Value = value;
        }

        public bool NoAggro
        {
            get => (bool) Column["NoAggro"].Value;

            set => Column["NoAggro"].Value = value;
        }

        public bool ShowNameBillboard
        {
            get => (bool) Column["ShowNameBillboard"].Value;

            set => Column["ShowNameBillboard"].Value = value;
        }
    }
}