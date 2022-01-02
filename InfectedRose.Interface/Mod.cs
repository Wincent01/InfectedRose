using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface
{
    public class Mod
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = "add";

        [JsonPropertyName("components")]
        public string[] Components { get; set; }
        
        [JsonPropertyName("table")]
        public string Table { get; set; }

        [JsonPropertyName("values")]
        public Dictionary<string, object> Values { get; set; } = new Dictionary<string, object>();

        public T GetValue<T>(string id)
        {
            return ((JsonElement) Values[id]).Deserialize<T>()!;
        }

        public int GetComponentType()
        {
            return (int) Enum.Parse(typeof(ComponentId), Type);
        }
    }
}