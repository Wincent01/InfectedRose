using System.IO;
using RakDotNet.IO;

namespace RakDotNet.IO
{
    public class ByteReader : BitReader
    {
        public ByteReader(Stream stream, Endianness endianness = Endianness.LittleEndian, bool orderLocked = true, bool leaveOpen = false) : base(stream, endianness, orderLocked, leaveOpen)
        {
        }

        public override int Read(byte[] buf, int bits)
        {
            var bytes = bits / 8;
            
            for (var i = 0; i < bytes; i++)
            {
                buf[i] = (byte) BaseStream.ReadByte();
            }

            return bits;
        }

        public override T Read<T>(int bits)
        {
            unsafe
            {
                var buffer = stackalloc byte[sizeof(T)];

                for (var i = 0; i < sizeof(T); ++i)
                {
                    buffer[i] = (byte) BaseStream.ReadByte();
                }

                return *(T*) buffer;
            }
        }
        
        public override T Read<T>()
        {
            unsafe
            {
                return Read<T>(sizeof(T) * 8);
            }
        }
    }
}