namespace InfectedRose.Database.Concepts.Tables
{
    public class MissionsTable

    {
        public MissionsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string defined_type
        {
            get => (string) Column["defined_type"].Value;

            set => Column["defined_type"].Value = value;
        }

        public string defined_subtype
        {
            get => (string) Column["defined_subtype"].Value;

            set => Column["defined_subtype"].Value = value;
        }

        public int UISortOrder
        {
            get => (int) Column["UISortOrder"].Value;

            set => Column["UISortOrder"].Value = value;
        }

        public int offer_objectID
        {
            get => (int) Column["offer_objectID"].Value;

            set => Column["offer_objectID"].Value = value;
        }

        public int target_objectID
        {
            get => (int) Column["target_objectID"].Value;

            set => Column["target_objectID"].Value = value;
        }

        public long reward_currency
        {
            get => (long) Column["reward_currency"].Value;

            set => Column["reward_currency"].Value = value;
        }

        public int LegoScore
        {
            get => (int) Column["LegoScore"].Value;

            set => Column["LegoScore"].Value = value;
        }

        public long reward_reputation
        {
            get => (long) Column["reward_reputation"].Value;

            set => Column["reward_reputation"].Value = value;
        }

        public bool isChoiceReward
        {
            get => (bool) Column["isChoiceReward"].Value;

            set => Column["isChoiceReward"].Value = value;
        }

        public int reward_item1
        {
            get => (int) Column["reward_item1"].Value;

            set => Column["reward_item1"].Value = value;
        }

        public int reward_item1_count
        {
            get => (int) Column["reward_item1_count"].Value;

            set => Column["reward_item1_count"].Value = value;
        }

        public int reward_item2
        {
            get => (int) Column["reward_item2"].Value;

            set => Column["reward_item2"].Value = value;
        }

        public int reward_item2_count
        {
            get => (int) Column["reward_item2_count"].Value;

            set => Column["reward_item2_count"].Value = value;
        }

        public int reward_item3
        {
            get => (int) Column["reward_item3"].Value;

            set => Column["reward_item3"].Value = value;
        }

        public int reward_item3_count
        {
            get => (int) Column["reward_item3_count"].Value;

            set => Column["reward_item3_count"].Value = value;
        }

        public int reward_item4
        {
            get => (int) Column["reward_item4"].Value;

            set => Column["reward_item4"].Value = value;
        }

        public int reward_item4_count
        {
            get => (int) Column["reward_item4_count"].Value;

            set => Column["reward_item4_count"].Value = value;
        }

        public int reward_emote
        {
            get => (int) Column["reward_emote"].Value;

            set => Column["reward_emote"].Value = value;
        }

        public int reward_emote2
        {
            get => (int) Column["reward_emote2"].Value;

            set => Column["reward_emote2"].Value = value;
        }

        public int reward_emote3
        {
            get => (int) Column["reward_emote3"].Value;

            set => Column["reward_emote3"].Value = value;
        }

        public int reward_emote4
        {
            get => (int) Column["reward_emote4"].Value;

            set => Column["reward_emote4"].Value = value;
        }

        public int reward_maximagination
        {
            get => (int) Column["reward_maximagination"].Value;

            set => Column["reward_maximagination"].Value = value;
        }

        public int reward_maxhealth
        {
            get => (int) Column["reward_maxhealth"].Value;

            set => Column["reward_maxhealth"].Value = value;
        }

        public int reward_maxinventory
        {
            get => (int) Column["reward_maxinventory"].Value;

            set => Column["reward_maxinventory"].Value = value;
        }

        public int reward_maxmodel
        {
            get => (int) Column["reward_maxmodel"].Value;

            set => Column["reward_maxmodel"].Value = value;
        }

        public int reward_maxwidget
        {
            get => (int) Column["reward_maxwidget"].Value;

            set => Column["reward_maxwidget"].Value = value;
        }

        public long reward_maxwallet
        {
            get => (long) Column["reward_maxwallet"].Value;

            set => Column["reward_maxwallet"].Value = value;
        }

        public bool repeatable
        {
            get => (bool) Column["repeatable"].Value;

            set => Column["repeatable"].Value = value;
        }

        public long reward_currency_repeatable
        {
            get => (long) Column["reward_currency_repeatable"].Value;

            set => Column["reward_currency_repeatable"].Value = value;
        }

        public int reward_item1_repeatable
        {
            get => (int) Column["reward_item1_repeatable"].Value;

            set => Column["reward_item1_repeatable"].Value = value;
        }

        public int reward_item1_repeat_count
        {
            get => (int) Column["reward_item1_repeat_count"].Value;

            set => Column["reward_item1_repeat_count"].Value = value;
        }

        public int reward_item2_repeatable
        {
            get => (int) Column["reward_item2_repeatable"].Value;

            set => Column["reward_item2_repeatable"].Value = value;
        }

        public int reward_item2_repeat_count
        {
            get => (int) Column["reward_item2_repeat_count"].Value;

            set => Column["reward_item2_repeat_count"].Value = value;
        }

        public int reward_item3_repeatable
        {
            get => (int) Column["reward_item3_repeatable"].Value;

            set => Column["reward_item3_repeatable"].Value = value;
        }

        public int reward_item3_repeat_count
        {
            get => (int) Column["reward_item3_repeat_count"].Value;

            set => Column["reward_item3_repeat_count"].Value = value;
        }

        public int reward_item4_repeatable
        {
            get => (int) Column["reward_item4_repeatable"].Value;

            set => Column["reward_item4_repeatable"].Value = value;
        }

        public int reward_item4_repeat_count
        {
            get => (int) Column["reward_item4_repeat_count"].Value;

            set => Column["reward_item4_repeat_count"].Value = value;
        }

        public int time_limit
        {
            get => (int) Column["time_limit"].Value;

            set => Column["time_limit"].Value = value;
        }

        public bool isMission
        {
            get => (bool) Column["isMission"].Value;

            set => Column["isMission"].Value = value;
        }

        public int missionIconID
        {
            get => (int) Column["missionIconID"].Value;

            set => Column["missionIconID"].Value = value;
        }

        public string prereqMissionID
        {
            get => (string) Column["prereqMissionID"].Value;

            set => Column["prereqMissionID"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public bool inMOTD
        {
            get => (bool) Column["inMOTD"].Value;

            set => Column["inMOTD"].Value = value;
        }

        public long cooldownTime
        {
            get => (long) Column["cooldownTime"].Value;

            set => Column["cooldownTime"].Value = value;
        }

        public bool isRandom
        {
            get => (bool) Column["isRandom"].Value;

            set => Column["isRandom"].Value = value;
        }

        public string randomPool
        {
            get => (string) Column["randomPool"].Value;

            set => Column["randomPool"].Value = value;
        }

        public int UIPrereqID
        {
            get => (int) Column["UIPrereqID"].Value;

            set => Column["UIPrereqID"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public string HUDStates
        {
            get => (string) Column["HUDStates"].Value;

            set => Column["HUDStates"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public int reward_bankinventory
        {
            get => (int) Column["reward_bankinventory"].Value;

            set => Column["reward_bankinventory"].Value = value;
        }
    }
}