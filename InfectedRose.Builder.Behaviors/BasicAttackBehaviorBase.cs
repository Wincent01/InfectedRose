namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.BasicAttack)]
    public class BasicAttackBehaviorBase : BehaviorBase
    {
        [Parameter("dir_angle_xz")]
        public float AngleXZ { get; set; }
        
        [Parameter("dir_angle_y")]
        public float AngleY { get; set; }
        
        [Parameter("dir_force")]
        public float Force { get; set; }
        
        [Parameter("max damage")]
        public uint MaxDamage { get; set; }
        
        [Parameter("min damage")]
        public uint MinDamage { get; set; }
        
        [Parameter("on_fail_armor")]
        public BehaviorBase OnFailArmor { get; set; }
        
        [Parameter("on_success")]
        public BehaviorBase OnSuccess { get; set; }
        
        [Parameter("use_caster_velocity")]
        public bool UseCasterVelocity { get; set; }
        
        [Parameter("velocity_multiplier")]
        public float VelocityMultiplier { get; set; }
    }
}