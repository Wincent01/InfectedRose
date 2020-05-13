namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.AlterChainDelay)]
    public class AlterChainDelayBehaviorBase : BehaviorBase
    {
        [Parameter("chain_action")]
        public BehaviorBase ChainAction { get; set; }
        
        [Parameter("new_delay")]
        public float NewDelay { get; set; }
    }
}