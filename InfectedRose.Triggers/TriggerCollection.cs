using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    [XmlRoot("triggers")]
    public class TriggerCollection
    {
        [XmlElement("trigger")] public Trigger[] Triggers { get; set; }
    }
}