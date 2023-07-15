using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates;

public class Effect
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string EffectType { get; set; }
            
    [JsonPropertyName("name")]
    public string EffectName { get; set; }
            
    [JsonPropertyName("animation")]
    public string AnimationName { get; set; }
            
    [JsonPropertyName("bone")]
    public string BoneName { get; set; }
            
    [JsonPropertyName("values")]
    public Dictionary<string, object> Values { get; set; }

    public int Apply()
    {
        var behaviorEffectTable = ModContext.Database["BehaviorEffect"];

        var behaviorEffect = behaviorEffectTable.FromLookup(Id);
            
        ModContext.RegisterId(Id, behaviorEffect.Key);
            
        foreach (var field in behaviorEffect)
        {
            switch (field.Name)
            {
                case "effectID":
                    break;
                case "effectType":
                    field.Value = EffectType;
                    break;
                case "effectName":
                    field.Value = EffectName;
                    break;
                case "animationName":
                    field.Value = AnimationName;
                    break;
                case "boneName":
                    field.Value = BoneName;
                    break;
            }
        }
            
        ModContext.ApplyValues(Values, behaviorEffect, behaviorEffectTable, true);

        return behaviorEffect.Key;
    }
}