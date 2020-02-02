using System.Linq;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiRef : NiRef<NiObject>
    {
        
    }
    
    public class NiRef<T> : NiObject where T : NiObject
    {
        public int Key { get; set; }

        public T Value
        {
            get
            {
                if (Key == -1) return default;
                
                return File.Blocks[Key] as T;
            }
            set
            {
                if (value == default)
                {
                    Key = -1;
                    
                    return;
                }
                
                Key = File.Blocks.ToList().IndexOf(value);
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

        public static implicit operator T(NiRef<T> @ref) => @ref.Value;
    }
}