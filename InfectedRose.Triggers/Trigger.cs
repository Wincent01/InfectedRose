using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class Trigger
    {
        [JsonIgnore]
        public int FileId { get; set; }
        
        [JsonPropertyName("id")]
        [XmlAttribute("id")] public int Id { get; set; }
        
        [JsonPropertyName("enabled")]
        [XmlAttribute("enabled")] public int Enabled { get; set; }
        
        [JsonPropertyName("events")]
        [XmlElement("event")] public List<TriggerEvent> Events { get; set; }
    }
}