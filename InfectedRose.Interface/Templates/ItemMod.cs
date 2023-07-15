using System;

namespace InfectedRose.Interface.Templates;

[ModType("item")]
public class ItemMod : ModType
{
    public override void Apply(Mod mod)
    {
        if (mod.Action != "add")
        {
            throw new Exception("ItemMod can only be used with the add action");
        }
            
        mod.Default("nametag", false);
        mod.Default("placeable", false);
        mod.Default("localize", true);
        mod.Default("locStatus", 2);
        mod.Default("offsetGroupID", 78);
        mod.Default("itemInfo", 0);
        mod.Default("fade", true);
        mod.Default("fadeInTime", 1);
        mod.Default("shader_id", 23);
        mod.Default("audioEquipMetaEventSet", "Weapon_Hammer_Generic");
        
        if (mod.HasValue("icon"))
        {
            var iconId = ModContext.AddIcon(mod.GetValue<string>("icon"), out var path);
            
            mod.Values["icon_asset"] = path;
            mod.Values["IconID"] = iconId;
        }

        var obj = ObjectMod.CreateObject(mod, false);

        obj["type"].Value = "Loot";

        ObjectMod.AddComponent(mod, obj, ComponentId.RenderComponent);
        ObjectMod.AddComponent(mod, obj, ComponentId.ItemComponent);
        
        if (mod.HasValue("icon"))
        {
            mod.Values.Remove("icon_asset");
            mod.Values.Remove("IconID");
        }
    }
}