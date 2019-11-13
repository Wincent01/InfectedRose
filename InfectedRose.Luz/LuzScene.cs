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
        
        public byte SceneId { get; set; }
        
        public bool IsAudioScene { get; set; }
        
        public string SceneName { get; set; }
        
        public byte[] UnknownByteArray0 { get; set; } = new byte[3];
        
        public byte[] UnknownByteArray1 { get; set; } = new byte[3];
        
        public byte[] UnknownByteArray2 { get; set; } = new byte[3];

        public void Serialize(BitWriter writer)
        {
            writer.WriteNiString(FileName, false, true);

            writer.Write(SceneId);
            
            writer.Write(UnknownByteArray0);
            
            writer.Write((byte) (IsAudioScene ? 1 : 0));
            
            writer.Write(UnknownByteArray1);

            writer.WriteNiString(SceneName, false, true);

            writer.Write(UnknownByteArray2);
        }

        public void Deserialize(BitReader reader)
        {
            FileName = reader.ReadNiString(false, true);

            SceneId = reader.Read<byte>();

            UnknownByteArray0 = reader.ReadBuffer(3);
            
            IsAudioScene = reader.Read<byte>() != 0;
            
            UnknownByteArray1 = reader.ReadBuffer(3);

            SceneName = reader.ReadNiString(false, true);
            
            UnknownByteArray2 = reader.ReadBuffer(3);
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}