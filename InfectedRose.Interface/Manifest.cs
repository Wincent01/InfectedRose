using System.Text.Json.Serialization;

namespace InfectedRose.Interface;

public class Manifest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "mod-name";

    [JsonPropertyName("files")]
    public string[] Files { get; set; } = {"mod.json"};
        
    [JsonPropertyName("resources")]
    public string Resources { get; set; } = "resources";
}