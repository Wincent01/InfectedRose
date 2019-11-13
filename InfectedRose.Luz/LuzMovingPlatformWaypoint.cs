using System;
using System.IO;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzMovingPlatformWaypoint : LuzPathWaypoint
    {
        public Quaternion Rotation { get; set; }
        
        public bool LockPlayer { get; set; }
        
        public float Speed { get; set; }
        
        public float Wait { get; set; }

        public string DepartSound { get; set; }
        
        public string ArriveSound { get; set; }
        
        public LuzMovingPlatformWaypoint(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.WriteNiQuaternion(Rotation);
            
            writer.Write((byte) (LockPlayer ? 1 : 0));

            writer.Write(Speed);

            writer.Write(Wait);

            if (Version < 13) return;
            
            writer.WriteNiString(DepartSound, true, true);

            writer.WriteNiString(ArriveSound, true, true);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Rotation = reader.ReadNiQuaternion();

            LockPlayer = reader.Read<byte>() != 0;

            Speed = reader.Read<float>();

            Wait = reader.Read<float>();

            if (Version < 13) return;

            DepartSound = reader.ReadNiString(true, true);

            ArriveSound = reader.ReadNiString(true, true);
            
            Console.WriteLine($"{DepartSound} -> {ArriveSound}");
        }
    }
}