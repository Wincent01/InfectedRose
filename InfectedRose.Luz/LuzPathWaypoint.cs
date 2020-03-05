using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzPathWaypoint : IConstruct
    {
        public Vector3 Position { get; set; }

        public uint Version { get; set; }

        public LuzPathWaypoint(uint version)
        {
            Version = version;
        }
        
        public virtual void Serialize(BitWriter writer)
        {
            writer.Write(Position);
        }

        public virtual void Deserialize(BitReader reader)
        {
            Position = reader.Read<Vector3>();
        }
    }
}