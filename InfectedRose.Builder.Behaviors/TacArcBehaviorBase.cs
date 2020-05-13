namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.TacArc)]
    public class TacArcBehaviorBase : BehaviorBase
    {
        [Parameter("action")]
        public BehaviorBase Action { get; set; }
        
        [Parameter("angle")]
        public float Angle { get; set; }
        
        [Parameter("angle_weight")]
        public float AngleWeight { get; set; }
        
        [Parameter("check_environment")]
        public bool CheckEnvironment { get; set; }
        
        [Parameter("clear_provided_target")]
        public bool ClearProvidedTarget { get; set; }
        
        [Parameter("distance_weight")]
        public float DistanceWeight { get; set; }
        
        [Parameter("height")]
        public float Height { get; set; }
        
        [Parameter("lower_bound")]
        public float LowerBound { get; set; }
        
        [Parameter("max range")]
        public float MaxRange { get; set; }
        
        [Parameter("max targets")]
        public float MaxTargets { get; set; }
        
        [Parameter("method")]
        public uint Method { get; set; }
        
        [Parameter("min range")]
        public float MinRange { get; set; }
        
        [Parameter("miss action")]
        public BehaviorBase MissAction { get; set; }
        
        [Parameter("target_enemy")]
        public bool TargetEnemy { get; set; }
        
        [Parameter("target_friend")]
        public bool TargetFriend { get; set; }
        
        [Parameter("target_self")]
        public bool TargetSelf { get; set; }
        
        [Parameter("upper_bound")]
        public float UpperBound { get; set; }
        
        [Parameter("use_attack_priority")]
        public bool UseAttackPriority { get; set; }
        
        [Parameter("use_picked_target")]
        public bool UsePickedTarget { get; set; }
        
        [Parameter("use_target_position")]
        public bool UseTargetPosition { get; set; }
    }
}