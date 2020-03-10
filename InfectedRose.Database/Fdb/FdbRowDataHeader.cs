using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbRowDataHeader : IConstruct
    {
        public FdbRowData Data { get; set; }

        public void Deserialize(BitReader reader)
        {
            var columnCount = reader.Read<uint>();

            using var s = new DatabaseScope(reader, true);

            if (!s) return;

            Data = new FdbRowData(columnCount);

            Data.Deserialize(reader);
        }
        
        public void Serialize(BitWriter writer)
        {
            writer.Write((uint) Data.Fields.Length);

            using (new PointerToken(writer))
            {
            }

            Data.Serialize(writer);
        }
    }
}