namespace InfectedRose.Database.Concepts.Tables
{
    public class PetComponentTable

    {
        public PetComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float minTameUpdateTime
        {
            get => (float) Column["minTameUpdateTime"].Value;

            set => Column["minTameUpdateTime"].Value = value;
        }

        public float maxTameUpdateTime
        {
            get => (float) Column["maxTameUpdateTime"].Value;

            set => Column["maxTameUpdateTime"].Value = value;
        }

        public float percentTameChance
        {
            get => (float) Column["percentTameChance"].Value;

            set => Column["percentTameChance"].Value = value;
        }

        public float tamability
        {
            get => (float) Column["tamability"].Value;

            set => Column["tamability"].Value = value;
        }

        public int elementType
        {
            get => (int) Column["elementType"].Value;

            set => Column["elementType"].Value = value;
        }

        public float walkSpeed
        {
            get => (float) Column["walkSpeed"].Value;

            set => Column["walkSpeed"].Value = value;
        }

        public float runSpeed
        {
            get => (float) Column["runSpeed"].Value;

            set => Column["runSpeed"].Value = value;
        }

        public float sprintSpeed
        {
            get => (float) Column["sprintSpeed"].Value;

            set => Column["sprintSpeed"].Value = value;
        }

        public float idleTimeMin
        {
            get => (float) Column["idleTimeMin"].Value;

            set => Column["idleTimeMin"].Value = value;
        }

        public float idleTimeMax
        {
            get => (float) Column["idleTimeMax"].Value;

            set => Column["idleTimeMax"].Value = value;
        }

        public int petForm
        {
            get => (int) Column["petForm"].Value;

            set => Column["petForm"].Value = value;
        }

        public float imaginationDrainRate
        {
            get => (float) Column["imaginationDrainRate"].Value;

            set => Column["imaginationDrainRate"].Value = value;
        }

        public string AudioMetaEventSet
        {
            get => (string) Column["AudioMetaEventSet"].Value;

            set => Column["AudioMetaEventSet"].Value = value;
        }

        public string buffIDs
        {
            get => (string) Column["buffIDs"].Value;

            set => Column["buffIDs"].Value = value;
        }
    }
}