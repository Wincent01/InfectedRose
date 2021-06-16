using System.Numerics;
using InfectedRose.Core;
using InfectedRose.Luz.Extensions;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzSpawnerWaypoint : LuzPathWaypoint
    {
        public Quaternion Rotation { get; set; }

        public LegoDataDictionary Configs { get; set; }
        
        public LuzSpawnerWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.WriteNiQuaternion(Quaternion.Identity);

            Configs.SerializePathConfigs(writer);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Rotation = reader.ReadNiQuaternion();

            Configs = new LegoDataDictionary();
            Configs.DeserializePathConfigs(reader);
        }
    }
}
