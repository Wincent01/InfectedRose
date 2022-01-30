using InfectedRose.Database;

namespace InfectedRose.Interface
{
    [ModType("object")]
    public class ObjectMod : ModType
    {
        public static Row CreateObject(Mod mod)
        {
            var table = ModContext.Database["Objects"];

            var row = table.FromLookup(mod);

            row["name"].Value = mod.Id;
            row["description"].Value = mod.Id;
            
            ModContext.ApplyValues(mod, row, table);

            ModContext.RegisterId(mod.Id, row.Key);

            if (mod.Components != null)
            {
                foreach (var component in mod.Components)
                {
                    AwaitComponent(row, component);
                }
            }

            if (mod.Locale != null)
            {
                foreach (var (locale, text) in mod.Locale)
                {
                    ModContext.AddToLocale($"Objects_{row.Key}_name", text, locale);
                }
            }

            return row;
        }

        public static void AwaitComponent(Row obj, string component)
        {
            var row = ModContext.Database["ComponentsRegistry"].Create(obj.Key);
            
            ModContext.AwaitId(component, id =>
            {
                row["component_id"].Value = id;
                row["component_type"].Value = ModContext.GetMod(component).GetComponentType();
            });
        }

        public static Row? AddComponent(Mod mod, Row obj, ComponentId componentId, int id = 0)
        {
            var table = ModContext.GetComponentTable(componentId);

            Row component;
            
            if (id == 0)
            {
                var row = ModContext.Database["ComponentsRegistry"].Create(obj.Key);

                row["component_type"].Value = (int) componentId;
                
                if (table == null)
                {
                    row["component_id"].Value = 0;
                
                    return null;
                }

                component = table.Create();

                row["component_id"].Value = component.Key;
            
                ModContext.ApplyValues(mod, component, table);
                
                ModContext.RegisterId(mod.Id + ":" + componentId, component.Key);

                return component;
            }

            if (table == null) return null;
            
            component = table.Create(id);
            
            ModContext.ApplyValues(mod, component, table);

            return component;
        }
        
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }

            CreateObject(mod);
        }
    }
}