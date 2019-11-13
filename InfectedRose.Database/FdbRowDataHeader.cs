using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowDataHeader : DatabaseData
    {
        public FdbRowData Data { get; set; }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            databaseFile.Structure.Add((uint) Data.Fields.Length);
            databaseFile.Structure.Add(Data);

            Data?.Compile(databaseFile);
        }

        public override void Deserialize(BitReader reader)
        {
            var columnCount = reader.Read<uint>();

            using var s = new DatabaseScope(reader, true);
            
            if (!s) return;
                
            Data = new FdbRowData(columnCount);

            Data.Deserialize(reader);
        }
    }
}