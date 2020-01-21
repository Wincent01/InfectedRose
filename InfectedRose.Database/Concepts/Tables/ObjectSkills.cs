namespace InfectedRose.Database.Concepts.Tables
{
    public class ObjectSkillsTable

    {
        public ObjectSkillsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int objectTemplate
        {
            get => (int) Column["objectTemplate"].Value;

            set => Column["objectTemplate"].Value = value;
        }

        public int skillID
        {
            get => (int) Column["skillID"].Value;

            set => Column["skillID"].Value = value;
        }

        public int castOnType
        {
            get => (int) Column["castOnType"].Value;

            set => Column["castOnType"].Value = value;
        }

        public int AICombatWeight
        {
            get => (int) Column["AICombatWeight"].Value;

            set => Column["AICombatWeight"].Value = value;
        }
    }
}