using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzRaceWaypoint : LuzPathWaypoint
    {
        public Quaternion Rotation { get; set; }
        
        public byte[] UnknownBytes { get; set; }
        
        public Vector3 UnknownVector { get; set; }
        
        public LuzRaceWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.WriteNiQuaternion(Rotation);

            writer.Write(UnknownBytes);

            writer.Write(UnknownVector);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            Rotation = reader.ReadNiQuaternion();

            UnknownBytes = reader.ReadBuffer(2);

            UnknownVector = reader.Read<Vector3>();
        }
    }
}