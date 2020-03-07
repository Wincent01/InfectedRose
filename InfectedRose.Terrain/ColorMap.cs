using System;
using System.Drawing;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class ColorMap : IConstruct
    {
        public int Size { get; set; }
        
        public Color[] Data { get; set; }

        public Color GetValue(int x, int y)
        {
            return Data[y * Size + x];
        }

        public void SetColor(int x, int y, Color value)
        {
            Data[y * Size + x] = value;
        }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Size);

            for (var i = 0; i < Size * Size; i++)
            {
                var color = Data[i];

                var bytes = new[]
                {
                    color.R,
                    color.G,
                    color.B,
                    color.A,
                };

                var value = BitConverter.ToUInt32(bytes);

                writer.Write(value);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Size = reader.Read<int>();
            
            Data = new Color[Size * Size];

            for (var i = 0; i < Data.Length; i++)
            {
                var data = reader.Read<uint>();

                var bytes = BitConverter.GetBytes(data);

                var color = Color.FromArgb(bytes[3], bytes[0], bytes[1], bytes[2]);

                Data[i] = color;
            }
        }

        public static ColorMap Empty
        {
            get
            {
                var map = new ColorMap {Size = 32};
                
                map.Data = new Color[map.Size * map.Size];

                for (var i = 0; i < map.Data.Length; i++)
                {
                    map.Data[i] = Color.FromArgb(127, 127, 127); // Creates green
                }

                return map;
            }
        }
    }
}