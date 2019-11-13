using System.Collections.Generic;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class TerrainFile : IConstruct
    {
        public List<Chunk> Chunks;

        public int ChunkTotalCount { get; set; }

        public int ChunkCountX { get; set; }

        public int ChunkCountY { get; set; }
        
        public byte[] UnknownHeader { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(UnknownHeader);

            writer.Write(ChunkTotalCount);
            writer.Write(ChunkCountX);
            writer.Write(ChunkCountY);

            foreach (var chunk in Chunks)
            {
                chunk.Serialize(writer);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Chunks = new List<Chunk>();

            UnknownHeader = reader.ReadBuffer(3);
            
            ChunkTotalCount = reader.Read<int>();
            ChunkCountX = reader.Read<int>();
            ChunkCountY = reader.Read<int>();

            for (var i = 0; i < ChunkTotalCount; i++)
            {
                var chunk = new Chunk();
                chunk.Deserialize(reader);
                
                Chunks.Add(chunk);
            }
        }
    }
}