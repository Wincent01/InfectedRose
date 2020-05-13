using System.Xml.Serialization;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Database.Fdb;

namespace InfectedRose.Builder
{
    [XmlRoot]
    public class Mission
    {
        [XmlIgnore] public AccessDatabase Database { get; set; }
        
        [XmlElement] public int Id { get; set; }
        
        [XmlElement] public string Type { get; set; }
        
        [XmlElement] public string SubType { get; set; }
        
        [XmlElement] public int UiSortOrder { get; set; }
        
        [XmlElement] public int RewardCurrency { get; set; }
        
        [XmlElement] public int RewardScore { get; set; }
        
        [XmlElement] public bool IsMission { get; set; }

        [XmlElement]  public bool ChoiceRewards { get; set; }
        
        [XmlElement("ItemReward")] public ItemReward[] ItemRewards { get; set; } = new ItemReward[4];

        [XmlElement("RepeatItemReward")] public ItemReward[] RepeatItemRewards { get; set; } = new ItemReward[4];

        [XmlElement("EmoteReward")] public int[] EmoteRewards { get; set; } = new int[4];
        
        [XmlElement] public int RewardMaxImagination { get; set; }
        
        [XmlElement] public int RewardMaxHealth { get; set; }
        
        [XmlElement] public int RewardMaxInventory { get; set; }
        
        [XmlElement] public bool Repeatable { get; set; }
        
        [XmlElement] public int RepeatRewardCurrency { get; set; }
        
        [XmlElement] public int MissionIconId { get; set; }

        [XmlElement] public string Prerequisites { get; set; }
        
        [XmlElement] public int OfferObject { get; set; }
        
        [XmlElement] public int TargetObject { get; set; }
        
        [XmlElement] public bool InMotd { get; set; }

        [XmlElement("Task")] public MissionTask[] Tasks { get; set; } = new MissionTask[1];

        public int Build()
        {
            var table = Database["Missions"];

            var row = table.Create(Id);

            var mission = new MissionsTable(row);

            mission.defined_type = Type;
            mission.defined_subtype = SubType;
            mission.UISortOrder = UiSortOrder;
            mission.reward_currency = RewardCurrency;
            mission.LegoScore = RewardScore;
            mission.isMission = IsMission;
            mission.isChoiceReward = ChoiceRewards;
            mission.localize = true;
            mission.reward_maximagination = RewardMaxImagination;
            mission.reward_maxhealth = RewardMaxHealth;
            mission.reward_maxinventory = RewardMaxInventory;
            mission.repeatable = Repeatable;
            mission.reward_currency_repeatable = RepeatRewardCurrency;
            mission.missionIconID = MissionIconId;
            mission.prereqMissionID = Prerequisites;
            mission.offer_objectID = OfferObject;
            mission.target_objectID = TargetObject;
            mission.inMOTD = InMotd;
            mission.gate_version = "freetrial";

            row["time_limit"].Type = DataType.Nothing;

            for (var i = 0; i < 4; i++)
            {
                var item = ItemRewards[i];
                var repeat = RepeatItemRewards[i];
                var emote = EmoteRewards[i];

                row[$"reward_item{i + 1}"].Value = item.Lot;
                row[$"reward_item{i + 1}_count"].Value = item.Count;
                
                row[$"reward_item{i + 1}_repeatable"].Value = repeat.Lot;
                row[$"reward_item{i + 1}_repeat_count"].Value = repeat.Count;

                var id = i == 0 ? "" : $"{i + 1}";

                row[$"reward_emote{id}"].Value = emote;
            }

            foreach (var task in Tasks)
            {
                task.Build(Database, Id);
            }
            
            BuildMissionText();

            return Id;
        }

        private void BuildMissionText()
        {
            var table = Database["MissionText"];

            var row = table.Create(Id);

            var missionText = new MissionTextTable(row);

            missionText.turnInIconID = 4393;

            missionText.localize = true;

            missionText.locStatus = 2;
        }
    }
}