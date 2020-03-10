using System;
using System.IO;
using System.Threading.Tasks;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Luz;
using InfectedRose.Lvl;
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
            }
            
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