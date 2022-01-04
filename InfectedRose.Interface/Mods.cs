using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface
{
    public class ModPriority
    {
        [JsonPropertyName("directory")]
        public string Directory { get; set; }
        
        [JsonPropertyName("priority")]
        public int Priority { get; set; }
    }
    
    public class Mods
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = "";

        [JsonPropertyName("database")]
        public string Database { get; set; } = "cdclient.fdb";

        [JsonPropertyName("sqlite")]
        public string Sqlite { get; set; } = "CDServer.sqlite";
        
        [JsonPropertyName("resource-folder")]
        public string ResourceFolder { get; set; }

        [JsonPropertyName("priorities")]
        public List<ModPriority> Priorities { get; set; } = new List<ModPriority>();
    }
}