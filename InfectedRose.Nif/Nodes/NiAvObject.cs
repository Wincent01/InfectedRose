using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiAvObject : NiObjectNet
    {
        public ushort Flags { get; set; }
        
        public Vector3 Position { get; set; }
        
        public Matrix3X3 Rotation { get; set; }
        
        public float Scale { get; set; }
        
        public NiRef<NiProperty>[] Properties { get; set; }
        
        public NiRef<NiCollisionObject> CollisionObject { get; set; }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.Write(Flags);

            writer.Write(Position);

            writer.Write(Rotation);

            writer.Write(Scale);

            writer.Write((uint) Properties.Length);

            foreach (var property in Properties)
            {
                writer.Write(property);
            }

            writer.Write(CollisionObject);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Flags = reader.Read<ushort>();

            Position = reader.Read<Vector3>();

            Rotation = reader.Read<Matrix3X3>();

            Scale = reader.Read<float>();
            
            Properties = new NiRef<NiProperty>[reader.Read<uint>()];

            for (var i = 0; i < Properties.Length; i++)
            {
                Properties[i] = reader.Read<NiRef<NiProperty>>(File);
            }

            CollisionObject = reader.Read<NiRef<NiCollisionObject>>(File);
        }
    }
}