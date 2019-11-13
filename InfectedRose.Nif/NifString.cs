using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NifString : IConstruct
    {
        public string Value { get; set; }
        
        public bool Wide { get; set; }
        
        public bool Small { get; set; }

        public void Serialize(BitWriter writer)
        {
            if (Small) writer.Write((byte) Value.Length);
            else writer.Write((uint) Value.Length);

            foreach (var character in Value)
            {
                if (Wide) writer.Write((ushort) character);
                else writer.Write((byte) character);
            }
        }

        public void Deserialize(BitReader reader)
        {
            var length = Small ? reader.Read<byte>() : reader.Read<uint>();

            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = (char) (Wide ? reader.Read<ushort>() : reader.Read<byte>());
            }

            Value = new string(chars);
        }
    }
}