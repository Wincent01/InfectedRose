using System.Numerics;
using System.Xml.Serialization;

namespace InfectedRose.World
{
    [XmlRoot("Height")]
    public class TerrainHeight
    {
        [XmlElement] public float Size { get; set; }
        
        [XmlElement] public float Power { get; set; }
        
        [XmlElement] public Vector2 Position { get; set; }
    }
}