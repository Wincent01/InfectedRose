using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class ColorMap : IConstruct
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public uint[] Data { get; set; }

        public uint GetValue(int x, int y)
        {
            return Data[y * Width + x];
        }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Width);

            for (var i = 0; i < Width * Height; i++)
            {
                writer.Write(Data[i]);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Width = Height = reader.Read<int>();
            
            Data = new uint[Width * Height];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.Read<uint>();
            }
        }
    }
}