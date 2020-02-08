using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public abstract class NiObject : IConstruct
    {
        public NiFile File { get; set; }
        
        public abstract void Serialize(BitWriter writer);

        public abstract void Deserialize(BitReader reader);
    }
}