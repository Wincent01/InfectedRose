using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class ParticleStruct : IConstruct
    {
        public ushort Priority { get; set; }
        
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; }
        
        public string ParticleName { get; set; }
        
        public string Config { get; set; } // ???
        
        public uint Version { get; set; }
        
        public ParticleStruct(uint version)
        {
            Version = version;
        }
        
        public void Serialize(BitWriter writer)
        {
            if (Version >= 43)
            {
                writer.Write(Priority);
            }

            writer.Write(Position);

            writer.WriteNiQuaternion(Rotation);

            writer.WriteNiString(ParticleName, true);
            
            if (Version < 46)
            {
                writer.Write<ushort>(0);
            }
            
            writer.WriteNiString(Config, true);
        }

        public void Deserialize(BitReader reader)
        {
            if (Version >= 43)
            {
                Priority = reader.Read<ushort>();
            }
            
            Position = reader.Read<Vector3>();

            Rotation = reader.ReadNiQuaternion();

            ParticleName = reader.ReadNiString(true);

            if (Version < 46)
            {
                reader.Read<ushort>();
            }
            
            Config = reader.ReadNiString(true);
        }
    }
}