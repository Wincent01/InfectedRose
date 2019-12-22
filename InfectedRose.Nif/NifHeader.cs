using System.IO;
using System.Text;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NifHeader : IConstruct
    {
        public NifVersion Version { get; set; }
        
        public Endian Endian { get; set; }
        
        public string VersionString { get; set; }
        
        public uint UserVersion { get; set; }
        
        public BlockInfo[] NodeInfo { get; set; }
        
        public string[] NodeTypes { get; set; }
        
        public uint MaxStringLength { get; set; }
        
        public uint[] Groups { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            foreach (var character in VersionString)
            {
                writer.Write((byte) character);
            }

            writer.Write<byte>(0xA);

            writer.Write<byte>(0);

            writer.Write((uint) Version);

            writer.Write((byte) Endian);

            writer.Write(UserVersion);

            writer.Write((uint) NodeInfo.Length);
            writer.Write((ushort) NodeTypes.Length);

            foreach (var type in NodeTypes)
            {
                writer.WriteNiString(type);
            }
            
            foreach (var blockInfo in NodeInfo)
            {
                writer.Write(blockInfo.TypeIndex);
            }

            foreach (var blockInfo in NodeInfo)
            {
                writer.Write(blockInfo.Size);
            }
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

            Version = (NifVersion) reader.Read<uint>();

            Endian = (Endian) reader.Read<byte>();

            UserVersion = reader.Read<uint>();

            NodeInfo = new BlockInfo[reader.Read<uint>()];

            NodeTypes = new string[reader.Read<ushort>()];

            for (var i = 0; i < NodeTypes.Length; i++)
            {
                NodeTypes[i] = reader.ReadNiString();
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