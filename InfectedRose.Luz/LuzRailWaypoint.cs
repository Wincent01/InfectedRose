using System.IO;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzRailWaypoint : LuzPathWaypoint
    {
        public LuzPathConfig[] Configs { get; set; }

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

            writer.Write((uint) Configs.Length);

            foreach (var config in Configs)
            {
                config.Serialize(writer);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            UnknownQuaternion = reader.ReadNiQuaternion();

            if (Version >= 17)
            {
                Speed = reader.Read<float>();
            }

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