using System.Numerics;
using InfectedRose.Builder.Behaviors.External;
using InfectedRose.Database;

namespace InfectedRose.Builder.Behaviors
{
    [Behavior(Template.Camera)]
    public class CameraBehaviorBase : BehaviorBase
    {
        [Parameter("lock_camera")]
        public bool Lock { get; set; }
        
        [Parameter("lookat_relative")]
        public bool LookAtRelative { get; set; }
        
        [Parameter("pos_relative")]
        public bool PositionRelative { get; set; }
        
        public Vector3 LookAt { get; set; }
        
        public Vector3 Position { get; set; }

        protected override void Load(AccessDatabase database)
        {
            LookAt = new Vector3
            {
                X = GetParameter<float>(database, "lookat_x"),
                Y = GetParameter<float>(database, "lookat_y"),
                Z = GetParameter<float>(database, "lookat_z"),
            };
            
            Position = new Vector3
            {
                X = GetParameter<float>(database, "pos_x"),
                Y = GetParameter<float>(database, "pos_y"),
                Z = GetParameter<float>(database, "pos_z"),
            };
        }

        protected override void ApplyChanges(AccessDatabase database)
        {
            SetParameter(database, "lookat_x", LookAt.X);
            
            SetParameter(database, "lookat_y", LookAt.Y);
            
            SetParameter(database, "lookat_z", LookAt.Z);
            
            SetParameter(database, "pos_x", Position.X);
            
            SetParameter(database, "pos_y", Position.Y);
            
            SetParameter(database, "pos_z", Position.Z);
        }
        
        public override void Export(BehaviorXml details)
        {
            details.SetParameter("lookat_x", LookAt.X);
            
            details.SetParameter("lookat_y", LookAt.Y);
            
            details.SetParameter("lookat_z", LookAt.Z);
            
            details.SetParameter("pos_x", Position.X);
            
            details.SetParameter("pos_y", Position.Y);
            
            details.SetParameter("pos_z", Position.Z);
        }
    }
}