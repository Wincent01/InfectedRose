using System.Xml.Serialization;

namespace InfectedRose.Builder
{
    [XmlRoot]
    public class ItemReward
    {
        [XmlElement] public int Lot { get; set; } = -1;

        [XmlElement] public int Count { get; set; } = 0;
    }
}