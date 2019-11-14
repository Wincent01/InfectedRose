# InfectedRose.Terrain
Each LEGO® Universe Zone (See InfectedRose.Luz) is accompanied with one RAW file, even zones that does not need terrain.

## Example
```c#
var terrain = new TerrainFile();

await using (var fileStream = File.OpenRead(file))
{
    using var reader = new BitReader(fileStream);

    terrain.Deserialize(reader); // Read terrain file

    foreach (var chunk in terrain.Chunks) 
    {
        var data = chunk.HeightMap.Data; // Get chunk terrain data

        var min = data.Min();
        var max = data.Max();
        
        //
        // Create high and low points all over the chunk
        //

        uint index = default;
        for (var i = 0; i < data.Length; i++)
        {
            if (index++ == 100)
            {
                data[i] = max;
            }
            else if (index == 200)
            {
                data[i] = min;

                index = default;
            }
        }

        chunk.HeightMap.Data = data; // Set chunk terrain data
    }
}

await using var writeStream = File.OpenWrite(file);
using var writer = new BitWriter(writeStream);

terrain.Serialize(writer); // Save terrain file
```