using System;
using System.Collections.Generic;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbTableHeader : IConstruct
    {
        private readonly uint _tableCount;

        public FdbTableHeader(uint tableCount)
        {
            _tableCount = tableCount;
        }

        public (FdbColumnHeader info, FdbRowBucket data)[] Tables { get; set; }

        public void Deserialize(BitReader reader)
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


        public void Serialize(BitWriter writer)
        {
            var pointer = new List<(PointerToken info, PointerToken data)>();

            for (var i = 0; i < Tables.Length; i++)
            {
                var info = new PointerToken(writer);

                var data = new PointerToken(writer);
                
                pointer.Add((info, data));
            }

            for (var index = 0; index < Tables.Length; index++)
            {
                var (info, data) = Tables[index];

                var (infoPointer, dataPointer) = pointer[index];
                
                infoPointer.Dispose();
                
                info.Serialize(writer);
                
                dataPointer.Dispose();
                
                data.Serialize(writer);
            }
        }
    }
}