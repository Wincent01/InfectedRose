# InfectedRose.Geometry
LEGO® Universe has a lot of "*.g#" files. They contain basic mesh data for building bricks.

## Example
Convert to Wavefront (OBJ) format.
```c#
var geometryFile = new GeometryFile();

await using (var fileStream = File.OpenRead(file))
{
    using var reader = new BitReader(fileStream);

    geometryFile.Deserialize(reader); // Read geometry file
}

var mesh = geometryFile.Mesh; // Get mesh

var meshString = new StringBuilder();

foreach (var v in mesh.Vertices) // Write vertices
    meshString.AppendLine($"v {v.X} {v.Y} {v.Z}");

foreach (var v in mesh.Normals) // Write normals
    meshString.AppendLine($"vn {v.X} {v.Y} {v.Z}");

foreach (var v in mesh.Uv) // Write UV
    meshString.AppendLine($"vt {v.X} {v.Y}");

for (var i = 0; i < mesh.Triangles.Length; i += 3) // Write triangles
{
    meshString.Append(
        string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n",
            mesh.Triangles[i] + 1,
            mesh.Triangles[i + 1] + 1,
            mesh.Triangles[i + 2] + 1
        )
    );
}

await File.WriteAllTextAsync($"{file}.obj", meshString.ToString()); // Save OBJ file
```