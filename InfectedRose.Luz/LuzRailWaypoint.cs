using System.Numerics;
using InfectedRose.Core;
using InfectedRose.Luz.Extensions;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzRailWaypoint : LuzPathWaypoint
    {
        public LegoDataDictionary Configs { get; set; }

        public Quaternion UnknownQuaternion { get; set; }
        
        public float Speed { get; set; }
        
        public LuzRailWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.WriteNiQuaternion(UnknownQuaternion);

            if (Version >= 17)
            {
                writer.Write(Speed);
            }

            Configs.SerializePathConfigs(writer);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            UnknownQuaternion = reader.ReadNiQuaternion();

            if (Version >= 17)
            {
                Speed = reader.Read<float>();
            }

            Configs = new LegoDataDictionary();
            Configs.DeserializePathConfigs(reader);
        }
    }
}
