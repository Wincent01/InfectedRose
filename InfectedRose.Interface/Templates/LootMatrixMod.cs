using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using InfectedRose.Database;

namespace InfectedRose.Interface.Templates;

[ModType("loot-matrix")]
public class LootMatrixMod : ModType
{
    class LootMatrix
    {
        [JsonPropertyName("rarity-table")]
        public int? RarityTableIndex { get; set; }
        
        [JsonPropertyName("percent")]
        public float? Percent { get; set; }
        
        [JsonPropertyName("min-quantity")]
        public int? MinQuantity { get; set; }
        
        [JsonPropertyName("max-quantity")]
        public int? MaxQuantity { get; set; }
        
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        [JsonPropertyName("flag-id")]
        public string? FlagId { get; set; }
    }
    
    public override void Apply(Mod mod)
    {
        var lootMatrix = ModContext.Database["LootMatrix"]!;
        var lootMatrixIndex = ModContext.Database["LootMatrixIndex"]!;

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
            var indexRow = lootMatrixIndex.Create();
            
            modId = indexRow.Key;
        }
        
        ModContext.RegisterId(mod.Id, modId);
        
        foreach (var (key, _) in mod.Values)
        {
            ModContext.AwaitId(key, lootTableIndex =>
            {
                var row = lootMatrix.Create(modId);
                
                row["LootTableIndex"].Value = modId;

                var value = mod.GetValue<LootMatrix>(key);

                row["LootTableIndex"].Value = lootTableIndex;
                row["RarityTableIndex"].Value = value.RarityTableIndex ?? 4;
                row["percent"].Value = value.Percent ?? 1;
                row["minToDrop"].Value = value.MinQuantity ?? 1;
                row["maxToDrop"].Value = value.MaxQuantity ?? 1;
                row["id"].Value = value.Id ?? lootMatrix.Max(l => (int)l[6].Value);
                if (value.FlagId != null)
                {
                    ModContext.AwaitId(value.FlagId, flagId =>
                    {
                        row["flagID"].Value = flagId;
                    });
                }
            });
        }
    }
}