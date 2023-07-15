using System;

namespace InfectedRose.Interface;

[AttributeUsage(AttributeTargets.Class)]
public class ModTypeAttribute : Attribute
{
    public string Type { get; set; }

    public ModTypeAttribute(string type)
    {
        Type = type;
    }
}