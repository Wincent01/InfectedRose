using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes
{
    public class Particle
    {
        [JsonPropertyName("position")]
        public Point3 Position { get; set; }
        
        [JsonPropertyName("rotation")]
        public Point4 Rotation { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}