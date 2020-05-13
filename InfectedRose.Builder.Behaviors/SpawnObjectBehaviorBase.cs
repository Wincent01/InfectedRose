namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.SpawnObject)]
    public class SpawnObjectBehaviorBase : BehaviorBase
    {
        [Parameter("LOT_ID")]
        public uint Lot { get; set; }
        
        [Parameter("distance")]
        public float Distance { get; set; }
        
        [Parameter("objectRadius")]
        public float Radius { get; set; }
        
        [Parameter("spawn_fail_action")]
        public BehaviorBase FailAction { get; set; }
        
        [Parameter("updatePositionWithParent")]
        public bool UpdatePositionWithParent { get; set; }
    }
}