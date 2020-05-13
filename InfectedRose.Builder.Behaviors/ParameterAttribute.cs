using System;

namespace InfectedRose.Builder.Behaviors
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : Attribute
    {
        public string Name { get; }
        
        public ParameterAttribute(string name)
        {
            Name = name;
        }
    }
}