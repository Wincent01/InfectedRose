using InfectedRose.Core;
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
        
        public PointerToken SkyBoxPointer { get; set; }
        
        public PointerToken EnvironmentPointer { get; set; }
        
        public PointerToken ObjectsPointer { get; set; }

        public override uint ChunkType => 1000;
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(LvlVersion);

            writer.Write(RevisionNumber);

            SkyBoxPointer = new PointerToken(writer);

            ObjectsPointer = new PointerToken(writer);

            EnvironmentPointer = new PointerToken(writer);
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