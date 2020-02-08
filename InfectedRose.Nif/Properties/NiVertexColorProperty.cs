using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiVertexColorProperty : NiProperty
    {
        public ushort Flags { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            Flags = reader.Read<ushort>();
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(Flags);
        }
    }
}