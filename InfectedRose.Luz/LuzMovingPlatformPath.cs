using System;
using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzMovingPlatformPath : LuzPathData
    {
        public string MovingPlatformSound { get; set; }
        
        public bool TimeBased { get; set; }
        
        public LuzMovingPlatformPath(uint version) : base(version)
        {
        }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            if (Version >= 18)
                writer.Write((byte) (TimeBased ? 1 : 0));
            else if (Version >= 13)
                writer.WriteNiString(MovingPlatformSound, true, true);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            if (Version >= 18)
                TimeBased = reader.Read<byte>() != 0;
            else if (Version >= 13)
                MovingPlatformSound = reader.ReadNiString(true, true);
        }
    }
}