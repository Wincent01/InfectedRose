namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.AlterCooldown)]
    public class AlterCooldownBehaviorBase : BehaviorBase
    {
        [Parameter("add")]
        public bool Add { get; set; }
        
        [Parameter("amount")]
        public float Amount { get; set; }
    }
}