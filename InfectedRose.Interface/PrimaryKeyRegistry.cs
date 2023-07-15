using System.Collections.Generic;
using System.Linq;
using InfectedRose.Database;

namespace InfectedRose.Interface;

public class PrimaryKeyRegistry
{
    public Dictionary<string, string[]> PrimaryKeys { get; } = new Dictionary<string, string[]>
    { 
        {"AICombatRoles", new[] {"id"}},
        {"AccessoryDefaultLoc", new[] {"GroupID"}},
        {"Activities", new[] {"ActivityID"}},
        {"ActivityRewards", new[] {"objectTemplate", "ActivityRewardIndex"}},
        {"ActivityText", new[] {"activityID", "type"}},
        {"AnimationIndex", new[] {"animationGroupID"}},
        {"Animations", new[] {"animationGroupID", "animation_type"}},
        {"BaseCombatAIComponent", new[] {"id"}},
        {"BehaviorEffect", new[] {"effectID", "effectType"}},
        {"BehaviorParameter", new[] {"behaviorID", "parameterID"}},
        {"BehaviorTemplate", new[] {"behaviorID"}},
        {"BehaviorTemplateName", new[] {"templateID"}},
        {"Blueprints", new[] {"id"}},
        {"BrickColors", new[] {"id"}},
        {"BrickIDTable", new[] {"NDObjectID"}},
        {"BuffDefinitions", new[] {"ID"}},
        {"BuffParameters", new[] {"BuffID", "ParameterName"}},
        {"Camera", new[] {"camera_name"}},
        {"CelebrationParameters", new[] {"id"}},
        {"ChoiceBuildComponent", new[] {"id"}},
        {"CollectibleComponent", new[] {"id"}},
        {"ComponentsRegistry", new[] {"id", "component_type"}},
        {"ControlSchemes", new[] {"control_scheme"}},
        {"CurrencyDenominations", new[] {"value"}},
        {"CurrencyTable", new[] {"currencyIndex", "npcminlevel"}},
        {"DBExclude", new[] {"table", "column"}},
        {"DeletionRestrictions", new[] {"id"}},
        {"DestructibleComponent", new[] {"id"}},
        {"DevModelBehaviors", new[] {"ModelID"}},
        {"Emotes", new[] {"id"}},
        {"EventGating", new[] {"eventName"}},
        {"ExhibitComponent", new[] {"id"}},
        {"Factions", new[] {"faction"}},
        {"FeatureGating", new[] {"featureName"}},
        {"FlairTable", new[] {"id"}},
        {"Icons", new[] {"IconID"}},
        {"InventoryComponent", new[] {"id", "itemid"}},
        {"ItemComponent", new[] {"id"}},
        {"ItemEggData", new[] {"id"}},
        {"ItemFoodData", new[] {"id"}},
        {"ItemSetSkills", new[] {"SkillSetID", "SkillID"}},
        {"ItemSets", new[] {"setID"}},
        {"JetPackPadComponent", new[] {"id"}},
        {"LUPExhibitComponent", new[] {"id"}},
        {"LUPExhibitModelData", new[] {"LOT"}},
        {"LUPZoneIDs", new[] {"zoneID"}},
        {"LanguageType", new[] {"LanguageID"}},
        {"LevelProgressionLookup", new[] {"id"}},
        {"LootMatrix", new[] {"LootMatrixIndex", "LootTableIndex", "RarityTableIndex"}},
        {"LootMatrixIndex", new[] {"LootMatrixIndex"}},
        {"LootTable", new[] {"itemid", "LootTableIndex", "id"}},
        {"LootTableIndex", new[] {"LootTableIndex"}},
        {"MinifigComponent", new[] {"id"}},
        {"MinifigDecals_Eyebrows", new[] {"ID"}},
        {"MinifigDecals_Eyes", new[] {"ID"}},
        {"MinifigDecals_Legs", new[] {"ID"}},
        {"MinifigDecals_Mouths", new[] {"ID"}},
        {"MinifigDecals_Torsos", new[] {"ID"}},
        {"MissionEmail", new[] {"ID"}},
        {"MissionNPCComponent", new[] {"id", "missionID"}},
        {"MissionTasks", new[] {"id", "uid"}},
        {"MissionText", new[] {"id"}},
        {"Missions", new[] {"id"}},
        {"ModelBehavior", new[] {"id"}},
        {"ModularBuildComponent", new[] {"id"}},
        {"ModuleComponent", new[] {"id"}},
        {"MotionFX", new[] {"id"}},
        {"MovementAIComponent", new[] {"id"}},
        {"MovingPlatforms", new[] {"id"}},
        {"NpcIcons", new[] {"id"}},
        {"ObjectBehaviorXREF", new[] {"LOT"}},
        {"ObjectBehaviors", new[] {"BehaviorID"}},
        {"ObjectSkills", new[] {"objectTemplate", "skillID"}},
        {"Objects", new[] {"id"}},
        {"PackageComponent", new[] {"id"}},
        {"PetAbilities", new[] {"id"}},
        {"PetComponent", new[] {"id"}},
        {"PetNestComponent", new[] {"id"}},
        {"PhysicsComponent", new[] {"id"}},
        {"PlayerFlags", new[] {"id"}},
        {"PlayerStatistics", new[] {"statID"}},
        {"PossessableComponent", new[] {"id"}},
        {"Preconditions", new[] {"id"}},
        {"PropertyEntranceComponent", new[] {"id"}},
        {"PropertyTemplate", new[] {"id"}},
        {"ProximityMonitorComponent", new[] {"id"}},
        {"ProximityTypes", new[] {"id"}},
        {"RacingModuleComponent", new[] {"id"}},
        {"RailActivatorComponent", new[] {"id"}},
        {"RarityTable", new[] {"id"}},
        {"RarityTableIndex", new[] {"RarityTableIndex"}},
        {"RebuildComponent", new[] {"id"}},
        {"RebuildSections", new[] {"id"}},
        {"Release_Version", new[] {"ReleaseVersion"}},
        {"RenderComponent", new[] {"id"}},
        {"RenderComponentFlash", new[] {"id", "interactive", "animated", "nodeName", "flashPath", "elementName", "_uid"}},
        {"RenderComponentWrapper", new[] {"id"}},
        {"RenderIconAssets", new[] {"id"}},
        {"ReputationRewards", new[] {"repLevel"}},
        {"RewardCodes", new[] {"id"}},
        {"Rewards", new[] {"id"}},
        {"RocketLaunchpadControlComponent", new[] {"id"}},
        {"SceneTable", new[] {"sceneID"}},
        {"ScriptComponent", new[] {"id"}},
        {"SkillBehavior", new[] {"skillID"}},
        {"SmashableChain", new[] {"chainIndex", "chainLevel"}},
        {"SmashableChainIndex", new[] {"id"}},
        {"SmashableComponent", new[] {"id"}},
        {"SmashableElements", new[] {"elementID"}},
        {"SpeedchatMenu", new[] {"id"}},
        {"SubscriptionPricing", new[] {"id"}},
        {"SurfaceType", new[] {"SurfaceType"}},
        {"TamingBuildPuzzles", new[] {"id"}},
        {"TextDescription", new[] {"TextID"}},
        {"TextLanguage", new[] {"TextID"}},
        {"TrailEffects", new[] {"trailID"}},
        {"UGBehaviorSounds", new[] {"id"}},
        {"VehiclePhysics", new[] {"id"}},
        {"VehicleStatMap", new[] {"id", "ModuleStat", "HavokStat"}},
        {"VendorComponent", new[] {"id"}},
        {"WhatsCoolItemSpotlight", new[] {"id"}},
        {"WhatsCoolNewsAndTips", new[] {"id"}},
        {"WorldConfig", new[] {"WorldConfigID"}},
        {"ZoneLoadingTips", new[] {"id"}},
        {"ZoneSummary", new[] {"zoneID", "type", "value", "_uniqueID"}},
        {"ZoneTable", new[] {"zoneID"}},
        {"brickAttributes", new[] {"ID"}},
        {"dtproperties", new[] {"id"}},
        {"mapAnimationPriorities", new[] {"id"}},
        {"mapAssetType", new[] {"id"}},
        {"mapIcon", new[] {"LOT", "iconID", "iconState"}},
        {"mapItemTypes", new[] {"id"}},
        {"mapRenderEffects", new[] {"id"}},
        {"mapShaders", new[] {"id"}},
        {"mapTextureResource", new[] {"id"}},
        {"map_BlueprintCategory", new[] {"id"}},
        {"sysdiagrams", new[] {"name"}}
    };

    public void Generate(AccessDatabase accessDatabase)
    {
        foreach (var table in accessDatabase)
        {
            var info = table.TableInfo;
            var rows = table.ToArray();
                
            var primaryKey = new List<string>();

            for (var i = 0; i < info.Count; ++i)
            {
                primaryKey.Add(info[i].Name);
                    
                // Check if there are duplicates of this value in the table.
                var index = i;
                    
                var values = rows.Where(r => r[index].Value != null).Select(r => r[index].Value).ToArray();
                    
                var containsDuplicates = values.Count() != values.Distinct().Count();
                    
                if (!containsDuplicates)
                {
                    break;
                }
            }
                
            PrimaryKeys.Add(table.Name, primaryKey.ToArray());
        }
    }
}