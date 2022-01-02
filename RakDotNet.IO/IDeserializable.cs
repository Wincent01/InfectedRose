namespace RakDotNet.IO
{
    public interface IDeserializable
    {
        void Deserialize(BitReader reader);
    }
}
