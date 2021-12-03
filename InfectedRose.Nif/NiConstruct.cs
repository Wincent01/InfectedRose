using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiConstruct<T> : IConstruct where T : unmanaged
    {
        public T Value { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Value);
        }

        public void Deserialize(BitReader reader)
        {
            Value = reader.Read<T>();
        }
    }
}