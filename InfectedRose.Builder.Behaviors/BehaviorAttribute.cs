using System;

namespace InfectedRose.Builder.Behaviors
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BehaviorAttribute : Attribute
    {
        public Template Template { get; }

        public BehaviorAttribute(Template template)
        {
            Template = template;
        }
    }
}