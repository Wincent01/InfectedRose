using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    public abstract class DatabaseData : HashConstruct, IDeserializable
    {
        public abstract void Deserialize(BitReader reader);
    }
}