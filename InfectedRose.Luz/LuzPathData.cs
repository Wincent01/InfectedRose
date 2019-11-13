using System;
using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    [Serializable]
    public class LuzPathData : IConstruct
    {
        public uint Version { get; set; }
        
        public string PathName { get; set; }
        
        public uint UnknownInt { get; set; }
        
        public PathType Type { get; set; }
        
        public PathBehavior Behavior { get; set; }
        
        public LuzPathWaypoint[] Waypoints { get; set; }
        
        public LuzPathData(uint version)
        {
            Version = version;
        }

        public virtual void Serialize(BitWriter writer)
        {
            writer.Write((uint) Behavior);
        }

        public virtual void Deserialize(BitReader reader)
        {
            Behavior = (PathBehavior) reader.Read<uint>();
        }
    }
}