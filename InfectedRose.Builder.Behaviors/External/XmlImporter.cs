using System.IO;
using System.Xml.Serialization;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;

namespace InfectedRose.Builder.Behaviors.External
{
    public static class XmlImporter
    {
        public static uint Import(string file, AccessDatabase database)
        {
            using var stream = File.OpenRead(file);

            var specifications = new XmlSerializer(typeof(SkillXml));

            var details = (SkillXml) specifications.Deserialize(stream);

            var skillTable = database["SkillBehavior"];

            var entry = skillTable.Create();

            var skill = new SkillBehaviorTable(entry);

            skill.imaginationcost = (int) details.Cost;
            
            skill.cooldown = details.Cooldown;

            skill.cooldowngroup = (int) details.CooldownGroup;

            skill.skillIcon = (int) details.Icon;

            skill.behaviorID = (int) ImportBehavior(details.Root, database);

            return (uint) entry.Key;
        }

        private static uint ImportBehavior(BehaviorXml details, AccessDatabase database)
        {
            var behaviorTable = database["BehaviorTemplate"];

            var entry = behaviorTable.Create();

            var behavior = new BehaviorTemplateTable(entry);

            behavior.effectID = (int) details.Effect;

            behavior.templateID = (int) details.Type;

            foreach (var detailsParameter in details.Parameters)
            {
                var parameterTable = database["BehaviorParameter"];

                var parameterEntry = parameterTable.Create(behavior.behaviorID);

                var parameter = new BehaviorParameterTable(parameterEntry);

                parameter.parameterID = detailsParameter.Name;
                
                if (detailsParameter.Behavior)
                {
                    parameter.value = detailsParameter.Next == null ? 0 : ImportBehavior(detailsParameter.Next, database);
                }
                else
                {
                    parameter.value = detailsParameter.Value;
                }
            }

            return (uint) behavior.behaviorID;
        }
    }
}