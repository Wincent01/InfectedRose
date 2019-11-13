using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowHeader : DatabaseData
    {
        private readonly uint _rowCount;
        
        public FdbRowHeader(uint rowCount)
        {
            _rowCount = rowCount;
        }

        public FdbRowInfo[] RowInfos;

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            
            foreach (var rowInfo in RowInfos) databaseFile.Structure.Add(rowInfo);

            for (var i = 0; i < FdbRowBucket.NextPowerOf2(RowInfos.Length) - RowInfos.Length; i++)
            {
                databaseFile.Structure.Add(-1);
            }
            
            foreach (var rowInfo in RowInfos) rowInfo?.Compile(databaseFile);
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
    }
}