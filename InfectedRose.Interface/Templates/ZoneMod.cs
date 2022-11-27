using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using InfectedRose.Database;
using InfectedRose.Interface.Templates.ValueTypes;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using InfectedRose.Triggers;
using RakDotNet.IO;

namespace InfectedRose.Interface.Templates
{
    [ModType("zone")]
    public class ZoneMod : ModType
    {
        public void InsertZone(Mod mod)
        {
            var zoneTable = ModContext.Database["ZoneTable"];

            Row entry;
            
            if (ModContext.TryGetFromLookup(mod, out var key))
            {
                entry = zoneTable.Create(key);
            }
            else
            {
                for (var i = 1000;; i += 100)
                {
                    if (zoneTable.ContainsKey(i))
                    {
                        continue;
                    }

                    entry = zoneTable.Create(i);
                    
                    break;
                }
            }
            
            mod.Default("ghostdistance_min", 150);
            mod.Default("ghostdistance", 250);
            mod.Default("population_soft_cap", 10);
            mod.Default("population_hard_cap", 15);
            mod.DefaultNull("smashableMinDistance");
            mod.DefaultNull("smashableMaxDistance");
            mod.DefaultNull("zoneControlTemplate");
            mod.DefaultNull("widthInChunks");
            mod.DefaultNull("heightInChunks");
            mod.Default("petsAllowed", true);
            mod.Default("localize", true);
            mod.Default("fZoneWeight", 1);
            mod.Default("PlayersLoseCoinsOnDeath", true);
            mod.DefaultNull("teamRadius");
            mod.Default("mountsAllowed", true);
            
            ModContext.RegisterId(mod.Id, entry.Key);
            
            ModContext.ApplyValues(mod, entry, zoneTable);

            if (mod.Locale != null)
            {
                ModContext.AddToLocale($"ZoneTable_{entry.Key}_DisplayDescription", mod.Locale);
            }

            if (mod.HasValue("zone"))
            {
                entry["zoneName"].Value = ModContext.ParseValue(mod.GetValue<string>("zone"));
            }
        }
        
