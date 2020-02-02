using System.Linq;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiStringRef : NiObject
    {
        public int Key { get; set; }

        public string Value
        {
            get => Key == -1 ? default : File.Header.Strings[Key];
            set
            {
                if (value == default)
                {
                    Key = -1;
                    
                    return;
                }
                
                Key = File.Header.Strings.ToList().IndexOf(value);
            }
        }

        public override void Serialize(BitWriter writer)
        {
            writer.Write(Key);
        }

        public override void Deserialize(BitReader reader)
        {
            Key = reader.Read<int>();
        }

        public static implicit operator string(NiStringRef @ref) => @ref.Value;
    }
}