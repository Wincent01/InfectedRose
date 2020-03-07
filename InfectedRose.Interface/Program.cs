using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;
using InfectedRose.World;

namespace InfectedRose.Interface
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"Usage: {Path.GetFileName(Assembly.GetEntryAssembly()?.Location)} <xml-file> <fdb>");

                Environment.Exit(1);
                
                return;
            }
            
            var serializer = new XmlSerializer(typeof(Zone));
            
            var zone = new Zone();
            
            if (File.Exists(args[0]))
            {
                await using var stream = File.OpenRead(args[0]);

                zone = (Zone) serializer.Deserialize(stream);
            }
            else
            {
                await using var stream = File.Create(args[0]);

                serializer.Serialize(stream, zone);
                
                Console.WriteLine("Created xml file");
                
                Environment.Exit(1);
                
                return;
            }

            await zone.SaveAsync(Path.GetDirectoryName(args[0]));

            var database = await AccessDatabase.OpenAsync(args[1]);

            var zones = database["ZoneTable"];

            foreach (var row in zones)
            {
                if (Enum.IsDefined(typeof(ZoneId), (ushort) row.Key)) continue;

                zones.Remove(row);
            }

            var entry = new ZoneTableTable(zones.Create(zone.Id));

            entry.zoneName = zone.Name;
            entry.zoneID = (int) zone.Id;
            entry.ghostdistance = zone.GhostDistance;
            entry.scriptID = -1;
            entry.locStatus = 0;
            entry.DisplayDescription = zone.Description;

            foreach (var table in database)
            {
                table.Recalculate();
            }

            var pad = 0;
            
            await database.SaveAsync(args[1], i =>
            {
                if (++pad != 10000) return;
                
                Console.WriteLine(i);

                pad = 0;
            });
        }
    }
}