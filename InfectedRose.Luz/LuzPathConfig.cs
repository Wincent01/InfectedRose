using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzPathConfig : IConstruct
    {
        public string ConfigName { get; set; }
        
        public string ConfigTypeAndValue { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.WriteNiString(ConfigName, true, true);
            writer.WriteNiString(ConfigTypeAndValue, true, true);
        }

        public void Deserialize(BitReader reader)
        {
            ConfigName = reader.ReadNiString(true, true);
            ConfigTypeAndValue = reader.ReadNiString(true, true);
        }
    }
}