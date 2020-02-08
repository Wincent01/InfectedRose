using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiGeometry : NiAvObject
    {
        public NiRef<NiGeometryData> Data { get; set; }
        
        public NiRef<NiSkinInstance> Skin { get; set; }
        
        public string[] Materials { get; set; }
        
        public NiRef<NiExtraData>[] MaterialExtraData { get; set; }
        
        public int ActiveMaterial { get; set; }
        
        public bool Dirty { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            Data = reader.Read<NiRef<NiGeometryData>>(File);

            Skin = reader.Read<NiRef<NiSkinInstance>>(File);

            Materials = new string[reader.Read<uint>()];

            MaterialExtraData = new NiRef<NiExtraData>[Materials.Length];

            for (var i = 0; i < Materials.Length; i++)
            {
                Materials[i] = reader.ReadNiString();

                MaterialExtraData[i] = reader.Read<NiRef<NiExtraData>>(File);
            }

            ActiveMaterial = reader.Read<int>();

            Dirty = reader.Read<byte>() != 0;
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(Data);

            writer.Write(Skin);

            writer.Write((uint) Materials.Length);

            for (var i = 0; i < Materials.Length; i++)
            {
                writer.WriteNiString(Materials[i]);

                writer.Write(MaterialExtraData[i]);
            }

            writer.Write(ActiveMaterial);

            writer.Write((byte) (Dirty ? 1 : 0));
        }
    }
}