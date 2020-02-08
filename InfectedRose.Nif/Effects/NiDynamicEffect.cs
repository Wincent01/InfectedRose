using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiDynamicEffect : NiAvObject
    {
        public bool SwitchState { get; set; }
        
        public NiRef<NiNode>[] Affected { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            SwitchState = reader.Read<byte>() != 0;

            Affected = new NiRef<NiNode>[reader.Read<uint>()];

            for (var i = 0; i < Affected.Length; i++)
            {
                Affected[i] = reader.Read<NiRef<NiNode>>(File);
            }
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write((byte) (SwitchState ? 1 : 0));

            writer.Write((uint) Affected.Length);

            foreach (var node in Affected)
            {
                writer.Write(node);
            }
        }
    }
}