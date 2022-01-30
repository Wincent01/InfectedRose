namespace InfectedRose.Interface
{
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
            
            ModContext.RegisterId(mod.Id, skillBehavior.Key);

            foreach (var (key, behavior) in mod.Behaviors)
            {
                behavior.Apply(key);
            }
            
            ModContext.ApplyValues(mod, skillBehavior, skillBehaviorTable);

            if (mod.HasValue("root-behavior"))
            {
                ModContext.AwaitId(mod.GetValue<string>("root-behavior"), i =>
                {
                    skillBehavior["behaviorID"].Value = i;
                });
            }
        }
    }
}