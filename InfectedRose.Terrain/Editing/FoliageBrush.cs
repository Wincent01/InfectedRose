using System;
using System.Numerics;

namespace InfectedRose.Terrain.Editing
{
    public class FoliageBrush : Brush
    {
        private Random Random { get; }
        
        public FoliageBrush(TerrainEditor editor) : base(editor)
        {
            Random = new Random();
        }

        public override void Apply(Vector2 position)
        {
            throw new NotImplementedException();
        }

        private Vector2 RandomPoint(float radius, Vector2 center)
        {
            var r = radius * Math.Sqrt(Random.Next());
            var theta = Random.Next() * 2 * Math.PI;
            
            var x = center.X + r * Math.Cos(theta);
            var y = center.Y + r * Math.Sin(theta);
            
            return new Vector2
            {
                X = (float) x,
                Y = (float) y
            };
        }
    }
}