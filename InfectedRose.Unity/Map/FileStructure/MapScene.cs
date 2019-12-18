using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfectedRose.Unity.Map
{
    [XmlRoot("scene")]
    public class MapScene
    {
        [XmlAttribute("name")] public string Name { get; set; }
        
        [XmlAttribute("layer")] public uint Layer { get; set; }
        
        [XmlElement("object")] public List<MapObject> Objects { get; set; }
    }
}