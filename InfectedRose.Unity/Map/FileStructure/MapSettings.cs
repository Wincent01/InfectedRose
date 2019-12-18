using System.Xml.Serialization;

namespace InfectedRose.Unity.Map
{
    [XmlRoot("settings")]
    public class MapSettings
    {
        [XmlElement("name")] public string Name { get; set; }
        
        [XmlElement("zone_id")] public uint ZoneId { get; set; }
        
        [XmlElement("revision")] public uint Revision { get; set; }
        
        [XmlElement("spawn_pos")] public XmlVector3 SpawnPoint { get; set; }
        
        [XmlElement("spawn_rot")] public XmlQuaternion SpawnRotation { get; set; }
    }
}