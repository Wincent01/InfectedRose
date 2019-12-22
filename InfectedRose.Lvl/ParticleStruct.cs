using System;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class ParticleStruct : IConstruct
    {
        public byte[] UnknownByteArray0 { get; set; } = new byte[2];
        
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; }
        
        public string ParticleName { get; set; }

        public byte[] UnknownByteArray1 { get; set; } = new byte[4];
        
        public void Serialize(BitWriter writer)
        {
            writer.Write(UnknownByteArray0);

            writer.Write(Position);

            writer.WriteNiQuaternion(Rotation);

            writer.WriteNiString(ParticleName, true);

            writer.Write(UnknownByteArray1);
        }

        public void Deserialize(BitReader reader)
        {
            UnknownByteArray0 = reader.ReadBuffer(2);

            Position = reader.Read<Vector3>();

            Rotation = reader.ReadNiQuaternion();

            var position = reader.BaseStream.Position;

            try
            {
                ParticleName = reader.ReadNiString(true);
            }
            catch
            {
                reader.BaseStream.Position = position + 4;
            }

            UnknownByteArray1 = reader.ReadBuffer(4);
        }
    }
}