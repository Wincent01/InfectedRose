namespace InfectedRose.Interface
{
    [ModType("environmental")]
    public class EnvironmentalMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }
            
            mod.Default("static", 1);
            mod.Default("shader_id", 1);

            var obj = ObjectMod.CreateObject(mod);

            obj["type"].Value = "Environmental";

            ObjectMod.AddComponent(mod, obj, ComponentId.RenderComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.SimplePhysicsComponent);
        }
    }
}