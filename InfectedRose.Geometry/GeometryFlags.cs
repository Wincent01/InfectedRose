using System;

namespace InfectedRose.Geometry
{
    [Flags]
    public enum GeometryFlags
    {
        None = 0,
        Uv = 1,
        Normals = 2,
        Flexible = 4,
        Unknown8 = 8,
        Unknown16 = 16,
        Unknown32 = 32
    }
}