using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    [XmlRoot("triggers")]
    public class TriggerCollection
    {
        [XmlElement("trigger")] public List<Trigger> Triggers { get; set; }
    }
}