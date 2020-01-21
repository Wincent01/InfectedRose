namespace InfectedRose.Database.Concepts.Tables
{
    public class PossessableComponentTable

    {
        public PossessableComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int controlSchemeID
        {
            get => (int) Column["controlSchemeID"].Value;

            set => Column["controlSchemeID"].Value = value;
        }

        public string minifigAttachPoint
        {
            get => (string) Column["minifigAttachPoint"].Value;

            set => Column["minifigAttachPoint"].Value = value;
        }

        public string minifigAttachAnimation
        {
            get => (string) Column["minifigAttachAnimation"].Value;

            set => Column["minifigAttachAnimation"].Value = value;
        }

        public string minifigDetachAnimation
        {
            get => (string) Column["minifigDetachAnimation"].Value;

            set => Column["minifigDetachAnimation"].Value = value;
        }

        public string mountAttachAnimation
        {
            get => (string) Column["mountAttachAnimation"].Value;

            set => Column["mountAttachAnimation"].Value = value;
        }

        public string mountDetachAnimation
        {
            get => (string) Column["mountDetachAnimation"].Value;

            set => Column["mountDetachAnimation"].Value = value;
        }

        public float attachOffsetFwd
        {
            get => (float) Column["attachOffsetFwd"].Value;

            set => Column["attachOffsetFwd"].Value = value;
        }

        public float attachOffsetRight
        {
            get => (float) Column["attachOffsetRight"].Value;

            set => Column["attachOffsetRight"].Value = value;
        }

        public int possessionType
        {
            get => (int) Column["possessionType"].Value;

            set => Column["possessionType"].Value = value;
        }

        public bool wantBillboard
        {
            get => (bool) Column["wantBillboard"].Value;

            set => Column["wantBillboard"].Value = value;
        }

        public float billboardOffsetUp
        {
            get => (float) Column["billboardOffsetUp"].Value;

            set => Column["billboardOffsetUp"].Value = value;
        }

        public bool depossessOnHit
        {
            get => (bool) Column["depossessOnHit"].Value;

            set => Column["depossessOnHit"].Value = value;
        }

        public float hitStunTime
        {
            get => (float) Column["hitStunTime"].Value;

            set => Column["hitStunTime"].Value = value;
        }

        public int skillSet
        {
            get => (int) Column["skillSet"].Value;

            set => Column["skillSet"].Value = value;
        }
    }
}