using System.Text;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbString : IConstruct
    {
        public string Value { get; set; }

        public static implicit operator string(FdbString s)
        {
            return s.Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public void Serialize(BitWriter writer)
        {
            foreach (var character in Value)
            {
                writer.Write((byte) character);
            }

            writer.Write<byte>(0);
        }

        public override bool Equals(object o)
        {
            if (o is FdbString str)
            {
                return str.Value == Value;
            }

            return false;
        }

        public void Deserialize(BitReader reader)
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