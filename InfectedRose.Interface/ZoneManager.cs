using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.World;
using RakDotNet.IO;

namespace InfectedRose.Interface
{
    public static class ZoneManager
    {
        public static async Task GenerateZoneAsync(string file)
        {
            var serializer = new XmlSerializer(typeof(Zone));
            
            var zone = new Zone();
            
            if (File.Exists(file))
            {
                await using var stream = File.OpenRead(file);

                zone = (Zone) serializer.Deserialize(stream);
            }
            else
            {
                await using var stream = File.Create(file);

                serializer.Serialize(stream, zone);
                
                Console.WriteLine($"Created zone config file: \"{file}\".");
                
                return;
            }

            await zone.SaveAsync(Path.Combine(Interface.Configuration.Output, "maps"));

            Console.WriteLine("Saved, running through checks.");

            await RunChecksAsync(zone);

            Console.WriteLine("Adding zone to database.");
            
            var zones = Interface.Database["ZoneTable"];

            var row = zones.Create(zone.Id);

            var _ = new ZoneTableTable(row)
            {
                zoneName = zone.Name,
                zoneID = (int) zone.Id,
                ghostdistance = zone.GhostDistance,
                scriptID = -1,
                locStatus = 0,
                DisplayDescription = zone.Description
            };
        }
        
        private static async Task RunChecksAsync(Zone zone)
        {
            var name = Path.GetFileName(zone.Name);
            
            var file = new LuzFile();
            
            Console.WriteLine($"Checking: {name}...");
            
            await using (var stream = File.OpenRead(name))
            {
                using var reader = new BitReader(stream);

                file.Deserialize(reader);
            }
            
            Console.WriteLine("Passed");

            foreach (var scene in file.Scenes)
            {
                var lvl = new LvlFile();
                
                Console.WriteLine($"Checking: {scene.FileName}...");
                
                await using (var stream = File.OpenRead(scene.FileName))
                {
                    using var reader = new BitReader(stream);

                    lvl.Deserialize(reader);
                }
                
                Console.WriteLine("Passed");
            }
        }
    }
}