using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public abstract class ChunkBase : IConstruct
    {
        public ushort Index { get; set; }
        
        public abstract uint ChunkType { get; }
        
        public abstract void Serialize(BitWriter writer);

        public abstract void Deserialize(BitReader reader);
    }
}