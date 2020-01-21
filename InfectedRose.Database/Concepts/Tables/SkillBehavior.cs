namespace InfectedRose.Database.Concepts.Tables
{
    public class SkillBehaviorTable

    {
        public SkillBehaviorTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int skillID
        {
            get => (int) Column["skillID"].Value;

            set => Column["skillID"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public int behaviorID
        {
            get => (int) Column["behaviorID"].Value;

            set => Column["behaviorID"].Value = value;
        }

        public int imaginationcost
        {
            get => (int) Column["imaginationcost"].Value;

            set => Column["imaginationcost"].Value = value;
        }

        public int cooldowngroup
        {
            get => (int) Column["cooldowngroup"].Value;

            set => Column["cooldowngroup"].Value = value;
        }

        public float cooldown
        {
            get => (float) Column["cooldown"].Value;

            set => Column["cooldown"].Value = value;
        }

        public bool inNpcEditor
        {
            get => (bool) Column["inNpcEditor"].Value;

            set => Column["inNpcEditor"].Value = value;
        }

        public int skillIcon
        {
            get => (int) Column["skillIcon"].Value;

            set => Column["skillIcon"].Value = value;
        }

        public string oomSkillID
        {
            get => (string) Column["oomSkillID"].Value;

            set => Column["oomSkillID"].Value = value;
        }

        public int oomBehaviorEffectID
        {
            get => (int) Column["oomBehaviorEffectID"].Value;

            set => Column["oomBehaviorEffectID"].Value = value;
        }

        public int castTypeDesc
        {
            get => (int) Column["castTypeDesc"].Value;

            set => Column["castTypeDesc"].Value = value;
        }

        public int imBonusUI
        {
            get => (int) Column["imBonusUI"].Value;

            set => Column["imBonusUI"].Value = value;
        }

        public int lifeBonusUI
        {
            get => (int) Column["lifeBonusUI"].Value;

            set => Column["lifeBonusUI"].Value = value;
        }

        public int armorBonusUI
        {
            get => (int) Column["armorBonusUI"].Value;

            set => Column["armorBonusUI"].Value = value;
        }

        public int damageUI
        {
            get => (int) Column["damageUI"].Value;

            set => Column["damageUI"].Value = value;
        }

        public bool hideIcon
        {
            get => (bool) Column["hideIcon"].Value;

            set => Column["hideIcon"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public int cancelType
        {
            get => (int) Column["cancelType"].Value;

            set => Column["cancelType"].Value = value;
        }
    }
}