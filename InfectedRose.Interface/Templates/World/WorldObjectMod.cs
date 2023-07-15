using System;
using System.Collections.Generic;
using System.Text;
using InfectedRose.Interface.Templates.ValueTypes;
using InfectedRose.Lvl;

namespace InfectedRose.Interface.Templates.World;

[ModType("world-object")]
public class WorldObjectMod : ModType
{
    public override void Apply(Mod mod)
    {
        var zoneId = mod.GetValue<string>("zone");
        var sceneId = mod.GetValue<string>("scene");
        
        WorldInstance.AwaitScene(zoneId, sceneId, scene => ApplyToZone(mod, scene));
    }

    private void ApplyToZone(Mod mod, LvlFile scene)
    {
        if (scene.LevelObjects == null)
        {
            scene.LevelObjects = new LevelObjects(scene.LvlVersion);
        }

        var zoneId = mod.GetValue<string>("zone");

        var instance = WorldInstance.Get(zoneId);
        
        LevelObjectTemplate levelObjectTemplate;

        switch (mod.Action)
        {
            case "add":
            {
                levelObjectTemplate = new LevelObjectTemplate(scene.LvlVersion);
                
                levelObjectTemplate.ObjectId = instance.ClaimId();
            } break;
            default:
            {
                throw new Exception($"Unknown action {mod.Action} for world-object");
            } break;
        }

        var template = mod.GetValue<LevelTemplate>("template");
        
        ModContext.AwaitId(template.Id, lot =>
        {
            levelObjectTemplate.Lot = lot;
        });
        
        levelObjectTemplate.Position = template.Position;
        levelObjectTemplate.Rotation = template.Rotation;
        levelObjectTemplate.Scale = template.Scale ?? 1;
        levelObjectTemplate.AssetType = (uint) (template.Type ?? 1);
        levelObjectTemplate.GlomId = 1;
        
        var dataString = new StringBuilder();

        var ids = new List<string>();

        foreach (var (_, dataValue) in template.Data)
        {
            var value = dataValue.ObjectValue ?? "";
            
            if (dataValue.Type == FieldType.Object)
            {
                ids.Add(value.ToString()!);
            }
        }
        
        ModContext.AwaitMultiple(ids.ToArray(), () =>
        {
            foreach (var (dataKey, dataValue) in template.Data)
            {
                var type = dataValue.TypeId;
                var value = dataValue.ObjectValue ?? "";
                    
                if (value is true) value = 1;
                if (value is false) value = 0;
                if (dataValue.Type == FieldType.Object)
                {
                    value = ModContext.AssertId(value.ToString()!);
                    type = 1;
                }
                    
                var strValue = value.ToString()!;

                if (dataValue.Type == FieldType.Position)
                {
                    if (dataValue.Value.TryGetValue(out string? _))
                    {
                        strValue = strValue.Replace("<", "").Replace(">", "").Replace(" ", "");
                        var split = strValue.Split(',');
                        strValue = $"{split[0]}\u001F{split[1]}\u001F{split[2]}";
                    }
                    else
                    {
                        var obj = dataValue.Value.ToDictionary();
                        strValue = $"{obj["X"]}\u001F{obj["Y"]}\u001F{obj["Z"]}";
                    }
                }
                else if (dataValue.Type == FieldType.Rotation)
                {
                    if (dataValue.Value.TryGetValue(out string? _))
                    {
                        strValue = strValue.Replace("<", "").Replace(">", "").Replace(" ", "");
                        var split = strValue.Split(',');
                        strValue = $"{split[0]}\u001F{split[1]}\u001F{split[2]}\u001F{split[3]}";
                    }
                    else
                    {
                        var obj = dataValue.Value.ToDictionary();
                        strValue = $"{obj["X"]}\u001F{obj["Y"]}\u001F{obj["Z"]}\u001F{obj["W"]}";
                    }
                }

                if (strValue == "True") strValue = "1";
                else if (strValue == "False") strValue = "0";
                    
                dataString.Append($"{dataKey}={type}:{strValue}\n");
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
            
            // Resize and add the object
            var levelObjectsTemplates = scene.LevelObjects.Templates;
            Array.Resize(ref levelObjectsTemplates, levelObjectsTemplates.Length + 1);
            levelObjectsTemplates[^1] = levelObjectTemplate;
            scene.LevelObjects.Templates = levelObjectsTemplates;
        });
    }
}