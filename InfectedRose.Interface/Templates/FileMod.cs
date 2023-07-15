namespace InfectedRose.Interface.Templates;

[ModType("file")]
public class FileMod : ModType
{
    public override void Apply(Mod mod)
    {
        var source = mod.GetValue<string>("source");
        var destination = mod.GetValue<string>("destination");
        
        ModContext.CreateArtifactFrom(source, destination);
    }
}