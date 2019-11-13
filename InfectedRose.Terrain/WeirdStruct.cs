using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Terrain
{
    public class WeirdStruct : IConstruct
    {
        public int Type { get; set; }
        
        public Vector3 Position { get; set; }
        
        public Quaternion Rotation { get; set; }
        
        public uint UnknownInt { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(Type);

            writer.Write(Rotation.W);

            writer.Write(Position);

            writer.Write(Rotation.X);
            writer.Write(Rotation.Y);
            writer.Write(Rotation.Z);

            writer.Write(UnknownInt);
        }

        public void Deserialize(BitReader reader)
        {
            Type = reader.Read<int>();

            var rotW = reader.Read<float>();

            Position = reader.Read<Vector3>();
            
            Rotation = new Quaternion
            {
                X = reader.Read<float>(),
                Y = reader.Read<float>(),
                Z = reader.Read<float>(),
                W = rotW
            };

            UnknownInt = reader.Read<uint>();
        }
    }
}