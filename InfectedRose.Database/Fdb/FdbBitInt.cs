using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbBitInt : ISerializable
    {
        public long Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public FdbBitInt(long value = 0)
        {
            Value = value;
        }

        public void Deserialize(BitReader reader)
        {
            using var s = new DatabaseScope(reader, true);

            if (s) Value = reader.Read<long>();
        }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Value);
        }
        
        public static implicit operator long(FdbBitInt value)
        {
            return value.Value;
        }
        
        public static implicit operator int(FdbBitInt value)
        {
            return (int) value.Value;
        }
    }
}