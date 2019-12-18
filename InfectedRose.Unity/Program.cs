using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Unity.Map;

namespace InfectedRose.Unity
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var file = args.Length > 0 ? args[0] : Console.ReadLine();

            var scheme = new XmlSerializer(typeof(MapFile));

            await using var stream = File.OpenRead(file);

            var map = (MapFile) scheme.Deserialize(stream);

            await MapBuilder.BuildAsync(map, args.Length > 1 ? args[1] : ".");
        }
    }
}