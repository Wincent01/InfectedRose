using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InfectedRose.Builder.Behaviors
{
    internal static class BehaviorRegistry
    {
        private static Dictionary<Template, Type> Types { get; set; }

        public static BehaviorBase InquireBehavior(Template template)
        {
            if (Types == default)
            {
                var assembly = Assembly.GetExecutingAssembly();

                var baseType = typeof(BehaviorBase);

                Types = new Dictionary<Template, Type>();

                foreach (var entry in assembly.GetTypes().Where(t => t.BaseType == baseType))
                {
                    var attribute = entry.GetCustomAttribute<BehaviorAttribute>();
                    
                    if (attribute == null) continue;

                    Types[attribute.Template] = entry;
                }
            }

            if (!Types.TryGetValue(template, out var type))
            {
                throw new Exception($"Unsupported behavior template: {template}!");
            }

            return Activator.CreateInstance(type) as BehaviorBase;
        }
    }
}