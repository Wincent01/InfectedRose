using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbColumnData : IConstruct
    {
        private readonly uint _columnCount;

        public FdbColumnData(uint columnCount)
        {
            _columnCount = columnCount;
        }

        public (DataType type, FdbString name)[] Fields { get; set; }

        public void Deserialize(BitReader reader)
        {
            Fields = new (DataType type, FdbString name)[_columnCount];

            for (var i = 0; i < _columnCount; i++)
            {
                Fields[i].type = (DataType) reader.Read<uint>();

                Fields[i].name = new FdbString();
                Fields[i].name.Deserialize(reader);
            }
        }

        public void Serialize(BitWriter writer)
        {
            var pointers = new PointerToken[Fields.Length];

            for (var i = 0; i < Fields.Length; i++)
            {
                writer.Write((uint) Fields[i].type);

                pointers[i] = new PointerToken(writer);
            }

            for (var i = 0; i < Fields.Length; i++)
            {
                pointers[i].Dispose();

                Fields[i].name.Serialize(writer);
            }
        }
    }
}