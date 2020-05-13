namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.Duration)]
    public class DurationBehaviorBase : BehaviorBase
    {
        [Parameter("action")]
        public BehaviorBase Action { get; set; }
        
        [Parameter("duration")]
        public float Duration { get; set; }
    }
}