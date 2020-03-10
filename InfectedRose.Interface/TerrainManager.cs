using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfectedRose.Terrain.Editor;

namespace InfectedRose.Interface
{
    public static class TerrainManager
    {
        public static async Task AnalyseAsync(string path)
        {
            foreach (var file in Directory.GetFiles(path, "*.raw", SearchOption.AllDirectories))
            {
                var editor = await TerrainEditor.OpenAsync(file);

                foreach (var chunk in editor.Source.Chunks)
                {
                    {
                        var data = chunk.ShortMap.Data;

                        Console.WriteLine($"MAX = {data.Max()}\tMIN = {data.Min()}\tLEN = {data.Length}");
                    }

                    {
                        var data = chunk.UnknownByteArray1;

                        Console.WriteLine($"MAX = {data.Max()}\tMIN = {data.Min()}\tLEN = {data.Length}\n");
                    }

                    {
                        foreach (var array in chunk.UnknownShortArray)
                        {
                            var data = array;

                            Console.WriteLine($"MAX = {data.Max()}\tMIN = {data.Min()}\tLEN = {data.Length}");
                        }
                        
                        Console.WriteLine();
                    }

                    Console.ReadKey();
                }
            }
        }
    }
}