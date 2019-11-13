using System.IO;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class LevelInfo : ChunkBase
    {
        public uint LvlVersion { get; set; }

        public uint RevisionNumber { get; set; }

        public uint AddressChunk2000 { get; set; }

        public uint AddressChunk2001 { get; set; }

        public uint AddressChunk2002 { get; set; }

        public override uint ChunkType => 1000;
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(LvlVersion);

            writer.Write(RevisionNumber);

            writer.Write(AddressChunk2000);

            writer.Write(AddressChunk2001);

            writer.Write(AddressChunk2002);
        }

        public override void Deserialize(BitReader reader)
        {
            LvlVersion = reader.Read<uint>();

            RevisionNumber = reader.Read<uint>();
            
            AddressChunk2000 = reader.Read<uint>();
            
            AddressChunk2001 = reader.Read<uint>();
            
            AddressChunk2002 = reader.Read<uint>();
        }
    }
}