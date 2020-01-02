using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Database;
using InfectedRose.Database.Concepts;
using InfectedRose.Database.Generic;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.Nif;
using RakDotNet.IO;

namespace Sandbox
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var list = new List<ZoneChecksum>();

            var path = "/mnt/MainDisk/LEGO Universe/LCDR Unpacked/res/maps/";
            
            foreach (var file in Directory.GetFiles(path, "*.luz", SearchOption.AllDirectories))
            {
                var sum = (ZoneChecksum) await InfectedRose.Utilities.Checksum.GenerateAsync(file);

                list.Add(sum);
                
                Console.WriteLine($"{Path.GetFileName(file)} -> {sum}");
            }

            Console.WriteLine();
            
            foreach (ZoneChecksum value in Enum.GetValues(typeof(ZoneChecksum)))
            {
                Console.WriteLine($"{value} -> {list.Contains(value)}");
            }
        }

        private static async Task World()
        {
            var file = "/mnt/MainDisk/LEGO Universe/LCDR Unpacked/res/maps/ozymandias/ozymandias.luz";
            
            var luz = new LuzFile();
            
            await using (var stream = File.OpenRead(file))
            {
                using var reader = new BitReader(stream);

                luz.Deserialize(reader);

                luz.WorldId = 2200;
            }

            await using var writeStream = File.OpenWrite(file);

            using var writer = new BitWriter(writeStream);

            luz.Serialize(writer);
        }

        private static async Task Nif()
        {
            var file = "/mnt/MainDisk/LEGO Universe/LCDR Unpacked/res/mesh/accessories/cape.nif";

            await using var stream = File.OpenRead(file);

            using var reader = new BitReader(stream);

            var nif = new NifFile();

            nif.Deserialize(reader);

            foreach (var nodeType in nif.Header.NodeTypes)
            {
                Console.WriteLine(nodeType);
            }
        }

        private static async Task<uint> Checksum(string file)
        {
            var root = Path.GetDirectoryName(file);
            
            var luz = new LuzFile();
            
            await using (var stream = File.OpenRead(file))
            {
                using var reader = new BitReader(stream);

                luz.Deserialize(reader);
            }

            uint a = ushort.MaxValue; 
            uint b = ushort.MaxValue;
            
            var sets = new List<(uint SceneId, uint LayerId, uint revision)>
            {
                (uint.MaxValue, 0, luz.RevisionNumber)
            };

            foreach (var scene in luz.Scenes)
            {
                var lvl = new LvlFile();

                await using (var stream = File.OpenRead(Path.Combine(root, scene.FileName)))
                {
                    using var reader = new BitReader(stream);

                    lvl.Deserialize(reader);
                }
                
                var revision = lvl.LevelInfo?.RevisionNumber ?? lvl.OldLevelHeader.Revision;
                
                sets.Add((scene.SceneId, scene.LayerId, revision));
            }
            
            foreach (var (sceneId, layerId, revision) in sets)
            {
                a += sceneId >> 16;
                b += a;

                a += sceneId & 0xFFFF;
                b += a;

                a += layerId >> 16;
                b += a;

                a += layerId & 0xFFFF;
                b += a;

                a += revision >> 16;
                b += a;

                a += revision & 0xFFFF;
                b += a;
                
                Console.WriteLine("SCENE: " + sceneId + " LAYER: " + layerId + " REVISION: " + revision);
            }

            a = (a & 0xFFFF) + (a >> 16);
            b = (b & 0xFFFF) + (b >> 16);

            var checksum = b << 16 | a;
            
            return checksum;
        }

        private static async Task Database()
        {
            var db = "/mnt/MainDisk/LEGO Universe/cdclient.fdb";

            var access = await AccessDatabase.OpenAsync(db);

            /*
            await using var stream = File.CreateText("/mnt/MainDisk/LEGO Universe/sql.sql");

            access.OnSql += sql =>
            {
                stream.WriteLine(sql);
            };
            */

            var working = access["Objects"];

            //await working.RecalculateRowsAsync();
            
            var pad = 0;
            
            var bytes = access.Source.Compile(b =>
            {
                if (++pad != 10000) return;
                
                Console.WriteLine(b);

                pad = 0;
            });

            await File.WriteAllBytesAsync($"{db}.xzp", bytes);
        }
    }
}