using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    [XmlRoot("triggers")]
    public class TriggerCollection
    {
        [JsonPropertyName("triggers")]
        [XmlElement("trigger")] public List<Trigger> Triggers { get; set; }
    }
}