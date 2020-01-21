namespace InfectedRose.Database.Concepts.Tables
{
    public class BaseCombatAIComponentTable

    {
        public BaseCombatAIComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int behaviorType
        {
            get => (int) Column["behaviorType"].Value;

            set => Column["behaviorType"].Value = value;
        }

        public float combatRoundLength
        {
            get => (float) Column["combatRoundLength"].Value;

            set => Column["combatRoundLength"].Value = value;
        }

        public int combatRole
        {
            get => (int) Column["combatRole"].Value;

            set => Column["combatRole"].Value = value;
        }

        public float minRoundLength
        {
            get => (float) Column["minRoundLength"].Value;

            set => Column["minRoundLength"].Value = value;
        }

        public float maxRoundLength
        {
            get => (float) Column["maxRoundLength"].Value;

            set => Column["maxRoundLength"].Value = value;
        }

        public float tetherSpeed
        {
            get => (float) Column["tetherSpeed"].Value;

            set => Column["tetherSpeed"].Value = value;
        }

        public float pursuitSpeed
        {
            get => (float) Column["pursuitSpeed"].Value;

            set => Column["pursuitSpeed"].Value = value;
        }

        public float combatStartDelay
        {
            get => (float) Column["combatStartDelay"].Value;

            set => Column["combatStartDelay"].Value = value;
        }

        public float softTetherRadius
        {
            get => (float) Column["softTetherRadius"].Value;

            set => Column["softTetherRadius"].Value = value;
        }

        public float hardTetherRadius
        {
            get => (float) Column["hardTetherRadius"].Value;

            set => Column["hardTetherRadius"].Value = value;
        }

        public float spawnTimer
        {
            get => (float) Column["spawnTimer"].Value;

            set => Column["spawnTimer"].Value = value;
        }

        public int tetherEffectID
        {
            get => (int) Column["tetherEffectID"].Value;

            set => Column["tetherEffectID"].Value = value;
        }

        public bool ignoreMediator
        {
            get => (bool) Column["ignoreMediator"].Value;

            set => Column["ignoreMediator"].Value = value;
        }

        public float aggroRadius
        {
            get => (float) Column["aggroRadius"].Value;

            set => Column["aggroRadius"].Value = value;
        }

        public bool ignoreStatReset
        {
            get => (bool) Column["ignoreStatReset"].Value;

            set => Column["ignoreStatReset"].Value = value;
        }

        public bool ignoreParent
        {
            get => (bool) Column["ignoreParent"].Value;

            set => Column["ignoreParent"].Value = value;
        }
    }
}