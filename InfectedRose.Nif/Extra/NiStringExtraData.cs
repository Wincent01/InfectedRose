using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiStringExtraData : NiExtraData
    {
        public NiStringRef StringData { get; set; }
        
        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            StringData = reader.Read<NiStringRef>(File);
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(StringData);
        }
    }
}