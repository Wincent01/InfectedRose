using InfectedRose.Nif.Controllers;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiObjectNet : NiObject
    {
        public NiStringRef Name { get; set; }
        
        public NiRef<NiExtraData>[] ExtraData { get; set; }
        
        public NiRef<NiTimeController> Controller { get; set; }
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(Name);

            writer.Write((uint) ExtraData.Length);

            foreach (var extra in ExtraData)
            {
                writer.Write(extra);
            }

            writer.Write(Controller);
        }

        public override void Deserialize(BitReader reader)
        {
            Name = reader.Read<NiStringRef>(File);

            ExtraData = new NiRef<NiExtraData>[reader.Read<uint>()];

            for (var i = 0; i < ExtraData.Length; i++)
            {
                ExtraData[i] = reader.Read<NiRef<NiExtraData>>(File);
            }

            Controller = reader.Read<NiRef<NiTimeController>>(File);
        }
    }
}