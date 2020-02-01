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

        public byte[] UnknownHeader { get; set; } = {0x20, 0x00, 0x00};

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

        public float[,] GenerateHeightMap()
        {
            var heights = new float[
                ChunkCountX * Chunks[0].HeightMap.Width,
                ChunkCountY * Chunks[0].HeightMap.Height
            ];
            
            for (var chunkY = 0; chunkY < ChunkCountY; ++chunkY)
            {
                for (var chunkX = 0; chunkX < ChunkCountX; ++chunkX)
                {
                    var chunk = Chunks[chunkY * ChunkCountX + chunkX];

                    for (var y = 0; y < chunk.HeightMap.Height; ++y)
                    {
                        for (var x = 0; x < chunk.HeightMap.Width; ++x)
                        {
                            var value = chunk.HeightMap.GetValue(x, y);

                            var pixelX = chunkX * Chunks[0].HeightMap.Width + x;
                            var pixelY = chunkY * Chunks[0].HeightMap.Height + y;

                            heights[pixelX, pixelY] = value;
                        }
                    }
                }
            }

            return heights;
        }
    }
}