using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.Lvl.Old;
using RakDotNet.IO;

namespace InfectedRose.Unity.Map
{
    public static class MapBuilder
    {
        public static async Task<MapResult> BuildAsync(MapFile file, string path)
        {
            var luz = new LuzFile
            {
                Version = 0x26,
                RevisionNumber = file.Settings.Revision,
                SpawnPoint = file.Settings.SpawnPoint.Vector3,
                SpawnRotation = file.Settings.SpawnRotation.Quaternion,
                WorldId = file.Settings.ZoneId,
                Transitions = new LuzSceneTransition[0]
            };

            var name = Path.GetInvalidFileNameChars().Aggregate(
                file.Settings.Name, (current, invalid) => current.Replace(invalid, '_')
            );

            luz.TerrainDescription = $"{name} Map";
            luz.TerrainFile = $"{name}_map.raw";
            luz.TerrainFileName = $"{name}_map.raw";

            uint sceneId = default;

            luz.Scenes = file.Scenes.Select(s =>
            {
                var sceneName = Path.GetInvalidFileNameChars().Aggregate(
                    s.Name, (current, invalid) => current.Replace(invalid, '_')
                );

                var lvl = new LvlFile
                {
                    LvlVersion = 30,
                    OldLevelHeader = new OldLevelHeader {LvlVersion = 30}
                };

                var objects = new LevelObjects(30);

                var templates = s.Objects.Select(obj =>
                    new LevelObjectTemplate(30)
                    {
                        ObjectId = obj.ObjectId,
                        Lot = obj.Lot,
                        Position = obj.Position.Vector3,
                        Rotation = obj.Rotation.Quaternion,
                        Scale = obj.Scale,
                        AssetType = obj.AssetType,
                        LegoInfo = LegoDataDictionary.FromString(obj.Settings)
                    }
                ).ToList();

                objects.Templates = templates.ToArray();

                lvl.LevelObjects = objects;
                
                using var stream = File.Create($"{path}/{sceneName}.lvl");

                using var writer = new BitWriter(stream);

                lvl.Serialize(writer);

                return new LuzScene
                {
                    FileName = $"{sceneName}.lvl",
                    SceneId = sceneId++,
                    LayerId = s.Layer
                };
            }).ToArray();

            await using var luzStream = File.Create($"{path}/{name}.luz");

            using var luzWriter = new BitWriter(luzStream);

            luz.Serialize(luzWriter);

            return new MapResult();
        }
    }
}