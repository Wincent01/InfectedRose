using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using InfectedRose.Database;
using InfectedRose.Database.Fdb;

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
        
        public static Localization Localization { get; set; }
        
        public static Dictionary<string, int> Ids { get; set; } = new Dictionary<string, int>();
        
        public static Dictionary<string, Mod> Mods { get; set; } = new Dictionary<string, Mod>();
        
        public static List<string> ServerSql { get; set; } = new List<string>();
        
        public static List<IdCallback> IdCallbacks { get; set; } = new List<IdCallback>();

        public static void AwaitId(string id, Action<int> callback)
        {
            if (Ids.TryGetValue(id, out var value))
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
            
            Ids[id] = value;
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
        
        public static string ParseValue(string value)
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
            
            var root = "../../res/";
            
            if (value.StartsWith("PHYSICS:"))
            {
                root = "../../res/physics/";

                value = value.Substring(8);
            }
            else if (value.StartsWith("ICON:"))
            {
                root = "../../res/mesh/bricks/";

                value = value.Substring(5);
            }

            root = Root + root;

            // Get the relative path from root to asset
            var relative = Path.GetRelativePath(root, Path.Combine(value));
            
            return relative.Replace("/", "\\\\");
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