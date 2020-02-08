using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiGeometryData : NiObject
    {
        public int GroupId { get; set; }

        public byte KeepFlags { get; set; }

        public byte CompressFlags { get; set; }

        public Vector3[] Vertices { get; set; }

        public Vector3[] Normals { get; set; }

        public Vector3 Center { get; set; }

        public float Radius { get; set; }

        public Color4[] VertexColors { get; set; }

        public ushort ConsistencyFlags { get; set; }

        public NiRef<AbstractAdditionalGeometryData> AdditionData { get; set; }

        public ushort NumUvSets { get; set; }

        public Vector2[][] Uv { get; set; }

        public Vector3[] Tangents { get; set; }

        public Vector3[] BitTangents { get; set; }

        public override void Serialize(BitWriter writer)
        {
            var verticesCount = (ushort) Vertices.Length;
            
            writer.Write(GroupId);

            writer.Write(verticesCount);

            writer.Write(KeepFlags);

            writer.Write(CompressFlags);

            writer.Write((byte) (verticesCount > 0 ? 1 : 0));

            foreach (var vertex in Vertices)
            {
                writer.Write(vertex);
            }

            writer.Write(NumUvSets);

            writer.Write((byte) (Normals.Length > 0 ? 1 : 0));

            foreach (var normal in Normals)
            {
                writer.Write(normal);
            }

            if (Normals.Length > 0 & (NumUvSets & 61440) != 0)
            {
                foreach (var tangent in Tangents)
                {
                    writer.Write(tangent);
                }

                foreach (var bitTangent in BitTangents)
                {
                    writer.Write(bitTangent);
                }
            }

            writer.Write(Center);

            writer.Write(Radius);

            writer.Write((byte) (VertexColors.Length > 0 ? 1 : 0));

            foreach (var vertexColor in VertexColors)
            {
                writer.Write(vertexColor);
            }

            foreach (var layer in Uv)
            {
                foreach (var vector2 in layer)
                {
                    writer.Write(vector2);
                }
            }

            writer.Write(ConsistencyFlags);

            writer.Write(AdditionData);
        }

        public override void Deserialize(BitReader reader)
        {
            GroupId = reader.Read<int>();

            var verticesCount = reader.Read<ushort>();

            KeepFlags = reader.Read<byte>();

            CompressFlags = reader.Read<byte>();

            var hasVertices = reader.Read<byte>() != 0;

            if (hasVertices)
            {
                Vertices = new Vector3[verticesCount];

                for (var i = 0; i < Vertices.Length; i++)
                {
                    Vertices[i] = reader.Read<Vector3>();
                }
            }

            NumUvSets = reader.Read<ushort>();
            
            var hasNormals = reader.Read<byte>() != 0;

            if (hasNormals)
            {
                Normals = new Vector3[verticesCount];

                for (var i = 0; i < Normals.Length; i++)
                {
                    Normals[i] = reader.Read<Vector3>();
                }
            }

            if (hasNormals && (NumUvSets & 61440) != 0)
            {
                Tangents = new Vector3[verticesCount];
                for (var i = 0; i < verticesCount; i++)
                {
                    Tangents[i] = reader.Read<Vector3>();
                }
                
                BitTangents = new Vector3[verticesCount];
                for (var i = 0; i < verticesCount; i++)
                {
                    BitTangents[i] = reader.Read<Vector3>();
                }
            }

            Center = reader.Read<Vector3>();

            Radius = reader.Read<float>();
            
            var hasVertexColors = reader.Read<byte>() != 0;

            if (hasVertexColors)
            {
                VertexColors = new Color4[verticesCount];

                for (var i = 0; i < verticesCount; i++)
                {
                    VertexColors[i] = reader.Read<Color4>();
                }
            }
            
            Uv = new Vector2[NumUvSets & 63][];

            for (var i = 0; i < Uv.Length; i++)
            {
                Uv[i] = new Vector2[verticesCount];

                for (var j = 0; j < verticesCount; j++)
                {
                    Uv[i][j] = reader.Read<Vector2>();
                }
            }

            ConsistencyFlags = reader.Read<ushort>();

            AdditionData = reader.Read<NiRef<AbstractAdditionalGeometryData>>(File);
        }
    }
}