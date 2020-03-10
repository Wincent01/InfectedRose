using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    public class DatabaseFile : IConstruct
    {
        internal FdbTableHeader TableHeader { get; set; }

        public void Deserialize(BitReader reader)
        {
            var tableCount = reader.Read<uint>();

            using (new DatabaseScope(reader))
            {
                TableHeader = new FdbTableHeader(tableCount);

                TableHeader.Deserialize(reader);
            }
        }

        public void Serialize(BitWriter writer)
        {
            writer.Write((uint) TableHeader.Tables.Length);

            using (new PointerToken(writer))
            {
            }

            TableHeader.Serialize(writer);
        }
    }
}