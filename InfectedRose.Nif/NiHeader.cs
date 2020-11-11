using System.IO;
using System.Text;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiHeader : IConstruct
    {
        public uint Version { get; set; }
        
        public byte Endian { get; set; }
        
        public string VersionString { get; set; }
        
        public uint UserVersion { get; set; }
        
        public BlockInfo[] NodeInfo { get; set; }
        
        public string[] NodeTypes { get; set; }
        
        public string[] Strings { get; set; }
        
        public uint MaxStringLength { get; set; }
        
        public uint[] Groups { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            foreach (var character in VersionString)
            {
                writer.Write((byte) character);
            }

            writer.Write<byte>(0xA);

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

            writer.Write((uint) Strings.Length);

            writer.Write(MaxStringLength);

            foreach (var str in Strings)
            {
                writer.WriteNiString(str);
            }

            writer.Write((uint) Groups.Length);

            foreach (var group in Groups)
            {
                writer.Write(group);
            }
        }

        public void Deserialize(BitReader reader)
        {
            var versionStringBuilder = new StringBuilder();

            //
            // Version
            //
            
            var character = reader.Read<byte>();
            while (character != 0xA)
            {
                versionStringBuilder.Append((char) character);

                character = reader.Read<byte>();
            }

            VersionString = versionStringBuilder.ToString();

            Version = reader.Read<uint>();

            Endian = reader.Read<byte>();

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
            
            Strings = new string[reader.Read<uint>()];

            MaxStringLength = reader.Read<uint>();

            for (var i = 0; i < Strings.Length; i++)
            {
                Strings[i] = reader.ReadNiString();
            }

            Groups = new uint[reader.Read<uint>()];

            for (var i = 0; i < Groups.Length; i++)
            {
                Groups[i] = reader.Read<uint>();
            }
        }
    }
}