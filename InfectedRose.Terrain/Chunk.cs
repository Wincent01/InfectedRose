using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class Chunk : IConstruct
    {
        public int ChunkIndex { get; set; }
        
        public HeightMap HeightMap { get; set; }
        
        public ColorMap Colormap0 { get; set; }
        
        public TerrainDirectDraw Lightmap { get; set; }
        
        public ColorMap Colormap1 { get; set; }

        public byte UnknownByte { get; set; }
        
        public TerrainDirectDraw Blendmap { get; set; }
        
        public WeirdStruct[] WeirdStructs { get; set; }
        
        public byte[] UnknownByteArray0 { get; set; }
        
        public ShortMap ShortMap { get; set; }
        
        public short[][] UnknownShortArray { get; set; }
        
        public byte[] UnknownByteArray1 { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(ChunkIndex);

            HeightMap.Serialize(writer);

            Colormap0.Serialize(writer);

            Lightmap.Serialize(writer);

            Colormap1.Serialize(writer);

            writer.Write(UnknownByte);
            
            Blendmap.Serialize(writer);

            writer.Write(WeirdStructs.Length);

            foreach (var weirdStruct in WeirdStructs)
            {
                weirdStruct.Serialize(writer);
            }

            foreach (var unknownByte in UnknownByteArray0)
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
            ChunkIndex = reader.Read<int>();

            HeightMap = new HeightMap();
            HeightMap.Deserialize(reader);
            
            Colormap0 = new ColorMap();
            Colormap0.Deserialize(reader);
            
            Lightmap = new TerrainDirectDraw();
            Lightmap.Deserialize(reader);
            
            Colormap1 = new ColorMap();
            Colormap1.Deserialize(reader);

            UnknownByte = reader.Read<byte>();
            
            Blendmap = new TerrainDirectDraw();
            Blendmap.Deserialize(reader);

            WeirdStructs = new WeirdStruct[reader.Read<int>()];

            for (var i = 0; i < WeirdStructs.Length; i++)
            {
                var weirdStruct = new WeirdStruct();
                weirdStruct.Deserialize(reader);

                WeirdStructs[i] = weirdStruct;
            }

            UnknownByteArray0 = reader.ReadBuffer((uint) (Colormap0.Width * Colormap0.Height));
            
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
    }
}