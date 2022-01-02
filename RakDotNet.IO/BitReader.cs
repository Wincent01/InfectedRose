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
    public class BitReader : IDisposable
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
                    // wait for read operations to complete so we don't mess them up
                    lock (_lock)
                    {
                        _endianness = value;
                    }
                }
            }
        }
        public virtual bool CanChangeEndianness => !_orderLocked;
        public virtual long Position => _pos;

        public BitReader(Stream stream, Endianness endianness = Endianness.LittleEndian, bool orderLocked = true, bool leaveOpen = false)
        {
            if (!stream.CanRead)
                throw new ArgumentException("Stream is not readable", nameof(stream));

            _stream = stream;
            _leaveOpen = leaveOpen;
            _orderLocked = orderLocked;
            _lock = new object();

            _endianness = endianness;
            _disposed = false;
            _pos = 0;

            // set the stream position back to 0 if this is a read+write stream
            if (_stream.CanWrite)
                _stream.Position = 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && !_leaveOpen)
                    _stream.Close();

                _disposed = true;
            }
        }

        public void Dispose() => Dispose(true);

        public virtual void Close() => Dispose(true);

        public virtual bool ReadBit()
        {
            lock (_lock)
            {
                var val = _stream.ReadByte();

                // if we aren't ending on a new byte, go back 1 byte on the stream
                if (((_pos + 1) & 7) != 0)
                    _stream.Position--;

                return (val & (0x80 >> (byte)(_pos++ & 7))) != 0;
            }
        }

        #if !UNITY
        public virtual int Read(Span<byte> buf, int bits)
        #else
        public virtual int Read(byte[] buf, int bits)
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
                // alloc the read buf on stack
                #if !UNITY
                Span<byte> bytes = stackalloc byte[byteCount];
                #else
                var bytes = new byte[byteCount];
                #endif

                // read from the Stream to the buf on the stack
                #if !UNITY
                _stream.Read(bytes);
                #else
                for (var i = 0; i < byteCount; i++)
                {
                    bytes[i] = (byte) _stream.ReadByte();
                }
                #endif

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

                // check if we don't have to do complex bit level operations
                if (bitOffset == 0 && (bits & 7) == 0)
                {
                    // copy read bytes to output buffer
                    #if !UNITY
                    bytes.CopyTo(buf);
                    #else
                    bytes.CopyTo(buf, 0);
                    #endif

                    _pos += bits;

                    return bufSize;
                }

                // loop over the bytes we read
                for (var i = 0; bits > 0; i++)
                {
                    // add bits starting from bitOffset to output buf
                    buf[i] |= (byte)(bytes[i] << bitOffset);

                    // if we're not reading from the start of a byte and we have enough bits left, add the remaining bits to the byte in the output buf
                    if (bitOffset != 0 && bits > invertedOffset)
                        buf[i] |= (byte)(bytes[i + 1] >> invertedOffset);

                    // we read a byte, remove 8 bits from the bit count
                    bits -= 8;

                    // add 8 bits minus X unused bits
                    _pos += bits < 0 ? bits & 7 : 8;

                    // shift bits we're not using
                    if (bits < 0)
                        buf[i] >>= -bits;
                }

                // roll back the position in case we haven't used the last byte fully
                _stream.Position -= (byteCount - bufSize);
            }

            // return the buffer length
            return bufSize;
        }

        #if !UNITY
        public virtual int Read(byte[] buf, int index, int length, int bits)
        {
            if (bits > (length * 8))
                throw new ArgumentOutOfRangeException(nameof(bits), "Bit count exceeds buffer length");

            if (index > length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index exceeds buffer length");

            return Read(new Span<byte>(buf, index, length), bits);
        }

        public virtual int Read(byte[] buf, int index, int count)
            => Read(new Span<byte>(buf, index, count), count * 8);
        #endif

        public virtual T Read<T>(int bits) where T : unmanaged
        {
            var bufSize = (int)Math.Ceiling(bits / 8d);
            
            #if !UNITY
            Span<byte> buf = stackalloc byte[bufSize];
            #else
            var buf = new byte[bufSize];
            #endif

            Read(buf, bits);

            // we "cast" the Span to our struct T
            #if !UNITY
            return MemoryMarshal.Read<T>(buf);
            #else
            T result;

            var handle = GCHandle.Alloc(buf, GCHandleType.Pinned);

            try
            {
                result = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }

            return result;
            #endif
        }

        public virtual T Read<T>() where T : unmanaged
            => Read<T>(Marshal.SizeOf<T>() * 8);

        public virtual void ReadDeserializable(IDeserializable deserializable)
            => deserializable.Deserialize(this);
    }
}
