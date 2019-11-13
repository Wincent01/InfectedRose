using System;
using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class LevelSkyConfig : ChunkBase
    {
        public IdStruct[] Identifiers { get; set; }

        public string[] SkyFilesPaths { get; set; } = new string[6];
        
        public float[] UnknownFloatArray0 { get; set; }

        public float[] UnknownFloatArray1 { get; set; } = new float[3];

        public float[] UnknownFloatArray2 { get; set; } = new float[3];
        
        public byte[] UnknownSectionData { get; set; }

        public override uint ChunkType => 2000;
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write(8);

            // TODO: Add UnknownFloatArray0?
            
            var addressPosition = writer.BaseStream.Position;

            writer.BaseStream.Position += 8;

            writer.Write((uint) Identifiers.Length);

            foreach (var identifier in Identifiers)
            {
                identifier.Serialize(writer);
            }

            for (var i = 0; i < 3; i++)
            {
                writer.Write(UnknownFloatArray1[i]);
            }
            
            for (var i = 0; i < 3; i++)
            {
                writer.Write(UnknownFloatArray2[i]);
            }

            var skySectionAddress = writer.BaseStream.Position;

            writer.Write(WriteSkySection());

            var otherSectionAddress = writer.BaseStream.Position;

            writer.Write(WriteOtherSection());

            writer.BaseStream.Position = addressPosition;

            writer.Write((uint) skySectionAddress);

            writer.Write((uint) otherSectionAddress);

            writer.BaseStream.Position = otherSectionAddress + 4;
        }

        private byte[] WriteSkySection()
        {
            using var stream = new MemoryStream();
            using var writer = new BitWriter(stream);

            for (var i = 0; i < 6; i++)
            {
                writer.WriteNiString(SkyFilesPaths[i]);
            }

            return stream.ToArray();
        }

        private byte[] WriteOtherSection()
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);

            writer.Write(0u);

            return stream.ToArray();
        }

        public override void Deserialize(BitReader reader)
        {
            var sizeOfData = reader.Read<uint>();

            var skySectionAddress = reader.Read<uint>();
            
            var otherSectionAddress = reader.Read<uint>();

            UnknownFloatArray0 = new float[(sizeOfData - 8) / 4];
            
            for (var i = 0; i < UnknownFloatArray0.Length; i++)
            {
                UnknownFloatArray0[i] = reader.Read<float>();
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
                UnknownFloatArray1[i] = reader.Read<float>();
            }
            
            for (var i = 0; i < 3; i++)
            {
                UnknownFloatArray2[i] = reader.Read<float>();
            }

            reader.BaseStream.Position = skySectionAddress;
            
            for (var i = 0; i < 6; i++)
            {
                SkyFilesPaths[i] = reader.ReadNiString();
            }

            reader.BaseStream.Position = otherSectionAddress;

            UnknownSectionData = reader.ReadBuffer(reader.Read<uint>());
        }
    }
}