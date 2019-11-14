using System.Text;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class Header : IConstruct
    {
        public string HeaderString { get; set; }
        
        public NifVersion Version { get; set; }
        
        public Endian Endian { get; set; }
        
        public string VersionString { get; set; }
        
        public uint UserVersion { get; set; }
        
        public BlockInfo[] NodeInfo { get; set; }
        
        public NifString[] NodeTypes { get; set; }
        
        public uint MaxStringLength { get; set; }
        
        public uint[] Groups { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(BitReader reader)
        {
            var versionStringBuilder = new StringBuilder();

            var character = reader.Read<byte>();
            while (character != 0xA)
            {
                versionStringBuilder.Append((char) character);

                character = reader.Read<byte>();
            }

            VersionString = versionStringBuilder.ToString();

            reader.Read<byte>();

            Version = (NifVersion) reader.Read<uint>();

            Endian = (Endian) reader.Read<byte>();

            UserVersion = reader.Read<uint>();

            NodeInfo = new BlockInfo[reader.Read<uint>()];

            NodeTypes = new NifString[reader.Read<uint>()];

            for (var i = 0; i < NodeTypes.Length; i++)
            {
                var str = new NifString();

                str.Deserialize(reader);

                NodeTypes[i] = str;
            }

            for (var i = 0; i < NodeInfo.Length; i++)
            {
                NodeInfo[i] = new BlockInfo
                {
                    TypeIndex = reader.Read<ushort>()
                };
            }

            foreach (var info in NodeInfo)
            {
                info.Size = reader.Read<uint>();
            }
        }
    }
}