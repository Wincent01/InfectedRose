using System;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowBucket : DatabaseData
    {
        public FdbRowHeader RowHeader { get; set; }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            Console.WriteLine(NextPowerOf2(RowHeader.RowInfos.Length));
            databaseFile.Structure.Add(NextPowerOf2(RowHeader.RowInfos.Length));
            
            databaseFile.Structure.Add(RowHeader);

            RowHeader?.Compile(databaseFile);
        }

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

            // First n in the below condition  
            // is for the case where n is 0  
            if (n > 0 && (n & (n - 1)) == 0)
                return (uint) n;

            while (n != 0)
            {
                n >>= 1;
                count += 1;
            }

            return (uint) (1 << count);
        }
    }
}