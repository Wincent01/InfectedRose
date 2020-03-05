using System;
using System.IO;

namespace InfectedRose.Core
{
    public abstract class Token : IDisposable
    {
        private bool Disposed { get; set; }
        
        public Stream Stream { get; }
        
        public long Reference { get; }
        
        public Token(Stream stream)
        {
            Stream = stream;
            
            Reference = stream.Position;
        }

        protected abstract void Construct();

        public void Dispose()
        {
            if (Disposed) return;

            Disposed = true;
            
            Construct();
        }
    }
}