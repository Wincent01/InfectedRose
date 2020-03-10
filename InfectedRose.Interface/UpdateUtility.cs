using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.Terrain.Editor;
using RakDotNet.IO;

namespace InfectedRose.Interface
{
    public static class UpdateUtility
    {
        public static async Task UpgradeZone(string path)
        {
            var origin = path;

            var id = Interface.Database["ZoneTable"].ClaimKey(100);
            
            path = Path.Combine(Interface.Configuration.Output, "maps", path);
            
            LuzFile luz;

            var root = Path.GetDirectoryName(path);
            
            await using (var stream = File.OpenRead(path))
            {
                using var reader = new BitReader(stream);
                
                luz = new LuzFile();

                luz.Deserialize(reader);
            }

            foreach (var scene in luz.Scenes)
            {
                LvlFile lvl;
                
                var scenePath = Path.Combine(root, scene.FileName);
                
                await using (var stream = File.OpenRead(scenePath))
                {
                    using var reader = new BitReader(stream);
                
                    lvl = new LvlFile();

                    lvl.Deserialize(reader);
                }

                if (lvl.IsOld)
                {
                    Console.WriteLine($"Converting {scene.SceneName} to new.");
                    
                    lvl.ConvertToNew();
                
                    await using (var stream = File.Create(scenePath))
                    {
                        using var writer = new BitWriter(stream);

                        lvl.Serialize(writer);
                    }
                }

                var spawnPoint = lvl.LevelObjects?.Templates?.FirstOrDefault(l => l.Lot == 4945);

                if (spawnPoint == null) continue;
                
                luz.SpawnPoint = spawnPoint.Position;
                luz.SpawnRotation = spawnPoint.Rotation;
            }

            if (luz.Version < 0x26)
            {
                Console.WriteLine($"Converting {Path.GetFileName(path)} to new.");
                
                luz.Version = 0x26;

                luz.WorldId = (uint) id;

                await using (var stream = File.Create(path))
                {
                    using var writer = new BitWriter(stream);

                    luz.Serialize(writer);
                }
            }
            
            Console.WriteLine("Updating terrain.");

            var terrainPath = Path.Combine(root, luz.TerrainFileName);
            
            var terrain = await TerrainEditor.OpenAsync(terrainPath);

            foreach (var chunk in terrain.Source.Chunks)
            {
                for (var i = 0; i < chunk.ColorRelatedArray.Length; i++)
                {
                    chunk.ColorRelatedArray[i] = 1;
                }
            }

            await terrain.SaveAsync(terrainPath);
            
            Console.WriteLine($"Adding [{id}] {Path.GetFileName(path)} to database.");
            
            var zones = Interface.Database["ZoneTable"];

            var row = zones.Create(id);

            var _ = new ZoneTableTable(row)
            {
                zoneName = origin,
                zoneID = (int) luz.WorldId,
                ghostdistance = 500,
                scriptID = -1,
                locStatus = 0
            };
        }
    }
}