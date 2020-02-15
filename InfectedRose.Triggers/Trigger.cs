using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class Trigger
    {
        public int FileId { get; set; }
        
        [XmlAttribute("id")] public int Id { get; set; }
        
        [XmlAttribute("enabled")] public int Enabled { get; set; }
        
        [XmlElement("event")] public List<TriggerEvent> Events { get; set; }
    }
}