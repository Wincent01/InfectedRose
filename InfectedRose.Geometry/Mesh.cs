using System.Numerics;

namespace InfectedRose.Geometry
{
    public class Mesh
    {
        public Vector3[] Vertices { get; set; }
        
        public Vector3[] Normals { get; set; }
        
        public Vector2[] Uv { get; set; }
        
        public int[] Triangles { get; set; }
    }
}