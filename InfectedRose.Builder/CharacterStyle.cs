using System.Xml.Serialization;

namespace InfectedRose.Builder
{
    [XmlRoot]
    public class CharacterStyle
    {
        [XmlElement] public int Chest { get; set; } = 0;
        [XmlElement] public int ChestDecal { get; set; } = 0;
        [XmlElement] public int EyeBrowStyle { get; set; } = 0;
        [XmlElement] public int EyesStyle { get; set; } = 0;
        [XmlElement] public int HairColor { get; set; } = 0;
        [XmlElement] public int HairStyle { get; set; } = 0;
        [XmlElement] public int Head { get; set; } = 0;
        [XmlElement] public int HeadColor { get; set; } = 0;
        [XmlElement] public int LeftHand { get; set; } = 0;
        [XmlElement] public int Legs { get; set; } = 0;
        [XmlElement] public int MouthStyle { get; set; } = 0;
        [XmlElement] public int RightHand { get; set; } = 0;
    }
}