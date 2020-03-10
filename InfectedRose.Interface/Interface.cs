using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Builder;
using InfectedRose.Database;

namespace InfectedRose.Interface
{
    public static class Interface
    {
        public static Configuration Configuration { get; private set; }
        
        public static AccessDatabase Database { get; private set; }
        
        private static List<string> Sql { get; set; }
        
        private static async Task Main()
        {
            Sql = new List<string>();
            
            await OpenConfig();

            /*
            await TerrainManager.AnalyseAsync(Configuration.Output);
            
            return;
            */

            Database = await AccessDatabase.OpenAsync(Configuration.CdClient);

            Database.OnSql += Sql.Add;
            
            await BuildZones();

            await UpdateZones();
            
            await BuildNpcs();

            await BuildMissions();

            await FinalizeAsync();
        }

        private static async Task BuildZones()
        {
            foreach (var zone in Configuration.Zones)
            {
                await ZoneManager.GenerateZoneAsync(zone);
            }
        }

        private static async Task UpdateZones()
        {
            foreach (var update in Configuration.Updates)
            {
                await UpdateUtility.UpgradeZone(update);
            }
        }

        private static async Task BuildNpcs()
        {
            var serializer = new XmlSerializer(typeof(Npc));
            
            foreach (var npc in Configuration.Npcs)
            {
                if (!File.Exists(npc))
                {
                    var sample = new Npc();

                    await using (var stream = File.Create(npc))
                    {
                        serializer.Serialize(stream, sample);
                    }
                
                    Console.WriteLine($"Created \"{npc}\".");
                
                    return;
                }
                
                Console.WriteLine($"Building {npc}.");

                await using (var stream = File.OpenRead(npc))
                {
                    var instance = (Npc) serializer.Deserialize(stream);

                    instance.Database = Database;

                    instance.Build();
                }
            }
        }

        private static async Task BuildMissions()
        {
            var serializer = new XmlSerializer(typeof(Mission));
            
            foreach (var mission in Configuration.Mission)
            {
                if (!File.Exists(mission))
                {
                    var sample = new Mission();

                    await using (var stream = File.Create(mission))
                    {
                        serializer.Serialize(stream, sample);
                    }
                
                    Console.WriteLine($"Created \"{mission}\".");
                
                    return;
                }

                Console.WriteLine($"Building {mission}.");

                await using (var stream = File.OpenRead(mission))
                {
                    var instance = (Mission) serializer.Deserialize(stream);

                    instance.Database = Database;

                    instance.Build();
                }
            }
        }

        private static async Task FinalizeAsync()
        {
            if (Sql.Count == 0)
            {
                Console.WriteLine("No changes to the database have been requested.");

                Environment.Exit(0);
                
                return;
            }
            
            await File.WriteAllLinesAsync(Configuration.SqlOutput, Sql);
            
            Console.WriteLine("SQL commands saved.");

            foreach (var table in Database)
            {
                table.Recalculate(Configuration.Release ? 0 : 1);
            }
            
            if (Configuration.Release)
            {
                Console.WriteLine("You are hashing the database for release, note that this may take several minutes.");
            }

            Console.WriteLine("Hashing database, please wait...");

            await Database.SaveAsync(Path.Combine(Configuration.Output, "cdclient.fdb"));
        }

        private static async Task OpenConfig()
        {
            var serializer = new XmlSerializer(typeof(Configuration));

            if (!File.Exists("config.xml"))
            {
                var sample = new Configuration();

                await using (var stream = File.Create("config.xml"))
                {
                    serializer.Serialize(stream, sample);
                }
                
                Console.WriteLine("Created config file.");
                
                Environment.Exit(0);
                
                return;
            }

            await using (var stream = File.OpenRead("config.xml"))
            {
                Configuration = (Configuration) serializer.Deserialize(stream);
            }
        }
    }
}