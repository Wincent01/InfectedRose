using System;
using System.Collections.Generic;
using System.Drawing;
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
            var weight = Chunks[0].HeightMap.Width;
            var height = Chunks[0].HeightMap.Height;
            
            var heights = new float[
                ChunkCountX * weight,
                ChunkCountY * height
            ];

            var map = new Bitmap(ChunkCountX * weight, ChunkCountY * height);

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

                            var pixelX = chunkX * weight + x;
                            var pixelY = chunkY * height + y;

                            heights[pixelX, pixelY] = value;
                            
                            var bytes = BitConverter.GetBytes(value);

                            map.SetPixel(pixelX, pixelY, Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]));
                        }
                    }
                }
            }

            map.RotateFlip(RotateFlipType.Rotate90FlipX);

            for (var x = 0; x < map.Width; x++)
            {
                for (var y = 0; y < map.Height; y++)
                {
                    var color = map.GetPixel(x, y);
                    
                    var bytes = new[]
                    {
                        color.A,
                        color.R,
                        color.G,
                        color.B
                    };

                    heights[x, y] = BitConverter.ToSingle(bytes);
                }
            }
            
            return heights;
        }
    }
}