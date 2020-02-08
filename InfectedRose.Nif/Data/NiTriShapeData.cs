using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiTriShapeData : NiTriBasedGeomData
    {
        public Triangle[] Triangles { get; set; }
        
        public MatchGroup[] Groups { get; set; }
        
        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            var points = reader.Read<uint>();

            Triangles = new Triangle[TriangleCount];

            for (var i = 0; i < TriangleCount; i++)
            {
                Triangles[i] = reader.Read<Triangle>();
            }

            Groups = new MatchGroup[reader.Read<ushort>()];

            for (var i = 0; i < Groups.Length; i++)
            {
                Groups[i] = reader.Read<MatchGroup>();
            }
        }

        public override void Serialize(BitWriter writer)
        {
            TriangleCount = (ushort) Triangles.Length;
            
            base.Serialize(writer);

            writer.Write((uint) (TriangleCount * 3));

            foreach (var triangle in Triangles)
            {
                writer.Write(triangle);
            }

            writer.Write((ushort) Groups.Length);

            foreach (var group in Groups)
            {
                writer.Write(group);
            }
        }
    }
}