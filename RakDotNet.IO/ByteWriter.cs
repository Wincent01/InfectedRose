using System.IO;
using RakDotNet.IO;

namespace RakDotNet.IO
{
    public class ByteWriter : BitWriter
    {
        public ByteWriter(Stream stream, Endianness endianness = Endianness.LittleEndian, bool orderLocked = true, bool leaveOpen = false) : base(stream, endianness, orderLocked, leaveOpen)
        {
        }

        public override int Write(byte[] buf, int bits)
        {
            var bytes = bits / 8;
            
            BaseStream.Write(buf, 0, bytes);
            
            return bits;
        }

        public override int Write<T>(T val, int bits)
        {
            unsafe
            {
                var buffer = (byte*) &val;
                
                for (var i = 0; i < sizeof(T); ++i)
                {
                    BaseStream.WriteByte(buffer[i]);
                }

                return bits;
            }
        }
        
        public override int Write<T>(T val)
        {
            unsafe
            {
                return Write(val, sizeof(T) * 8);
            }
        }
    }
}