using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class TriggerEvent
    {
        [XmlAttribute("id")] public string Id { get; set; }
        
        [XmlElement("command")] public TriggerCommand[] Commands { get; set; }
    }
}