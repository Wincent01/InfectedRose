using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CommandLine;
using InfectedRose.Database;
using InfectedRose.Database.Fdb;
using InfectedRose.Interface.Templates;
using InfectedRose.Interface.Templates.World;
using InfectedRose.Luz;
using InfectedRose.Lvl;
using Microsoft.Data.Sqlite;
using RakDotNet.IO;
using SqlExt = InfectedRose.Database.Sql.ColumnExtensions;

namespace InfectedRose.Interface;

public static class Program
{
    public const string Version = "0.1";

    public static Options CommandLineOptions { get; set; }
        
    public static Dictionary<string, ModType> ModTypes { get; set; } = new Dictionary<string, ModType>();
        
    public static List<string> Zones { get; set; } = new List<string>();

    public class Options
    {
        [Option('i', "input", Required = false, HelpText = "Path to mods.json.")]
        public string Input { get; set; } = "mods.json";

        [Option('e', "export", Required = false, HelpText = "Export mods (object/skills).")]
        public string Export { get; set; }

        [Option('d', "id", Required = false, HelpText = "ID of mod to export.")]
        public string ExportId { get; set; }

        [Option('p', "prefix", Required = false, HelpText = "The prefix of the mods exported.")]
        public string Prefix { get; set; }
            
        [Option("database", Required = false, HelpText = "Override for database.")]
        public string DatabaseOverride { get; set; }
            
        [Option("no-sqlite", Required = false, HelpText = "If true, don't export database to SQLite.")]
        public bool NoSqlite { get; set; }
    }

    public static T ReadJson<T>(string file)
    {
        using var stream = File.OpenRead(file);

        return JsonSerializer.Deserialize<T>(stream) ?? throw new FileNotFoundException($"Could not find {file}!");
    }

    public static void WriteJson<T>(string file, T json)
    {
        using var stream = File.Create(file);
            
        var options = new JsonSerializerOptions();

        options.WriteIndented = true;
        options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

        JsonSerializer.Serialize(stream, json, options);
            
        stream.Close();
    }

    public static T ReadOrCreateJson<T>(string file) where T : new()
    {
        if (!File.Exists(file))
        {
            return new T();
        }
            
        using var stream = File.OpenRead(file);

        return JsonSerializer.Deserialize<T>(stream) ?? new T();
    }

    public static void ApplyRow(Mod mod)
    {
        var tableName = ModContext.GetComponentTableName(mod.Type);

        if (!string.IsNullOrWhiteSpace(mod.Table))
        {
            tableName = mod.Table;
        }

        var table = ModContext.Database[tableName];

        Row row;

        if (table != null)
        {
            if (mod.Action == "add")
            {
                row = table.Create();
            }
            else if (mod.Action == "edit")
            {
                if (!Enum.TryParse<ComponentId>(mod.Type, out var componentId))
                {
                    throw new Exception($"Could not parse component ID {mod.Type}!");
                }
                    
                if (!mod.Id.StartsWith("lego-universe:"))
                {
                    throw new InvalidOperationException($"Can not edit mod of id '{mod.Id}'; only mods starting with a prefix of 'lego-universe:' can be edited.");
                }
                    
                var id = int.Parse(mod.Id.Split(':')[1]);
                    
                var componentRegistry = ModContext.Database["ComponentsRegistry"];

                var componentRow = componentRegistry.SeekMultiple(id).FirstOrDefault(
                    c => (int)c["component_type"].Value == (int)componentId
                );
                    
                if (componentRow == null)
                {
                    throw new InvalidOperationException($"Could not find component with ID {id} of type {componentId}!");
                }

                if (!table.Seek((int) componentRow["component_id"].Value, out row))
                {
                    throw new InvalidOperationException($"Could not find mod to edit of id '{mod.Id}' in table '{tableName}'.");
                }
            }
            else if (mod.Action == "delete")
            {
                goto delete;
            }
            else
            {
                throw new InvalidOperationException($"Unknown action '{mod.Action}' for mod of id '{mod.Id}'.");
            }
            
            ModContext.RegisterId(mod.Id, row.Key);
                
            ModContext.ApplyValues(mod, row, table);
        }
            
        delete:
            
        if (mod.Action == "delete")
        {
            if (!Enum.TryParse<ComponentId>(mod.Type, out var componentId))
            {
                throw new Exception($"Could not parse component ID {mod.Type}!");
            }
                    
            if (!mod.Id.StartsWith("lego-universe:"))
            {
                throw new InvalidOperationException($"Can not delete mod of id '{mod.Id}'; only mods starting with a prefix of 'lego-universe:' can be deleted.");
            }
                    
            var id = int.Parse(mod.Id.Split(':')[1]);
                    
            var componentRegistry = ModContext.Database["ComponentsRegistry"];
                    
            var componentRow = componentRegistry.SeekMultiple(id).FirstOrDefault(
                c => (int)c["component_type"].Value == (int)componentId
            );
                    
            if (componentRow == null)
            {
                throw new InvalidOperationException($"Could not find component with ID {id} of type {componentId}!");
            }
                    
            if (table != null)
            {
                if (!table.Seek((int)componentRow["component_id"].Value, out row))
                {
                    throw new InvalidOperationException($"Could not find mod to delete of id '{mod.Id}' in table '{tableName}'.");
                }
                    
                table.Remove(row);
            }

            componentRegistry.Remove(componentRow);
        }
        else
        {
            // For entries without tables, like the MissionNPCComponent
            ModContext.RegisterId(mod.Id, 0);
        }
    }

