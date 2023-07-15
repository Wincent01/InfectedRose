namespace InfectedRose.Interface.Templates;

[ModType("skill")]
public class SkillMod : ModType
{
    public override void Apply(Mod mod)
    {
        if (mod.Action != "add")
        {
            return;
        }

        var skillBehaviorTable = ModContext.Database["SkillBehavior"]!;

        var skillBehavior = skillBehaviorTable.FromLookup(mod);

        if (mod.Locale != null)
        {
            ModContext.AddToLocale($"SkillBehavior_{skillBehavior.Key}_name", mod.Locale);
        }

        ModContext.RegisterId(mod.Id, skillBehavior.Key);

        foreach (var (key, behavior) in mod.Behaviors)
        {
            behavior.Apply(key);
        }
        
        if (mod.HasValue("icon"))
        {
            var iconId = ModContext.AddIcon(mod.GetValue<string>("icon"), out var path);
            
            mod.Values["skillIcon"] = iconId;
        }

        ModContext.ApplyValues(mod, skillBehavior, skillBehaviorTable);

        if (mod.HasValue("icon"))
        {
            mod.Values.Remove("skillIcon");
        }
        
        if (mod.HasValue("root-behavior"))
        {
            ModContext.AwaitId(mod.GetValue<string>("root-behavior"), i =>
            {
                skillBehavior["behaviorID"].Value = i;
            });
        }
    }
}