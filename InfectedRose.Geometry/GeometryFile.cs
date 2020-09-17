using System;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Geometry
{
    public class GeometryFile : IConstruct
    {
        public Mesh Mesh { get; set; }

        public byte[] Header { get; set; } = {49, 48, 71, 66};
        
        public GeometryFlags Flags { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            for (var i = 0; i < 4; i++)
            {
                writer.Write(Header[i]);
            }

            writer.Write((uint) Mesh.Vertices.Length);
            writer.Write((uint) Mesh.Triangles.Length);

            writer.Write((uint) Flags);

            foreach (var vertex in Mesh.Vertices)
            {
                writer.Write(vertex);
            }

            if ((Flags & GeometryFlags.Normals) == GeometryFlags.Normals)
            {
                foreach (var normal in Mesh.Normals)
                {
                    writer.Write(normal);
                }
            }
            
            if ((Flags & GeometryFlags.Uv) == GeometryFlags.Uv)
            {
                foreach (var vector2 in Mesh.Uv)
                {
                    writer.Write(vector2);
                }
            }

            foreach (var triangle in Mesh.Triangles)
            {
                writer.Write((uint) triangle);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Mesh = new Mesh();

            Header = new byte[4];

            for (var i = 0; i < 4; i++)
            {
                Header[i] = reader.Read<byte>();
                
                Console.Write($" [{Header[i]}] ");
            }

            var vertexCount = reader.Read<uint>();
            var indexCount = reader.Read<uint>();
            
            Flags = (GeometryFlags) reader.Read<uint>();

            Mesh.Vertices = new Vector3[vertexCount];

            for (var i = 0; i < vertexCount; i++)
            {
                Mesh.Vertices[i] = reader.Read<Vector3>();
            }

            Mesh.Normals = new Vector3[vertexCount];

            if ((Flags & GeometryFlags.Normals) == GeometryFlags.Normals)
            {
                for (var i = 0; i < vertexCount; i++)
                {
                    Mesh.Normals[i] = reader.Read<Vector3>();
                }
            }

            Mesh.Uv = new Vector2[vertexCount];

            if ((Flags & GeometryFlags.Uv) == GeometryFlags.Uv)
            {
                for (var i = 0; i < vertexCount; i++)
                {
                    Mesh.Uv[i] = reader.Read<Vector2>();
                }
            } else
            {
                for (var i = 0; i < vertexCount; i++)
                {
                    Mesh.Uv[i] = new Vector2(0.0f, 0.0f);
                }
            }

            Mesh.Triangles = new int[indexCount];

            for (var i = 0; i < indexCount; i++)
            {
                Mesh.Triangles[i] = (int) reader.Read<uint>();
            }
            
            // I'm aware there is more stuff to be read with different flags, but the content is unknown. If you 
            // want to add them, be my guest.
        }
    }
}