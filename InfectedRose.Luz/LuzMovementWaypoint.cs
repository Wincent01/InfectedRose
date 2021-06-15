using InfectedRose.Core;
using InfectedRose.Luz.Extensions;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzMovementWaypoint : LuzPathWaypoint
    {
        public LegoDataDictionary Configs { get; set; }
        
        public LuzMovementWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            Configs.SerializePathConfigs(writer);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            Configs = new LegoDataDictionary();
            Configs.DeserializePathConfigs(reader);
        }
    }
}
