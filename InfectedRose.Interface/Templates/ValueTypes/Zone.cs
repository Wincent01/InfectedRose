using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes
{
    public class Zone
    {
        [JsonPropertyName("spawn-point")]
        public Point3 SpawnPoint { get; set; }
        
        [JsonPropertyName("spawn-rotation")]
        public Point4 SpawnRotation { get; set; }
        
        [JsonPropertyName("terrain-file")]
        public string TerrainFile { get; set; }
        
        [JsonPropertyName("scenes")]
        public Scene[] Scenes { get; set; }
        
        [JsonPropertyName("transitions")]
        public Transition[] Transitions { get; set; }
        
        [JsonPropertyName("paths")]
        public PathData[] Paths { get; set; }
    }
}