using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using InfectedRose.Database;
using InfectedRose.Database.Concepts;
using InfectedRose.Database.Concepts.Generic;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.Terrain;
using RakDotNet.IO;

/*
 * W.I.P
 */

namespace InfectedRose.Pipeline
{
    public static class LuzFileExtensions
    {
        public static async Task ExportToWavefrontAsync(this LuzFile @this, AccessDatabase database, string source, string resources, string result)
        {
            TerrainFile terrain;
            
            using (var stream = File.OpenRead(Path.Combine(source, @this.TerrainFileName)))
            {
                using var reader = new BitReader(stream);
                
                terrain = new TerrainFile();

                terrain.Deserialize(reader);
            }

            var levels = new LvlFile[@this.Scenes.Length];

            for (var i = 0; i < @this.Scenes.Length; i++)
            {
                var scene = @this.Scenes[i];

                using var stream = File.OpenRead(Path.Combine(source, scene.FileName));

                using var reader = new BitReader(stream);
                
                var level = new LvlFile();

                level.Deserialize(reader);

                levels[i] = level;
            }
            
            var objects = new List<LevelObjectTemplate>();

            foreach (var level in levels)
            {
                if (level.LevelObjects?.Templates == default) continue;

                foreach (var template in level.LevelObjects.Templates)
                {
                    if (!template.LegoInfo.TryGetValue("add_to_navmesh", out var add)) continue;
                    
                    if (!(bool) add) continue;

                    objects.Add(template);
                }
            }

            foreach (var template in objects)
            {
                var instance = database.LoadObject(template.Lot);

                var renderer = instance.GetComponent<RenderComponentTable>();
                
                if (renderer == default) continue;
                
                Console.WriteLine(renderer.render_asset);
            }
        }
    }
}