using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class TriggerCommand
    {
        [XmlAttribute("id")] public string Id { get; set; }
        
        [XmlAttribute("target")] public string Target { get; set; }
        
        [XmlAttribute("targetName")] public string TargetName { get; set; }

        [XmlAttribute("args")] public string Arguments { get; set; }
    }
}