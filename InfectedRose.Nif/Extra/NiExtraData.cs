using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiExtraData : NiObject
    {
        public NiStringRef Name { get; set; }
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(Name);
        }

        public override void Deserialize(BitReader reader)
        {
            Name = reader.Read<NiStringRef>(File);
        }
    }
}