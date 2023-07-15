namespace InfectedRose.Interface.Templates;

[ModType("flag")]
public class FlagMod : ModType
{
    public override void Apply(Mod mod)
    {
        if (mod.Action != "add")
        {
            return;
        }
            
        mod.Default("SessionOnly", false);
        mod.Default("OnlySetByServer", false);
        mod.Default("SessionZoneOnly", false);

        var flags = ModContext.Database["PlayerFlags"]!;

        var row = flags.Create();
            
        ModContext.ApplyValues(mod, row, flags);
            
        ModContext.RegisterId(mod.Id, row.Key);
    }
}