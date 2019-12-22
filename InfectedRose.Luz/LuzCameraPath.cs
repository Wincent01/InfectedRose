using System;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzCameraPath : LuzPathData
    {
        public string NextPath { get; set; }
        
        public bool UnknownBool { get; set; }

        public LuzCameraPath(uint version) : base(version)
        {
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.WriteNiString(NextPath, true, true);

            if (Version >= 14)
                writer.Write((byte) (UnknownBool ? 1 : 0));
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            NextPath = reader.ReadNiString(true, true);

            if (Version >= 14)
                UnknownBool = reader.Read<byte>() != 0;
        }
    }
}