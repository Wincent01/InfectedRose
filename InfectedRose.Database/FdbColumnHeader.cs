using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbColumnHeader : DatabaseData
    {
        public FdbString TableName { get; set; }

        public FdbColumnData Data { get; set; }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            databaseFile.Structure.Add((uint) Data.Fields.Length);
            databaseFile.Structure.Add(TableName);
            databaseFile.Structure.Add(Data);

            TableName.Compile(databaseFile);
            Data.Compile(databaseFile);
        }

        public override void Deserialize(BitReader reader)
        {
            var columnCount = reader.Read<uint>();

            TableName = new FdbString();
            TableName.Deserialize(reader);

            using (new DatabaseScope(reader))
            {
                Data = new FdbColumnData(columnCount);
                Data.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return TableName;
        }
    }
}