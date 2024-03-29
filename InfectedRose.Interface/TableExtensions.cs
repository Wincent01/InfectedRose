using System.Collections.Generic;
using InfectedRose.Database;

namespace InfectedRose.Interface;

public static class TableExtensions
{
    public static Row FromLookup(this Table @this, string id)
    {
        return !ModContext.Lookup.TryGetValue(id, out var value) ? @this.Create() : @this.Create(value);
    }
        
    public static Row FromLookup(this Table @this, Mod mod)
    {
        if (mod.Id.StartsWith("lego-universe:"))
        {
            @this.Seek(int.Parse(mod.Id[14..]), out var row);

            return row;
        }
            
        if (ModContext.Lookup.TryGetValue(mod.Id, out var value))
        {
            return @this.Create(value);
        }

        if (mod.OldIds == null)
        {
            return @this.CreateWithFilter(ModContext.Lookup.Values);
        }

        foreach (var oldId in mod.OldIds)
        {
            if (ModContext.Lookup.TryGetValue(oldId, out value))
            {
                return @this.Create(value);
            }
        }
            
        throw new KeyNotFoundException($"Could not determine the ID of {mod.Id}, no old ids match lookup.json.");
    }
}