using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbTableHeader : DatabaseData
    {
        private readonly uint _tableCount;

        public FdbTableHeader(uint tableCount)
        {
            _tableCount = tableCount;
        }

        public (FdbColumnHeader info, FdbRowBucket data)[] Tables { get; set; }

        public override void Deserialize(BitReader reader)
        {
            Tables = new (FdbColumnHeader info, FdbRowBucket data)[_tableCount];

            for (var i = 0; i < _tableCount; i++)
            {
                using (new DatabaseScope(reader))
                {
                    Tables[i].info = new FdbColumnHeader();
                    Tables[i].info.Deserialize(reader);
                }

                using (new DatabaseScope(reader))
                {
                    Tables[i].data = new FdbRowBucket();
                    Tables[i].data.Deserialize(reader);
                }
            }
        }

        public override void Compile(HashMap map)
        {
            map += this;

            for (var i = 0; i < Tables.Length; i++)
            {
                map += Tables[i].info;
                map += Tables[i].data;
            }

            for (var i = 0; i < Tables.Length; i++)
            {
                Tables[i].data.Compile(map);
                Tables[i].info.Compile(map);
            }
        }
    }
}