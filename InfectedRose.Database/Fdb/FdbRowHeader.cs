using System.Linq;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
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

                var info = new FdbRowInfo();

                RowInfos[i] = info;

                while (info != default)
                {
                    using (var scope = new DatabaseScope(reader, true))
                    {
                        if (scope)
                        {
                            info.DataHeader = new FdbRowDataHeader();

                            info.DataHeader.Deserialize(reader);
                        }
                    }

                    {
                        var scope = new DatabaseScope(reader, true);
                        
                        if (!scope)
                        {
                            break;
                        }

                        info.Linked = new FdbRowInfo();

                        info = info.Linked;
                    }
                }
            }
        }

        public override void Compile(HashMap map)
        {
            map += this;
            
            map = RowInfos.Aggregate(map, (current, info) => current + info);

            for (var i = 0; i < FdbRowBucket.NextPowerOf2(RowInfos.Length) - RowInfos.Length; i++) map += -1;

            foreach (var rowInfo in RowInfos)
            {
                var current = rowInfo;

                while (current != default)
                {
                    map += current;
                    map += current.DataHeader;

                    if (current.Linked == default)
                        map += -1;
                    else
                        map += current.Linked;

                    current.DataHeader?.Compile(map);

                    current = current.Linked;
                }
            }
        }
    }
}