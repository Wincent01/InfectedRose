using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using InfectedRose.Database;
using InfectedRose.Database.Fdb;
using InfectedRose.Interface.Templates;

namespace InfectedRose.Interface
{
    public class IdCallback
    {
        public string Id { get; set; }
        
        public Action<int> Callback { get; set; }
    }
    
    public static class ModContext
    {
        public static Mods Configuration { get; set; }
        
        public static string Root { get; set; }

        public static AccessDatabase Database { get; set; }
        
        public static XmlDatabase OriginalDatabase { get; set; }

        public static Localization Localization { get; set; }
        
        public static Dictionary<string, Mod> Mods { get; set; } = new Dictionary<string, Mod>();
        
        public static List<string> ServerSql { get; set; } = new List<string>();
        
        public static List<IdCallback> IdCallbacks { get; set; } = new List<IdCallback>();
        
        public static Lookup Lookup { get; set; }
        
        public static Artifacts Artifacts { get; set; }

        public static void AwaitId(JsonValue json, Action<int> callback)
        {
            if (json.TryGetValue<int>(out var value))
            {
                callback(value);
                
                return;
            }
            
            IdCallbacks.Add(new IdCallback { Id = json.ToString(), Callback = callback });
        }
        
        public static void AwaitId(string id, Action<int> callback)
        {
            if (Lookup.TryGetValue(id, out var value))
            {
                callback(value);
                
                return;
            }
            
            IdCallbacks.Add(new IdCallback { Id = id, Callback = callback });
        }

        public static void RegisterId(string id, int value)
        {
            foreach (var idCallback in IdCallbacks.Where(callback => callback.Id == id).ToArray())
            {
                idCallback.Callback(value);

                IdCallbacks.Remove(idCallback);
            }
            
            Lookup[id] = value;
        }

        public static void RegisterArtifact(string source, string destination)
        {
            Artifacts[source] = destination;
        }

