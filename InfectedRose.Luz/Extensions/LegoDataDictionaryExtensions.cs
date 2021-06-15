using InfectedRose.Core;
using RakDotNet.IO;
using BitWriterExtensions = InfectedRose.Core.BitWriterExtensions;
using BitReaderExtensions = InfectedRose.Core.BitReaderExtensions;
using LegoDataDictionary = InfectedRose.Core.LegoDataDictionary;

namespace InfectedRose.Luz.Extensions
{
    public static class LegoDataDictionaryExtensions
    {
        public static void DeserializePathConfigs(this LegoDataDictionary @this, BitReader reader)
        {
            var configCount = reader.Read<uint>();

            for (var i = 0; i < configCount; i++)
            {
                var key = BitReaderExtensions.ReadNiString(reader, true, true);
                var typeAndValue = BitReaderExtensions.ReadNiString(reader, true, true);
                var firstColon = typeAndValue.IndexOf(':');
                var type = int.Parse(typeAndValue[..firstColon]);
                var val = typeAndValue[(firstColon + 1)..];
                @this.Add(key, type, val);
            }
        }

        public static void SerializePathConfigs(this LegoDataDictionary @this, BitWriter writer)
        {
            writer.Write((uint) @this.Count);

            foreach (var (key, value) in @this)
            {
                var type =
                    value is int ? 1 :
                    value is float ? 3 :
                    value is double ? 4 :
                    value is uint ? 5 :
                    value is bool ? 7 :
                    value is long ? 8 :
                    value is byte[] ? 13 : 0;

                writer.WriteNiString(key, true, true);
                writer.WriteNiString(type + ":" + value, true, true);
            }
        }
    }
}
