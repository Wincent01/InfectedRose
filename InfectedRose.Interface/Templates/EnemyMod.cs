namespace InfectedRose.Interface.Templates
{
    [ModType("enemy")]
    public class EnemyMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }
            
            // Controller
            mod.Default("physics_asset", @"miscellaneous\standard_enemy.hkx");
            mod.Default("static", 0);
            mod.Default("jump", 4);
            mod.Default("doublejump", 0);
            mod.Default("speed", 8);
            mod.Default("rotSpeed", 720);
            mod.Default("playerHeight", 4.4f);
            mod.Default("playerRadius", 1.7f);
            mod.Default("pcShapeType", 0);
            mod.Default("collisionGroup", 12);
            mod.Default("airSpeed", 5);
            mod.Default("jumpAirSpeed", 25);
            
            // Render
            mod.Default("render_asset", @"animations\\creatures\\cre_strombie.kfm");
            mod.Default("animationGroupIDs", "513,535");
            mod.Default("shader_id", 66);
            mod.DefaultNull("interactionDistance");
            mod.DefaultNull("chatBubbleOffset");
            mod.Default("fade", true);
            mod.Default("fadeInTime", 0.1f);
            mod.DefaultNull("billboardHeight");
            mod.DefaultNull("AudioMetaEventSet");
            mod.Default("usedropshadow", false);
            mod.Default("preloadAnimations", false);
            mod.Default("ignoreCameraCollision", false);
            mod.Default("gradualSnap", false);
            mod.Default("staticBillboard", false);
            mod.Default("attachIndicatorsToNode", false);
            
            // Destroyable
            mod.Default("life", 1);
            mod.Default("armor", 0);
            mod.Default("imagination", 0);
            mod.Default("level", 1);
            mod.Default("faction", 4);
            mod.Default("factionList", "4");
            mod.Default("isnpc", true);
            mod.Default("isSmashable", true);
            mod.Default("attack_priority", 1);
            mod.Default("death_behavior", 2);
            mod.Default("CurrencyIndex", 1);
            mod.Default("LootMatrixIndex", 160);
            mod.DefaultNull("difficultyLevel");
            
            // Movement
            mod.Default("MovementType", "Wander");
            mod.Default("WanderChance", 90);
            mod.Default("WanderDelayMin", 3);
            mod.Default("WanderDelayMax", 6);
            mod.Default("WanderSpeed", 0.5f);
            mod.Default("WanderRadius", 8);
            mod.DefaultNull("attachedPath");
            
            // BaseCombatAI
            mod.Default("behaviorType", 1);
            mod.Default("minRoundLength", 3);
            mod.Default("maxRoundLength", 5);
            mod.Default("pursuitSpeed", 2);
            mod.Default("spawnTimer", 1);
            mod.Default("tetherSpeed", 4);
            mod.Default("softTetherRadius", 25);
            mod.Default("hardTetherRadius", 101);
            mod.Default("tetherEffectID", 6270);
            mod.Default("combatRoundLength", 4);
            mod.Default("combatRole", 5);
            mod.Default("combatStartDelay", 1.5f);
            mod.Default("aggroRadius", 25);
            mod.Default("ignoreMediator", true);
            mod.Default("ignoreStatReset", false);
            mod.Default("ignoreParent", false);

            // Object
            mod.DefaultNull("npcTemplateID");
            mod.Default("nametag", true);
            mod.Default("placeable", true);
            mod.Default("localize", true);
            mod.Default("locStatus", 2);
            
            var obj = ObjectMod.CreateObject(mod);

            obj["type"].Value = "Enemies";

            ObjectMod.AddComponent(mod, obj, ComponentId.ControllablePhysicsComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.RenderComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.DestructibleComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.SkillComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.MovementAIComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.BaseCombatAIComponent);
            
            if (mod.Skills != null)
            {
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