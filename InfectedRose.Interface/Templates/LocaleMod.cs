namespace InfectedRose.Interface.Templates;

[ModType("locale")]
public class LocaleMod : ModType
{
    public override void Apply(Mod mod)
    {
        foreach (var value in mod.Values)
        {
            ModContext.AddToLocale(value.Key, value.Key, mod);
        }
    }
}