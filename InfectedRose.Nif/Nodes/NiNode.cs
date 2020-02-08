using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiNode : NiAvObject
    {
        public NiRef<NiAvObject>[] Children { get; set; }
        
        public NiRef<NiDynamicEffect>[] Effects { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Children = new NiRef<NiAvObject>[reader.Read<uint>()];

            for (var i = 0; i < Children.Length; i++)
            {
                Children[i] = reader.Read<NiRef<NiAvObject>>(File);
            }
            
            Effects = new NiRef<NiDynamicEffect>[reader.Read<uint>()];

            for (var i = 0; i < Effects.Length; i++)
            {
                Effects[i] = reader.Read<NiRef<NiDynamicEffect>>(File);
            }
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write((uint) Children.Length);

            foreach (var child in Children)
            {
                writer.Write(child);
            }

            writer.Write((uint) Effects.Length);

            foreach (var effect in Effects)
            {
                writer.Write(effect);
            }
        }
    }
}