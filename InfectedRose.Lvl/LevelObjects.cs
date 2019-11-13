using System.IO;
using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class LevelObjects : ChunkBase
    {
        public LevelObjectTemplate[] Templates { get; set; }

        public uint LvlVersion { get; set; }

        public override uint ChunkType => 2001;
        
        public LevelObjects(uint lvlVersion)
        {
            LvlVersion = lvlVersion;
        }
        
        public override void Serialize(BitWriter writer)
        {
            writer.Write((uint) Templates.Length);

            foreach (var template in Templates)
            {
                template.Serialize(writer);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            Templates = new LevelObjectTemplate[reader.Read<uint>()];

            for (var i = 0; i < Templates.Length; i++)
            {
                var template = new LevelObjectTemplate(LvlVersion);
                template.Deserialize(reader);

                Templates[i] = template;
            }
        }
    }
}