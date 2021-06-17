using System;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz.Extensions
{
    public static class LegoDataDictionaryExtensions
    {
        /// <summary>
        /// Build a LegoDataDictionary from path config values. Path configs have a different serialization than LDF in
        /// Lvl files has.
        /// </summary>
        /// <remarks>
        /// Some config entries have no type defined, for example `pathspeed=0.8` or `delay=5`.
        /// This code tries to interpret those values first as an int, then as a float, and if
        /// neither succeeds, stores it as a string.
        /// </remarks>
        /// <seealso cref="SerializePathConfigs"/>
        public static void DeserializePathConfigs(this LegoDataDictionary @this, BitReader reader)
        {
            var configCount = reader.Read<uint>();

            for (var i = 0; i < configCount; i++)
            {
                var key = reader.ReadNiString(true, true);
                var typeAndValue = reader.ReadNiString(true, true);
                var firstColon = typeAndValue.IndexOf(':');
                if (firstColon == -1)
                {
                    if (int.TryParse(typeAndValue, out var intValue))
                        @this.Add(key, intValue);
                    else if (float.TryParse(typeAndValue, out var floatVal))
                        @this.Add(key, floatVal);
                    else
                        @this.Add(key, typeAndValue);

                    continue;
                }
                var type = int.Parse(typeAndValue[..firstColon]);
                var val = typeAndValue[(firstColon + 1)..];
                @this.Add(key, type, val);
            }
        }

        /// <summary>
        /// Serialize a LegoDataDictionary as path configs.
        /// </summary>
        /// <remarks>
        /// The output of this includes the type that entries like `pathspeed=0.8` were parsed as.
        /// </remarks>
        /// <seealso cref="DeserializePathConfigs"/>
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
