using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class TerrainDirectDraw : IConstruct
    {
        public byte[] Data { get; set; }

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
            Data = reader.ReadBuffer((uint) reader.Read<int>());
        }
    }
}