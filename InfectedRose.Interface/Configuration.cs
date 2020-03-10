using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfectedRose.Interface
{
    [XmlRoot("Config")]
    public class Configuration
    {
        [XmlElement("CDClient")] public string CdClient { get; set; } = "cdclient.fdb";

        [XmlElement("Output")] public string Output { get; set; } = "/res";

        [XmlElement("SqlOutput")] public string SqlOutput { get; set; } = "output.sql";

        [XmlElement("Zone")] public List<string> Zones { get; set; } = new List<string>();
        
        [XmlElement("Npc")] public List<string> Npcs { get; set; } = new List<string>();
        
        [XmlElement("Mission")] public List<string> Mission { get; set; } = new List<string>();
        
        [XmlElement("Update")] public List<string> Updates { get; set; } = new List<string>();
        
        [XmlElement("Insert")] public List<string> Insert { get; set; } = new List<string>();
    }
}