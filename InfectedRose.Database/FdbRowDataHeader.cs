using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowDataHeader : DatabaseData
    {
        public FdbRowData Data { get; set; }

        public override void Deserialize(BitReader reader)
        {
            var columnCount = reader.Read<uint>();

            using var s = new DatabaseScope(reader, true);

            if (!s) return;

            Data = new FdbRowData(columnCount);

            Data.Deserialize(reader);
        }

        public override void Compile(HashMap map)
        {
            map += this;
            map += (uint) Data.Fields.Length;
            map += Data;

            Data?.Compile(map);
        }
    }
}