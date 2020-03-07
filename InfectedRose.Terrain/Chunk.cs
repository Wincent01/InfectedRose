using System.Collections.Generic;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class Chunk : IConstruct
    {
        public int Index { get; set; }
        
        public HeightMap HeightMap { get; set; }
        
        public ColorMap Colormap0 { get; set; }
        
        public TerrainDirectDraw Lightmap { get; set; }
        
        public ColorMap Colormap1 { get; set; }

        public byte TextureSetting { get; set; } = 0x1;
        
        public TerrainDirectDraw Blendmap { get; set; }
        
        public List<Foliage> Foliage { get; set; }
        
        public byte[] ColorRelatedArray { get; set; }
        
        public ShortMap ShortMap { get; set; }
        
        public short[][] UnknownShortArray { get; set; }

        public byte[] UnknownByteArray1 { get; set; } = new byte[32];

        public void Serialize(BitWriter writer)
        {
            writer.Write(Index);

            HeightMap.Serialize(writer);

            Colormap0.Serialize(writer);

            Lightmap.Serialize(writer);

            Colormap1.Serialize(writer);

            writer.Write(TextureSetting);
            
            Blendmap.Serialize(writer);

            writer.Write(Foliage.Count);

            foreach (var foliage in Foliage)
            {
                foliage.Serialize(writer);
            }

            foreach (var unknownByte in ColorRelatedArray)
            {
                writer.Write(unknownByte);
            }

            ShortMap.Serialize(writer);
            
            if (ShortMap.Data.Length == default) return;

            for (var i = 0; i < 32; i++)
            {
                writer.Write(UnknownByteArray1[i]);
            }

            for (var i = 0; i < 16; i++)
            {
                writer.Write((short) UnknownShortArray[i].Length);

                for (var j = 0; j < UnknownShortArray[i].Length; j++)
                {
                    writer.Write(UnknownShortArray[i][j]);
                }
            }
        }

        public void Deserialize(BitReader reader)
        {
            Index = reader.Read<int>();

            HeightMap = new HeightMap();
            HeightMap.Deserialize(reader);
            
            Colormap0 = new ColorMap();
            Colormap0.Deserialize(reader);
            
            Lightmap = new TerrainDirectDraw();
            Lightmap.Deserialize(reader);
            
            Colormap1 = new ColorMap();
            Colormap1.Deserialize(reader);

            TextureSetting = reader.Read<byte>();
            
            Blendmap = new TerrainDirectDraw();
            Blendmap.Deserialize(reader);

            var foliageCount = reader.Read<int>();
            
            Foliage = new List<Foliage>();

            for (var i = 0; i < foliageCount; i++)
            {
                var foliage = new Foliage();
                foliage.Deserialize(reader);

                Foliage.Add(foliage);
            }

            ColorRelatedArray = reader.ReadBuffer((uint) (Colormap0.Size * Colormap0.Size));
            
            ShortMap = new ShortMap();
            ShortMap.Deserialize(reader);
            
            if (ShortMap.Data.Length == default) return;

            UnknownByteArray1 = reader.ReadBuffer(32);

            UnknownShortArray = new short[16][];

            for (var i = 0; i < 16; i++)
            {
                var length = reader.Read<short>();
                UnknownShortArray[i] = new short[length];

                for (var j = 0; j < length; j++)
                {
                    UnknownShortArray[i][j] = reader.Read<short>();
                }
            }
        }

        public static Chunk Empty
        {
            get
            {
                var chunk = new Chunk
                {
                    Colormap0 = ColorMap.Empty,
                    Colormap1 = ColorMap.Empty,
                    HeightMap = HeightMap.Empty,
                    ShortMap = ShortMap.Empty,
                    Blendmap = TerrainDirectDraw.Empty,
                    Lightmap = TerrainDirectDraw.Empty,
                    Foliage = new List<Foliage>()
                };

                chunk.ColorRelatedArray = new byte[chunk.Colormap0.Size * chunk.Colormap0.Size];
                chunk.UnknownShortArray = new short[16][];

                for (var i = 0; i < 16; i++)
                {
                    chunk.UnknownShortArray[i] = new short[0];
                }

                return chunk;
            }
        }
    }
}