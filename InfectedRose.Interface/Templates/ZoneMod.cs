using System;
using InfectedRose.Database;

namespace InfectedRose.Interface.Templates
{
    [ModType("zone")]
    public class ZoneMod : ModType
    {
        public void InsertZone(Mod mod)
        {
            var zoneTable = ModContext.Database["ZoneTable"];

            Row entry;
            
            if (ModContext.TryGetFromLookup(mod, out var key))
            {
                entry = zoneTable.Create(key);
            }
            else
            {
                for (var i = 1000;; i += 100)
                {
                    if (zoneTable.ContainsKey(i))
                    {
                        continue;
                    }

                    entry = zoneTable.Create(i);
                    
                    break;
                }
            }
            
            mod.Default("ghostdistance_min", 150);
            mod.Default("ghostdistance", 250);
            mod.Default("population_soft_cap", 10);
            mod.Default("population_hard_cap", 15);
            mod.DefaultNull("smashableMinDistance");
            mod.DefaultNull("smashableMaxDistance");
            mod.DefaultNull("zoneControlTemplate");
            mod.DefaultNull("widthInChunks");
            mod.DefaultNull("heightInChunks");
            mod.Default("petsAllowed", true);
            mod.Default("localize", true);
            mod.Default("fZoneWeight", 1);
            mod.Default("PlayersLoseCoinsOnDeath", true);
            mod.DefaultNull("teamRadius");
            mod.Default("mountsAllowed", true);
            
            ModContext.RegisterId(mod.Id, entry.Key);
            
            ModContext.ApplyValues(mod, entry, zoneTable);

            if (mod.Locale != null)
            {
                ModContext.AddToLocale($"ZoneTable_{entry.Key}_DisplayDescription", mod.Locale);
            }

            if (mod.HasValue("zone"))
            {
                entry["zoneName"].Value = ModContext.ParseValue(mod.GetValue<string>("zone"));
            }
        }
        
        public override void Apply(Mod mod)
        {
            if (mod.Action == "insert")
            {
                InsertZone(mod);
                
                return;
            }

            throw new NotSupportedException(
                            "Adding new zones is not supported yet, " +
                            "consider using the action 'insert' to add already compiled zone files."
            );
        }
    }
}