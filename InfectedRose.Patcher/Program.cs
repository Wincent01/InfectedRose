using System;
using System.IO;
using System.Threading.Tasks;

namespace InfectedRose.Patcher
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            //
            // Make the client skip the zone checksum check, allowing for loading of new and modified zones.
            //
            
            var file = args.Length > 0 ? args[0] : default;

            if (file == default)
            {
                Console.WriteLine("Expected path to \"legouniverse.exe\" as first argument");
                
                return;
            }
            
            var bytes = await File.ReadAllBytesAsync(file);

            bytes[0x735358] = 0xEB; // Patch JZ to JMP

            await File.WriteAllBytesAsync(file, bytes);
        }
    }
}