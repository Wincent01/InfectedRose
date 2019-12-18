using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfectedRose.Unity.Map
{
    [XmlRoot("map")]
    public class MapFile
    {
        [XmlElement("settings")] public MapSettings Settings { get; set; }
        
        [XmlElement("scene")] public List<MapScene> Scenes { get; set; }
    }
}