using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzSpawnerPath : LuzPathData
    {
        public uint SpawnedLot { get; set; }
        
        public uint RespawnTime { get; set; }
        
        public int MaxSpawnCount { get; set; }
        
        public uint NumberToMaintain { get; set; }
        
        public long SpawnerObjectId { get; set; }
        
        public bool ActivateSpawnerNetworkOnLoad { get; set; }

        public LuzSpawnerPath(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(SpawnedLot);

            writer.Write(RespawnTime);

            writer.Write(MaxSpawnCount);

            writer.Write(NumberToMaintain);

            writer.Write(SpawnerObjectId);
            
            if (Version > 8)
                writer.Write((byte) (ActivateSpawnerNetworkOnLoad ? 1 : 0));
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            SpawnedLot = reader.Read<uint>();

            RespawnTime = reader.Read<uint>();

            MaxSpawnCount = reader.Read<int>();

            NumberToMaintain = reader.Read<uint>();

            SpawnerObjectId = reader.Read<long>();

            if (Version > 8)
                ActivateSpawnerNetworkOnLoad = reader.Read<byte>() != 0;
        }
    }
}