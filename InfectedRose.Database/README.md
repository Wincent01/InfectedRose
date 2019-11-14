# InfectedRose.Database
LEGO® Universe has a client side database (cdclient.fdb). It contains information about objects,
their components, movement set, and a lot more.

It takes a long time to calculate the hash table for this file format.

## Example
```c#
var databaseFile = new DatabaseFile();

await using (var fileStream = File.OpenRead(file))
{
    using var reader = new BitReader(fileStream);

    databaseFile.Deserialize(reader); // Read database
}

var database = new AccessDatabase(databaseFile);

var table = database["ZoneLoadingTips"]; // Find table

foreach (var tip in table)
{
    tip["imagelocation"].Value = "mod\\tips\\amazing_image.dds"; // Set field value
}

var bytes = databaseFile.Compile(); // Compile the database, this will take awhile

File.WriteAllBytes(file, bytes); // Save database
```