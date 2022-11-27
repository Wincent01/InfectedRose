using System.Numerics;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes
{
    public struct Point4
    {
        [JsonPropertyName("x")]
        public float X { get; set; }
        
        [JsonPropertyName("y")]
        public float Y { get; set; }
        
        [JsonPropertyName("z")]
        public float Z { get; set; }
        
        [JsonPropertyName("w")]
        public float W { get; set; }
        
        // Implicit conversion from Point4 to Quaternion
        public static implicit operator Quaternion(Point4 point)
        {
            return new Quaternion(point.X, point.Y, point.Z, point.W);
        }
    }
}