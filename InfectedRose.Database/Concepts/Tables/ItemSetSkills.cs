namespace InfectedRose.Database.Concepts.Tables
{
    public class ItemSetSkillsTable

    {
        public ItemSetSkillsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int SkillSetID
        {
            get => (int) Column["SkillSetID"].Value;

            set => Column["SkillSetID"].Value = value;
        }

        public int SkillID
        {
            get => (int) Column["SkillID"].Value;

            set => Column["SkillID"].Value = value;
        }

        public int SkillCastType
        {
            get => (int) Column["SkillCastType"].Value;

            set => Column["SkillCastType"].Value = value;
        }
    }
}