using System.Numerics;

namespace InfectedRose.Terrain.Editor
{
    public abstract class Brush
    {
        public TerrainEditor Editor { get; }
        
        public float Size { get; set; }
        
        public float Power { get; set; }
        
        public Brush(TerrainEditor editor)
        {
            Editor = editor;
        }

        public abstract void Apply(Vector2 position);
    }
}