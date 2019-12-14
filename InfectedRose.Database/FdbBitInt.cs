using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbBitInt : DatabaseData
    {
        public long Value { get; set; }

        public override void Deserialize(BitReader reader)
        {
            using var s = new DatabaseScope(reader, true);
            
            if (s) Value = reader.Read<long>();
        }

        public override void Compile(HashMap map)
        {
            map += this;
            
            map.Add(Value);
        }
    }
}