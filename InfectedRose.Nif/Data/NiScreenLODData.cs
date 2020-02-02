using System.Numerics;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiScreenLODData : NiLODData
    {
        public Vector3 BoundCenter { get; set; }
        
        public float BoundRadius { get; set; }
        
        public Vector3 WorldCenter { get; set; }
        
        public float WorldRadius { get; set; }
        
        public float[] Proportions { get; set; }
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(BoundCenter);

            writer.Write(BoundRadius);

            writer.Write(WorldCenter);

            writer.Write(WorldRadius);

            writer.Write((uint) Proportions.Length);

            foreach (var proportion in Proportions)
            {
                writer.Write(proportion);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            BoundCenter = reader.Read<Vector3>();

            BoundRadius = reader.Read<float>();

            WorldCenter = reader.Read<Vector3>();

            WorldRadius = reader.Read<float>();

            Proportions = new float[reader.Read<uint>()];

            for (var i = 0; i < Proportions.Length; i++)
            {
                Proportions[i] = reader.Read<float>();
            }
        }
    }
}