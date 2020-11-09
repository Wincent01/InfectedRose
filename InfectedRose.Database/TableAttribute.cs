using System;

namespace InfectedRose.Database
{
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }

        public TableAttribute(string value)
        {
            Name = value;
        }
    }
}