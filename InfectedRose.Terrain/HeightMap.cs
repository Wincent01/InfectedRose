using System.Linq;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class HeightMap : IConstruct
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public float PositionX { get; set; }
        
        public float PositionY { get; set; }

        public float ScaleFactor { get; set; } = 3.2f;

        public int[] TexturePallet { get; set; } = {1, 2, 3, 4};
        
        public float[] Data { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Width);
            writer.Write(Height);

            writer.Write(PositionX);
            writer.Write(PositionY);

            for (var i = 0; i < 4; i++)
            {
                writer.Write(TexturePallet[i]);
            }

            writer.Write(ScaleFactor);

            for (var i = 0; i < Width * Height; i++)
            {
                writer.Write(Data[i]);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Width = reader.Read<int>();
            Height = reader.Read<int>();

            PositionX = reader.Read<float>();
            PositionY = reader.Read<float>();
            
            TexturePallet = new int[4];

            for (var i = 0; i < 4; i++)
            {
                TexturePallet[i] = reader.Read<int>();
            }

            ScaleFactor = reader.Read<float>();

            Data = new float[Width * Height];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.Read<float>();
            }
        }
        
        public float GetValue(int x, int y)
        {
            return Data[y * Width + x];
        }

        public void SetValue(int x, int y, float value)
        {
            Data[y * Width + x] = value;
        }

        public float Min => Data.Min();

        public float Max => Data.Max();

        public static HeightMap Empty
        {
            get
            {
                var map = new HeightMap {Width = 65, Height = 65};

                map.Data = new float[map.Width * map.Height];

                for (var i = 0; i < map.Data.Length; i++)
                {
                    map.Data[i] = 200;
                }

                return map;
            }
        }

        public static HeightMap FromSize(int size, float height = 200)
        {
            var map = new HeightMap {Width = size, Height = size};

            map.Data = new float[map.Width * map.Height];

            for (var i = 0; i < map.Data.Length; i++)
            {
                map.Data[i] = height;
            }

            return map;
        }
    }
}