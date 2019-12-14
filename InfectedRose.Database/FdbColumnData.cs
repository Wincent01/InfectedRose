using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbColumnData : DatabaseData
    {
        private readonly uint _columnCount;
        
        public FdbColumnData(uint columnCount)
        {
            _columnCount = columnCount;
        }

        public (DataType type, FdbString name)[] Fields { get; set; }

        public override void Deserialize(BitReader reader)
        {
            Fields = new (DataType type, FdbString name)[_columnCount];

            for (var i = 0; i < _columnCount; i++)
            {
                Fields[i].type = (DataType) reader.Read<uint>();
                
                Fields[i].name = new FdbString();
                Fields[i].name.Deserialize(reader);
            }
        }

        public override void Compile(HashMap map)
        {
            map += this;
            for (var i = 0; i < Fields.Length; i++)
            {
                map += (uint) Fields[i].type;
                map += Fields[i].name;
            }

            foreach (var s in Fields) s.name.Compile(map);
        }
    }
}