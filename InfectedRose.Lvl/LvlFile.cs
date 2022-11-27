using System;
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

        public bool IsOld => OldLevelHeader != default;

        private static readonly byte[] ChunkHeader = "CHNK".Select(c => (byte) c).ToArray();

        public void Serialize(BitWriter writer)
        {
            if (OldLevelHeader == default)
            {
                LevelInfo.LvlVersion = LvlVersion;

                if (LevelObjects != default)
                    LevelObjects.LvlVersion = LvlVersion;

                if (LevelEnvironmentConfig != default)
                    LevelEnvironmentConfig.LvlVersion = LvlVersion;
                
                SerializeNew(writer);
                
                return;
            }

            OldLevelHeader.Serialize(writer);

            LevelObjects.LvlVersion = OldLevelHeader.LvlVersion;

            LevelObjects.Serialize(writer);

            writer.Write<byte>(0);
            writer.Write<byte>(0);
        }

        private void SerializeNew(BitWriter writer)
        {
            SerializeChunk(writer, LevelInfo);
            
            if (LevelSkyConfig == default)
            {
                LevelInfo.SkyBoxPointer.Zero = true;
            }

            if (LevelObjects == default)
            {
                LevelInfo.ObjectsPointer.Zero = true;
            }

            if (LevelEnvironmentConfig == default)
            {
                LevelInfo.EnvironmentPointer.Zero = true;
            }

            SerializeChunk(writer, LevelSkyConfig);

            SerializeChunk(writer, LevelObjects);

            SerializeChunk(writer, LevelEnvironmentConfig);

            LevelInfo.EnvironmentPointer.Dispose();
            LevelInfo.ObjectsPointer.Dispose();
            LevelInfo.SkyBoxPointer.Dispose();
        }

        private void SerializeChunk(BitWriter writer, ChunkBase chunkBase)
        {
            if (chunkBase == default) return;

            chunkBase.DataVersion = 1;
            chunkBase.HeaderVersion = 1;
            
            using var token = new LengthToken(writer);
            
            switch (chunkBase)
            {
                case LevelEnvironmentConfig _:
                    LevelInfo.EnvironmentPointer.Dispose();
                    break;
                case LevelObjects _:
                    LevelInfo.ObjectsPointer.Dispose();
                    break;
                case LevelSkyConfig _:
                    LevelInfo.SkyBoxPointer.Dispose();
                    break;
            }
                
            writer.Write(ChunkHeader);

            writer.Write(chunkBase.ChunkType);

            writer.Write(chunkBase.HeaderVersion);

            writer.Write(chunkBase.DataVersion);
                
            token.Allocate();

            using (new PointerToken(writer))
            {
                while (writer.BaseStream.Position % 16 != 0)
                {
                    writer.Write<byte>(0xCD);
                }
            }

            chunkBase.Serialize(writer);
                
            while (writer.BaseStream.Position % 16 != 0)
            {
                writer.Write<byte>(0xCD);
            }
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

                var headerVersion = reader.Read<ushort>();

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
                            DataVersion = index,
                            HeaderVersion = headerVersion
                        };
                        
                        chunk1000.Deserialize(reader);

                        LvlVersion = chunk1000.LvlVersion;

                        LevelInfo = chunk1000;
                        break;
                    case 2000:
                        var chunk2000 = new LevelSkyConfig
                        {
                            DataVersion = index,
                            HeaderVersion = headerVersion
                        };

                        chunk2000.Deserialize(reader);

                        LevelSkyConfig = chunk2000;
                        break;
                    case 2001:
                        var chunk2001 = new LevelObjects(LvlVersion)
                        {
                            DataVersion = index,
                            HeaderVersion = headerVersion
                        };

                        chunk2001.Deserialize(reader);

                        LevelObjects = chunk2001;
                        break;
                    case 2002:
                        var chunk2002 = new LevelEnvironmentConfig(LevelInfo.LvlVersion)
                        {
                            DataVersion = index,
                            HeaderVersion = headerVersion
                        };

                        chunk2002.Deserialize(reader);

                        LevelEnvironmentConfig = chunk2002;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"{chunkType} is not a valid chunk type.");
                }

                reader.BaseStream.Position = startPosition + chunkLength;
            }
        }

        public void ConvertToOld(ushort version = 39)
        {
            OldLevelHeader = new OldLevelHeader {LvlVersion = version, SkyBox = LevelSkyConfig.Skybox};
        }

        public void ConvertToNew(ushort version = 39)
        {
            var header = OldLevelHeader;

            OldLevelHeader = default;
            
            LevelInfo = new LevelInfo
            {
                LvlVersion = header.LvlVersion,
                RevisionNumber = header.Revision
            };

            if (header.SkyBox?.Length > 0)
            {
                LevelSkyConfig = new LevelSkyConfig
                {
                    Skybox = header.SkyBox
                };
            }

            if (LevelObjects.Templates.Length == 0)
            {
                LevelObjects = default;
            }
            
            LevelEnvironmentConfig = default;
        }
    }
}