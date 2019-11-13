using System.IO;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzMovementWaypoint : LuzPathWaypoint
    {
        public LuzPathConfig[] Configs { get; set; }
        
        public LuzMovementWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write((uint) Configs.Length);

            foreach (var config in Configs)
            {
                config.Serialize(writer);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

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