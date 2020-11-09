using System;

namespace InfectedRose.Database
{
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public ColumnAttribute(string value)
        {
            Name = value;
        }
    }
}