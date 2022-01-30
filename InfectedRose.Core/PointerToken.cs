using System;
using RakDotNet.IO;

namespace InfectedRose.Core
{
    public class PointerToken : Token
    {
        public bool Zero { get; set; }
        
        public PointerToken(BitWriter writer) : base(writer.BaseStream)
        {
            Stream.Position += 4;
        }

        protected override void Construct()
        {
            var position = (uint) Stream.Position;

            Stream.Position = Reference;
            
            unsafe
            {
                var buffer = (byte*) &position;
                
                for (var i = 0; i < sizeof(uint); ++i)
                {
                    Stream.WriteByte(buffer[i]);
                }
            }

            Stream.Position = position;
        }
    }
}