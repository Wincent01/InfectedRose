using System.IO;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzCameraWaypoint : LuzPathWaypoint
    {
        public Quaternion Rotation { get; set; }
        
        public float Time { get; set; }
        
        public float Tension { get; set; }
        
        public float Continuity { get; set; }
        
        public float Bias { get; set; }
        
        public float FieldOfView { get; set; }

        public LuzCameraWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.WriteNiQuaternion(Rotation);

            writer.Write(Time);

            writer.Write(FieldOfView);
            
            writer.Write(Tension);

            writer.Write(Continuity);

            writer.Write(Bias);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Rotation = reader.ReadNiQuaternion();

            Time = reader.Read<float>();

            FieldOfView = reader.Read<float>();

            Tension = reader.Read<float>();

            Continuity = reader.Read<float>();

            Bias = reader.Read<float>();
        }
    }
}