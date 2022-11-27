using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using InfectedRose.Interface.Templates;
using InfectedRose.Interface.Templates.ValueTypes;

namespace InfectedRose.Interface
{
    public class Mod
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";
        
        [JsonPropertyName("explicit-id")]
        public int? ExplicitId { get; set; }

        [JsonPropertyName("old-ids")]
        public string[]? OldIds { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";

        [JsonPropertyName("action")]
        public string Action { get; set; } = "add";
        
        [JsonPropertyName("show-defaults")]
        public bool? ShowDefaults { get; set; }

        [JsonPropertyName("components")]
        public string[]? Components { get; set; }
        
        [JsonPropertyName("table")]
        public string? Table { get; set; }
        
        [JsonPropertyName("items")]
        public JsonValue[]? Items { get; set; }

        [JsonPropertyName("skills")]
        public ObjectSkillEntry[]? Skills { get; set; }
        
        [JsonPropertyName("tasks")]
        public MissionModTask[]? Tasks { get; set; }
        
        [JsonPropertyName("missions")]
        public MissionOffer[]? MissionOffers { get; set; }
        
        [JsonPropertyName("behaviors")]
        public Dictionary<string, Behavior> Behaviors { get; set; }
        
        [JsonPropertyName("zone")]
        public Zone? Zone { get; set; }
        
        [JsonPropertyName("locale")]
        public Dictionary<string, string>? Locale { get; set; } = new Dictionary<string, string>
        {
            {"en_US", ""}
        };
        
        [JsonPropertyName("values")]
        public Dictionary<string, object?> Values { get; set; } = new Dictionary<string, object?>();
        
        [JsonIgnore]
        public Dictionary<string, object?> Defaults { get; set; } = new Dictionary<string, object?>();

        public T GetValue<T>(string id)
        {
            if (Values[id] is JsonElement jsonElement)
            {
                return jsonElement.Deserialize<T>()!;
            }
            
            if (Values[id] is T value)
            {
                return value;
            }

            if (Values[id] is null)
            {
                return default;
            }

            return (T) Convert.ChangeType(Values[id], typeof(T));
        }

        public bool HasValue(string id)
        {
            return Values.ContainsKey(id);
        }

        public void Default<T>(string id, T value)
        {
            Defaults[id] = value;
            
            if (HasValue(id)) return;

            Values[id] = value;
        }

        public void DefaultNull(string id)
        {
            Defaults[id] = null;
            
            if (HasValue(id)) return;

            Values[id] = null;
        }
        
        public int GetComponentType()
        {
            return (int) Enum.Parse(typeof(ComponentId), Type);
        }
    }
}