using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiSwitchNode : NiNode
    {
        public ushort SwitchFlags { get; set; }
        
        public int Index { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            SwitchFlags = reader.Read<ushort>();

            Index = reader.Read<int>();
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(SwitchFlags);

            writer.Write(Index);
        }
    }
}