using System;
using RakDotNet.IO;

namespace InfectedRose.Core
{
    public class LengthToken : Token
    {
        public long Point { get; set; }
        
        public LengthToken(BitWriter writer) : base(writer.BaseStream)
        {
        }
        
        public void Allocate()
        {
            Point = Stream.Position;

            Stream.Position += 4;
        }

        protected override void Construct()
        {
            if (Point <= 0)
            {
                throw new InvalidOperationException($"{nameof(Point)} cannot be negative or 0");
            }
            
            var position = Stream.Position;

            var length = (int) Math.Abs(Reference - position);

            var bytes = BitConverter.GetBytes(length);

            Stream.Position = Point;
            
            for (var i = 0; i < 4; i++)
            {
                Stream.WriteByte(bytes[i]);
            }

            Stream.Position = position;
        }
    }
}