        public void AddZone(Mod mod)
        {
            var zoneTable = ModContext.Database["ZoneTable"];

            Row entry;
            
            if (ModContext.TryGetFromLookup(mod, out var key))
            {
                entry = zoneTable.Create(key);
            }
            else
            {
                for (var i = 1000;; i += 100)
                {
                    if (zoneTable.ContainsKey(i))
                    {
                        continue;
                    }

                    entry = zoneTable.Create(i);
                    
                    break;
                }
            }
            mod.Default("ghostdistance_min", 150);
            mod.Default("ghostdistance", 250);
            mod.Default("population_soft_cap", 10);
            mod.Default("population_hard_cap", 15);
            mod.DefaultNull("smashableMinDistance");
            mod.DefaultNull("smashableMaxDistance");
            mod.DefaultNull("zoneControlTemplate");
            mod.DefaultNull("widthInChunks");
            mod.DefaultNull("heightInChunks");
            mod.Default("petsAllowed", true);
            mod.Default("localize", true);
            mod.Default("fZoneWeight", 1);
            mod.Default("PlayersLoseCoinsOnDeath", true);
            mod.DefaultNull("teamRadius");
            mod.Default("mountsAllowed", true);
            
            ModContext.RegisterId(mod.Id, entry.Key);
            
            ModContext.ApplyValues(mod, entry, zoneTable);

            var zone = mod.Zone!;

            var root = $"./compiled/{mod.Id}/";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            else
            {
                foreach (var file in Directory.EnumerateFiles(root))
                {
                    File.Delete(file);
                }
            }
            
            File.CreateSymbolicLink(Path.Combine(root, Path.GetFileName(zone.TerrainFile)), Path.Combine("../../", zone.TerrainFile));
            
            var luzFile = new LuzFile();

            luzFile.TerrainFile = zone.TerrainFile;
            luzFile.TerrainFileName = zone.TerrainFile;
            luzFile.TerrainDescription = Path.GetFileNameWithoutExtension(zone.TerrainFile);

            luzFile.Version = 0x29U;

            luzFile.RevisionNumber = 1;

            luzFile.SpawnPoint = zone.SpawnPoint;
            luzFile.SpawnRotation = zone.SpawnRotation;

            luzFile.WorldId = (uint)entry.Key;

            luzFile.PathFormatVersion = 1;

            luzFile.PathData = new LuzPathData[zone.Paths.Length];

            for (var index = 0; index < zone.Paths.Length; index++)
            {
                var data = zone.Paths[index];
                LuzPathData luzPathData;

                const uint version = 0x12U;

                var type = Enum.Parse<PathType>(data.Type);

                switch (type)
                {
                    case PathType.Movement:
                        luzPathData = new LuzPathData(version);
                        luzPathData.Waypoints = data.Waypoints.Select(w =>
                        {
                            return (LuzPathWaypoint) new LuzMovementWaypoint(version)
                            {
                                Position = w.Position,
                                Configs = w.Configuration.Select(c => new LuzPathConfig()
                                {
                                    ConfigName = c.Name,
                                    ConfigTypeAndValue = c.Value.ToString()
                                }).ToArray()
                            };
                        }).ToArray();
                        break;
                    case PathType.MovingPlatform:
                        var movingPlatformPath = new LuzMovingPlatformPath(version);
                        luzPathData = movingPlatformPath;
                        movingPlatformPath.MovingPlatformSound = data.Sound;
                        movingPlatformPath.TimeBased = data.TimeBased!.Value;
                        luzPathData.Waypoints = data.Waypoints.Select(w => (LuzPathWaypoint) new LuzMovingPlatformWaypoint(version)
                        {
                            Position = w.Position,
                            Rotation = w.Rotation!.Value,
                            LockPlayer = w.LockPlayer!.Value,
                            Speed = w.Speed!.Value,
                            Wait = w.Wait!.Value,
                            DepartSound = w.DepartSound,
                            ArriveSound = w.ArriveSound
                        }).ToArray();
                        break;
                    case PathType.Property:
                        var propertyPath = new LuzPropertyPath(version);
                        luzPathData = propertyPath;
                        propertyPath.Price = data.Price!.Value;
                        propertyPath.RentalTime = data.RentalTime!.Value;
                        propertyPath.AssociatedZone = ulong.Parse(data.AssociativeZone!);
                        propertyPath.DisplayName = data.DisplayName;
                        propertyPath.DisplayDescription = data.DisplayDescription;
                        propertyPath.CloneLimit = data.CloneLimit!.Value;
                        propertyPath.ReputationMultiplier = data.ReputationMultiplier!.Value;
                        propertyPath.TimeUnit = Enum.Parse<RentalTimeUnit>(data.TimeUnit);
                        propertyPath.Achievement = Enum.Parse<AchievementRequired>(data.Achievement);
                        propertyPath.PlayerZonePoint = data.PlayerZonePoint!.Value;
                        propertyPath.MaxBuildHeight = data.MaxBuildHeight!.Value;
                        luzPathData.Waypoints = data.Waypoints.Select(w => (LuzPathWaypoint) new LuzPathWaypoint(version)
                        {
                            Position = w.Position
                        }).ToArray();
                        break;
                    case PathType.Camera:
                        var cameraPath = new LuzCameraPath(version);
                        luzPathData = cameraPath;
                        cameraPath.NextPath = data.NextPath;
                        cameraPath.Waypoints = data.Waypoints.Select(w => (LuzPathWaypoint) new LuzCameraWaypoint(version)
                        {
                            Position = w.Position,
                            Rotation = w.Rotation!.Value,
                            Time = w.Time!.Value,
                            Tension = w.Tension!.Value,
                            Continuity = w.Continuity!.Value,
                            Bias = w.Bias!.Value,
                            FieldOfView = w.FieldOfView!.Value
                        }).ToArray();
                        break;
                    case PathType.Spawner:
                        var spawnerPath = new LuzSpawnerPath(version);
                        luzPathData = spawnerPath;
                        spawnerPath.SpawnedId = data.SpawnedId;
                        spawnerPath.SpawnedLot = (uint)ModContext.AssertId(data.SpawnedId!);
                        spawnerPath.RespawnTime = (uint)data.RespawnTime!.Value;
                        spawnerPath.MaxSpawnCount = data.MaxSpawnCount!.Value;
                        spawnerPath.NumberToMaintain = (uint)data.NumberToMaintain!.Value;
                        spawnerPath.SpawnerObject = data.SpawnerObject;
                        spawnerPath.SpawnerObjectId = long.Parse(data.SpawnerObject!);
                        spawnerPath.ActivateSpawnerNetworkOnLoad = data.ActivateOnLoad!.Value;
                        luzPathData.Waypoints = data.Waypoints.Select(w =>
                        {
                            return (LuzPathWaypoint) new LuzSpawnerWaypoint(version)
                            {
                                Position = w.Position,
                                Configs = w.Configuration.Select(c => new LuzPathConfig()
                                {
                                    ConfigName = c.Name,
                                    ConfigTypeAndValue = c.Value.ToString()
                                }).ToArray()
                            };
                        }).ToArray();
                        break;
                    case PathType.Showcase:
                        luzPathData = new LuzPathData(version);
                        luzPathData.Waypoints = data.Waypoints.Select(w => (LuzPathWaypoint) new LuzPathWaypoint(version)
                        {
                            Position = w.Position
                        }).ToArray();
                        break;
                    case PathType.Race:
                        luzPathData = new LuzPathData(version);
                        luzPathData.Waypoints = data.Waypoints.Select(w => (LuzPathWaypoint) new LuzRaceWaypoint(version)
                        {
                            Position = w.Position,
                            Rotation = w.Rotation!.Value
                        }).ToArray();
                        break;
                    case PathType.Rail:
                        luzPathData = new LuzPathData(version);
                        luzPathData.Waypoints = data.Waypoints.Select(w => (LuzPathWaypoint) new LuzRailWaypoint(version)
                        {
                            Position = w.Position,
                            UnknownQuaternion = w.Rotation!.Value,
                            Speed = w.Speed!.Value,
                            Configs = w.Configuration.Select(c => new LuzPathConfig()
                            {
                                ConfigName = c.Name,
                                ConfigTypeAndValue = c.Value.ToString()
                            }).ToArray()
                        }).ToArray();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                luzPathData.Type = type;
                luzPathData.PathName = data.Name;
                luzPathData.Behavior = (PathBehavior)Enum.Parse(typeof(PathBehavior), data.Behavior);
                
                luzFile.PathData[index] = luzPathData;
            }

            luzFile.Scenes = new LuzScene[zone.Scenes.Length];

            var objId = 0x38B40AUL;
            
            var taken = new HashSet<ulong>();

            for (var i = 0; i < zone.Scenes.Length; ++i)
            {
                var lvl = new LvlFile();
                var luzScene = luzFile.Scenes[i] = new LuzScene();

                var scene = zone.Scenes[i];

                luzScene.LayerId = (uint)scene.Layer;
                luzScene.SceneId = (uint)scene.Id;
                luzScene.SceneName = scene.Name;
                string filename;
                if (scene.Layer == 0)
                {
                    filename = Path.Combine(root, $"{mod.Id.Replace("-", "_")}_{scene.Id}_{scene.Name.ToLower().Replace(" ", "_")}.lvl");
                }
                else
                {
                    filename = Path.Combine(root, $"{mod.Id.Replace("-", "_")}_{scene.Id}x{scene.Layer}_{scene.Name.ToLower().Replace(" ", "_")}.lvl");
                }
                luzScene.FileName = Path.GetFileName(filename);

                lvl.LvlVersion = 0x2D;

                if (scene.Layer == 0)
                {
                    var levelSkyConfig = new LevelSkyConfig();

                    levelSkyConfig.Skybox[0] = scene.Skybox;

                    levelSkyConfig.Identifiers = new IdStruct[11]
                    {
                        new IdStruct(),
                        new IdStruct(1, 100, 150),
                        new IdStruct(2, 150, 200),
                        new IdStruct(3, 200, 250),
                        new IdStruct(4, 350, 450),
                        new IdStruct(5, 50, 100),
                        new IdStruct(6, 40, 40),
                        new IdStruct(7, 400, 600),
                        new IdStruct(8, 60, 100),
                        new IdStruct(9, 50, 100),
                        new IdStruct(10, 300, 400)
                    };

                    levelSkyConfig.SavedColors = new byte[388]
                    {
                        32, 0, 0, 0, 141, 140, 12, 62, 141, 140, 12, 62, 193, 192, 64, 62, 255, 254, 126, 63, 0, 0, 128, 63,
                        222, 221, 93, 63, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 245, 117, 63, 181, 180, 52,
                        62, 0, 0, 0, 0, 181, 180, 180, 62, 161, 160, 160, 62, 0, 0, 0, 0, 184, 183, 55, 63, 227, 226, 98,
                        63, 0, 0, 0, 0, 184, 183, 55, 63, 227, 226, 98, 63, 255, 254, 126, 63, 0, 0, 128, 63, 222, 221, 93,
                        63, 166, 165, 37, 63, 166, 165, 37, 63, 166, 165, 37, 63, 0, 0, 0, 0, 181, 180, 180, 62, 161, 160,
                        160, 62, 0, 0, 0, 0, 181, 180, 52, 62, 161, 160, 32, 62, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128,
                        63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0,
                        128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63,
                        0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128,
                        63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0,
                        128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63,
                        0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128,
                        63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0,
                        128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63,
                        0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128,
                        63
                    };

                    levelSkyConfig.LightInformation = new float[25]
                    {
                        scene.BlendTime,
                        scene.AmbientColor.R, scene.AmbientColor.G, scene.AmbientColor.B,
                        scene.SpecularColor.R, scene.SpecularColor.G, scene.SpecularColor.B,
                        scene.UpperHemiColor.R, scene.UpperHemiColor.G, scene.UpperHemiColor.B,
                        scene.LightDirection.X, scene.LightDirection.Y, scene.LightDirection.Z,
                        scene.FogNearMin, scene.FogFarMin, scene.PostFogSolidMin, scene.PostFogFadeMin,
                        0, 0,
                        scene.FogNearMax, scene.FogFarMax, scene.PostFogSolidMax, scene.PostFogFadeMax,
                        0, 0
                    };
                    
                    levelSkyConfig.FogColor = new[]
                    {
                        scene.FogColor.R, scene.FogColor.G, scene.FogColor.B
                    };
                    
                    levelSkyConfig.DirectionalLightColor = new[]
                    {
                        scene.DirectionalLightColor.R, scene.DirectionalLightColor.G, scene.DirectionalLightColor.B
                    };
                    
                    lvl.LevelSkyConfig = levelSkyConfig;
                }

                var levelObjects = new LevelObjects(lvl.LvlVersion);
                
                levelObjects.Templates = new LevelObjectTemplate[scene.Templates.Length];

                for (var o = 0; o < scene.Templates.Length; o++)
                {
                    var template = scene.Templates[o];
                    var levelObjectTemplate = levelObjects.Templates[o] = new LevelObjectTemplate();

                    levelObjectTemplate.Lot = ModContext.AssertId(template.Id);
                    levelObjectTemplate.Position = template.Position;
                    levelObjectTemplate.Rotation = template.Rotation;
                    levelObjectTemplate.Scale = template.Scale;
                    levelObjectTemplate.AssetType = (uint)template.Type;
                    levelObjectTemplate.GlomId = 1;
                    
                    var objectId = template.ObjectId ?? objId++;

                    while (!template.ObjectId.HasValue && taken.Contains(objectId))
                    {
                        objectId = objId++;
                    }
                    
                    taken.Add(objectId);
                    
                    levelObjectTemplate.ObjectId = objectId;

                    var dataString = new StringBuilder();
                    foreach (var (dataKey, dataValue) in template.Data)
                    {
                        var type = dataValue.TypeId;
                        var value = dataValue.Value;
                        
                        if (value is true) value = 1;
                        if (value is false) value = 0;
                        if (dataValue.Type == "id")
                        {
                            value = ModContext.AssertId(value.ToString()!);
                            type = 1;
                        }
                        
                        if (value != null)
                        {
                            value = value.ToString();
                
                            if (value == "True") value = "1";
                            else if (value == "False") value = "0";
                        }
                        
                        dataString.Append($"{dataKey}={type}:{value}\n");
                    }

                    if (dataString.Length > 0)
                    {
                        dataString.Length -= 1;
                    
                        levelObjectTemplate.LegoInfo = LegoDataDictionary.FromString(dataString.ToString());
                    }
                    else
                    {
                        levelObjectTemplate.LegoInfo = new LegoDataDictionary();
                    }
                }
                
                lvl.LevelObjects = levelObjects;

                if (scene.Particles != null && scene.Particles.Any())
                {
                    lvl.LevelEnvironmentConfig = new LevelEnvironmentConfig(lvl.LvlVersion)
                    {
                        ParticleStructs = scene.Particles.Select(p => new ParticleStruct(lvl.LvlVersion)
                        {
                            Position = p.Position,
                            Rotation = p.Rotation,
                            ParticleName = p.Name
                        }).ToArray()
                    };
                }
                else
                {
                    lvl.LevelEnvironmentConfig = null; //new LevelEnvironmentConfig(lvl.LvlVersion) { ParticleStructs = Array.Empty<ParticleStruct>() };
                }

                var collection = new TriggerCollection();

                collection.Triggers = new List<Trigger>();
                
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

                ns.Add("", "");
                
                if (scene.Triggers != null && scene.Triggers.Any())
                {
                    foreach (var trigger in scene.Triggers)
                    {
                        collection.Triggers.Add(trigger);
                    }

                    // Filename but with .lutriggers extension
                    var path = Path.Combine(Path.GetDirectoryName(filename)!, Path.GetFileNameWithoutExtension(filename) + ".lutriggers");
                
                    // Save as xml
                    var xml = new XmlSerializer(typeof(TriggerCollection));

                    using var stream = new StreamWriter(path);
                    using var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true });
                    xml.Serialize(xmlWriter, collection, ns);
                }

                if (scene.SceneAudio != null)
                {
                    if (!string.IsNullOrWhiteSpace(scene.SceneAudio.Guid2D))
                    {
                        // Filename but with .aud extension
                        var path = Path.Combine(Path.GetDirectoryName(filename)!, Path.GetFileNameWithoutExtension(filename) + ".aud");
                    
                        // Save as xml
                        var xml = new XmlSerializer(typeof(SceneAudio));
                    
                        using var stream = new StreamWriter(path);
                        using var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true });
                        xml.Serialize(xmlWriter, scene.SceneAudio, ns);
                    }
                }

