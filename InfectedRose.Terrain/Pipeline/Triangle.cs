using System.Numerics;

namespace InfectedRose.Terrain.Pipeline
{
    public struct Triangle
    {
        public Vector3 Position1 { get; set; }
        
        public Vector3 Position2 { get; set; }
        
        public Vector3 Position3 { get; set; }

        public Vector3[] ToArray => new[]
        {
            Position1,
            Position2,
            Position3
        };
    }
}