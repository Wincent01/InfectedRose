using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Database.Generic;
using InfectedRose.Luz;
using InfectedRose.Terrain.Editing;
using RakDotNet.IO;

namespace InfectedRose.Interface
{
    public static class InsertionUtility
    {
        public static async Task InsertAsync(string path)
        {
            LuzFile luz;

            using (var stream = File.OpenRead(path))
            {
                using var reader = new BitReader(stream);
                
                luz = new LuzFile();

                luz.Deserialize(reader);
            }

            var worlds = Interface.Database["ZoneTable"];
            
            if (luz.WorldId == 0)
            {
                var attributes = File.GetAttributes(path);

                attributes &= ~ FileAttributes.ReadOnly;

                File.SetAttributes(path, attributes);
                
                luz.WorldId = (uint) worlds.ClaimKey(100);

                using var stream = File.Create(path);
                
                using var writer = new BitWriter(stream);

                luz.Serialize(writer);
            }

            var entry = worlds.FirstOrDefault(w => w.Key == luz.WorldId);

            if (entry != default)
            {
                if (entry.Value<string>("zoneName").StartsWith("ZoneTable"))
                {
                    worlds.Remove(entry);
                }
                else
                {
                    return;
                }
            }

            var rootPath = Path.GetDirectoryName(path);

            var terrain = await TerrainEditor.OpenAsync(Path.Combine(rootPath, luz.TerrainFileName));

            entry = worlds.Create(luz.WorldId);
            
            var root = new Uri(Path.Combine(Interface.Configuration.Output, "./maps/"));
            var map = new Uri(path);

            var relative = root.MakeRelativeUri(map).ToString();
            
            Console.WriteLine($"Inserting: [{luz.WorldId}] {Path.GetFileName(path)} into {relative}");
            
            var _ = new ZoneTableTable(entry)
            {
                zoneName = relative,
                ghostdistance = 5000,
                zoneID = (int) luz.WorldId,
                scriptID = -1,
                ghostdistance_min = 150,
                heightInChunks = terrain.Source.Height,
                widthInChunks = terrain.Source.Weight,
                localize = false,
                petsAllowed = true,
                mountsAllowed = true
            };
        }
    }
}