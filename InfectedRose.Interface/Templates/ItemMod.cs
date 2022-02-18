namespace InfectedRose.Interface.Templates
{
    [ModType("item")]
    public class ItemMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
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
            
            var obj = ObjectMod.CreateObject(mod);

            obj["type"].Value = "Loot";

            ObjectMod.AddComponent(mod, obj, ComponentId.RenderComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.ItemComponent);

            if (mod.Skills != null)
            {
                ObjectMod.AddComponent(mod, obj, ComponentId.SkillComponent);
                
                var objectSkillsTable = ModContext.Database["ObjectSkills"];
                
                foreach (var skill in mod.Skills)
                {
                    var objectSkill = objectSkillsTable.Create(obj.Key);

                    objectSkill["castOnType"].Value = mod.HasValue("castOnType") ? mod.GetValue<int>("castOnType") : 0;
                    objectSkill["AICombatWeight"].Value = 0;
                    
                    if (skill.TryGetValue(out int? value))
                    {
                        objectSkill["skillID"].Value = value;
                    }
                    else if (skill.TryGetValue(out string? itemId))
                    {
                        ModContext.AwaitId(itemId, lot => objectSkill["skillID"].Value = lot);
                    }
                }
            }
        }
    }
}