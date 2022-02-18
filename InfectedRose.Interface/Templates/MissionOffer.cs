using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates
{
    public class MissionOffer
    {
        [JsonPropertyName("mission")]
        public JsonValue Mission { get; set; }
        
        [JsonPropertyName("accept")]
        public bool Accept { get; set; }
        
        [JsonPropertyName("offer")]
        public bool Offer { get; set; }
    }
}