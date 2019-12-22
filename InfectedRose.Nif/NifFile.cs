using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NifFile : IConstruct
    {
        public NifHeader Header { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            Header.Serialize(writer);
        }

        public void Deserialize(BitReader reader)
        {
            Header = new NifHeader();

            Header.Deserialize(reader);
        }
    }
}