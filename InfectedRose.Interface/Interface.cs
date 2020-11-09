using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Builder.Behaviors;
using InfectedRose.Builder;
using InfectedRose.Builder.Behaviors.External;
using InfectedRose.Database;
using InfectedRose.Database.Concepts;
using InfectedRose.Database.Concepts.Generic;
using InfectedRose.Database.Concepts.Tables;

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

            BuildSkill();

            await FinalizeAsync();

            await BuildZones();

            await UpdateZones();

            await InsertZones();

            await BuildNpcs();

            await BuildMissions();

            await FinalizeAsync();
        }

        private static void BuildSkill()
        {
            Console.Write("Xml: "); // Xml from Editor

            var input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input)) return;

            var skill = XmlImporter.Import(input, Database);

            var obj = Database.CopyObject(9864);

            var component = new LwoComponent(ComponentId.SkillComponent);

            obj.Add(component);

            var entry = Database["ObjectSkills"].Create(obj.Row.Key);

            var skillEntry = new ObjectSkillsTable(entry);

            skillEntry.castOnType = 0;

            skillEntry.skillID = (int) skill;
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

        private static async Task InsertZones()
        {
            foreach (var root in Configuration.Insert)
            {
                foreach (var file in Directory.GetFiles(root, "*.luz", SearchOption.AllDirectories))
                {
                    await InsertionUtility.InsertAsync(file);
                }
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

                    using (var stream = File.Create(npc))
                    {
                        serializer.Serialize(stream, sample);
                    }

                    Console.WriteLine($"Created \"{npc}\".");

                    return;
                }

                Console.WriteLine($"Building {npc}.");

                using (var stream = File.OpenRead(npc))
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

                    using (var stream = File.Create(mission))
                    {
                        serializer.Serialize(stream, sample);
                    }

                    Console.WriteLine($"Created \"{mission}\".");

                    return;
                }

                Console.WriteLine($"Building {mission}.");

                using (var stream = File.OpenRead(mission))
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

            File.WriteAllLines(Configuration.SqlOutput, Sql);

            Console.WriteLine("SQL commands saved.");

            foreach (var table in Database)
            {
                table.Recalculate();
            }

            Console.WriteLine("Hashing database, please wait...");

            var watch = new Stopwatch();

            watch.Start();

            await Database.SaveAsync(Path.Combine(Configuration.Output, "cdclient.fdb"));

            Console.WriteLine($"{watch.ElapsedMilliseconds}ms");

            watch.Stop();
        }

        private static async Task OpenConfig()
        {
            var serializer = new XmlSerializer(typeof(Configuration));

            if (!File.Exists("config.xml"))
            {
                var sample = new Configuration();

                using (var stream = File.Create("config.xml"))
                {
                    serializer.Serialize(stream, sample);
                }

                Console.WriteLine("Created config file.");

                Environment.Exit(0);

                return;
            }

            using (var stream = File.OpenRead("config.xml"))
            {
                Configuration = (Configuration) serializer.Deserialize(stream);
            }
        }
    }
}