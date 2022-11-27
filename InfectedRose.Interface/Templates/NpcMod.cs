namespace InfectedRose.Interface.Templates
{
    [ModType("npc")]
    public class NpcMod : ModType
    {
        public override void Apply(Mod mod)
        {
            if (mod.Action != "add")
            {
                return;
            }
            
            mod.Default("render_asset", @"animations\\minifig\\mf_ambient.kfm");
            mod.Default("animationGroupIDs", "93");
            mod.Default("shader_id", 14);
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
            
            mod.DefaultNull("chatBubbleOffset");
            mod.Default("fade", true);
            mod.Default("fadeInTime", 1);
            mod.DefaultNull("billboardHeight");
            mod.Default("AudioMetaEventSet", "Emotes_Non_Player");
            mod.Default("usedropshadow", false);
            mod.Default("preloadAnimations", false);
            mod.Default("ignoreCameraCollision", false);
            mod.Default("gradualSnap", false);
            mod.Default("staticBillboard", false);
            mod.Default("attachIndicatorsToNode", false);
            
            mod.Default("npcTemplateID", 14);
            mod.Default("nametag", true);
            mod.Default("placeable", true);
            mod.Default("localize", true);
            mod.Default("locStatus", 2);
            
            var obj = ObjectMod.CreateObject(mod);

            obj["type"].Value = "UserGeneratedNPCs";

            ObjectMod.AddComponent(mod, obj, ComponentId.SimplePhysicsComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.RenderComponent);
            ObjectMod.AddComponent(mod, obj, ComponentId.MinifigComponent);
        }
    }
}