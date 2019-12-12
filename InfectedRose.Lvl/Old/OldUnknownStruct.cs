using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl.Old
{
    public class OldUnknownStruct : IConstruct
    {
        public uint UnknownInt { get; set; }
        
        public Vector2 UnknownVector { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            writer.Write(UnknownInt);

            writer.Write(UnknownVector);
        }

        public void Deserialize(BitReader reader)
        {
            UnknownInt = reader.Read<uint>();

            UnknownVector = reader.Read<Vector2>();
        }
    }
}