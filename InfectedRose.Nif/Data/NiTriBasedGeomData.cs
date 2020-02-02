using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiTriBasedGeomData : NiGeometryData
    {
        public ushort TriangleCount { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            TriangleCount = reader.Read<ushort>();
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(TriangleCount);
        }
    }
}