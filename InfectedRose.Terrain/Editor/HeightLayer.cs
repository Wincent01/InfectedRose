using System.Collections.Generic;
using System.Numerics;

namespace InfectedRose.Terrain.Editor
{
    public class HeightLayer
    {
        public TerrainEditor Editor { get; }
        
        public Dictionary<Vector2, float> Heights { get; }

        public HeightLayer(TerrainEditor editor)
        {
            Editor = editor;
            
            Heights = new Dictionary<Vector2, float>();
        }

        public void SetHeight(Vector2 position, float value)
        {
            Heights[position] = value;

            var additionalX = (position.X % 65).Equals(0);
            var additionalY = (position.Y % 65).Equals(0);

            if (additionalX)
            {
                SetHeight(position - Vector2.UnitX, value);
            }

            if (additionalY)
            {
                SetHeight(position - Vector2.UnitY, value);
            }

            if (additionalX && additionalY)
            {
                SetHeight(position - new Vector2(1, 1), value);
            }
        }

        public void LoadHeightMap()
        {
            var heightMap = Editor.Source.GenerateHeightMap();

            for (var x = 0; x < heightMap.GetLength(0); x++)
            {
                for (var y = 0; y < heightMap.GetLength(1); y++)
                {
                    Heights[new Vector2(x, y)] = heightMap[x, y];
                }
            }
        }

        public void ApplyHeightMap()
        {
            var heightMap = Editor.Source.GenerateHeightMap();

            for (var x = 0; x < heightMap.GetLength(0); x++)
            {
                for (var y = 0; y < heightMap.GetLength(1); y++)
                {
                    heightMap[x, y] = Heights[new Vector2(x, y)];
                }
            }

            Editor.Source.ApplyHeightMap(heightMap);
        }
    }
}