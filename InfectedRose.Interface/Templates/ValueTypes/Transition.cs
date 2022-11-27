using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes
{
    public class Transition
    {
        public class Point
        {
            [JsonPropertyName("scene")]
            public string Scene { get; set; }
            
            [JsonPropertyName("position")]
            public Point3 Position { get; set; }
        }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("points")]
        public Point[] Points { get; set; }
    }
}