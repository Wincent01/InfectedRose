using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using InfectedRose.Database;
using InfectedRose.Database.Fdb;
using InfectedRose.Interface.Templates;

namespace InfectedRose.Interface;

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
        
    public static List<string> GeneralSql { get; set; } = new List<string>();

    public static List<IdCallback> IdCallbacks { get; set; } = new List<IdCallback>();
        
    public static Lookup Lookup { get; set; }
        
    public static Artifacts Artifacts { get; set; }

    public static bool IsId(JsonValue json)
    {
        // It is an id if it's a string and contains a ':' or is an integer.
        if (json.TryGetValue<string>(out var id))
        {
            return id.Contains(':') || int.TryParse(id, out _);
        }
            
        return false;
    }
        
    public static bool AwaitIdIfRequired(JsonValue json, Action<int> callback)
    {
        if (!IsId(json)) return false;
            
        AwaitId(json, callback);
                
        return true;

    }
        
    public static void AwaitId(string? id, Action<int> callback, bool requireMod = false, bool nonDefault = false)
    {
        if (id == null)
        {
            return;
        }
            
        if (int.TryParse(id, out var integer))
        {
            callback(integer);
                
            return;
        }
            
        if (id.StartsWith("lego-universe:") && !nonDefault)
        {
            // Parse ID from legacy format
            callback(int.Parse(id[14..]));
                
            return;
        }
            
        if (Lookup.TryGetValue(id, out var value) && !requireMod || requireMod && Mods.ContainsKey(id))
        {
            callback(value);
                
            return;
        }
            
        IdCallbacks.Add(new IdCallback { Id = id, Callback = callback });
    }
        
    public static void AwaitId(JsonValue json, Action<int> callback, bool requireMod = false, bool nonDefault = false)
    {
        if (json.TryGetValue<int>(out var value))
        {
            callback(value);
                
            return;
        }
            
        if (json.TryGetValue<string>(out var id))
        {
            AwaitId(id, callback, requireMod, nonDefault);
                
            return;
        }
            
        throw new Exception($"Undefined reference to id: {json}");
    }

    public static void AwaitMultiple(string[] ids, Action callback)
    {
        var count = 0;
            
        foreach (var id in ids)
        {
            AwaitId(id, _ =>
            {
                count++;
                    
                if (count == ids.Length)
                {
                    callback();
                }
            });
        }
    }

    public static int AssertId(JsonValue json)
    {
        if (json.TryGetValue<int>(out var value))
        {
            return value;
        }
            
        if (!json.TryGetValue<string>(out var id))
        {
            throw new Exception($"Undefined reference to id: {json}");
        }

        if (id.StartsWith("lego-universe:"))
        {
            // Parse ID from legacy format
            return int.Parse(id[14..]);
        }
            
        if (Lookup.TryGetValue(id, out var i))
        {
            return i;
        }
            
        throw new Exception($"Undefined reference to id: {json}");
    }

    public static bool ShouldBeNull(string id)
    {
        return string.IsNullOrWhiteSpace(id) || id == "lego-universe:0" || id == "lego-universe:-1";
    }

    public static int AssertId(string id)
    {
        if (id.StartsWith("lego-universe:"))
        {
            // Parse ID from legacy format
            return int.Parse(id[14..]);
        }
            
        if (Lookup.TryGetValue(id, out var i))
        {
            return i;
        }
            
        throw new Exception($"Undefined reference to id: {id}");
    }

    public static void RegisterId(string id, int value)
    {
        Lookup[id] = value;
        
        foreach (var idCallback in IdCallbacks.Where(callback => callback.Id == id).ToArray())
        {
            idCallback.Callback(value);

            IdCallbacks.Remove(idCallback);
        }
    }

    public static void RegisterArtifact(string file)
    {
        Artifacts.Add(file);
    }
    
    public static void CreateArtifactFrom(string sourceFile, string destination)
    {
        var dr = new Uri(Path.Combine(Root, "../", destination));

        var src = Path.GetRelativePath(Root, Directory.GetCurrentDirectory());
        
        var resources = Configuration.ResourceFolder;

        var relative = sourceFile.Split("mods/").Last();
            
        // Create the path to the resource folder
        var actual = new Uri(Path.Combine(Root, resources, src, relative));
        
        var relativePath = dr.MakeRelativeUri(actual).ToString();
        
        if (File.Exists(dr.LocalPath))
        {
            var artifactsRoot = Path.Combine(Root, "artifacts");
            
            if (!Directory.Exists(artifactsRoot))
            {
                Directory.CreateDirectory(artifactsRoot);
            }
            
            // Copy the directory structure to the artifacts folder
            var artifacts = Path.Combine(artifactsRoot, Path.GetDirectoryName(destination) ?? "./");
            
            if (!Directory.Exists(artifacts))
            {
                Directory.CreateDirectory(artifacts);
            }
            
            var dest = Path.Combine(artifacts, Path.GetFileName(dr.LocalPath));
            
            if (!File.Exists(dest))
            {
                File.Copy(dr.LocalPath, dest, true);
            }
            
            File.Delete(dr.LocalPath);
        }
        else
        {
            RegisterArtifact(dr.LocalPath);
        }
        
        File.CreateSymbolicLink(dr.LocalPath, relativePath);
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

        if (component == "QuickBuildComponent")
        {
            return "RebuildComponent";
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
            phrase = new Phrase
            {
                Id = id,
                Translations = new List<Translation>()
            };

            Localization.Phrases.Phrase.Add(phrase);
        }

        var translation = phrase.Translations.FirstOrDefault(t => t.Locale == locale);

        if (translation == null)
        {
            translation = new Translation
            {
                Locale = locale
            };

            phrase.Translations.Add(translation);
        }

        translation.Text = text;
    }

    public static bool TryGetFromLookup(Mod mod, out int key)
    {
        if (mod.ExplicitId.HasValue)
        {
            key = mod.ExplicitId.Value;

            return true;
        }

        if (Lookup.TryGetValue(mod.Id, out var value))
        {
            key = value;
                
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
        
    public static string ParseValue(string value, bool ignoreSpecialRoot = false, string root = "../../res/", string columnName = "")
    {
        if (value.StartsWith("INCLUDE:"))
        {
            value = value.Substring(8);
                
            return File.ReadAllText(value);
        }

        if (value.StartsWith("ICON:"))
        {
            value = value.Substring(5);

            if (!value.Contains(':'))
            {
                throw new Exception($"Invalid icon: {value}");
            }
                
            var folder = value.Split(':');
                
            var path = Path.Combine(Configuration.ResourceFolder, folder[0], "resources", "icon", folder[1]);

            return path;
        }
            
        if (string.IsNullOrWhiteSpace(Configuration.ResourceFolder))
        {
            throw new Exception("Resource folder not set");
        }
            
        var resources = Configuration.ResourceFolder;

        if (!value.Contains("mods/"))
        {
            return value;
        }

        if (columnName == "LXFMLFolder")
        {
            var r = value.Split("mods/").Last();
            var a = new Uri(Path.Combine(Root, resources, r));
            var s = new Uri(Path.Combine(Root, "../", "res/BrickModels/"));
                
            return s.MakeRelativeUri(a).ToString();
        }
            
        var extension = Path.GetExtension(value);

        if (string.IsNullOrWhiteSpace(extension) || string.IsNullOrWhiteSpace(Path.GetDirectoryName(value)))
        {
            return value;
        }

        var createSymlink = false;
            
        if (extension == ".hkx")
        {
            root = "res/physics/";
        }
        else if (extension == ".luz")
        {
            root = "res/maps/";
        }
        else if (extension == ".dds")
        {
            root = "res/mesh/bricks/";
        }
        else if (extension == ".lxfml")
        {
            root = "res/BrickModels/";
        }
        else if (extension is ".kfm" or ".nif")
        {
            root = "res/";
        }

        // Take all parts after the mods folder
        var relative = value.Split("mods/").Last();
            
        // Create the path to the resource folder
        var actual = new Uri(Path.Combine(Root, resources, relative));
            
        var source = new Uri(Path.Combine(Root, "../", root));
            
        // Get the relative path from the source to the resource folder
        var relativePath = source.MakeRelativeUri(actual).ToString();
            
        return relativePath;
    }

    public static int AddIcon(string file)
    {
        if (file.StartsWith("lego-universe:"))
        {
            return int.Parse(file.Substring(14));
        }
            
        file = ParseValue(file);

        var table = Database["Icons"]!;

        var icon = table.Create()!;

        icon["IconPath"].Value = "..\\..\\textures/../" + file;

        return icon.Key;
    }
    
    public static int AddIcon(string file, out string path)
    {
        if (file.StartsWith("lego-universe:"))
        {
            throw new Exception("Cannot add icon with lego-universe ID");
        }
            
        file = ParseValue(file);

        var table = Database["Icons"]!;

        var icon = table.Create()!;

        path = "..\\..\\textures/../" + file;
        
        icon["IconPath"].Value = path;

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

                    var parsed = ParseValue(str);
                        
                    if (parsed != str) break;

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
                {
                    field.Value = "";
                        
                    var str = objValue.ToString()!;

                    if (str.Contains(",") && str.Contains(":"))
                    {
                        var parts = str.Split(",");
                            
                        foreach (var part in parts)
                        {
                            var count = 1;
                                
                            var parts2 = part.Split(":");

                            if (parts2.Length >= 3)
                            {
                                var last = parts2.Last();
                                    
                                if (int.TryParse(last, out var c))
                                {
                                    count = c;
                                }
                                else
                                {
                                    throw new Exception($"Invalid count {last} in {str}");
                                }
                            }
                                
                            // Value is all parts except the last
                            var value = string.Join(":", parts2.Take(parts2.Length - 1));

                            AwaitId(value, id =>
                            {
                                if (field.Value == null || field.Value == "")
                                {
                                    field.Value = "";
                                }
                                else
                                {
                                    field.Value = $"{field.Value},";
                                }
                                    
                                field.Value = $"{field.Value}{id}:{count}";
                            });
                        }
                    }
                    else
                    {
                        field.Value = ParseValue(objValue.ToString()!, columnName: info.Name);
                    }
                }
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