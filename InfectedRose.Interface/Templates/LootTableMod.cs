using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using InfectedRose.Database;

namespace InfectedRose.Interface.Templates;

[ModType("loot-table")]
public class LootTableMod : ModType
{
    class LootTable
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        [JsonPropertyName("mission-drop")]
        public bool? MissionDrop { get; set; }
        
        [JsonPropertyName("sort-priority")]
        public int? SortPriority { get; set; }
    }
    
    public override void Apply(Mod mod)
    {
        var lootTable = ModContext.Database["LootTable"]!;
        var lootTableIndex = ModContext.Database["LootTableIndex"]!;

        int modId;

        if (mod.ExplicitId.HasValue)
        {
            modId = mod.ExplicitId.Value;
        }
        else if (mod.Id.StartsWith("lego-universe:"))
        {
            modId = int.Parse(mod.Id[14..]);
        }
        else
        {
            var indexRow = lootTableIndex.Create();
            
            modId = indexRow.Key;
        }
        
        ModContext.RegisterId(mod.Id, modId);
        
        foreach (var (key, _) in mod.Values)
        {
            ModContext.AwaitId(key, itemId =>
            {
                var row = lootTable.Create(itemId);
                
                row["LootTableIndex"].Value = modId;

                var value = mod.GetValue<LootTable?>(key);

                if (value == null)
                {
                    row["id"].Value = lootTable.Max(l => (int)l[2].Value);
                    row["MissionDrop"].Value = false;
                    row["sortPriority"].Value = 0;
                }
                else
                {
                    row["id"].Value = value.Id ?? lootTable.Max(l => (int)l[2].Value);
                    row["MissionDrop"].Value = value.MissionDrop ?? false;
                    row["sortPriority"].Value = value.SortPriority ?? 0;
                }
            });
        }
    }
}