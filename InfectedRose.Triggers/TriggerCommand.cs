using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class TriggerCommand
    {
        [JsonPropertyName("id")]
        [XmlAttribute("id")] public string Id { get; set; }
        
        [JsonPropertyName("target")]
        [XmlAttribute("target")] public string Target { get; set; }
        
        [JsonPropertyName("target-name")]
        [XmlAttribute("targetName")] public string TargetName { get; set; }

        [JsonPropertyName("args")]
        [XmlAttribute("args")] public string Arguments { get; set; }
    }
}