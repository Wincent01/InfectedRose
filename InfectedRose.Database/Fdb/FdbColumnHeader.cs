using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbColumnHeader : IConstruct
    {
        public FdbString TableName { get; set; }

        public FdbColumnData Data { get; set; }

        public void Deserialize(BitReader reader)
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

        public void Serialize(BitWriter writer)
        {
            writer.Write((uint) Data.Fields.Length);

            var namePointer = new PointerToken(writer);
            var dataPointer = new PointerToken(writer);
            
            namePointer.Dispose();

            TableName.Serialize(writer);
            
            dataPointer.Dispose();

            Data.Serialize(writer);
        }
    }
}