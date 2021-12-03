using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiFile : IConstruct
    {
        public NiHeader Header { get; set; }
        
        public NiObject[] Blocks { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            writer.Write(Header);

            for (var index = 0; index < Blocks.Length; index++)
            {
                var info = Header.NodeInfo[index];

                var current = writer.BaseStream.Position;
                
                var block = Blocks[index];
                writer.Write(block);

                var now = writer.BaseStream.Position;

                var size = now - current;
                
                if (size != info.Size)
                {
                    throw new Exception($"Failed to write {block}, {size}/{info.Size} bytes");
                }
            }
        }

        public void Deserialize(BitReader reader)
        {
            Header = reader.Read<NiHeader>();
        }

        public void ReadBlocks(BitReader reader)
        {
            var type = typeof(NiObject);

            var blockTypes = type.Assembly.GetTypes().Where(
                t => t.IsSubclassOf(type)
            ).ToArray();

            var blocks = Header.NodeInfo.Length;

            Blocks = new NiObject[blocks];

            for (var i = 0; i < blocks; i++)
            {
                var blockInfo = Header.NodeInfo[i];
                var typeName = Header.NodeTypes[blockInfo.TypeIndex];

                var data = reader.ReadBuffer(blockInfo.Size);

                var index = i;
                
                using var stream = new MemoryStream(data);

                using var blockReader = new ByteReader(stream);
                
                var blockType = blockTypes.FirstOrDefault(
                    t => t.Name == typeName
                );

                if (blockType == default)
                {
                    throw new NotImplementedException($"Block \"{typeName}\" is not implemented");
                }

                var instance = (NiObject) Activator.CreateInstance(blockType);

                try
                {
                    instance.Deserialize(blockReader);
                }
                catch (Exception e)
                {
                    throw (Exception) Activator.CreateInstance(e.GetType(), $"Failed to load {blockType.Name}", e);
                }

                Blocks[index] = instance;

                if (stream.Position != stream.Length)
                {
                    throw new Exception(
                        $"Failed to read {typeName}, read {stream.Position}/{stream.Length} bytes"
                    );
                }
            }
        }
    }
}