    public static void ApplyMod(Mod mod)
    {
        Console.Write("\t\u21B3 ");
            
        if (ModTypes.TryGetValue(mod.Type, out var type))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
                
            type.Apply(mod);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            ApplyRow(mod);
        }
            
        Console.WriteLine($"[{mod.Type}] \"{mod.Id}\"");

        Console.ResetColor();
    }

    public static void ApplyModFile(Manifest manifest, string file, bool applyZone = false)
    {
        var mods = ReadJson<Mod[]>(file);

        var directory = Directory.GetCurrentDirectory();
            
        Directory.SetCurrentDirectory(Path.GetDirectoryName(file)!);
            
        foreach (var mod in mods)
        {
            ModContext.Mods[mod.Id] = mod;

            if (mod.Type == "zone" && !applyZone)
            {
                Zones.Add(file);
                    
                Directory.SetCurrentDirectory(directory);

                return;
            }
                
            ApplyMod(mod);

            if (mod.ShowDefaults.HasValue && mod.ShowDefaults.Value) continue;
                
            foreach (var (key, value) in mod.Defaults)
            {
                if (mod.HasValue(key) && (mod.Values[key] == null || (value != null && mod.Values[key].ToString() == value.ToString())))
                {
                    mod.Values.Remove(key);
                }
            }
        }
            
        Directory.SetCurrentDirectory(directory);
            
        WriteJson(file, mods);
    }

    public static void ApplyManifest(string file)
    {
        Manifest manifest = ReadJson<Manifest>(file);
            
        Console.Write("Applying ");

        Console.ForegroundColor = ConsoleColor.Green;
            
        Console.WriteLine($"\"{manifest.Name}\"");
            
        Console.ResetColor();

        var directory = Path.GetDirectoryName(file)!;
            
        var resources = ModContext.Configuration.ResourceFolder;
            
        if (!string.IsNullOrWhiteSpace(resources))
        {
            if (!Directory.Exists(resources))
            {
                Directory.CreateDirectory(resources);
            }
                
            // Get the directory name of the mod (last part of the path)
            var modName = manifest.Name;

            var link = Path.Combine(resources, modName);
                
            if (Directory.Exists(link))
            {
                Directory.Delete(link);
            }

            Directory.CreateSymbolicLink(link, Path.GetRelativePath(resources, directory));
        }
            
        foreach (var modFile in manifest.Files)
        {
            ApplyModFile(manifest, Path.Combine(directory, modFile));
        }

        foreach (var zone in Zones)
        {
            ApplyModFile(manifest, zone, true);
        }
            
        Zones.Clear();
    }

    public static void SaveDatabase()
    {
        // Save the database
        if (CommandLineOptions.NoSqlite)
        {
            foreach (var table in ModContext.Database)
            {
                table.Recalculate();
            }
            
            ModContext.Database.Save(Path.Combine(CommandLineOptions.Input, "../../res/cdclient.fdb"));

            return;
        }
            
        // Export the database as SQLite
        if (File.Exists(ModContext.Configuration.Sqlite))
        {
            File.Delete(ModContext.Configuration.Sqlite);
        }

        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ModContext.Configuration.Sqlite };

        using var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            
        connection.Open();

        ModContext.Database.SaveSqlite(connection);
            
        {
            // Setup lookup table
            new SqliteCommand(
                "CREATE TABLE lookupTable ( \"id\" TEXT_4 PRIMARY KEY NOT NULL, \"value\" INT NOT NULL );",
                connection
            ).ExecuteNonQuery();

            // Create lookup function
            connection.CreateFunction("lookup", (string id) => ModContext.Lookup[id]);

            // Insert all the ids
            foreach (var (id, value) in ModContext.Lookup)
            {
                SqliteCommand command = new SqliteCommand(
                    "INSERT INTO lookupTable (id, value) VALUES (@id, @value);",
                    connection
                );

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@value", value);

                command.ExecuteNonQuery();

                // Test the function
                command = new SqliteCommand(
                    "SELECT lookup(@id);",
                    connection
                );

                command.Parameters.AddWithValue("@id", id);

                var result = command.ExecuteReader();

                if (!result.Read())
                {
                    throw new Exception($"Could not find {id} in lookup table!");
                }

                if (result.GetInt32(0) != value)
                {
                    throw new Exception($"Lookup function returned {result.GetInt32(0)} instead of {value}!");
                }
            }
        }

        // Run general sql commands
        foreach (var command in ModContext.GeneralSql)
        {
            using var commandInstance = new SqliteCommand(command, connection);

            commandInstance.ExecuteNonQuery();
        }

        // Do a trip from SQL -> XML -> FDB
        XmlDatabase tmp = XmlDatabase.LoadSql(connection);

        // Run sql commands specified by mods on the server
        foreach (var command in ModContext.ServerSql)
        {
            using var commandInstance = new SqliteCommand(command, connection);
                
            commandInstance.ExecuteNonQuery();
        }
            
        AccessDatabase accessDatabase = AccessDatabase.OpenXml(tmp);
            
        foreach (var table in accessDatabase)
        {
            table.Recalculate();
        }
            
        // Set the permissions of the database to allow writing
        var clientDatabase = Path.Combine(CommandLineOptions.Input, "../../res/cdclient.fdb");
            
        if (File.Exists(clientDatabase))
        {
            var attributes = File.GetAttributes(clientDatabase);
                
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                File.SetAttributes(clientDatabase, attributes & ~FileAttributes.ReadOnly);
            }
        }

        accessDatabase.Save(clientDatabase);
            
        connection.Close();

        var sqliteCopy = Path.Combine(CommandLineOptions.Input, "../../res/CDServer.sqlite");
            
        if (File.Exists(sqliteCopy))
        {
            File.Delete(sqliteCopy);
        }
            
        File.Copy(ModContext.Configuration.Sqlite, sqliteCopy);
    }

    public static async Task ConsoleRotateAnimation(Task other)
    {
        var index = 0;
        var array = new[] {"|", "/", "-", "\\", "|", "/", "-", "\\"};

        while (!other.IsCompleted)
        {
            await Task.Delay(100);
                    
            Console.Write(array[index++ % array.Length] + "\b");
        }
            
        Console.WriteLine();
    }

    public static Mod[] CopyObject(int lot, string id)
    {
        var objectsTable = ModContext.Database["Objects"];
        var componentsRegistryTable = ModContext.Database["ComponentsRegistry"];

        if (!objectsTable.Seek(lot, out var objectRow))
        {
            throw new Exception($"Failed to find object {lot} to copy!");
        }
            
        var componentRegistryRows = componentsRegistryTable.SeekMultiple(lot).ToArray();
            
        var mods = new List<Mod>();
            
        var objectMod = new Mod();
        mods.Add(objectMod);
            
        objectMod.Id = id;
        objectMod.Type = "object";
            
        var components = new List<string>();
            
        foreach (var registryRow in componentRegistryRows)
        {
            var componentId = (int) registryRow["component_id"].Value;
            var componentType = (ComponentId) registryRow["component_type"].Value;
                
            var componentMod = new Mod();
            mods.Add(componentMod);
                
            componentMod.Id = $"{id}:{componentType}";
            componentMod.Type = $"{componentType}";
                
            components.Add(componentMod.Id);
                
            var table = ModContext.Database[ModContext.GetComponentTableName(componentMod.Type)];

            if (table == null || !table.Seek(componentId, out var componentRow))
            {
                continue;
            }

            foreach (var field in componentRow.ToArray()[1..])
            {
                if (field.Type == DataType.Nothing) continue;
                    
                componentMod.Values[field.Name] = field.Value;
            }
        }

        objectMod.Components = components.ToArray();
            
        foreach (var field in objectRow.ToArray()[1..])
        {
            if (field.Type == DataType.Nothing) continue;
                
            objectMod.Values[field.Name] = field.Value;
        }

        return mods.ToArray();
    }

    public static Effect? LoadEffect(int effectId, string prefix)
    {
        var behaviorEffectTable = ModContext.Database["BehaviorEffect"];
            
        if (!behaviorEffectTable.Seek(effectId, out var behaviorEffect))
        {
            return null;
        }
            
        var effect = new Effect();

        effect.Id = $"{prefix}:effect:{effectId}";
            
        effect.Values = new Dictionary<string, object>();

        foreach (var field in behaviorEffect)
        {
            switch (field.Name)
            {
                case "effectID":
                    break;
                case "effectType":
                    effect.EffectType = field.Value as string;
                    break;
                case "effectName":
                    effect.EffectName = field.Value as string;
                    break;
                case "animationName":
                    effect.AnimationName = field.Value as string;
                    break;
                case "boneName":
                    effect.BoneName = field.Value as string;
                    break;
                default:
                    if (field.Value is float f && f == 0 || field.Value is int i && i == 0)
                    {
                        break;
                    }
                        
                    effect.Values[field.Name] = field.Value;
                    break;
            }
        }
            
        return effect;
    }

    public static Behavior? ExportBehavior(int behaviorId, string prefix)
    {
        var behaviorTemplateTable = ModContext.Database["BehaviorTemplate"]!;
        var behaviorParameterTable = ModContext.Database["BehaviorParameter"]!;
        var behaviorTemplateNameTable = ModContext.Database["BehaviorTemplateName"]!;

        if (!behaviorTemplateTable.Seek(behaviorId, out var behaviorTemplate))
        {
            return null;
        }
            
        var behavior = new Behavior();

        var templateId = (int) behaviorTemplate["templateID"].Value;

        if (!behaviorTemplateNameTable.Seek(templateId, out var templateName))
        {
            return null;
        }

        behavior.Template = (string) templateName["name"].Value;
            
        behavior.Effect = LoadEffect((int) behaviorTemplate["effectID"].Value, prefix);
        behavior.EffectHandle = behaviorTemplate["effectHandle"].Value as string;
        behavior.Parameters = new Dictionary<string, object>();

        foreach (var parameter in behaviorParameterTable.SeekMultiple(behaviorTemplate.Key))
        {
            behavior.Parameters[(string) parameter["parameterID"].Value] = (float) parameter["value"].Value;
        }

        return behavior;
    }

    public static void SeekTree(Behavior behavior, Dictionary<string, Behavior> registry, string prefix)
    {
        foreach (var (key, parameter) in behavior.Parameters)
        {
            if (!(parameter is float f)) continue;

            var value = (int) f;
                
            if (value < 1000)
            {
                continue;
            }
                
            var id = $"{prefix}:behavior:{value}";

            if (registry.ContainsKey(id))
            {
                behavior.Parameters[key] = id;

                continue;
            }
                
            var branch = ExportBehavior(value, prefix);

            if (branch == null)
            {
                continue;
            }
                
            behavior.Parameters[key] = id;

            registry[id] = branch;
                
            SeekTree(branch, registry, prefix);
        }
    }

    public static void ExportSkill(int skillId, string prefix = "lego-universe")
    {
        var skillBehaviorTable = ModContext.Database["SkillBehavior"]!;

        if (!skillBehaviorTable.Seek(skillId, out var skillBehavior))
        {
            return;
        }
            
        var behaviors = new Dictionary<string, Behavior>();

        var rootId = (int) skillBehavior["behaviorID"].Value;
        var root = ExportBehavior(rootId, prefix)!;

        var rootName = $"{prefix}:behavior:{rootId}";
            
        behaviors[rootName] = root;

        SeekTree(root, behaviors, prefix);
            
        var mod = new Mod();
        mod.Type = "skill";
        mod.Behaviors = behaviors;
        mod.Id = $"{prefix}:skill:{skillId}";
        mod.Values["root-behavior"] = rootName;

        for (var index = 1; index < skillBehavior.Count; index++)
        {
            var field = skillBehavior[index];
                
            if (field.Name == "behaviorID") continue;

            mod.Values[field.Name] = field.Value;
        }

        WriteJson($"{prefix}-skill-{skillId}.json", new[] {mod});
    }

    public static AccessDatabase LoadXmlDatabase(AccessDatabase constraints, string file)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(XmlDatabase));

        var content = File.ReadAllText(file);

        content = content
            .Replace("", "'")
            .Replace("", "")
            .Replace("", "")
            .Replace("", "a");
            
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            
        var xmlDatabase = (XmlDatabase) serializer.Deserialize(stream)!;

        var database = AccessDatabase.OpenXml(constraints, xmlDatabase);
            
        return database;
    }
        
    public static XmlDatabase LoadXmlDatabase(string file)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(XmlDatabase));

        var content = File.ReadAllText(file);

        content = content
            .Replace("", "'")
            .Replace("", "")
            .Replace("", "")
            .Replace("", "a");
            
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            
        var xmlDatabase = (XmlDatabase) serializer.Deserialize(stream)!;

        return xmlDatabase;
    }

    private static void CopyFilesRecursively(string sourcePath, string targetPath)
    {
        //Now Create all of the directories
        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
        }

        //Copy all the files & Replaces any files with the same name
        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
        {
            File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
        }
    }

    private static void CompareZones(string pathA, string pathB)
    {
        using var luzAStream = File.OpenRead(pathA);
        using var luzAReader = new ByteReader(luzAStream);
            
        var luzA = new LuzFile();
        luzA.Deserialize(luzAReader);
            
        var rootA = Path.GetDirectoryName(pathA)!;
            
        using var luzBStream = File.OpenRead(pathB);
        using var luzBReader = new ByteReader(luzBStream);
            
        var luzB = new LuzFile();
        luzB.Deserialize(luzBReader);
            
        var rootB = Path.GetDirectoryName(pathB)!;
            
        if (luzA.Scenes.Length != luzB.Scenes.Length)
        {
            throw new Exception("Scene count mismatch");
        }
            
        if (luzA.Transitions.Length != luzB.Transitions.Length)
        {
            throw new Exception("Transition count mismatch");
        }

        for (var index = 0; index < luzA.PathData.Length; ++index)
        {
            var pathAData = luzA.PathData[index];
            var pathBData = luzB.PathData.First(b => b.PathName == pathAData.PathName);

            if (pathAData.PathName == "smashNetwork4")
            {
                continue;
            }
                
            if (pathAData.Type != pathBData.Type)
            {
                throw new Exception($"Path type mismatch: {pathAData.PathName}");
            }
                
            if (pathAData.Behavior != pathBData.Behavior)
            {
                throw new Exception($"Path behavior mismatch: {pathAData.PathName}");
            }
                
            if (pathAData.Waypoints.Length != pathBData.Waypoints.Length)
            {
                throw new Exception($"Path waypoint count mismatch: {pathAData.PathName}");
            }
        }

        /*
        for (var index = 0; index < luzA.Transitions.Length; index++)
        {
            var transitionA = luzA.Transitions[index];
            var transitionB = luzB.Transitions[index];
            
            if (transitionA.SceneTransitionName != transitionB.SceneTransitionName)
            {
                throw new Exception("Transition name mismatch");
            }
            
            if (transitionA.TransitionPoints.Length != transitionB.TransitionPoints.Length)
            {
                throw new Exception("Transition point count mismatch");
            }
            
            for (var pointIndex = 0; pointIndex < transitionA.TransitionPoints.Length; pointIndex++)
            {
                var pointA = transitionA.TransitionPoints[pointIndex];
                var pointB = transitionB.TransitionPoints[pointIndex];
                
                if (pointA.SceneId != pointB.SceneId)
                {
                    throw new Exception("Transition point scene id mismatch");
                }
            }
        }
        */

        for (var sceneIndex = 0; sceneIndex < luzA.Scenes.Length; ++sceneIndex)
        {
            var sceneA = luzA.Scenes[sceneIndex];
            var sceneB = luzB.Scenes[sceneIndex];
                
            if (sceneA.LayerId != sceneB.LayerId || sceneA.SceneId != sceneB.SceneId)
            {
                throw new Exception("Scene id/layer mismatch");
            }
                
            var lvlAPath = Path.Combine(rootA, sceneA.FileName);
                
            using var lvlAStream = File.OpenRead(lvlAPath);
            using var lvlAReader = new ByteReader(lvlAStream);
                
            var lvlA = new LvlFile();
            lvlA.Deserialize(lvlAReader);
                
            var lvlBPath = Path.Combine(rootB, sceneB.FileName);
                
            using var lvlBStream = File.OpenRead(lvlBPath);
            using var lvlBReader = new ByteReader(lvlBStream);
                
            var lvlB = new LvlFile();
            lvlB.Deserialize(lvlBReader);
                
            if ((lvlA.LevelObjects == null) != (lvlB.LevelObjects == null))
            {
                continue;
            }
                
            if (lvlA.LevelEnvironmentConfig != null && lvlB.LevelEnvironmentConfig != null)
            {
                var envA = lvlA.LevelEnvironmentConfig;
                var envB = lvlB.LevelEnvironmentConfig;
                    
                if (envA.ParticleStructs.Length != envB.ParticleStructs.Length)
                {
                    throw new Exception("Particle count mismatch");
                }

                for (var particleIndex = 0; particleIndex < envA.ParticleStructs.Length; ++particleIndex)
                {
                    var particleA = envA.ParticleStructs[particleIndex];
                    var particleB = envB.ParticleStructs[particleIndex];

                    if (particleA.Config != particleB.Config)
                    {
                        throw new Exception("Particle config mismatch");
                    }
                        
                    if (particleA.ParticleName != particleB.ParticleName)
                    {
                        throw new Exception("Particle name mismatch");
                    }
                        
                    if (particleA.Priority != particleB.Priority)
                    {
                        throw new Exception("Particle priority mismatch");
                    }
                }
            }
                
            if (lvlA.LevelSkyConfig != null && lvlB.LevelSkyConfig != null)
            {
                var skyA = lvlA.LevelSkyConfig;
                var skyB = lvlB.LevelSkyConfig;
                    
                if (skyA.Skybox[0] != skyB.Skybox[0])
                {
                    throw new Exception("Skybox mismatch");
                }
            }
                
            if (lvlA.LevelObjects.Templates.Length != lvlB.LevelObjects.Templates.Length)
            {
                throw new Exception("Template count mismatch");
            }
                
            // Loop through all templates
            for (var templateIndex = 0; templateIndex < lvlA.LevelObjects.Templates.Length; ++templateIndex)
            {
                var templateA = lvlA.LevelObjects.Templates[templateIndex];
                var templateB = lvlB.LevelObjects.Templates[templateIndex];

                if (templateA.ObjectId != templateB.ObjectId)
                {
                    throw new Exception("Template id mismatch");
                }
                    
                if (templateA.Lot != templateB.Lot)
                {
                    throw new Exception("Template lot mismatch");
                }
                    
                if (Math.Abs(templateA.Scale - templateB.Scale) > 0.01f)
                {
                    throw new Exception("Template scale mismatch");
                }
                    
                if (templateA.AssetType != templateB.AssetType)
                {
                    throw new Exception("Template asset type mismatch");
                }
                    
                if (templateA.LegoInfo.ToString() != templateB.LegoInfo.ToString())
                {
                    Console.WriteLine("Template LegoInfo mismatch");
                }
            }
                
            Console.WriteLine($"Scene {sceneIndex} OK");
        }
            
        Console.WriteLine("OK");
    }

    public static void Main(string[] arguments)
    {
        // Parse command line arguments
        CommandLineOptions = Parser.Default.ParseArguments<Options>(arguments).Value;

        // Collect all implemented mod types
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var attribute = type.GetCustomAttribute<ModTypeAttribute>();

            if (attribute == null)
            {
                continue;
            }

            ModTypes[attribute.Type] = Activator.CreateInstance(type) as ModType ?? 
                                       throw new InvalidOperationException($"Invalid mod type class {type}!");
        }
            
        // Store the root directory
        ModContext.Root = Directory.GetCurrentDirectory();
            
        ModContext.Configuration = ReadOrCreateJson<Mods>(CommandLineOptions.Input);

        // Load lookup
        ModContext.Lookup = ReadOrCreateJson<Lookup>("lookup.json");

        // Load locale
        XmlSerializer localeSerializer = new XmlSerializer(typeof(Localization));

        // Load artifacts
        ModContext.Artifacts = ReadOrCreateJson<Artifacts>("artifacts.json");

        foreach (var value in ModContext.Artifacts)
        {
            if (File.Exists(value))
            {
                File.Delete(value);
            }
        }
        
        // Copy the "ModContext.Root/artifacts" folder to "ModContext.Root/../", overwriting any existing files
        var artifactsSourcePath = Path.Combine(ModContext.Root, "./artifacts");
        var artifactsDestinationPath = Path.Combine(ModContext.Root, "../");
        
        // Get all files and copy them with replacement, keeping folder structure
        foreach (var sourcePath in Directory.GetFiles(artifactsSourcePath, "*.*", SearchOption.AllDirectories))
        {
            var destinationPath = sourcePath.Replace(artifactsSourcePath, artifactsDestinationPath);
            var destinationDirectory = Path.GetDirectoryName(destinationPath);

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory!);
            }
            
            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }

            File.Copy(sourcePath, destinationPath);
        }

        ModContext.Artifacts.Clear();

        var localeSourcePath = Path.Combine(Path.GetDirectoryName(CommandLineOptions.Input)!, "./locale.xml");
        var localeDestinationPath = Path.Combine(Path.GetDirectoryName(CommandLineOptions.Input)!, "../locale/locale.xml");

        if (!File.Exists(localeSourcePath))
        {
            File.Copy(localeDestinationPath, localeSourcePath);
        }

        using (var stream = File.OpenRead(localeSourcePath))
        {
            ModContext.Localization = (Localization) localeSerializer.Deserialize(stream)!;
        }

        // Check version
        if (string.IsNullOrWhiteSpace(ModContext.Configuration.Version))
        {
            ModContext.Configuration.Version = Version;
        }
        else if (ModContext.Configuration.Version != Version)
        {
            throw new Exception($"Version {Version} incompatible with mods.json version {ModContext.Configuration.Version}");
        }

        if (!string.IsNullOrWhiteSpace(ModContext.Configuration.ResourceFolder))
        {
            var assetsDirectory = Path.Combine(Path.GetDirectoryName(CommandLineOptions.Input)!, ModContext.Configuration.ResourceFolder);

            if (Directory.Exists(assetsDirectory))
            {
                Directory.Delete(assetsDirectory, true);
            }

            Directory.CreateDirectory(assetsDirectory);
        }
            
        // Create the mods.json file or update it
        WriteJson(CommandLineOptions.Input, ModContext.Configuration);

        var databasePath = !string.IsNullOrWhiteSpace(CommandLineOptions.DatabaseOverride)
            ? CommandLineOptions.DatabaseOverride
            : ModContext.Configuration.Database;
            
        // Open database
        if (!File.Exists(ModContext.Configuration.Database))
        {
            var databaseSourcePath = Path.Combine(Path.GetDirectoryName(CommandLineOptions.Input)!, "./cdclient.fdb");
            var databaseDestinationPath = Path.Combine(Path.GetDirectoryName(CommandLineOptions.Input)!, "../res/cdclient.fdb");
                
            File.Copy(databaseDestinationPath, databaseSourcePath);
        }

        var origin = Console.GetCursorPosition();

        Console.Write("Starting  \b");

        var openDatabaseTask = Task.Run(() =>
        {
            var database = AccessDatabase.Open(databasePath);

            ModContext.Database = database;
            ModContext.OriginalDatabase = database.ToXml();
        });

        var rotation = Task.Run(async () =>
        {
            await ConsoleRotateAnimation(openDatabaseTask);
        });

        Task.WaitAll(openDatabaseTask, rotation);

        Console.SetCursorPosition(origin.Left, origin.Top);

        var componentsRegistry = ModContext.Database["ComponentsRegistry"];
        var renderComponentTable = ModContext.Database["RenderComponent"];
        
        /*
        foreach (var itemComponent in ModContext.Database["ItemComponent"])
        {
            if (!"special_r".Equals(itemComponent[1].Value)) continue;
            
            var componentRow = componentsRegistry.FirstOrDefault(
                c => itemComponent.Key.Equals(c[2].Value) && ((int) ComponentId.ItemComponent).Equals(c[1].Value)
            );
            
            if (componentRow == null) continue;

            var lot = componentRow.Key;

            var renderComponentEntry = componentsRegistry.SeekMultiple(lot).FirstOrDefault(c => 2.Equals(c[1].Value));
            
            if (renderComponentEntry == null) continue;
            
            if (!renderComponentTable.Seek((int) renderComponentEntry[2].Value, out var renderComponent)) continue;

            var field = renderComponent[5];
            
            if (field.Value is null or 0) continue;
            
            Console.WriteLine($"Found {field.Value} for {lot}");
        }
        
        return;
        */

        if (CommandLineOptions.Export == "object")
        {
            Console.Write($"Generating copy of {CommandLineOptions.ExportId} as ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[object] \"{CommandLineOptions.ExportId}\"");
            Console.ResetColor();
            Console.WriteLine($" to {CommandLineOptions.Prefix}.json");
                
            var mods = CopyObject(int.Parse(CommandLineOptions.ExportId), CommandLineOptions.Prefix);
                
            WriteJson($"{CommandLineOptions.Prefix}.json", mods);
                
            return;
        }

        if (CommandLineOptions.Export == "skills")
        {
            foreach (var row in ModContext.Database["ObjectSkills"].SeekMultiple(int.Parse(CommandLineOptions.ExportId)))
            {
                ExportSkill((int) row["skillID"].Value, CommandLineOptions.Prefix ?? "lego-universe");
            }
                
            return;
        }
            
        // Sort the mods into a list of priorities
        List<string> priorities;

        if (ModContext.Configuration.Priorities.Count != 0)
        {
            ModContext.Configuration.Priorities.Sort((a, b) => a.Priority - b.Priority);

            priorities = ModContext.Configuration.Priorities.Select(m => m.Directory).ToList();
        }
        else
        {
            priorities = new List<string>();
                
            foreach (var file in Directory.GetFiles("./", "*manifest.json", SearchOption.AllDirectories))
            {
                priorities.Add(Path.GetDirectoryName(file)!);
            }
        }

        // Apply the mods
        foreach (var priority in priorities)
        {
            ApplyManifest(Path.Combine(priority, "./manifest.json"));
        }
        
        WorldInstance.SaveWorldInstances();
            
        // Check for unresolved references and print errors
        if (ModContext.IdCallbacks.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
                
            foreach (var callback in ModContext.IdCallbacks)
            {
                Console.WriteLine($"Unknown reference to \"{callback.Id}\"");
            }
                
            Console.ResetColor();
                
            throw new Exception($"{ModContext.IdCallbacks.Count} unknown references found!");
        }
            
        // Create the lookup.json for ids
        WriteJson("lookup.json", ModContext.Lookup);
            
        // Create the artifacts.json for symlinks
        WriteJson("artifacts.json", ModContext.Artifacts);

        // Copy over files
        if (ModContext.Configuration.Copy != null)
        {
            if (Directory.Exists(ModContext.Configuration.Copy))
            {
                Directory.Delete(ModContext.Configuration.Copy, true);
            }
                
            File.CreateSymbolicLink(ModContext.Configuration.Copy, ModContext.Root);
        }

        origin = Console.GetCursorPosition();

        if (File.Exists("lupdata.xml"))
        {
            // TODO: Generate lupdata.xml for interop with Happy Flower
        }
            
        Console.Write("Saving  \b");
            
        var saveDatabaseTask = Task.Run(SaveDatabase);

        rotation = Task.Run(async () =>
        {
            await ConsoleRotateAnimation(saveDatabaseTask);
        });
            
        Task.WaitAll(saveDatabaseTask, rotation);

        Console.SetCursorPosition(origin.Left, origin.Top);

        using (var stream = File.Create(localeDestinationPath))
        {
            ModContext.Localization.Locales.Count = ModContext.Localization.Locales.Locale.Length;
            ModContext.Localization.Phrases.Count = ModContext.Localization.Phrases.Phrase.Count;

            foreach (var pTranslation in ModContext.Localization.Phrases.Phrase.SelectMany(p => p.Translations))
            {
                if (pTranslation.Text == null) continue;
                    
                pTranslation.Text = pTranslation.Text.Replace("'", "[']").Replace("\n", @"[\n]");
            }
                
            localeSerializer.Serialize(stream, ModContext.Localization);
        }

        {
            var localeContent = File.ReadAllText(localeDestinationPath);
                
            localeContent = localeContent.Replace("[']", "&apos;").Replace(@"[\n]", "&#x0A;");
                
            File.WriteAllText(localeDestinationPath, localeContent);
        }
            
        Console.WriteLine("Complete!");
    }
}