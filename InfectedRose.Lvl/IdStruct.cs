using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class IdStruct : IConstruct
    {
        public uint Id { get; set; }

        public float UnknownFloat0 { get; set; }
        
        public float UnknownFloat1 { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            writer.Write(Id);

            writer.Write(UnknownFloat0);

            writer.Write(UnknownFloat1);
        }

        public void Deserialize(BitReader reader)
        {
            Id = reader.Read<uint>();

            UnknownFloat0 = reader.Read<float>();

            UnknownFloat1 = reader.Read<float>();
        }
    }
}