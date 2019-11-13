using System.IO;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzPropertyPath : LuzPathData
    {
        public int UnknownInt0 { get; set; }
        
        public int UnknownInt1 { get; set; }
        
        public int Price { get; set; }
        
        public int RentalTime { get; set; }
        
        public ulong AssociatedZone { get; set; }
        
        public string DisplayName { get; set; }
        
        public string DisplayDescription { get; set; }
        
        public int CloneLimit { get; set; }
        
        public float ReputationMultiplier { get; set; }
        
        public RentalTimeUnit TimeUnit { get; set; }
        
        public AchievementRequired Achievement { get; set; }
        
        public Vector3 PlayerZonePoint { get; set; }
        
        public float MaxBuildHeight { get; set; }

        public LuzPropertyPath(uint version) : base(version)
        {
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(UnknownInt0);

            writer.Write(Price);

            writer.Write(RentalTime);

            writer.Write(AssociatedZone);
            
            writer.WriteNiString(DisplayName, true, true);

            writer.WriteNiString(DisplayDescription, true);

            writer.Write(UnknownInt1);

            writer.Write(CloneLimit);

            writer.Write(ReputationMultiplier);

            writer.Write((int) TimeUnit);

            writer.Write((int) Achievement);

            writer.Write(PlayerZonePoint);

            writer.Write(MaxBuildHeight);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            UnknownInt0 = reader.Read<int>();

            Price = reader.Read<int>();

            RentalTime = reader.Read<int>();

            AssociatedZone = reader.Read<ulong>();

            DisplayName = reader.ReadNiString(true, true);
            
            DisplayDescription = reader.ReadNiString(true);
            
            UnknownInt1 = reader.Read<int>();

            CloneLimit = reader.Read<int>();

            ReputationMultiplier = reader.Read<float>();

            TimeUnit = (RentalTimeUnit) reader.Read<int>();

            Achievement = (AchievementRequired) reader.Read<int>();

            PlayerZonePoint = reader.Read<Vector3>();

            MaxBuildHeight = reader.Read<float>();
        }
    }
}