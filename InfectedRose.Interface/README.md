# InfectedRose.Interface

This is a modding interface for LEGO® Universe.

## Setup

In the client, create a `mods` directory, than create a `mods.json` file in that directory:
```json
{
  "database": "cdclient.fdb",
  "sqlite": "CDServer.sqlite"
}
```
Copy over `res/cdclient.fdb` directory into `mods` directory, this will be the database the interface works upon.

When the interface is run, it will save to`res/cdclient.fdb`, the database in the `mods` directory will remain contant.

The interface will also save the database converted to SQLite,
the `sqlite` entry in the `mods.json` file can be changed to point to where the server loads it.

## Running

```bash
# Apply mods (-i can be excluded if exectued from where mods.json is located)
dotnet InfectedRose.Interface.dll -i <path-to-mods.json>

# Copy an object into a mod file
dotnet InfectedRose.Interface.dll -c <lot> -d <my-mod:id> -o <output-mod.json>
```

## Mods

In the `mods` directory can subdirectories be created, each containing a `manifest.json`:
```json
{
    "name": "My Mods",
    "files": [
        "npc/mod.json"
    ]
}
```

Each subdirectory with a `manifest.json` will be loaded by the interface.

The `files` entry specifies paths to json files where the details of the mod is specified.

## Creating mods

An example of a mod file:
```json
# mod.json
[
  {
    "id": "my-mod:brick",
    "type": "object",
    "action": "add",
    "components": [
      "my-mod:render-component:brick",
      "my-mod:simple-physics-component:brick"
    ],
    "values": {
      "name": "my brick!",
      "type": "Environmental"
    }
  },
  {
    "id": "my-mod:render-component:brick",
    "type": "RenderComponent",
    "action": "add",
    "values": {
      "render_asset": "ASSET:assets/brick.nif",
      "shader_id": 1
    }
  },
  {
    "id": "my-mod:simple-physics-component:brick",
    "type": "SimplePhysicsComponent",
    "action": "add",
    "values": {
      "static": 1,
      "physics_asset": "ASSET:PHYSICS:assets/brick.hkx"
    }
  }
]
```

This will create an object with two components, a RenderComponent and a SimplePhysicsComponent.

Values starting with `ASSET:` will be formatted to a path the game will use to find files included in the mod.

In this example a `assets` subdirectory was created in the same directory where `mod.json` is located, where the mod includes two assets.
The resulting path to the asset will be `..\\mods\\my-mod\\brick\\assets\\brick.nif`. 

Additionally `PHYSICS:` can be appended for when the path has to originate from `res/physics`.