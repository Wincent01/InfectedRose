using System.IO;
using System.Threading.Tasks;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using RakDotNet.IO;

namespace InfectedRose.Utilities;

public static class Checksum
{
    /// <summary>
    ///     Calculate the checksum for a LEGO Universe zone
    /// </summary>
    /// <param name="zone">Path to zone file</param>
    /// <returns>Calculated checksum</returns>
    public static uint Generate(string zone)
    {
        uint value = ushort.MaxValue; // For checksum calculations
        uint total = ushort.MaxValue; // Sum of all changes applied to value

        //
        // Read zone file
        //
            
        var luz = new LuzFile();

        using (var stream = File.OpenRead(zone))
        {
            using var reader = new BitReader(stream);

            luz.Deserialize(reader);
        }

        //
        // Apply zone layer
        //
            
        var zoneLayer = new ChecksumLayer
        {
            Id = uint.MaxValue,
            Layer = default,
            Revision = luz.RevisionNumber
        };

        zoneLayer.Apply(ref value, ref total);
            
        //
        // Get layers for scenes
        //
            
        var root = Path.GetDirectoryName(zone);

        var sceneLayers = new ChecksumLayer[luz.Scenes.Length];

        for (var index = 0; index < luz.Scenes.Length; index++)
        {
            var scene = luz.Scenes[index];
                 
            //
            // Read scene (level) file
            //
                 
            var lvl = new LvlFile();

            using (var stream = File.OpenRead(Path.Combine(root, scene.FileName)))
            {
                using var reader = new BitReader(stream);

                lvl.Deserialize(reader);
            }

            //
            // Get revision
            //
                 
            var revision = lvl.LevelInfo?.RevisionNumber ?? lvl.OldLevelHeader.Revision;

            //
            // Get layer
            //
                 
            sceneLayers[index] = new ChecksumLayer
            {
                Id = scene.SceneId,
                Layer = scene.LayerId,
                Revision = revision
            };
        }

        //
        // Apply scene layers
        //

        foreach (var layer in sceneLayers)
        {
            layer.Apply(ref value, ref total);
        }

        //
        // Get final checksum
        //
            
        var lower = (ushort) ((value & ushort.MaxValue) + (value >> 16));
        var upper = (ushort) ((total & ushort.MaxValue) + (total >> 16));

        //
        // The checksum has two parts, one for the 'total', and one for the 'value', these combine to form a 32bit value
        // 

        return (uint) (upper << 16 | lower);
    }
        
    /// <summary>
    ///     Calculate the checksum for a LEGO Universe zone
    /// </summary>
    /// <param name="zone">Path to zone file</param>
    /// <returns>Calculated checksum</returns>
    public static async Task<uint> GenerateAsync(string zone)
    {
        uint value = ushort.MaxValue; // For checksum calculations
        uint total = ushort.MaxValue; // Sum of all changes applied to value

        //
        // Read zone file
        //
            
        var luz = new LuzFile();

        using (var stream = File.OpenRead(zone))
        {
            using var reader = new BitReader(stream);

            luz.Deserialize(reader);
        }

        //
        // Apply zone layer
        //
            
        var zoneLayer = new ChecksumLayer
        {
            Id = uint.MaxValue,
            Layer = default,
            Revision = luz.RevisionNumber
        };

        zoneLayer.Apply(ref value, ref total);
            
        //
        // Get layers for scenes
        //
            
        var root = Path.GetDirectoryName(zone);

        var sceneLayers = new ChecksumLayer[luz.Scenes.Length];

        var tasks = new Task[luz.Scenes.Length];
            
        for (var index = 0; index < luz.Scenes.Length; index++)
        {
            var sceneIndex = index;
                
            tasks[index] = Task.Run(() =>
            {
                var scene = luz.Scenes[sceneIndex];
                    
                //
                // Read scene (level) file
                //
                    
                var lvl = new LvlFile();

                using (var stream = File.OpenRead(Path.Combine(root, scene.FileName)))
                {
                    using var reader = new BitReader(stream);

                    lvl.Deserialize(reader);
                }

                //
                // Get revision
                //
                    
                var revision = lvl.LevelInfo?.RevisionNumber ?? lvl.OldLevelHeader.Revision;

                //
                // Get layer
                //
                    
                sceneLayers[sceneIndex] = new ChecksumLayer
                {
                    Id = scene.SceneId,
                    Layer = scene.LayerId,
                    Revision = revision
                };
            });
        }

        await Task.WhenAll(tasks);

        //
        // Apply scene layers
        //

        foreach (var layer in sceneLayers)
        {
            layer.Apply(ref value, ref total);
        }

        //
        // Get final checksum
        //
            
        var lower = (ushort) ((value & ushort.MaxValue) + (value >> 16));
        var upper = (ushort) ((total & ushort.MaxValue) + (total >> 16));

        //
        // The checksum has two parts, one for the 'total', and one for the 'value', these combine to form a 32bit value
        // 
            
        return (uint) (upper << 16 | lower);
    }
}