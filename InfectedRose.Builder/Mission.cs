using System.Collections.Generic;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Database.Fdb;

namespace InfectedRose.Builder
{
    public class Mission
    {
        internal AccessDatabase Database { get; }
        
        public int Id { get; }
        
        public string Type { get; set; }
        
        public string SubType { get; set; }
        
        public int UiSortOrder { get; set; }
        
        public int RewardCurrency { get; set; }
        
        public int RewardScore { get; set; }
        
        public bool IsMission { get; set; }

        public bool ChoiceRewards { get; set; }
        
        public ItemReward[] ItemRewards { get; set; } = new ItemReward[4];

        public ItemReward[] RepeatItemRewards { get; set; } = new ItemReward[4];

        public int[] EmoteRewards { get; set; } = new int[4];
        
        public int RewardMaxImagination { get; set; }
        
        public int RewardMaxHealth { get; set; }
        
        public int RewardMaxInventory { get; set; }
        
        public bool Repeatable { get; set; }
        
        public int RepeatRewardCurrency { get; set; }
        
        public int MissionIconId { get; set; }

        public string Prerequisites { get; set; }
        
        public int OfferObject { get; set; }
        
        public int TargetObject { get; set; }
        
        public bool InMotd { get; set; }
        
        public List<MissionTask> Tasks { get; set; }

        public Mission(AccessDatabase database)
        {
            Database = database;

            var table = database["Missions"];

            Id = table.ClaimKey(333);

            for (var i = 0; i < 4; i++)
            {
                ItemRewards[i] = new ItemReward
                {
                    Lot = -1,
                    Count = 0
                };
                
                RepeatItemRewards[i] = new ItemReward
                {
                    Lot = -1,
                    Count = 0
                };

                EmoteRewards[i] = -1;
            }
        }

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