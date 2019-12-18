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

        public IdStruct[] UnknownStructArray { get; set; } = new IdStruct[0];

        public float[] UnknownFloatArray { get; set; } = new float[12];
        
        public float[] UnknownFloatArray1 { get; set; } = new float[12];

        public float[] UnknownFloatArray2 { get; set; } = new float[2];
        
        public float[] UnknownFloatArray3 { get; set; } = new float[3];
        
        public float[] UnknownFloatArray4 { get; set; } = new float[3];
        
        public float[] UnknownFloatArray5 { get; set; } = new float[4];

        public Vector3 UnknownVector3 { get; set; }

        public string[] SkyBox { get; set; } = new string[6];
        
        public uint UnknownInt { get; set; }
        
        public uint UnknownInt1 { get; set; }

        public Vector3[] UnknownVectorArray { get; set; } = new Vector3[0];
        
        public void Serialize(BitWriter writer)
        {
            writer.Write(LvlVersion);
            
            writer.Write(LvlVersion);

            writer.Write<byte>(0);

            if (LvlVersion >= 37)
            {
                writer.Write(Revision);
            }

            if (LvlVersion >= 45)
            {
                writer.Write(UnknownFloat);
            }

            writer.Write(UnknownFloatArray);

            if (LvlVersion >= 31)
            {
                if (LvlVersion >= 39)
                {
                    writer.Write(UnknownFloatArray1);
                    
                    if (LvlVersion >= 40)
                    {
                        writer.Write((uint) UnknownStructArray.Length);

                        foreach (var unknownStruct in UnknownStructArray)
                        {
                            unknownStruct.Serialize(writer);
                        }
                    }
                }
                else
                {
                    writer.Write(UnknownFloatArray2);
                }

                writer.Write(UnknownFloatArray3);
            }

            if (LvlVersion >= 36)
            {
                writer.Write(UnknownFloatArray4);
            }

            if (LvlVersion < 42)
            {
                writer.Write(UnknownVector3);

                if (LvlVersion >= 33)
                {
                    writer.Write(UnknownFloatArray5);
                }
            }

            foreach (var sky in SkyBox)
            {
                writer.WriteNiString(sky ?? "(invalid)");
            }

            writer.Write(UnknownInt);

            if (LvlVersion > 36)
            {
                writer.Write((uint) UnknownVectorArray.Length);

                writer.Write(UnknownVectorArray);
            }
            else
            {
                writer.Write(UnknownInt1);
            }
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
                UnknownFloat = reader.Read<float>();
            }

            for (var i = 0; i < 12; i++)
            {
                UnknownFloatArray[i] = reader.Read<float>();
            }
            
            if (LvlVersion >= 31)
            {
                if (LvlVersion >= 39)
                {
                    for (var i = 0; i < 12; i++)
                    {
                        UnknownFloatArray1[i] = reader.Read<float>();
                    }

                    if (LvlVersion >= 40)
                    {
                        UnknownStructArray = new IdStruct[reader.Read<uint>()];

                        for (var i = 0; i < UnknownStructArray.Length; i++)
                        {
                            var unknownStruct = new IdStruct();

                            unknownStruct.Deserialize(reader);

                            UnknownStructArray[i] = unknownStruct;
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < 2; i++)
                    {
                        UnknownFloatArray2[i] = reader.Read<float>();
                    }
                }

                for (var i = 0; i < 3; i++)
                {
                     UnknownFloatArray3[i] = reader.Read<float>();
                }
            }

            if (LvlVersion >= 36)
            {
                for (var i = 0; i < 3; i++)
                {
                    UnknownFloatArray4[i] = reader.Read<float>();
                }
            }

            if (LvlVersion < 42)
            {
                UnknownVector3 = reader.Read<Vector3>();

                if (LvlVersion >= 33)
                {
                    for (var i = 0; i < 4; i++)
                    {
                        UnknownFloatArray5[i] = reader.Read<float>();
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
                UnknownVectorArray = new Vector3[reader.Read<uint>()];

                for (var i = 0; i < UnknownVectorArray.Length; i++)
                {
                    UnknownVectorArray[i] = reader.Read<Vector3>();
                }
            }
            else
            {
                UnknownInt1 = reader.Read<uint>();
            }
        }
    }
}