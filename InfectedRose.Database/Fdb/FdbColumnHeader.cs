using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbColumnHeader : DatabaseData
    {
        public FdbString TableName { get; set; }

        public FdbColumnData Data { get; set; }

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

        public override void Compile(HashMap map)
        {
            map += this;
            map += (uint) Data.Fields.Length;
            map += TableName;
            map += Data;

            TableName.Compile(map);
            Data.Compile(map);
        }
    }
}