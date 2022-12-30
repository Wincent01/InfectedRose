using System;
using System.Linq;
using System.Text;

namespace InfectedRose.Interface.Templates
{
    [ModType("mission")]
    public class MissionMod : ModType
    {
        // Proud of this one :D
        public static void ParsePrerequisites(StringBuilder builder, StringBuilder missionId, string str, int i, Action<string> done)
        {
            if (i >= str.Length)
            {
                done(builder.ToString());
                
                return;
            }
            
            var c = str[i];

            switch (c)
            {
                case '(':
                    break;
                case ')':
                    break;
                case '&' or ',' or ';':
                    break;
                case '|':
                    break;
                case ' ':
                    ParsePrerequisites(builder, missionId, str, i + 1, done);
                    return;
                default:
                    missionId.Append(c);

                    ParsePrerequisites(builder, missionId, str, i + 1, done);
                    return;
            }

            if (missionId.Length == 0)
            {
                builder.Append(c);
                
                ParsePrerequisites(builder, missionId, str, i + 1, done);
                
                return;
            }

            var missionIdString = missionId.ToString();

            if (string.IsNullOrEmpty(missionIdString))
            {
                builder.Append(c);

                ParsePrerequisites(builder, missionId, str, i + 1, done);
                
                return;
            }

            missionIdString = missionIdString.Trim();
            
            // If the string ends with ":2" state is true
            var state = missionIdString.EndsWith(":2");

            // Remove the ":2" from the string
            if (state)
            {
                missionIdString = missionIdString.Substring(0, missionIdString.Length - 2);
            }

            // Get the mission ID
            ModContext.AwaitId(missionIdString, id =>
            {
                builder.Append(id);

                if (state)
                {
                    builder.Append(":2");
                }
                
                missionId.Clear();

                builder.Append(c);
                
                ParsePrerequisites(builder, missionId, str, i + 1, done);
            });
        }
        
        public override void Apply(Mod mod)
        {
            mod.Default("locStatus", 2);
            mod.DefaultNull("UIPrereqID");
            mod.Default("localize", true);
            mod.Default("isMission", false);
            mod.Default("isChoiceReward", false);
            mod.DefaultNull("missionIconID");

            if (mod.HasValue("repeatable") && mod.GetValue<bool>("repeatable"))
            {
                mod.Default("time_limit", 1300);
            }
            else
            {
                mod.DefaultNull("time_limit");
            }
            
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

            var mission = missionsTable.FromLookup(mod);

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
            var missionText = missionTextTable.FromLookup(mod)!;

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
            
            if (mod.HasValue("reward_item1"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item1"), id =>
                {
                    mission["reward_item1"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item2"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item2"), id =>
                {
                    mission["reward_item2"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item3"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item3"), id =>
                {
                    mission["reward_item3"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item4"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item4"), id =>
                {
                    mission["reward_item4"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item1_repeatable"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item1_repeatable"), id =>
                {
                    mission["reward_item1_repeatable"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item2_repeatable"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item2_repeatable"), id =>
                {
                    mission["reward_item2_repeatable"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item3_repeatable"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item3_repeatable"), id =>
                {
                    mission["reward_item3_repeatable"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_item4_repeatable"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_item4_repeatable"), id =>
                {
                    mission["reward_item4_repeatable"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_emote"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_emote"), id =>
                {
                    mission["reward_emote"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_emote2"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_emote2"), id =>
                {
                    mission["reward_emote2"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_emote3"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_emote3"), id =>
                {
                    mission["reward_emote3"].Value = id;
                });
            }
            
            if (mod.HasValue("reward_emote4"))
            {
                ModContext.AwaitId(mod.GetValue<string>("reward_emote4"), id =>
                {
                    mission["reward_emote4"].Value = id;
                });
            }

            if (mod.HasValue("prereqMissionID"))
            {
                var prereqMissionId = mod.GetValue<string>("prereqMissionID");

                var builder = new StringBuilder();
                
                var missionId = new StringBuilder();
                
                ParsePrerequisites(builder, missionId, prereqMissionId, 0, done =>
                {
                    mission["prereqMissionID"].Value = done;
                });
            }
            
            ModContext.RegisterId(mod.Id, mission.Key);

            if (mod.HasValue("icon") && !ModContext.ShouldBeNull(mod.GetValue<string>("icon")))
            {
                var missionIconId = ModContext.AddIcon(mod.GetValue<string>("icon"));
                mission["missionIconID"].Value = missionIconId;
            }
            else if (mod.HasValue("missionIconID") && !ModContext.ShouldBeNull(mod.GetValue<string>("missionIconID")))
            {
                var missionIconId = ModContext.AddIcon(mod.GetValue<string>("missionIconID"));
                mission["missionIconID"].Value = missionIconId;
            }
            else
            {
                mission["missionIconID"].Value = null;
            }
            
            var uid = (int) missionTasksTable.Max(t => t["uid"].Value)!;

            foreach (var task in missionTasksTable.SeekMultiple(mission.Key))
            {
                missionTasksTable.Remove(task);
            }
            
            foreach (var task in mod.Tasks!)
            {
                var missionTask = missionTasksTable.Create(mission.Key)!;

                missionTask["locStatus"].Value = 2;
                missionTask["localize"].Value = true;
                missionTask["taskType"].Value = (int) ModContext.ParseEnum<MissionTaskType>(task.Type);
                missionTask["largeTaskIcon"].Value = null;
                missionTask["targetValue"].Value = task.Count;
                missionTask["uid"].Value = ++uid;
                
                var iconAsset = ModContext.ParseValue(task.Icon, true);
                var iconId = ModContext.AddIcon(iconAsset);
                missionTask["largeTaskIconID"].Value = iconId;
                
                var smallIcon = string.IsNullOrWhiteSpace(task.SmallIcon) ? task.Icon : task.SmallIcon;
                
                var smallIconAsset = ModContext.ParseValue(smallIcon, true);
                var smallIconId = ModContext.AddIcon(smallIconAsset);
                missionTask["IconID"].Value = smallIconId;
                
                foreach (var (locale, text) in task.Locale!)
                {
                    ModContext.AddToLocale($"MissionTasks_{missionTask["uid"].Value}_description", text, locale);
                }
                
                ModContext.AwaitId(task.Target, value => missionTask["target"].Value = value);

                foreach (var groupTarget in task.Group)
                {
                    var value = groupTarget!.AsValue();

                    if (ModContext.IsId(value))
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
                    else
                    {
                        var current = missionTask["targetGroup"].Value?.ToString() ?? "";

                        if (!string.IsNullOrWhiteSpace(current))
                        {
                            current += ",";
                        }

                        current += groupTarget!.AsValue().ToString();

                        missionTask["targetGroup"].Value = current;
                    }
                }

                foreach (var parameter in task.Parameters)
                {
                    // taskParam1
                    
                    var value = parameter!.AsValue();
                    
                    if (ModContext.IsId(value))
                    {
                        ModContext.AwaitId(parameter!.AsValue(), value =>
                        {
                            var current = missionTask["taskParam1"].Value?.ToString() ?? "";

                            if (!string.IsNullOrWhiteSpace(current))
                            {
                                current += ",";
                            }

                            current += value.ToString();

                            missionTask["taskParam1"].Value = current;
                        });
                    }
                    else
                    {
                        var current = missionTask["taskParam1"].Value?.ToString() ?? "";

                        if (!string.IsNullOrWhiteSpace(current))
                        {
                            current += ",";
                        }

                        current += parameter!.AsValue().ToString();

                        missionTask["taskParam1"].Value = current;
                    }
                }
            }
        }
    }
}