using System.Linq;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface
{
    [ModType("mission")]
    public class MissionMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }
            
            mod.Default("locStatus", 2);
            mod.DefaultNull("UIPrereqID");
            mod.Default("localize", true);
            mod.Default("isMission", true);
            mod.Default("isChoiceReward", false);
            mod.DefaultNull("missionIconID");
            mod.DefaultNull("time_limit");
            mod.Default("reward_item1", -1);
            mod.Default("reward_item2", -1);
            mod.Default("reward_item3", -1);
            mod.Default("reward_item4", -1);
            mod.Default("reward_item1_repeatable", -1);
            mod.Default("reward_item2_repeatable", -1);
            mod.Default("reward_item3_repeatable", -1);
            mod.Default("reward_item4_repeatable", -1);
            mod.Default("reward_emote", -1);
            mod.Default("reward_emote2", -1);
            mod.Default("reward_emote3", -1);
            mod.Default("reward_emote4", -1);
            mod.Default("reward_maxwallet", 0);
            mod.Default("reward_reputation", 0);
            mod.Default("reward_currency_repeatable", 0);

            var missionsTable = ModContext.Database["Missions"];
            var missionTasksTable = ModContext.Database["MissionTasks"];

            var mission = missionsTable.Create();

            foreach (var (locale, text) in mod.Locale!)
            {
                ModContext.AddToLocale($"Missions_{mission.Key}_name", text, locale);
            }
            
            ModContext.AddToLocale($"MissionText_{mission.Key}_accept_chat_bubble", "accept_chat_bubble", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_accept_chat_bubble", "chat_accept", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_1", "chat_state_1", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_2", "chat_state_2", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_3", "chat_state_3", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_4", "chat_state_4", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_1", "chat_available", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_2", "chat_active", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_3", "chat_ready_to_complete", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_chat_state_4", "chat_complete", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_completion_succeed_tip", "completion_succeed_tip", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_in_progress", "in_progress", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_offer", "offer", mod);
            ModContext.AddToLocale($"MissionText_{mission.Key}_ready_to_complete", "ready_to_complete", mod);

            var missionTextTable = ModContext.Database["MissionText"];
            var missionText = missionTextTable.Create(mission.Key)!;

            missionText["localize"].Value = true;
            missionText["locStatus"].Value = 2;
            missionText["IconID"].Value = null;
            if (mod.HasValue("icon-turn-in"))
            {
                var turnInIconAsset = ModContext.ParseValue(mod.GetValue<string>("icon-turn-in"), true);
                var turnInIconId = ModContext.AddIcon(turnInIconAsset);
                missionText["turnInIconID"].Value = turnInIconId;
            }
            else
            {
                missionText["turnInIconID"].Value = null;
            }
            
            ModContext.ApplyValues(mod, mission, missionsTable);
            
            ModContext.RegisterId(mod.Id, mission.Key);

            if (mod.HasValue("icon"))
            {
                var missionIconId = ModContext.AddIcon(mod.GetValue<string>("icon"));
                mission["missionIconID"].Value = missionIconId;
            }
            else
            {
                mission["missionIconID"].Value = null;
            }
            
            var uid = (int) missionTasksTable.Max(t => t["uid"].Value)!;

            foreach (var task in mod.Tasks!)
            {
                var missionTask = missionTasksTable.Create(mission.Key)!;

                missionTask["locStatus"].Value = 2;
                missionTask["localize"].Value = true;
                missionTask["taskType"].Value = (int) ModContext.ParseEnum<MissionTaskType>(task.Type);
                missionTask["taskParam1"].Value = task.Parameters;
                missionTask["largeTaskIcon"].Value = null;
                missionTask["targetValue"].Value = task.Count;
                missionTask["uid"].Value = ++uid;
                
                var iconAsset = ModContext.ParseValue(task.Icon, true);
                var iconId = ModContext.AddIcon(iconAsset);
                missionTask["largeTaskIconID"].Value = iconId;
                
                var smallIconAsset = ModContext.ParseValue(task.SmallIcon, true);
                var smallIconId = ModContext.AddIcon(smallIconAsset);
                missionTask["IconID"].Value = smallIconId;
                
                foreach (var (locale, text) in task.Locale!)
                {
                    ModContext.AddToLocale($"MissionTasks_{missionTask["uid"].Value}_description", text, locale);
                }
                
                ModContext.AwaitId(task.Target, value => missionTask["target"].Value = value);

                if (!string.IsNullOrWhiteSpace(task.Location))
                {
                    missionTask["targetGroup"].Value = task.Location;
                }
                else
                {
                    foreach (var groupTarget in task.Group)
                    {
                        ModContext.AwaitId(groupTarget!.AsValue(), value =>
                        {
                            var current = missionTask["targetGroup"].Value?.ToString() ?? "";

                            if (!string.IsNullOrWhiteSpace(current))
                            {
                                current += ",";
                            }

                            current += value.ToString();

                            missionTask["targetGroup"].Value = current;
                        });
                    }
                }
            }
        }
    }
}