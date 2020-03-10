using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Luz;
using RakDotNet.IO;

namespace InfectedRose.World
{
    [XmlRoot("Zone")]
    public class Zone
    {
        [XmlElement] public string Name { get; set; } = "my_maps/zone/zone.luz";

        [XmlElement] public uint Id { get; set; } = 0;

        [XmlElement] public uint Revision { get; set; } = 1;

        [XmlElement] public float GhostDistance { get; set; } = 500;

        [XmlElement] public string Description { get; set; } = "amazing zone";
        
        [XmlElement("Scene")] public List<Scene> Scenes { get; set; } = new List<Scene>();
        
        [XmlElement] public Vector3 SpawnPosition { get; set; }

        [XmlElement] public Quaternion SpawnRotation { get; set; } = Quaternion.Identity;
        
        [XmlElement] public Terrain Terrain { get; set; } = new Terrain();
        
        public async Task SaveAsync(string path)
        {
            var file = new LuzFile
            {
                TerrainFile = Terrain.Name,
                TerrainFileName = Terrain.FileName,
                TerrainDescription = Terrain.Description,
                Version = 0x26,
                SpawnPoint = SpawnPosition,
                SpawnRotation = SpawnRotation,
                WorldId = Id,
                Scenes = Scenes.Select(s => s.LuzScene).ToArray(),
                RevisionNumber = Revision
            };

            var zoneFile = Path.Combine(path, Name);

            var root = Path.GetDirectoryName(zoneFile);
            
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            
            await using var stream = File.Create(zoneFile);

            using var writer = new BitWriter(stream);

            file.Serialize(writer);

            foreach (var scene in Scenes)
            {
                await scene.SaveAsync(Path.Combine(path, Path.GetDirectoryName(Name)));
            }

            await Terrain.SaveAsync(root);
        }
    }
}