                lvl.LevelInfo = new LevelInfo();

                lvl.LevelInfo.RevisionNumber = 1;
                
                using var fileStream = File.Create(filename);
                using var writer = new ByteWriter(fileStream);
                
                lvl.Serialize(writer);
            }
            
            var sceneList = luzFile.Scenes.ToList();

            sceneList.Sort((a, b) => (int)(a.SceneId * 1000 + a.LayerId) - (int)(b.SceneId * 1000 + b.LayerId));
            
            luzFile.Scenes = sceneList.ToArray();
            
            luzFile.Transitions = new LuzSceneTransition[zone.Transitions.Length];

            for (var index = 0; index < zone.Transitions.Length; index++)
            {
                var version = 0x2DU;
                
                var data = zone.Transitions[index];

                var transition = new LuzSceneTransition(version);
                
                transition.SceneTransitionName = data.Name;

                transition.UnknownFloat = 0;

                transition.TransitionPoints = new LuzSceneTransitionPoint[data.Points.Length];

                for (var transitionPointIndex = 0; transitionPointIndex < data.Points.Length; transitionPointIndex++)
                {
                    var transitionPoint = new LuzSceneTransitionPoint();
                    transitionPoint.Point = data.Points[transitionPointIndex].Position;
                    transitionPoint.SceneId = luzFile.Scenes.First(s => s.SceneName == data.Points[transitionPointIndex].Scene).SceneId;
                    
                    transition.TransitionPoints[transitionPointIndex] = transitionPoint;
                }
                
                luzFile.Transitions[index] = transition;
            }
            
            var luzFilename = Path.Combine(root, $"{mod.Id.ToLower()}.luz");
            
            using var zoneFileStream = File.Create(luzFilename);
            using var zoneWriter = new ByteWriter(zoneFileStream);
            
            luzFile.Serialize(zoneWriter);
            
            if (mod.Locale != null)
            {
                ModContext.AddToLocale($"ZoneTable_{entry.Key}_DisplayDescription", mod.Locale);
            }

            entry["zoneName"].Value = ModContext.ParseValue($"ASSET:MAP:{luzFilename}");
        }
        
        public override void Apply(Mod mod)
        {
            if (mod.Action == "insert")
            {
                InsertZone(mod);
                
                return;
            }
            
            if (mod.Action == "add")
            {
                AddZone(mod);
                
                return;
            }

            throw new NotSupportedException(
                            "Action " + mod.Action + " is not supported for zone mods"
            );
        }
    }
}