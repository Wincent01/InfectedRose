using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class Trigger
    {
        [XmlAttribute("id")] public int Id { get; set; }
        
        [XmlAttribute("enabled")] public int Enabled { get; set; }
        
        [XmlElement("event")] public TriggerEvent[] Events { get; set; }
    }
}