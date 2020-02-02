using System.Numerics;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiRangeLODData : NiLODData
    {
        public Vector3 Center { get; set; }
        
        public LODRange[] Ranges { get; set; }
        
        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.Write(Center);

            writer.Write((uint) Ranges.Length);

            foreach (var range in Ranges)
            {
                writer.Write(range);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            Center = reader.Read<Vector3>();

            Ranges = new LODRange[reader.Read<uint>()];

            for (var i = 0; i < Ranges.Length; i++)
            {
                Ranges[i] = reader.Read<LODRange>();
            }
        }
    }
}