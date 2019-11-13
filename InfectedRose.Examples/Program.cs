using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Database;
using InfectedRose.Database.Generic;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.Terrain;
using RakDotNet.IO;

namespace InfectedRose.Examples
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.Write("Type: ");
            
            if (!int.TryParse(Console.ReadLine(), out var i)) return;

            switch (i)
            {
                case 0:
                    await Terrain(args);
                    return;
                case 1:
                    await Luz(args);
                    return;
                case 2:
                    await Lvl(args);
                    return;
                case 3:
                    await LvlTest(args);
                    return;
                case 4:
                    await Database(args);
                    return;
            }
        }

        private static async Task Database(IReadOnlyList<string> args)
        {
            string file;

            if (args.Count > 0)
            {
                file = args[0];
            }
            else
            {
                Console.Write("File: ");

                file = Console.ReadLine();
            }

            var databaseFile = new DatabaseFile();
            
            await using (var fileStream = File.OpenRead(file))
            {
                using var reader = new BitReader(fileStream);

                databaseFile.Deserialize(reader);
            }
            
            var database = new AccessDatabase(databaseFile);

            var table = database.Typed<ZoneSummary>();

            foreach (var col in table)
            {
                Console.WriteLine(col["ZoneId"].Value);
            }

            var newColumn = table.Create();

            newColumn.ZoneId = 42;

            table.Save();

            var margin = 0;
            var bytes = databaseFile.Compile(i =>
            {
                margin++;

                if (margin != 100000) return;
                
                margin = default;

                Console.WriteLine($"{Math.Round(i / (double) databaseFile.Structure.Count * 100, 2)}%");
            });

            File.WriteAllBytes($"{file}.new.fdb", bytes);
        }
        
        private static async Task Terrain(IReadOnlyList<string> args)
        {
            string file;

            if (args.Count > 0)
            {
                file = args[0];
            }
            else
            {
                Console.Write("File: ");

                file = Console.ReadLine();
            }

            var terrain = new TerrainFile();
            
            await using (var fileStream = File.OpenRead(file))
            {
                using var reader = new BitReader(fileStream);

                terrain.Deserialize(reader);

                foreach (var chunk in terrain.Chunks)
                {
                    var data = chunk.HeightMap.Data;

                    var min = data.Min();
                    var max = data.Max();

                    uint randomIndex = default;
                    for (var i = 0; i < data.Length; i++)
                    {
                        if (randomIndex++ == 100)
                        {
                            data[i] = max;
                        }
                        else if (randomIndex == 200)
                        {
                            data[i] = min;

                            randomIndex = default;
                        }
                    }

                    chunk.HeightMap.Data = data;
                }
            }

            await using var writeStream = File.OpenWrite(file);
            using var writer = new BitWriter(writeStream);

            terrain.Serialize(writer);
            
            Console.Write("Done");
        }

        private static async Task Luz(IReadOnlyList<string> args)
        {
            string file;

            if (args.Count > 0)
            {
                file = args[0];
            }
            else
            {
                Console.Write("File: ");

                file = Console.ReadLine();
            }
            
            var luz = new LuzFile();

            await using (var fileStream = File.OpenRead(file))
            {
                using var reader = new BitReader(fileStream);

                luz.Deserialize(reader);
            }
            
            await using var writeStream = File.OpenWrite(file);
            using var writer = new BitWriter(writeStream);

            luz.Serialize(writer);
            
            Console.Write("Done");
        }

        private static async Task Lvl(IReadOnlyList<string> args)
        {
            string file;

            if (args.Count > 0)
            {
                file = args[0];
            }
            else
            {
                Console.Write("File: ");

                file = Console.ReadLine();
            }
            
            var lvl = new LvlFile();

            await using (var fileStream = File.OpenRead(file))
            {
                using var reader = new BitReader(fileStream);

                lvl.Deserialize(reader);
            }
            
            await using var writeStream = File.OpenWrite(file);
            using var writer = new BitWriter(writeStream);

            lvl.Serialize(writer);
            
            Console.Write("Done");
        }
        
        private static async Task LvlTest(IReadOnlyList<string> args)
        {
            string dir;

            if (args.Count > 0)
            {
                dir = args[0];
            }
            else
            {
                Console.Write("Dir: ");

                dir = Console.ReadLine();
            }

            foreach (var file in Directory.GetFiles(dir, "*.lvl", SearchOption.AllDirectories))
            {
                var lvl = new LvlFile();

                await using var fileStream = File.OpenRead(file);
                
                using var reader = new BitReader(fileStream);

                Console.Write($"{file} -> ");
                
                lvl.Deserialize(reader);
                
                Console.Write('\n');
            }
            
            Console.Write("Done");
        }
    }
}