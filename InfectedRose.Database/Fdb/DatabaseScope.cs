using System;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class DatabaseScope : IDisposable
    {
        private readonly long _current;
        private readonly int _pointer;
        private readonly BitReader _reader;

        public DatabaseScope(BitReader reader, bool signed = false)
        {
            _current = reader.BaseStream.Position + 4;
            _pointer = signed ? reader.Read<int>() : (int) reader.Read<uint>();
            if (_pointer != -1) reader.BaseStream.Position = _pointer;
            _reader = reader;
        }

        public void Dispose()
        {
            _reader.BaseStream.Position = _current;
        }

        public static implicit operator bool(DatabaseScope s)
        {
            return s._pointer != -1;
        }
    }
}