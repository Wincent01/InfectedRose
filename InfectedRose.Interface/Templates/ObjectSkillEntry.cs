using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates
{
    public class ObjectSkillEntry
    {
        [JsonPropertyName("skill-id")]
        public JsonValue SkillId { get; set; }
        
        [JsonPropertyName("cast-on-type")]
        public int CastOnType { get; set; }
        
        [JsonPropertyName("combat-ai-weight")]
        public int CombatAiWeight { get; set; }
    }
}