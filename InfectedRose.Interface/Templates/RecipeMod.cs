using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using InfectedRose.Database.Generic;

namespace InfectedRose.Interface.Templates;

[ModType("recipe")]
public class RecipeMod : ModType
{
    class RecipeList : Dictionary<string, int>
    {
        
    }

    public override void Apply(Mod mod)
    {
        foreach (var (key, _) in mod.Values)
        {
            ModContext.AwaitId(key, objectId =>
            {
                var itemTable = ModContext.GetComponentTable(ComponentId.ItemComponent)!;
                
                var componentRegistry = ModContext.Database["ComponentsRegistry"]!;
                
                var itemComponentEntry = componentRegistry.SeekMultiple(objectId).FirstOrDefault(
                    c => c.Value<int>("component_type") == (int) ComponentId.ItemComponent
                );

                if (itemComponentEntry == null)
                {
                    throw new KeyNotFoundException($"Item component entry for {key} not found.");
                }
                
                if (!itemTable.Seek(itemComponentEntry.Value<int>("component_id"), out var itemComponent))
                {
                    throw new KeyNotFoundException($"Item component for {key} not found.");
                }
                
                var field = itemComponent["currencyCosts"];

                field.Value = "";

                foreach (var (itemId, quantity) in mod.GetValue<RecipeList>(key))
                {
                    ModContext.AwaitId(itemId, id =>
                    {
                        var fieldValue = (string) field.Value;
                        
                        if (fieldValue != "")
                        {
                            fieldValue += ",";
                        }
                        
                        fieldValue = $"{fieldValue}{id}:{quantity}";
                        
                        field.Value = fieldValue;
                    });
                }
            });
        }
    }
}