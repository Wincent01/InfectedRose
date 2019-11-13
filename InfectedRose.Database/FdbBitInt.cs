using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbBitInt : DatabaseData
    {
        public long Value { get; set; }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            databaseFile.Structure.Add(Value);
        }

        public override void Deserialize(BitReader reader)
        {
            using var s = new DatabaseScope(reader, true);
            
            if (s) Value = reader.Read<long>();
        }
    }
}