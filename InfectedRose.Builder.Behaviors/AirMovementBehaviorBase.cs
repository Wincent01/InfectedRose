using System.Numerics;
using InfectedRose.Builder.Behaviors.External;
using InfectedRose.Database;

namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.AirMovement)]
    public class AirMovementBehaviorBase : BehaviorBase
    {
        [Parameter("goto_target")]
        public bool GotoTarget { get; set; }
        
        [Parameter("gravity_scale")]
        public float GravityScale { get; set; }
        
        [Parameter("ground_action")]
        public BehaviorBase GroundAction { get; set; }
        
        [Parameter("hit_action")]
        public BehaviorBase HitAction { get; set; }
        
        [Parameter("hit_action_enemy")]
        public BehaviorBase HitActionEnemy { get; set; }
        
        [Parameter("timeout_action")]
        public BehaviorBase TimeoutAction { get; set; }
        
        [Parameter("timeout_ms")]
        public uint TimeoutMs { get; set; }
        
        public Vector3 Velocity { get; set; }

        protected override void Load(AccessDatabase database)
        {
            Velocity = new Vector3
            {
                X = GetParameter<float>(database, "x_velocity"),
                Y = GetParameter<float>(database, "y_velocity"),
                Z = GetParameter<float>(database, "z_velocity"),
            };
        }

        protected override void ApplyChanges(AccessDatabase database)
        {
            SetParameter(database, "x_velocity", Velocity.X);
            
            SetParameter(database, "y_velocity", Velocity.Y);
            
            SetParameter(database, "z_velocity", Velocity.Z);
        }

        public override void Export(BehaviorXml details)
        {
            details.SetParameter("x_velocity", Velocity.X);
            
            details.SetParameter("y_velocity", Velocity.Y);
            
            details.SetParameter("z_velocity", Velocity.Z);
        }
    }
}