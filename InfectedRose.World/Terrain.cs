using System.Xml.Serialization;

namespace InfectedRose.World
{
    [XmlRoot]
    public class Terrain
    {
        [XmlElement] public string FileName { get; set; } = "terrain.raw";

        [XmlElement] public string Name { get; set; } = "terrain";

        [XmlElement] public string Description { get; set; } = "terrain file";
    }
}