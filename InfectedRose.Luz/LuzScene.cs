using System;
using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    [Serializable]
    public class LuzScene : IConstruct
    {
        public string FileName { get; set; }
        
        public uint SceneId { get; set; }
        
        public uint LayerId { get; set; }
        
        public string SceneName { get; set; }

        public byte[] UnknownByteArray { get; set; } = new byte[3];

        public void Serialize(BitWriter writer)
        {
            writer.WriteNiString(FileName, false, true);

            writer.Write(SceneId);

            writer.Write(LayerId);

            writer.WriteNiString(SceneName, false, true);

            writer.Write(UnknownByteArray);
        }

        public void Deserialize(BitReader reader)
        {
            FileName = reader.ReadNiString(false, true);

            SceneId = reader.Read<uint>();

            LayerId = reader.Read<uint>();

            SceneName = reader.ReadNiString(false, true);
            
            UnknownByteArray = reader.ReadBuffer(3);
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}