using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using CommandLine;
using InfectedRose.Database;
using InfectedRose.Database.Fdb;
using InfectedRose.Interface.Templates;
using Microsoft.Data.Sqlite;
using RakDotNet.IO;

namespace InfectedRose.Interface
{
    public static class Program
    {
        public const string Version = "0.1";

        public static Options CommandLineOptions { get; set; }
        
        public static Dictionary<string, ModType> ModTypes { get; set; } = new Dictionary<string, ModType>();
        
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
            if (mod.Action != "add")
            {
                return;
            }

            var tableName = ModContext.GetComponentTableName(mod.Type);

            if (!string.IsNullOrWhiteSpace(mod.Table))
            {
                tableName = mod.Table;
            }

            var table = ModContext.Database[tableName];

            if (table != null)
            {
                var row = table.Create();
            
                ModContext.RegisterId(mod.Id, row.Key);
                
                ModContext.ApplyValues(mod, row, table);
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

        public static void ApplyModFile(Manifest manifest, string file)
        {
            Mod[] mods = ReadJson<Mod[]>(file);

            var directory = Directory.GetCurrentDirectory();
            
            Directory.SetCurrentDirectory(Path.GetDirectoryName(file)!);
            
            foreach (var mod in mods)
            {
                ModContext.Mods[mod.Id] = mod;
                
                ApplyMod(mod);

                if (!mod.ShowDefaults.HasValue || mod.ShowDefaults.Value == false)
                {
                    foreach (var (key, value) in mod.Defaults)
                    {
                        if (mod.HasValue(key) && (mod.Values[key] == null || (value != null && mod.Values[key].ToString() == value.ToString())))
                        {
                            mod.Values.Remove(key);
                        }
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

            foreach (var modFile in manifest.Files)
            {
                ApplyModFile(manifest, Path.Combine(directory, modFile));
            }
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

            accessDatabase.Save(Path.Combine(CommandLineOptions.Input, "../../res/cdclient.fdb"));
            
            connection.Close();
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

            foreach (var (key, value) in ModContext.Artifacts)
            {
                if (File.Exists(value))
                {
                    File.Delete(value);
                }
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
                
                localeSerializer.Serialize(stream, ModContext.Localization);
            }
            
            Console.WriteLine("Complete!");
        }
    }
}