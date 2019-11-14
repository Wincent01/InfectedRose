# InfectedRose.Luz
All LEGO Universe Zone are centered around a LUZ file. It includes information about other associated zone
files, along with paths. Paths can be enemy spawn details, moving platform waypoints, among other things.

## Example
```c#
var luz = new LuzFile();

await using (var fileStream = File.OpenRead(file))
{
    using var reader = new BitReader(fileStream);

    luz.Deserialize(reader); // Read zone file

    luz.SpawnPoint = new Vector3(100, 200, 300); // Set new spawn point
}

await using var writeStream = File.OpenWrite(file);
using var writer = new BitWriter(writeStream);

luz.Serialize(writer); // Save zone file
```