using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes;

public class LevelTemplate
{
    [JsonPropertyName("id")]
    public JsonValue Id { get; set; }

    [JsonPropertyName("type")]
    public int? Type { get; set; }
        
    [JsonPropertyName("object-id")]
    public ulong? ObjectId { get; set; }
        
    [JsonPropertyName("position")]
    public Point3 Position { get; set; }
        
    [JsonPropertyName("rotation")]
    public Point4 Rotation { get; set; }
        
    [JsonPropertyName("scale")]
    public float? Scale { get; set; }
        
    [JsonPropertyName("data")]
    public DataDictionary Data { get; set; }
}