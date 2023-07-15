using System.Drawing;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes;

public struct Color3
{
    [JsonPropertyName("r")]
    public float R { get; set; }
        
    [JsonPropertyName("g")]
    public float G { get; set; }
        
    [JsonPropertyName("b")]
    public float B { get; set; }
}