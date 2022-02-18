namespace InfectedRose.Interface.Templates
{
    [ModType("quickbuild")]
    public class QuickBuildMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }
            
            mod.Default("render_asset", @"mesh\\re\\re_won_tesla_1-whole.nif");
            mod.Default("animationGroupIDs", "93");
            mod.Default("shader_id", 1);
            
            mod.Default("static", 1);
            mod.Default("jump", 0);
            mod.Default("doublejump", 0);
            mod.Default("speed", 5);
            mod.Default("rotSpeed", 360);
            mod.Default("playerHeight", 4.4f);
            mod.Default("playerRadius", 1);
            mod.Default("pcShapeType", 2);
            mod.Default("collisionGroup", 3);
            mod.Default("airSpeed", 5);
            mod.Default("jumpAirSpeed", 25);
            mod.DefaultNull("interactionDistance");
            mod.Default("physics_asset", @"re\\re_won_tesla_1-whole.hkx");
            
            mod.DefaultNull("chatBubbleOffset");
            mod.Default("fade", true);
            mod.Default("fadeInTime", 1);
            mod.DefaultNull("billboardHeight");
            mod.Default("usedropshadow", false);
            mod.Default("preloadAnimations", false);
            mod.Default("ignoreCameraCollision", false);
            mod.Default("gradualSnap", false);
            mod.Default("staticBillboard", false);
            mod.Default("attachIndicatorsToNode", false);
            
            mod.Default("npcTemplateID", 14);
            mod.Default("nametag", false);
            mod.Default("placeable", true);
            mod.Default("localize", true);
            mod.Default("locStatus", 2);

            mod.Default("reset_time", 20);
            mod.Default("complete_time", 3);
            mod.Default("take_imagination", 6);
            mod.Default("interruptible", true);
            mod.Default("self_activator", false);
            mod.Default("activityID", 6209);
            mod.Default("time_before_smash", 10);
            
            mod.Default("level", 1);
            mod.Default("life", 1);
            mod.Default("isnpc", false);
            mod.Default("isSmashable", false);
            mod.Default("death_behavior", 2);
            mod.Default("faction", 16);
            mod.Default("factionList", "16");
            
            var obj = ObjectMod.CreateObject(mod);

            obj["type"].Value = "Rebuildables";

            ObjectMod.AddComponent(mod, obj, ComponentId.SimplePhysicsComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.RenderComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.DestructibleComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.QuickBuildComponent);

            if (mod.HasValue("lxfml"))
            {
                ModContext.ParseValue(mod.GetValue<string>("lxfml"));
            }
        }
    }
}