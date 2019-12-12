using System;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Lvl.Old
{
    public class OldLevelHeader : IConstruct
    {
        public ushort LvlVersion { get; set; }
        
        public uint Revision { get; set; }

        public float UnknownFloat { get; set; } = 10f;

        public byte[][] UnknownByteArrays { get; set; } = {
            new byte[12],
            new byte[12],
            new byte[12]
        };
        
        public float[] UnknownFloats { get; set; } = new float[12];
        
        public OldUnknownStruct[] UnknownStructs { get; set; }

        public float[] UnknownFloats1 { get; set; } = new float[2];
        
        public byte[] UnknownByteArray { get; set; } = new byte[12];
        
        public byte[] UnknownByteArray1 { get; set; } = new byte[12];
        
        public Vector3 UnknownVector3 { get; set; }
        
        public byte[] UnknownByteArray2 { get; set; } = new byte[16];

        public string[] SkyBox { get; set; } = new string[6];
        
        public uint UnknownInt { get; set; }
        
        public uint UnknownInt1 { get; set; }
        
        public Vector3[] UnknownVectors { get; set; }
        
        public void Serialize(BitWriter writer)
        {
            
        }

        public void Deserialize(BitReader reader)
        {
            LvlVersion = reader.Read<ushort>();

            var checkVersion = reader.Read<ushort>();

            if (LvlVersion != checkVersion)
            {
                throw new Exception($"Version {LvlVersion} does not match {checkVersion}");
            }

            reader.Read<byte>();

            if (LvlVersion >= 37)
            {
                Revision = reader.Read<uint>();
            }

            if (LvlVersion >= 45)
            {
                if (reader.ReadBit())
                {
                    UnknownFloat = reader.Read<float>();
                }
            }

            for (var i = 0; i < 4 * 3; i++)
            {
                reader.Read<float>();
            }
            
            if (LvlVersion >= 31)
            {
                if (LvlVersion >= 39)
                {
                    for (var i = 0; i < 12; i++)
                    {
                        UnknownFloats[i] = reader.Read<float>();
                    }

                    if (LvlVersion >= 40)
                    {
                        UnknownStructs = new OldUnknownStruct[reader.Read<uint>()];

                        for (var i = 0; i < UnknownStructs.Length; i++)
                        {
                            var unknownStruct = new OldUnknownStruct();

                            unknownStruct.Deserialize(reader);

                            UnknownStructs[i] = unknownStruct;
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < 2; i++)
                    {
                        UnknownFloats1[i] = reader.Read<float>();
                    }
                }

                for (var i = 0; i < 3; i++)
                {
                    reader.Read<float>();
                }
            }

            if (LvlVersion >= 36)
            {
                for (var i = 0; i < 3; i++)
                {
                    reader.Read<float>();
                }
            }

            if (LvlVersion < 42)
            {
                UnknownVector3 = reader.Read<Vector3>();

                if (LvlVersion >= 33)
                {
                    for (var i = 0; i < 4; i++)
                    {
                        reader.Read<float>();
                    }
                }
            }

            for (var i = 0; i < 6; i++)
            {
                SkyBox[i] = reader.ReadNiString();
            }

            UnknownInt = reader.Read<uint>();
            
            if (LvlVersion > 36)
            {
                UnknownVectors = new Vector3[reader.Read<uint>()];

                for (var i = 0; i < UnknownVectors.Length; i++)
                {
                    UnknownVectors[i] = reader.Read<Vector3>();
                }
            }
            else
            {
                UnknownInt1 = reader.Read<uint>();
            }
        }
    }
}