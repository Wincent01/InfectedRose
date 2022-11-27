using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public abstract class ChunkBase : IConstruct
    {
        public ushort DataVersion { get; set; }

        public ushort HeaderVersion { get; set; } = 1;

        public abstract uint ChunkType { get; }
        
        public abstract void Serialize(BitWriter writer);

        public abstract void Deserialize(BitReader reader);
    }
}