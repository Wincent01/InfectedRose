using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbBitInt : ISerializable
    {
        public long Value { get; set; }

        public void Deserialize(BitReader reader)
        {
            using var s = new DatabaseScope(reader, true);

            if (s) Value = reader.Read<long>();
        }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Value);
        }
    }
}