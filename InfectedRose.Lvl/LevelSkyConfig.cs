using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class LevelSkyConfig : ChunkBase
    {
        public IdStruct[] Identifiers { get; set; } = new IdStruct[0];

        public string[] Skybox { get; set; } = new string[6];

        public float[] LightInformation { get; set; } = new float[0];

        public float[] FogColor { get; set; } = new float[3];

        public float[] DirectionalLightColor { get; set; } = new float[3];

        public byte[] SavedColors { get; set; } = new byte[0];

        public override uint ChunkType => 2000;
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write((uint) (8 + LightInformation.Length * 4));

            var skySectionPointer = new PointerToken(writer);

            var otherSectionPointer = new PointerToken(writer);

            foreach (var f in LightInformation)
            {
                writer.Write(f);
            }

            writer.Write((uint) Identifiers.Length);

            foreach (var identifier in Identifiers)
            {
                identifier.Serialize(writer);
            }

            for (var i = 0; i < 3; i++)
            {
                writer.Write(FogColor[i]);
            }
            
            for (var i = 0; i < 3; i++)
            {
                writer.Write(DirectionalLightColor[i]);
            }

            skySectionPointer.Dispose();
            
            writer.Write(WriteSkySection());

            otherSectionPointer.Dispose();

            writer.Write(WriteOtherSection());
        }

        private byte[] WriteSkySection()
        {
            using var stream = new MemoryStream();
            using var writer = new BitWriter(stream);

            for (var i = 0; i < 6; i++)
            {
                writer.WriteNiString(Skybox[i] ?? "(invalid)");
            }

            return stream.ToArray();
        }

        private byte[] WriteOtherSection()
        {
            using var stream = new MemoryStream();
            using var writer = new BitWriter(stream);

            writer.Write((uint) SavedColors.Length);

            writer.Write(SavedColors);

            return stream.ToArray();
        }

        public override void Deserialize(BitReader reader)
        {
            var sizeOfData = reader.Read<uint>();

            var skySectionAddress = reader.Read<uint>();
            
            var otherSectionAddress = reader.Read<uint>();

            LightInformation = new float[(sizeOfData - 8) / 4];
            
            for (var i = 0; i < LightInformation.Length; i++)
            {
                LightInformation[i] = reader.Read<float>();
            }

            Identifiers = new IdStruct[reader.Read<uint>()];

            for (var i = 0; i < Identifiers.Length; i++)
            {
                var idStruct = new IdStruct();
                idStruct.Deserialize(reader);

                Identifiers[i] = idStruct;
            }

            for (var i = 0; i < 3; i++)
            {
                FogColor[i] = reader.Read<float>();
            }
            
            for (var i = 0; i < 3; i++)
            {
                DirectionalLightColor[i] = reader.Read<float>();
            }

            reader.BaseStream.Position = skySectionAddress;
            
            for (var i = 0; i < 6; i++)
            {
                Skybox[i] = reader.ReadNiString();
            }

            reader.BaseStream.Position = otherSectionAddress;

            SavedColors = reader.ReadBuffer(reader.Read<uint>());
        }
    }
}