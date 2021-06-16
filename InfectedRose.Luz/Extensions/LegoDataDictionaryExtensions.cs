using System;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz.Extensions
{
    public static class LegoDataDictionaryExtensions
    {
        public static void DeserializePathConfigs(this LegoDataDictionary @this, BitReader reader)
        {
            var configCount = reader.Read<uint>();

            for (var i = 0; i < configCount; i++)
            {
                var key = reader.ReadNiString(true, true);
                var typeAndValue = reader.ReadNiString(true, true);
                var firstColon = typeAndValue.IndexOf(':');
                var type = int.Parse(typeAndValue[..firstColon]);
                var val = typeAndValue[(firstColon + 1)..];
                @this.Add(key, type, val);
            }
        }

        public static void SerializePathConfigs(this LegoDataDictionary @this, BitWriter writer)
        {
            writer.Write((uint) @this.Count);

            foreach (var (key, type, value) in @this.AsTuples())
            {
                var output = value switch
                {
                    bool b => b ? "1" : "0",
                    Vector2 vec2 => $"{vec2.X}{LegoDataDictionary.InfoSeparator}{vec2.Y}",
                    Vector3 vec3 => $"{vec3.X}{LegoDataDictionary.InfoSeparator}{vec3.Z}{LegoDataDictionary.InfoSeparator}{vec3.Y}",
                    Vector4 vec4 => $"{vec4.X}{LegoDataDictionary.InfoSeparator}{vec4.Z}{LegoDataDictionary.InfoSeparator}{vec4.Y}{LegoDataDictionary.InfoSeparator}{vec4.W}",
                    LegoDataList list => list.ToString(),
                    _ => value.ToString(),
                };

                writer.WriteNiString(key, true, true);
                writer.WriteNiString(type + ":" + output, true, true);
            }
        }
    }
}
