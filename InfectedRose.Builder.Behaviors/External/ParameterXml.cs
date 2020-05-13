using System.Xml.Serialization;

namespace InfectedRose.Builder.Behaviors.External
{
    [XmlRoot("Parameter")]
    public class ParameterXml
    {
        [XmlAttribute("Name")] public string Name { get; set; }
        
        [XmlAttribute("Behavior")] public bool Behavior { get; set; }
        
        [XmlAttribute("Value")] public float Value { get; set; }
        
        [XmlElement("Next")] public BehaviorXml Next { get; set; }
    }
}