namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.ForceMovement)]
    public class ForceMovementBehaviorBase : BehaviorBase
    {
        [Parameter("duration")]
        public float Duration { get; set; }
        
        [Parameter("forward")]
        public float Forward { get; set; }
        
        [Parameter("left")]
        public float Left { get; set; }
        
        [Parameter("move_target")]
        public bool MoveTarget { get; set; }
        
        [Parameter("relative")]
        public bool Relative { get; set; }
        
        [Parameter("yaw")]
        public float Yaw { get; set; }
        
        [Parameter("yaw_abs")]
        public float YawAbs { get; set; }
    }
}