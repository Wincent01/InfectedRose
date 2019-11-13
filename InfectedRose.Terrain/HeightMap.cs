using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class HeightMap : IConstruct
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public float UnknownFloat0 { get; set; }
        public float UnknownFloat1 { get; set; }
        public float UnknownFloat2 { get; set; }
        
        public int[] UnknownIntArray { get; set; }
        
        public float[] Data { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Width);
            writer.Write(Height);

            writer.Write(UnknownFloat0);
            writer.Write(UnknownFloat1);

            for (var i = 0; i < 4; i++)
            {
                writer.Write(UnknownIntArray[i]);
            }

            writer.Write(UnknownFloat2);

            for (var i = 0; i < Width * Height; i++)
            {
                writer.Write(Data[i]);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Width = reader.Read<int>();
            Height = reader.Read<int>();

            UnknownFloat0 = reader.Read<float>();
            UnknownFloat1 = reader.Read<float>();
            
            UnknownIntArray = new int[4];

            for (var i = 0; i < 4; i++)
            {
                UnknownIntArray[i] = reader.Read<int>();
            }

            UnknownFloat2 = reader.Read<float>();

            Data = new float[Width * Height];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.Read<float>();
            }
        }
    }
}