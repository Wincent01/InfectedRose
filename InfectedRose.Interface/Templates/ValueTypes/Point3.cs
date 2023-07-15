using System.Numerics;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes;

public struct Point3
{
    [JsonPropertyName("x")]
    public float X { get; set; }
        
    [JsonPropertyName("y")]
    public float Y { get; set; }
        
    [JsonPropertyName("z")]
    public float Z { get; set; }
        
    // Implicit conversion from Point3 to Vector3
    public static implicit operator Vector3(Point3 point)
    {
        return new Vector3(point.X, point.Y, point.Z);
    }
}