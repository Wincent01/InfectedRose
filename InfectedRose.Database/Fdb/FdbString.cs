using System.Linq;
using System.Text;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbString : DatabaseData
    {
        public string Value { get; set; }

        public static implicit operator string(FdbString s)
        {
            return s.Value;
        }

        public override string ToString()
        {
            return "FdbString";
        }

        public override bool Equals(object o)
        {
            if (o is FdbString str)
            {
                return str.Value == Value;
            }

            return false;
        }

        public override void Compile(HashMap map)
        {
            map += this;

            if (Value != default) map = Value.Aggregate(map, (current, c) => current + (byte) c);

            map.Add((byte) 0);
        }

        public override void Deserialize(BitReader reader)
        {
            var builder = new StringBuilder();

            using (new DatabaseScope(reader))
            {
                while (true)
                {
                    var c = reader.Read<byte>();
                    if (c == 0) break;
                    builder.Append((char) c);
                }
            }

            Value = builder.ToString();
        }
    }
}