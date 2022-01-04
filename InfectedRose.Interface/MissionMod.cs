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
            mod.DefaultNull("missionIconID");
            mod.DefaultNull("time_limit");

            var missionsTable = ModContext.Database["Missions"];
            var missionTasksTable = ModContext.Database["MissionTasks"];

            var mission = missionsTable.Create();

            foreach (var (locale, text) in mod.Locale!)
            {
                ModContext.AddToLocale($"Missions_{mission.Key}_name", text, locale);
            }
            
            ModContext.ApplyValues(mod, mission, missionsTable);
            
            ModContext.RegisterId(mod.Id, mission.Key);

            if (mod.HasValue("icon"))
            {
                var missionIconId = ModContext.AddIcon(mod.GetValue<string>("icon"));
                mission["missionIconID"].Value = missionIconId;
            }
            
            var uid = (int) missionTasksTable.Max(t => t["uid"].Value)!;

            foreach (var task in mod.Tasks!)
            {
                var missionTask = missionTasksTable.Create(mission.Key)!;

                missionTask["locStatus"].Value = 2;
                missionTask["taskType"].Value = (int) ModContext.ParseEnum<MissionTaskType>(task.Type);
                missionTask["taskParam1"].Value = task.Parameters;
                var iconAsset = ModContext.ParseValue(task.Icon);
                var iconId = ModContext.AddIcon(iconAsset);
                missionTask["largeTaskIcon"].Value = iconAsset;
                missionTask["largeTaskIconID"].Value = iconId;
                missionTask["targetValue"].Value = task.Count;
                missionTask["IconID"].Value = iconId;
                missionTask["uid"].Value = ++uid;
                
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