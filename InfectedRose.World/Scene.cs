using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using RakDotNet.IO;

namespace InfectedRose.World
{
    [XmlRoot]
    public class Scene
    {
        [XmlAttribute] public string Name { get; set; }
        
        [XmlAttribute] public uint Id { get; set; }
        
        [XmlAttribute] public uint Layer { get; set; }
        
        [XmlAttribute] public uint Revision { get; set; }
        
        [XmlElement] public string SkyBox { get; set; }

        [XmlElement("Object")] public List<WorldObject> Objects { get; set; }

        public LuzScene LuzScene => new LuzScene
        {
            FileName = $"{Name.Replace(" ", "_").ToLower()}.lvl",
            SceneName = Name,
            SceneId = Id,
            LayerId = Layer
        };

        public async Task SaveAsync(string path)
        {
            var scene = LuzScene;
            
            var file = new LvlFile
            {
                LvlVersion = 0x26
            };

            if (Objects?.Count > 0)
            {
                file.LevelObjects = new LevelObjects(file.LvlVersion)
                {
                    Templates = Objects.Select(o => o.Template).ToArray()
                };
            }

            if (!string.IsNullOrWhiteSpace(SkyBox))
            {
                var skyConfig = new LevelSkyConfig
                {
                    Skybox = {[0] = SkyBox}
                };

                file.LevelSkyConfig = skyConfig;
            }
            
            file.LevelInfo = new LevelInfo
            {
                RevisionNumber = Revision
            };

            using var stream = File.Create(Path.Combine(path, scene.FileName));

            using var writer = new BitWriter(stream);

            file.Serialize(writer);
        }
    }
}