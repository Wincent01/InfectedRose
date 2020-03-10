using System.Drawing;
using System.Numerics;
using System.Xml.Serialization;

namespace InfectedRose.World
{
    [XmlRoot("Color")]
    public class TerrainColor
    {
        [XmlElement] public float Size { get; set; }
        
        [XmlElement] public Color Color { get; set; }
        
        [XmlElement] public Vector2 Position { get; set; }
    }
}