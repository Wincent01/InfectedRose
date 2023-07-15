using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InfectedRose.Database.Generic;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using RakDotNet.IO;

namespace InfectedRose.Interface.Templates.World;

public class WorldInstance
{
    public static Dictionary<string, WorldInstance> WorldInstances { get; } = new();
    
    public string Name { get; set; }
    
    public LuzFile Zone { get; set; }
    
    public Dictionary<string, LvlFile> Scenes { get; set; }
    
    public HashSet<ulong> ClaimedIds { get; }
        
    public WorldInstance(string name, LuzFile zone, Dictionary<string, LvlFile> scenes, HashSet<ulong> claimedIds)
    {
        Name = name;
        Zone = zone;
        Scenes = scenes;
        ClaimedIds = claimedIds;
    }

    public ulong ClaimId()
    {
        var lowest = 0x38B40AUL;
        
        while (ClaimedIds.Contains(lowest))
        {
            lowest++;
        }
        
        ClaimedIds.Add(lowest);
        
        return lowest;
    }
    
    public static void Await(string id, Action<WorldInstance> callback)
    {
        if (WorldInstances.TryGetValue(id, out var instance))
        {
            callback(instance);
        }
        
        ModContext.AwaitId(id, zoneId =>
        {
            var zoneTable = ModContext.Database["ZoneTable"]!;

            if (!zoneTable.Seek(zoneId, out var zoneEntry))
            {
                throw new Exception($"Zone {zoneId} not found");
            }

            var zoneName = zoneEntry.Value<string>("zoneName").ToLower();
            
            var path = Path.Combine(ModContext.Root, "../res/maps/", zoneName);
            
            if (!File.Exists(path))
            {
                throw new Exception($"Zone file for {zoneName} not found: {path}");
            }
            
            var zone = new LuzFile();

            {
                using var zoneStream = File.OpenRead(path);
                using var zoneReader = new ByteReader(zoneStream);

                zone.Deserialize(zoneReader);
            }
            
            var scenes = new Dictionary<string, LvlFile>();
            
            var claimedIds = new HashSet<ulong>();
            
            var zoneRoot = Path.GetDirectoryName(path)!;
            
            foreach (var scene in zone.Scenes)
            {
                var scenePath = Path.Combine(zoneRoot, scene.FileName.ToLower());
                
                if (!File.Exists(scenePath))
                {
                    throw new Exception($"Scene file for {scene.SceneName} not found: {scenePath}");
                }
                
                var lvl = new LvlFile();

                using var lvlStream = File.OpenRead(scenePath);
                using var lvlReader = new ByteReader(lvlStream);

                lvl.Deserialize(lvlReader);

                if (lvl.LevelObjects != null)
                {
                    foreach (var template in lvl.LevelObjects.Templates)
                    {
                        claimedIds.Add(template.ObjectId);
                    }
                }
                
                scenes.Add(scene.FileName.ToLower(), lvl);
            }
            
            instance = new WorldInstance(zoneName, zone, scenes, claimedIds);
            
            WorldInstances.Add(id, instance);
            
            callback(instance);
        });
    }
    
    public static WorldInstance Get(string id)
    {
        if (!WorldInstances.TryGetValue(id, out var instance))
        {
            throw new Exception($"World instance {id} not found");
        }

        return instance;
    }
    
    public static void AwaitZone(string id, Action<LuzFile> callback)
    {
        Await(id, instance => callback(instance.Zone));
    }
    
    public static void AwaitScene(string id, string sceneName, Action<LvlFile> callback)
    {
        Await(id, instance =>
        {
            var sceneId = -1;
            var layerId = -1;

            if (sceneName.Contains(":"))
            {
                var split = sceneName.Split(':');

                if (split.Length != 3)
                {
                    throw new Exception($"Invalid scene id {id}");
                }
                
                sceneName = split[0];
                sceneId = int.Parse(split[1]);
                layerId = int.Parse(split[2]);
            }
            
            foreach (var scene in instance.Zone.Scenes)
            {
                if (sceneId == -1 && layerId == -1 && sceneName == scene.SceneName)
                {
                    callback(instance.Scenes[scene.FileName.ToLower()]);
                    
                    return;
                }

                if (sceneId != scene.SceneId || layerId != scene.LayerId || sceneName != scene.SceneName) continue;
                
                callback(instance.Scenes[scene.FileName.ToLower()]);
                    
                return;
            }
            
            throw new Exception($"Scene {sceneName} not found");
        });
    }

    public static void SaveWorldInstances()
    {
        foreach (var (name, instance) in WorldInstances)
        {
            SaveWorldInstance(name, instance.Zone, instance.Scenes);
        }
    }

    private static void SaveWorldInstance(string name, LuzFile luzFile, Dictionary<string, LvlFile> scenes)
    {
        var zoneTable = ModContext.Database["ZoneTable"]!;

        var zoneId = ModContext.AssertId(name);
        
        if (!zoneTable.Seek(zoneId, out var zoneEntry))
        {
            throw new Exception($"Zone {name} not found");
        }

        var zoneName = zoneEntry.Value<string>("zoneName").ToLower();
        
        var root = Path.Combine(
            ModContext.Root,
            ModContext.Configuration.ResourceFolder,
            $"./compiled/{zoneId}/", 
            Path.GetDirectoryName(zoneName)!
        );
        
        if (!Directory.Exists(root))
        {
            Directory.CreateDirectory(root);
        }
        
        var path = Path.Combine(root, Path.GetFileName(zoneName));

        {
            using var zoneStream = File.Create(path);
            using var zoneWriter = new ByteWriter(zoneStream);
            
            luzFile.Serialize(zoneWriter);
        }

        foreach (var (fileName, scene) in scenes)
        {
            var scenePath = Path.Combine(root, fileName);
            
            using var sceneStream = File.Create(scenePath);
            using var sceneWriter = new ByteWriter(sceneStream);
            
            scene.Serialize(sceneWriter);
        }
        
        var originalPath = Path.Combine(ModContext.Root, "../res/maps/", zoneName);
        
        // Copy all ".raw", ".lutriggers", ".evc", and ".ast" files
        foreach (var file in Directory.GetFiles(Path.GetDirectoryName(originalPath)!))
        {
            var extension = Path.GetExtension(file);
            
            if (extension == ".raw" || extension == ".lutriggers" || extension == ".evc" || extension == ".ast")
            {
                File.Copy(file, Path.Combine(root, Path.GetFileName(file)), true);
                
                // Remove read-only flag
                var attributes = File.GetAttributes(Path.Combine(root, Path.GetFileName(file)));
                attributes &= ~FileAttributes.ReadOnly;
                File.SetAttributes(Path.Combine(root, Path.GetFileName(file)), attributes);
            }
        }

        var link = new Uri(Path.Combine("../", ModContext.Configuration.ResourceFolder, $"./compiled/{zoneId}/", zoneName), UriKind.Relative);
        
        zoneEntry["zoneName"].Value = link.ToString();
    }
}