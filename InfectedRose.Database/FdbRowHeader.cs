using System.Linq;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowHeader : DatabaseData
    {
        private readonly uint _rowCount;

        public FdbRowInfo[] RowInfos;

        public FdbRowHeader(uint rowCount)
        {
            _rowCount = rowCount;
        }

        public override void Deserialize(BitReader reader)
        {
            RowInfos = new FdbRowInfo[_rowCount];

            for (var i = 0; i < _rowCount; i++)
            {
                using var s = new DatabaseScope(reader, true);

                if (!s) continue;

                RowInfos[i] = new FdbRowInfo();
                RowInfos[i].Deserialize(reader);
            }
        }

        public override void Compile(HashMap map)
        {
            map += this;

            map = RowInfos.Aggregate(map, (current, info) => current + info);

            for (var i = 0; i < FdbRowBucket.NextPowerOf2(RowInfos.Length) - RowInfos.Length; i++) map += -1;

            foreach (var rowInfo in RowInfos) rowInfo?.Compile(map);
        }
    }
}