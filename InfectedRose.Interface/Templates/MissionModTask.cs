using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates;

public class MissionModTask
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
        
    [JsonPropertyName("target")]
    public JsonValue Target { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
        
    [JsonPropertyName("group")]
    public JsonArray Group { get; set; }
        
    [JsonPropertyName("location")]
    public string Location { get; set; }
        
    [JsonPropertyName("parameters")]
    public JsonArray Parameters { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
        
    [JsonPropertyName("small-icon")]
    public string SmallIcon { get; set; }
        
    [JsonPropertyName("locale")]
    public Dictionary<string, string>? Locale { get; set; } = new Dictionary<string, string>
    {
        {"en_US", ""}
    };
}