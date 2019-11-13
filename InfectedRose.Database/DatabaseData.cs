using RakDotNet.IO;

namespace InfectedRose.Database
{
    public abstract class DatabaseData : IDeserializable
    {
        internal abstract void Compile(DatabaseFile databaseFile);

        public abstract void Deserialize(BitReader reader);
    }
}