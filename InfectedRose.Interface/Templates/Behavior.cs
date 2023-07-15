using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates;

public class Behavior
{
    [JsonPropertyName("template")]
    public string Template { get; set; }
            
    [JsonPropertyName("effect")]
    public Effect? Effect { get; set; }
        
    [JsonPropertyName("effect-handle")]
    public string? EffectHandle { get; set; }
            
    [JsonPropertyName("parameters")]
    public Dictionary<string, object>? Parameters { get; set; }

    public int Apply(string id)
    {
        var behaviorTemplateTable = ModContext.Database["BehaviorTemplate"]!;
        var behaviorParameterTable = ModContext.Database["BehaviorParameter"]!;
        var behaviorTemplateNameTable = ModContext.Database["BehaviorTemplateName"]!;

        var templateName = behaviorTemplateNameTable.FirstOrDefault(t => (string) t["name"].Value == Template);
        
        if (templateName == null)
        {
            throw new Exception($"Invalid behavior template {Template}!");
        }

        var behaviorTemplate = behaviorTemplateTable.FromLookup(id);
            
        ModContext.RegisterId(id, behaviorTemplate.Key);
            
        behaviorTemplate["templateID"].Value = (int) templateName["templateID"].Value;
        var effectId = behaviorTemplate["effectID"];
        if (Effect == null)
        {
            effectId.Value = 0;
        }
        else if (Effect.Id.StartsWith("lego-universe"))
        {
            effectId.Value = Effect.Id.Split(":")[1];
        }
        else
        {
            effectId.Value = Effect.Apply();
        }
        
        behaviorTemplate["effectHandle"].Value = EffectHandle;
        
        if (Parameters == null) return behaviorTemplate.Key;

        foreach (var (key, value) in Parameters)
        {
            var parameter = behaviorParameterTable.Create(behaviorTemplate.Key);
            parameter["parameterID"].Value = key;

            var valueField = parameter["value"];

            if (float.TryParse(value.ToString(), out var f))
            {
                valueField.Value = f;
                    
                continue;
            }
            
            // Check if true or false
            if (value.ToString()!.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                valueField.Value = 1;
                    
                continue;
            }
            
            if (value.ToString()!.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                valueField.Value = 0;
                    
                continue;
            }
                
            ModContext.AwaitId(value.ToString()!, i =>
            {
                valueField.Value = (float) i;
            });
        }

        return behaviorTemplate.Key;
    }
}