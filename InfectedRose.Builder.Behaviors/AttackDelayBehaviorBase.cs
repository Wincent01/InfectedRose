namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.AttackDelay)]
    public class AttackDelayBehaviorBase : BehaviorBase
    {
        [Parameter("action")]
        public BehaviorBase Action { get; set; }
        
        [Parameter("delay")]
        public float Delay { get; set; }
        
        [Parameter("ignore_interrupts")]
        public bool IgnoreInterrupts { get; set; }
        
        [Parameter("num_intervals")]
        public uint Intervals { get; set; }
    }
}