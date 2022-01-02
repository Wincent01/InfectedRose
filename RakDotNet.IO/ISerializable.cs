namespace RakDotNet.IO
{
    public interface ISerializable
    {
        void Serialize(BitWriter writer);
    }
}
