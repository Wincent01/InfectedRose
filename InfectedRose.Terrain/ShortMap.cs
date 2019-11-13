using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class ShortMap : IConstruct
    {
        public short[] Data { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Data.Length);

            foreach (var data in Data)
            {
                writer.Write(data);
            }
        }

        public void Deserialize(BitReader reader)
        {
            Data = new short[reader.Read<int>()];

            for (var i = 0; i < Data.Length; i++)
            {
                Data[i] = reader.Read<short>();
            }
        }
    }
}