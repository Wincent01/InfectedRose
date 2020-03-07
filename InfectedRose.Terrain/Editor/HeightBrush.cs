using System.Linq;
using System.Numerics;

namespace InfectedRose.Terrain.Editor
{
    public class HeightBrush : Brush
    {
        public HeightBrush(TerrainEditor editor) : base(editor)
        {
        }

        public override void Apply(Vector2 position)
        {
            var layer = Editor.HeightLayer;
            
            var points = layer.Heights.Where(
                pair => Vector2.Distance(pair.Key, position) <= Size
            ).ToArray();

            foreach (var (key, value) in points)
            {
                var distance = Vector2.Distance(key, position);

                var fractal = Lerp(1, 0, distance / Size);

                layer.SetHeight(key, value + fractal * Power);
            }
        }

        private static float Lerp(float a, float b, float c)
        {
            return a * (1 - c) + b * c;
        }
    }
}