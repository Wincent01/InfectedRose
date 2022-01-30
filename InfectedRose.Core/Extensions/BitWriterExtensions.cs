using System.Collections.Generic;
using System.Numerics;
using RakDotNet.IO;

namespace InfectedRose.Core
{
    public static class BitWriterExtensions
    {
        public static void WriteNiString(this BitWriter @this, string str, bool wide = false, bool small = false)
        {
            if (small) @this.Write((byte) str.Length);
            else @this.Write((uint) str.Length);

            foreach (var c in str)
            {
                if (wide) @this.Write((ushort) c);
                else @this.Write((byte) c);
            }
        }
        
        public static void WriteLwoString(this BitWriter @this, string val, int length = 33, bool wide = false)
        {
            foreach (var c in val)
            {
                if (wide) @this.Write((short) c);
                else @this.Write((byte) c);
            }

            Write(@this, new byte[(length - val.Length) * (wide ? sizeof(char) : sizeof(byte))]);
        }

        public static void WriteNiQuaternion(this BitWriter @this, Quaternion quaternion)
        {
            @this.Write(quaternion.W);
            @this.Write(quaternion.X);
            @this.Write(quaternion.Y);
            @this.Write(quaternion.Z);
        }

        public static void Write(this BitWriter @this, byte[] buffer)
        {
            foreach (var value in buffer)
            {
                @this.Write(value);
            }
        }

        public static void Write<T>(this BitWriter @this, ICollection<T> collection) where T : unmanaged
        {
            foreach (var value in collection)
            {
                @this.Write(value);
            }
        }

        public static void Write(this BitWriter @this, ISerializable serializable)
        {
            serializable.Serialize(@this);
        }
    }
}