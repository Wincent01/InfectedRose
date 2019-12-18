using System.Xml.Serialization;

namespace InfectedRose.Unity.Map
{
    [XmlRoot("object")]
    public class MapObject
    {
        [XmlAttribute("id")] public ulong ObjectId { get; set; }
        
        [XmlAttribute("lot")] public int Lot { get; set; }
        
        [XmlAttribute("type")] public uint AssetType { get; set; }
        
        [XmlElement("position")] public XmlVector3 Position { get; set; }
        
        [XmlElement("rotation")] public XmlQuaternion Rotation { get; set; }
        
        [XmlElement("float")] public float Scale { get; set; }
        
        [XmlElement("settings")] public string Settings { get; set; }
    }
}