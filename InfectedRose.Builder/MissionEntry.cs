using System.Xml.Serialization;

namespace InfectedRose.Builder
{
    [XmlRoot]
    public class MissionEntry
    {
        [XmlElement] public int MissionId { get; set; } = 300;

        [XmlElement] public bool Offers { get; set; } = true;

        [XmlElement] public bool Accepting { get; set; } = true;
    }
}