        public static void CreateArtifact(string source, string destination)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"Could not create artifact to non-existent file: {source}");
            }

            File.CreateSymbolicLink(source, destination);
            
            RegisterArtifact(source, destination);
        }

        public static void CreateArtifactFrom(string sourceFile, string destinationDirectory)
        {
            var dr = Path.Combine(Root, "../", destinationDirectory);

            var src = Path.GetRelativePath(dr, Directory.GetCurrentDirectory());
                
            var destination = Path.Combine(dr, Path.GetFileName(sourceFile));

            src = Path.Combine(src, sourceFile);
            
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.CreateSymbolicLink(destination, src);
            
            RegisterArtifact(src, destination);
        }

        public static Mod GetMod(string id)
        {
            return Mods[id];
        }

        public static Table? GetComponentTable(ComponentId component)
        {
            return Database[GetComponentTableName(component)];
        }

        public static Table? GetComponentTable(string component)
        {
            return Database[GetComponentTableName(component)];
        }
        
        public static string GetComponentTableName(ComponentId component)
        {
            if (component == ComponentId.QuickBuildComponent)
            {
                return "RebuildComponent";
            }
            
            return GetComponentTableName(component.ToString());
        }
        
        public static string GetComponentTableName(string component)
        {
            if (component.Contains("PhysicsComponent"))
            {
                return "PhysicsComponent";
            }

            return component;
        }

        public static T ParseEnum<T>(string value)
        {
            // Remove spaces and dashes
            value = value.Replace(" ", "").Replace("-", "");
            
            // Parse the enum case-insensitively
            return (T) Enum.Parse(typeof(T), value, true);
        }

        public static void AddToLocale(string id, string locale, Mod mod)
        {
            if (!mod.HasValue(locale))
            {
                var normalized = locale.Replace("_", "").Replace("-", "").ToLower();
                
                if (mod.HasValue(normalized))
                {
                    AddToLocale(id, mod.GetValue<Dictionary<string, string>>(normalized));
                }
                
                return;
            }
            
            AddToLocale(id, mod.GetValue<Dictionary<string, string>>(locale));
        }

        public static void AddToLocale(string id, Dictionary<string, string> locales)
        {
            foreach (var (locale, text) in locales)
            {
                AddToLocale(id, text, locale);
            }
        }

        public static void AddToLocale(string id, string text, string locale)
        {
            var phrase = Localization.Phrases.Phrase.FirstOrDefault(p => p.Id == id);

            if (phrase == null)
            {
                phrase = new Phrase();

                phrase.Id = id;
                
                phrase.Translations = new List<Translation>();
                
                Localization.Phrases.Phrase.Add(phrase);
            }

            var translation = phrase.Translations.FirstOrDefault(t => t.Locale == locale);

            if (translation == null)
            {
                translation = new Translation();

                translation.Locale = locale;
                
                phrase.Translations.Add(translation);
            }

            translation.Text = text;
        }

        public static bool TryGetFromLookup(Mod mod, out int key)
        {
            if (Lookup.TryGetValue(mod.Id, out var value))
            {
                key = value;
                
                return true;
            }
            
            if (mod.ExplicitId.HasValue)
            {
                key = mod.ExplicitId.Value;

                return true;
            }
            
            if (mod.OldIds == null)
            {
                key = 0;
                
                return false;
            }

            if (mod.OldIds.Any(oldId => Lookup.TryGetValue(oldId, out value)))
            {
                key = value;
                
                return true;
            }
            
            key = 0;
            
            return false;
        }
        
        public static string ParseValue(string value, bool ignoreSpecialRoot = false)
        {
            if (value.StartsWith("INCLUDE:"))
            {
                value = value.Substring(8);
                
                return File.ReadAllText(value);
            }
            
            if (!value.StartsWith("ASSET:"))
            {
                return value;
            }

            value = value.Substring(6);

            var createSymlink = false;
            
            var root = "../../res/";
            
            if (value.StartsWith("PHYSICS:"))
            {
                root = "../../res/physics/";

                value = value.Substring(8);
            }
            else if (value.StartsWith("MAP:"))
            {
                root = "../../res/maps/";

                value = value.Substring(4);
            }
            else if (value.StartsWith("ICON:"))
            {
                root = "../../res/mesh/bricks/";

                value = value.Substring(5);
            }
            else if (value.StartsWith("LXFML:"))
            {
                createSymlink = true;

                root = "res/BrickModels/";

                value = value.Substring(6);
            }

            if (ignoreSpecialRoot)
            {
                root = "../../res/";
            }

            string final;

            // Copy the file to the selected resource folder is specified
            if (!string.IsNullOrWhiteSpace(Configuration.ResourceFolder))
            {
                final = Path.Combine(Root, Configuration.ResourceFolder, Path.GetRelativePath(Root, Directory.GetCurrentDirectory()), value);

                var directory = Path.GetDirectoryName(final);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory!);
                }

                if (!File.Exists(final))
                {
                    File.Copy(value, final);
                }
            }
            else
            {
                final = value;
            }

            if (createSymlink)
            {
                CreateArtifactFrom(value, root);
                
                /*
                var dr = Path.Combine(Root, "../", root);

                var src = Path.GetRelativePath(dr, Directory.GetCurrentDirectory());
                
                var destination = Path.Combine(dr, Path.GetFileName(value));

                src = Path.Combine(src, value);
                
                Console.WriteLine(destination);

                if (File.Exists(destination))
                {
                    File.Delete(destination);
                }

                File.CreateSymbolicLink(destination, src);
                */
            }

            root = Root + root;

            // Get the relative path from root to asset
            var finalRelative = Path.GetRelativePath(root, final);

            return finalRelative;
        }

        public static int AddIcon(string file)
        {
            file = ParseValue(file);

            var table = Database["Icons"]!;

            var icon = table.Create()!;

            icon["IconPath"].Value = "..\\..\\textures/../" + file;

            return icon.Key;
        }

        public static void ApplyValues(Dictionary<string, object> values, Row row, Table table, bool defaultNull = false)
        {
            for (var index = 1; index < table.TableInfo.Count; index++)
            {
                var info = table.TableInfo[index];
                if (info == null)
                {
                    continue;
                }

                var field = row[info.Name];

                if (!values.TryGetValue(info.Name, out var objValue))
                {
                    if (defaultNull)
                    {
                        field.Value = null;
                    }

                    continue;
                }

                if (objValue == null)
                {
                    field.Value = null;

                    continue;
                }

                switch (info.Type)
                {
                    case DataType.Integer:
                    {
                        var str = objValue.ToString();

                        if (str.Contains(':'))
                        {
                            AwaitId(str, id => { field.Value = id; });
                        }
                        else
                        {
                            field.Value = InterpretValue<int>(objValue);
                        }

                        break;
                    }
                    case DataType.Float:
                        field.Value = InterpretValue<float>(objValue);
                        break;
                    case DataType.Varchar:
                    case DataType.Text:
                        field.Value = ParseValue(objValue.ToString()!);
                        break;
                    case DataType.Boolean:
                        field.Value = InterpretValue<bool>(objValue);
                        break;
                    case DataType.Bigint:
                        field.Value = InterpretValue<long>(objValue);
                        break;
                }
            }
        }

        public static T InterpretValue<T>(object obj)
        {
            if (obj is JsonElement jsonElement)
            {
                return jsonElement.Deserialize<T>()!;
            }
            
            if (obj is T value)
            {
                return value;
            }

            if (obj is null)
            {
                return default;
            }

            return (T) Convert.ChangeType(obj, typeof(T));
        }
        
        public static void ApplyValues(Mod mod, Row row, Table table)
        {
            foreach (var (key, objValue) in mod.Values)
            {
                var info = table.TableInfo.FirstOrDefault(column => column.Name == key);

                if (info == null)
                {
                    continue;
                }
                
                var field = row[key];
                
                if (objValue == null)
                {
                    field.Value = null;
                    
                    continue;
                }
                
                switch (info.Type)
                {
                    case DataType.Integer:
                    {
                        var str = objValue.ToString();

                        if (str.Contains(':'))
                        {
                            AwaitId(str, id =>
                            {
                                field.Value = id;
                            });
                        }
                        else
                        {
                            field.Value = mod.GetValue<int>(key);
                        }
                        
                        break;
                    }
                    case DataType.Float:
                        field.Value = mod.GetValue<float>(key);
                        break;
                    case DataType.Varchar:
                    case DataType.Text:
                        field.Value = ParseValue(objValue.ToString()!);
                        break;
                    case DataType.Boolean:
                        field.Value = mod.GetValue<bool>(key);
                        break;
                    case DataType.Bigint:
                        field.Value = mod.GetValue<long>(key);
                        break;
                }
            }
        }
    }
}