using System;
using System.IO;
using System.Linq;
using InfectedRose.Core;
using InfectedRose.Lvl.Old;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class LvlFile : IConstruct
    {
        public uint LvlVersion { get; set; }

        public OldLevelHeader OldLevelHeader { get; set; }
        
        public LevelInfo LevelInfo { get; set; }

        public LevelSkyConfig LevelSkyConfig { get; set; }

        public LevelObjects LevelObjects { get; set; }

        public LevelEnvironmentConfig LevelEnvironmentConfig { get; set; }

        private static readonly byte[] ChunkHeader = "CHNK".Select(c => (byte) c).ToArray();
        
        public void Serialize(BitWriter writer)
        {
            if (OldLevelHeader == default)
                throw new NotSupportedException("Writing new level files is not yet supported.");

            OldLevelHeader.Serialize(writer);

            LevelObjects.LvlVersion = OldLevelHeader.LvlVersion;

            LevelObjects.Serialize(writer);

            writer.Write<byte>(0);
            writer.Write<byte>(0);
        }

        public void Deserialize(BitReader reader)
        {
            var magic = new string(reader.ReadBuffer(4).Select(s => (char) s).ToArray());

            if (magic != "CHNK")
            {
                reader.BaseStream.Position = 0;
                
                OldLevelHeader = new OldLevelHeader();

                OldLevelHeader.Deserialize(reader);

                LvlVersion = OldLevelHeader.LvlVersion;
                
                LevelObjects = new LevelObjects(LvlVersion);

                LevelObjects.Deserialize(reader);

                return;
            }

            reader.BaseStream.Position = 0;

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                var startPosition = reader.BaseStream.Position;
                
                magic = new string(reader.ReadBuffer(4).Select(s => (char) s).ToArray());

                if (startPosition % 16 != 0 || magic != "CHNK")
                {
                    throw new Exception($"{startPosition} % 16 = {startPosition % 16} | {magic}");
                }

                var chunkType = reader.Read<uint>();

                reader.Read<ushort>();

                var index = reader.Read<ushort>();

                var chunkLength = reader.Read<uint>();

                var chunkAddress = reader.Read<uint>();
                
                reader.BaseStream.Position = chunkAddress;

                if (reader.BaseStream.Position % 16 != 0) break;
                
                switch (chunkType)
                {
                    case 1000:
                        var chunk1000 = new LevelInfo
                        {
                            Index = index
                        };
                        
                        chunk1000.Deserialize(reader);

                        LvlVersion = chunk1000.LvlVersion;

                        LevelInfo = chunk1000;
                        break;
                    case 2000:
                        var chunk2000 = new LevelSkyConfig
                        {
                            Index = index
                        };

                        chunk2000.Deserialize(reader);

                        LevelSkyConfig = chunk2000;
                        break;
                    case 2001:
                        var chunk2001 = new LevelObjects(LvlVersion)
                        {
                            Index = index
                        };

                        chunk2001.Deserialize(reader);

                        LevelObjects = chunk2001;
                        break;
                    case 2002:
                        var chunk2002 = new LevelEnvironmentConfig
                        {
                            Index = index
                        };

                        chunk2002.Deserialize(reader);

                        LevelEnvironmentConfig = chunk2002;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"{chunkType} is not a valid chunk type.");
                }

                while (reader.BaseStream.Position != startPosition + chunkLength)
                {
                    reader.Read<byte>();
                }

                reader.BaseStream.Position = startPosition + chunkLength;
                
                Console.WriteLine($"[END] -> {reader.BaseStream.Position}");
            }
        }

        public void ConvertToOld(ushort version = 39)
        {
            OldLevelHeader = new OldLevelHeader {LvlVersion = version, SkyBox = LevelSkyConfig.Skybox};
        }
    }
}