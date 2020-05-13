namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.MovementSwitch)]
    public class MovementSwitchBehaviorBase : BehaviorBase
    {
        [Parameter("double_jump_action")]
        public BehaviorBase DoubleJumpAction { get; set; }
        
        [Parameter("falling_action")]
        public BehaviorBase FallingAction { get; set; }
        
        [Parameter("ground_action")]
        public BehaviorBase GroundAction { get; set; }
        
        [Parameter("jetpack_action")]
        public BehaviorBase JetpackAction { get; set; }
        
        [Parameter("jump_action")]
        public BehaviorBase JumpAction { get; set; }
    }
}