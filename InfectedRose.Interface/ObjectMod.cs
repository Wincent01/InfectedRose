namespace InfectedRose.Interface
{
    [ModType("object")]
    public class ObjectMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }

            var table = ModContext.Database["Objects"];

            var obj = table.Create();
            
            ModContext.ApplyValues(mod, obj, table);

            ModContext.RegisterId(mod.Id, obj.Key);

            foreach (var component in mod.Components)
            {
                var row = ModContext.Database["ComponentsRegistry"].Create(obj.Key);
                
                ModContext.AwaitId(component, id =>
                {
                    row["component_id"].Value = id;
                    row["component_type"].Value = ModContext.GetMod(component).GetComponentType();
                });
            }
        }
    }
}