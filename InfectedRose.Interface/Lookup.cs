using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface
{
    public class Lookup
    {
        [JsonPropertyName("ids")]
        public Dictionary<string, int> Ids { get; set; }
    }
}