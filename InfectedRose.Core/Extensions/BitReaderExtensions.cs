using System;
using System.Numerics;
using RakDotNet.IO;

namespace InfectedRose.Core
{
    public static class BitReaderExtensions
    {
        public static string ReadNiString(this BitReader @this, bool wide = false, bool small = false)
        {
            var len = small ? @this.Read<byte>() : @this.Read<uint>();
            var str = new char[len];

            for (var i = 0; i < len; i++)
            {
                str[i] = (char) (wide ? @this.Read<ushort>() : @this.Read<byte>());
            }


            return new string(str);
        }

        public static Quaternion ReadNiQuaternion(this BitReader @this)
        {
            return new Quaternion
            {
                W = @this.Read<float>(),
                X = @this.Read<float>(),
                Y = @this.Read<float>(),
                Z = @this.Read<float>()
            };
        }

        public static byte[] ReadBuffer(this BitReader @this, uint length)
        {
            var buffer = new byte[length];

            for (var i = 0; i < length; i++)
            {
                buffer[i] = @this.Read<byte>();
            }

            return buffer;
        }

        public static T Read<T>(this BitReader @this) where T : IDeserializable
        {
            var instance = Activator.CreateInstance<T>();
            
            instance.Deserialize(@this);

            return instance;
        }
    }
}