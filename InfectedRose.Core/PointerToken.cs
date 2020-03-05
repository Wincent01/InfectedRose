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
            var position = Stream.Position;

            var bytes = BitConverter.GetBytes(Zero ? 0 : (int) Stream.Position);

            Stream.Position = Reference;
            
            for (var i = 0; i < 4; i++)
            {
                Stream.WriteByte(bytes[i]);
            }

            Stream.Position = position;
        }
    }
}