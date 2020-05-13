using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace InfectedRose.Builder.Behaviors.External
{
    public static class XmlExporter
    {
        public static void Export(string file, Skill skill)
        {
            using (var stream = File.Create(file))
            {
                var details = new SkillXml();

                details.Cost = skill.Cost;

                details.Cooldown = skill.Cooldown;

                details.CooldownGroup = skill.CooldownGroup;

                details.Icon = skill.Icon;

                details.Root = ExportBehavior(skill.Root);

                var specifications = new XmlSerializer(typeof(SkillXml));

                specifications.Serialize(stream, details);
            }
        }

        public static BehaviorXml ExportBehavior(BehaviorBase behavior)
        {
            if (behavior == null) return null;

            var details = new BehaviorXml
            {
                Effect = behavior.Effect
            };

            var type = behavior.GetType();
            
            var attribute = type.GetCustomAttribute<BehaviorAttribute>();

            if (attribute == null)
            {
                throw new Exception($"Invalid behavior: {behavior.GetType()}");
            }

            details.Type = (uint) attribute.Template;

            var properties = new List<ParameterXml>();
            
            foreach (var property in type.GetProperties())
            {
                if (property.Name == "Effect") continue;
                
                var info = property.GetCustomAttribute<ParameterAttribute>();

                if (info == null)
                {
                    continue;
                }

                var propertyDetails = new ParameterXml
                {
                    Name = info.Name
                };

                if (property.PropertyType == typeof(BehaviorBase))
                {
                    propertyDetails.Behavior = true;

                    propertyDetails.Next = ExportBehavior(property.GetValue(behavior) as BehaviorBase);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    propertyDetails.Value = (bool) property.GetValue(behavior) ? 1 : 0;
                }
                else
                {
                    propertyDetails.Value = (float) Convert.ChangeType(
                        property.GetValue(behavior) ?? 0f,
                        typeof(float)
                    );
                }

                properties.Add(propertyDetails);
            }

            details.Parameters = properties.ToArray();

            behavior.Export(details);

            return details;
        }
    }
}