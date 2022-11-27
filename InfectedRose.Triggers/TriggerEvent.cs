using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class TriggerEvent
    {
        [JsonPropertyName("id")]
        [XmlAttribute("id")] public string Id { get; set; }
        
        [JsonPropertyName("commands")]
        [XmlElement("command")] public List<TriggerCommand> Commands { get; set; }
    }
}