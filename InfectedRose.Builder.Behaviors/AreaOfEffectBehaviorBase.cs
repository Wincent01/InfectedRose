namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.AreaOfEffect)]
    public class AreaOfEffectBehaviorBase : BehaviorBase
    {
        [Parameter("action")]
        public BehaviorBase Action { get; set; }
        
        [Parameter("max targets")]
        public uint MaxTargets { get; set; }
        
        [Parameter("radius")]
        public float Radius { get; set; }
        
        [Parameter("target_enemy")]
        public bool TargetEnemy { get; set; }
        
        [Parameter("target_self")]
        public bool TargetSelf { get; set; }
        
        [Parameter("target_team")]
        public bool TargetTeam { get; set; }
        
        [Parameter("use_target_as_caster")]
        public bool UseTargetAsCaster { get; set; }
        
        [Parameter("use_target_position")]
        public bool UseTargetPosition { get; set; }
    }
}