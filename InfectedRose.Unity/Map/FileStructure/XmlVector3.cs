using System.Numerics;
using System.Xml.Serialization;

namespace InfectedRose.Unity.Map
{
    public class XmlVector3
    {
        [XmlAttribute("x")] public float X { get; set; }
        
        [XmlAttribute("y")] public float Y { get; set; }
        
        [XmlAttribute("z")] public float Z { get; set; }
        
        public Vector3 Vector3 => new Vector3
        {
            X = X,
            Y = Y,
            Z = Z
        };
    }
}