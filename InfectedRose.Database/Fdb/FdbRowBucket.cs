using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbRowBucket : DatabaseData
    {
        public FdbRowHeader RowHeader { get; set; }

        public override void Deserialize(BitReader reader)
        {
            var rowCount = reader.Read<uint>();

            using var s = new DatabaseScope(reader, true);

            if (!s) return;

            RowHeader = new FdbRowHeader(rowCount);
            RowHeader.Deserialize(reader);
        }

        internal static uint NextPowerOf2(int n)
        {
            var count = 0;

            if (n > 0 && (n & (n - 1)) == 0)
                return (uint) n;

            while (n != 0)
            {
                n >>= 1;
                count += 1;
            }

            return (uint) (1 << count);
        }

        public override void Compile(HashMap map)
        {
            map += this;
            map += NextPowerOf2(RowHeader.RowInfos.Length);

            map += RowHeader;

            RowHeader?.Compile(map);
        }
    }
}