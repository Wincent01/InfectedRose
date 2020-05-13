namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.ChangeOrientation)]
    public class ChangeOrientationBehaviorBase : BehaviorBase
    {
        [Parameter("angle")]
        public float Angle { get; set; }
        
        [Parameter("orient_caster")]
        public bool OrientCaster { get; set; }
        
        [Parameter("relative")]
        public bool Relative { get; set; }
        
        [Parameter("to_angle")]
        public bool ToAngle { get; set; }
        
        [Parameter("to_point")]
        public bool ToPoint { get; set; }
        
        [Parameter("to_target")]
        public bool ToTarget { get; set; }
    }
}