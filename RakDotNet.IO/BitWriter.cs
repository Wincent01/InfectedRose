#if ENABLE_MONO
#define UNITY
#elif ENABLE_IL2CPP
#define UNITY
#endif

#define UNITY

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RakDotNet.IO
{
    public class BitWriter : IDisposable
    {
        private readonly Stream _stream;
        private readonly bool _leaveOpen;
        private readonly bool _orderLocked;
        private readonly object _lock;

        private Endianness _endianness;
        private bool _disposed;
        private long _pos;

        public virtual Stream BaseStream => _stream;
        public virtual Endianness Endianness
        {
            get => _endianness;
            set
            {
                if (_orderLocked)
                    throw new InvalidOperationException("Endianness is fixed");

                if (value != _endianness)
                {
                    // wait for write operations to complete so we don't mess them up
                    lock (_lock)
                    {
                        _endianness = value;
                    }
                }
            }
        }
        public virtual bool CanChangeEndianness => !_orderLocked;
        public virtual long Position => _pos;

        public BitWriter(Stream stream, Endianness endianness = Endianness.LittleEndian, bool orderLocked = true, bool leaveOpen = false)
        {
            if (!stream.CanWrite)
                throw new ArgumentException("Stream is not writeable", nameof(stream));

            if (!stream.CanRead)
                throw new ArgumentException("Stream is not readable", nameof(stream));

            _stream = stream;
            _leaveOpen = leaveOpen;
            _orderLocked = orderLocked;
            _lock = new object();

            _endianness = endianness;
            _disposed = false;
            _pos = 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_leaveOpen)
                    _stream.Flush();
                else
                    _stream.Close();

                _disposed = true;
            }
        }

        public void Dispose() => Dispose(true);

        
        public virtual void Close() => Dispose(true);

        public virtual void WriteBit(bool bit)
        {
            lock (_lock)
            {
                // offset in bits, in case we're not starting on the 8th (i = 7) bit
                var bitOffset = (byte)(_pos & 7);

                // read the last byte from the stream
                var val = _stream.ReadByte();

                // don't go back if we haven't actually read anything
                if (val != -1)
                    _stream.Position--;
                else // ReadByte returns -1 if we reached the end of the stream, we need unsigned data so set it to 0
                    val = 0;

                if (bit)
                {
                    // if we're setting, shift 0x80 (10000000) to the right by bitOffset
                    var mask = (byte)(0x80 >> bitOffset);

                    // we set the bit using our mask and bitwise OR
                    val |= mask;
                }
                else
                {
                    // hacky mask
                    var mask = (byte)(1 << (-(bitOffset + 1) & 7));

                    // unset using bitwise AND and bitwise NOT on the mask
                    val &= ~mask;
                }

                // write the modified byte to the stream
                _stream.WriteByte((byte)val);

                // advance the bit position
                _pos++;

                // if we aren't ending on a new byte, go back 1 byte on the stream
                if ((_pos & 7) != 0)
                    _stream.Position--;
            }
        }

        #if !UNITY
        public virtual int Write(ReadOnlySpan<byte> buf, int bits)
        #else
        public virtual int Write(byte[] buf, int bits)
        #endif
        {
            // offset in bits, in case we're not starting on the 8th (i = 7) bit
            var bitOffset = (byte)(_pos & 7);

            // inverted bit offset (eg. 3 becomes 5)
            var invertedOffset = (byte)(-bitOffset & 7);

            // get num of bytes we have to read from the Stream, we add bitOffset so we have enough data to add in case bitOffset != 0
            var byteCount = (int)Math.Ceiling((bits + bitOffset) / 8d);

            // get size of output buffer
            var bufSize = (int)Math.Ceiling(bits / 8d);

            // lock the read so we don't mess up other calls
            lock (_lock)
            {
                // check if we don't have to do complex bit level operations
                if (bitOffset == 0 && (bits & 7) == 0)
                {
                    foreach (var b in buf)
                    {
                        _stream.WriteByte(b);
                    }

                    _pos += bits;

                    return bufSize;
                }

                // allocate a buffer on the stack to write
                #if !UNITY
                Span<byte> bytes = stackalloc byte[byteCount];
                #else
                var bytes = new byte[byteCount];
                #endif

                // we might already have data in the stream
                #if !UNITY
                var readSize = _stream.Read(bytes);
                #else
                var readSize = _stream.Read(bytes, 0, bytes.Length);
                #endif

                // subtract the read bytes from the position so we can write them later
                _stream.Position -= readSize;

                for (var i = 0; bits > 0; i++)
                {
                    // add bits starting from bitOffset from the input buffer to the write buffer
                    bytes[i] |= (byte)(buf[i] >> bitOffset);

                    // set the leaking bits on the next byte
                    if (invertedOffset < 8 && bits > invertedOffset)
                        bytes[i + 1] = (byte)(buf[i] << invertedOffset);

                    // add max 8 remaining bits to the position
                    _pos += bits < 8 ? bits & 7 : 8;

                    // we wrote a byte, remove 8 bits from the bit count
                    bits -= 8;

                    // if we're at the last byte, cut off the unused bits
                    if (bits < 8)
                        bytes[i] <<= (-bits & 7);
                }

                // swap endianness in case we're not using same endianness as host
                if ((_endianness != Endianness.LittleEndian && BitConverter.IsLittleEndian) ||
                    (_endianness != Endianness.BigEndian && !BitConverter.IsLittleEndian))
                {
                    #if !UNITY
                    bytes.Reverse();
                    #else
                    bytes = bytes.Reverse().ToArray();
                    #endif
                }

                // write the buffer
                #if !UNITY
                _stream.Write(bytes);
                #else
                foreach (var b in bytes)
                {
                    _stream.WriteByte(b);
                }
                #endif

                // roll back the position in case we haven't used the last byte fully
                _stream.Position -= (byteCount - bufSize);
            }

            return bufSize;
        }

        #if !UNITY
        public virtual int Write(Span<byte> buf, int bits)
            => Write((ReadOnlySpan<byte>)buf, bits);

        public virtual int Write(byte[] buf, int index, int length, int bits)
        {
            if (bits > (length * 8))
                throw new ArgumentOutOfRangeException(nameof(bits), "Bit count exceeds buffer length");

            if (index > length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index exceeds buffer length");

            return Write(new ReadOnlySpan<byte>(buf, index, length), bits);
        }
        #endif

        public virtual int Write<T>(T val, int bits) where T : struct
        {
            var size = Marshal.SizeOf<T>();
            var buf = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr<T>(val, ptr, false);
            Marshal.Copy(ptr, buf, 0, size);
            Marshal.FreeHGlobal(ptr);

            #if !UNITY
            return Write(new ReadOnlySpan<byte>(buf), bits);
            #else
            return Write(buf, bits);
            #endif
        }

        public virtual int Write<T>(T val) where T : struct
            => Write<T>(val, Marshal.SizeOf<T>() * 8);

        public virtual void Write(ISerializable serializable)
            => serializable.Serialize(this);
    }
}