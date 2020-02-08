using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiCollisionObject : NiObject
    {
        public NiRef<NiAvObject> Target { get; set; }
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(Target);
        }

        public override void Deserialize(BitReader reader)
        {
            Target = reader.Read<NiRef<NiAvObject>>(File);
        }
    }
}