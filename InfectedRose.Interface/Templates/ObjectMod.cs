using System.Linq;
using InfectedRose.Database;

namespace InfectedRose.Interface.Templates
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

            if (mod.Skills != null && mod.Skills.Length > 0)
            {
                AddComponent(mod, row, ComponentId.SkillComponent);
                
                var objectSkillsTable = ModContext.Database["ObjectSkills"];
                
                foreach (var skill in mod.Skills)
                {
                    var objectSkill = objectSkillsTable.Create(row.Key);

                    objectSkill["castOnType"].Value = skill.CastOnType;
                    objectSkill["AICombatWeight"].Value = skill.CombatAiWeight;
                    
                    if (skill.SkillId.TryGetValue(out int? value))
                    {
                        objectSkill["skillID"].Value = value;
                    }
                    else if (skill.SkillId.TryGetValue(out string? itemId))
                    {
                        ModContext.AwaitId(itemId, lot => objectSkill["skillID"].Value = lot);
                    }
                }
            }

            if (mod.Items != null && mod.Items.Length > 0)
            {
                var id = 0;
                
                foreach (var item in mod.Items)
                {
                    var itemComponent = ObjectMod.AddComponent(mod, row, ComponentId.InventoryComponent, id)!;

                    itemComponent["count"].Value = 1;
                    itemComponent["equip"].Value = true;
                    
                    id = itemComponent.Key;
                    
                    if (item.TryGetValue(out int? value))
                    {
                        itemComponent["itemid"].Value = value;
                    }
                    else if (item.TryGetValue(out string? itemId))
                    {
                        ModContext.AwaitId(itemId, lot => itemComponent["itemid"].Value = lot);
                    }
                }
            }

            if (mod.MissionOffers != null)
            {
                var id = 0;

                foreach (var missionOffer in mod.MissionOffers)
                {
                    var missionNpcComponent = ObjectMod.AddComponent(mod, row, ComponentId.MissionNPCComponent, id)!;

                    id = missionNpcComponent.Key;

                    missionNpcComponent["offersMission"].Value = missionOffer.Offer;
                    missionNpcComponent["acceptsMission"].Value = missionOffer.Accept;

                    ModContext.AwaitId(missionOffer.Mission, value => missionNpcComponent["missionID"].Value = value);
                }

                var mapIconTable = ModContext.Database["mapIcon"];
                var mapRow = mapIconTable.Create(row.Key);
                mapRow["iconID"].Value = 1;
                mapRow["iconState"].Value = 1;
                mapRow = mapIconTable.Create(row.Key);
                mapRow["iconID"].Value = 3;
                mapRow["iconState"].Value = 2;
                mapRow = mapIconTable.Create(row.Key);
                mapRow["iconID"].Value = 4;
                mapRow["iconState"].Value = 4;
            }

            return row;
        }

        public static Row EditObject(Mod mod)
        {
            var table = ModContext.Database["Objects"];

            var row = table.FromLookup(mod);

            row["name"].Value = mod.Id;
            row["description"].Value = mod.Id;
            
            ModContext.ApplyValues(mod, row, table);

            ModContext.RegisterId(mod.Id, row.Key);

            var existingComponents = ModContext.Database["ComponentsRegistry"].SeekMultiple(row.Key).ToArray();

            if (mod.Components != null)
            {
                foreach (var component in mod.Components)
                {
                    AwaitComponentWithExistingRows(existingComponents, component);
                }
            }

            if (mod.Locale != null)
            {
                foreach (var (locale, text) in mod.Locale)
                {
                    ModContext.AddToLocale($"Objects_{row.Key}_name", text, locale);
                }
            }

            if (mod.Skills != null && mod.Skills.Length > 0)
            {
                var objectSkillsTable = ModContext.Database["ObjectSkills"];
            
                foreach (var objectSkill in objectSkillsTable.SeekMultiple(row.Key))
                {
                    objectSkillsTable.Remove(objectSkill);
                }
                
                AddComponent(mod, row, ComponentId.SkillComponent);
                
                foreach (var skill in mod.Skills)
                {
                    var objectSkill = objectSkillsTable.Create(row.Key);

                    objectSkill["castOnType"].Value = skill.CastOnType;
                    objectSkill["AICombatWeight"].Value = skill.CombatAiWeight;
                    
                    if (skill.SkillId.TryGetValue(out int? value))
                    {
                        objectSkill["skillID"].Value = value;
                    }
                    else if (skill.SkillId.TryGetValue(out string? itemId))
                    {
                        ModContext.AwaitId(itemId, lot => objectSkill["skillID"].Value = lot);
                    }
                }
            }
            
            if (mod.Items != null && mod.Items.Length > 0)
            {
                var id = 0;
                
                foreach (var item in mod.Items)
                {
                    var itemComponent = ObjectMod.AddComponent(mod, row, ComponentId.InventoryComponent, id)!;

                    itemComponent["count"].Value = 1;
                    itemComponent["equip"].Value = true;
                    
                    id = itemComponent.Key;
                    
                    if (item.TryGetValue(out int? value))
                    {
                        itemComponent["itemid"].Value = value;
                    }
                    else if (item.TryGetValue(out string? itemId))
                    {
                        ModContext.AwaitId(itemId, lot => itemComponent["itemid"].Value = lot);
                    }
                }
            }

            if (mod.MissionOffers != null)
            {
                var id = 0;

                foreach (var missionOffer in mod.MissionOffers)
                {
                    var missionNpcComponent = ObjectMod.AddComponent(mod, row, ComponentId.MissionNPCComponent, id)!;

                    id = missionNpcComponent.Key;

                    missionNpcComponent["offersMission"].Value = missionOffer.Offer;
                    missionNpcComponent["acceptsMission"].Value = missionOffer.Accept;

                    ModContext.AwaitId(missionOffer.Mission, value => missionNpcComponent["missionID"].Value = value);
                }

                var mapIconTable = ModContext.Database["mapIcon"];
                var mapRow = mapIconTable.Create(row.Key);
                mapRow["iconID"].Value = 1;
                mapRow["iconState"].Value = 1;
                mapRow = mapIconTable.Create(row.Key);
                mapRow["iconID"].Value = 3;
                mapRow["iconState"].Value = 2;
                mapRow = mapIconTable.Create(row.Key);
                mapRow["iconID"].Value = 4;
                mapRow["iconState"].Value = 4;
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
            }, true);
        }
        
        public static void AwaitComponentWithExistingRows(Row[] rows, string component)
        {
            ModContext.AwaitId(component, id =>
            {
                var componentType = ModContext.GetMod(component).GetComponentType();
                
                var row = rows.FirstOrDefault(row => (int) row["component_type"].Value == componentType);

                if (row == null)
                {
                    row = ModContext.Database["ComponentsRegistry"].Create(rows[0].Key);
                }
                
                row["component_id"].Value = id;
                row["component_type"].Value = ModContext.GetMod(component).GetComponentType();
            }, true, true);
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
            if (mod.Action == "add")
            {
                CreateObject(mod);
            }
            else if (mod.Action == "edit")
            {
                EditObject(mod);
            }
        }
    }
}