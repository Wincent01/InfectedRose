using System.Xml.Serialization;

namespace InfectedRose.Builder.Behaviors.External
{
    [XmlRoot("Skill")]
    public class SkillXml
    {
        [XmlElement] public uint Cost { get; set; }
        
        [XmlElement] public float Cooldown { get; set; }
        
        [XmlElement] public uint CooldownGroup { get; set; }
        
        [XmlElement] public uint Icon { get; set; }
        
        [XmlElement] public BehaviorXml Root { get; set; }
    }
}