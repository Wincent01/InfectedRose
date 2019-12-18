using System.Numerics;
using System.Xml.Serialization;

namespace InfectedRose.Unity.Map
{
    public class XmlQuaternion
    {
        [XmlAttribute("x")] public float X { get; set; }
        
        [XmlAttribute("y")] public float Y { get; set; }
        
        [XmlAttribute("z")] public float Z { get; set; }
        
        [XmlAttribute("w")] public float W { get; set; }
        
        public Quaternion Quaternion => new Quaternion
        {
            X = X,
            Y = Y,
            Z = Z,
            W = W
        };
    }
}