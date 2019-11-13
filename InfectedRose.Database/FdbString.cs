using System.Text;
using RakDotNet.IO;

namespace InfectedRose.Database
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
            return Value;
        }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            foreach (var c in Value) databaseFile.Structure.Add((byte) c);

            databaseFile.Structure.Add((byte) 0);
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