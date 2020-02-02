using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiLODNode : NiSwitchNode
    {
        public NiRef<NiLODData> Data { get; set; }
        
        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            Data = reader.Read<NiRef<NiLODData>>(File);
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(Data);
        }
    }
}