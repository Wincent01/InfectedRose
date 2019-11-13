using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzSpawnerWaypoint : LuzPathWaypoint
    {
        public Quaternion Rotation { get; set; }
        
        public LuzPathConfig[] Configs { get; set; }
        
        public LuzSpawnerWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.WriteNiQuaternion(Quaternion.Identity);
            
            writer.Write((uint) Configs.Length);

            foreach (var config in Configs)
            {
                config.Serialize(writer);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Rotation = reader.ReadNiQuaternion();

            var configCount = reader.Read<uint>();

            Configs = new LuzPathConfig[configCount];

            for (var i = 0; i < configCount; i++)
            {
                Configs[i] = new LuzPathConfig();
                Configs[i].Deserialize(reader);
            }
        }
    }
}