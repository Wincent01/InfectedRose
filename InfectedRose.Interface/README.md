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

Additionally `PHYSICS:` and `ICON:` can be appended for when the path needs a specific origin.

# Examples

```json
[
  {
    "id": "my-mod:brick",
    "type": "environmental",
    "action": "add",
    "locale": {
      "en_US": ""
    },
    "values": {
      "render_asset": "ASSET:assets/brick.nif",
      "physics_asset": "ASSET:PHYSICS:assets/brick.hkx"
    }
  }
]
```

```json
[
  {
    "id": "my-mod:item",
    "type": "item",
    "action": "add",
    "skills": [
      150
    ],
    "locale": {
      "en_US": "My Item!"
    },
    "values": {
      "render_asset": "ASSET:assets/item.nif",
      "icon_asset": "ASSET:ICON:assets/item.dds",
      "equipLocation": "special_r",
      "color1": 10,
      "baseValue": 100,
      "itemType": 6,
      "rarity": 3,
      "stackSize": 1
    }
  }
]
```

```json
[
  {
    "id": "my-mod:npc",
    "type": "npc",
    "action": "add",
    "items": [
      "my-mod:item"
    ],
    "missions": [
      {
        "mission": "my-mod:mission",
        "accept": true,
        "offer": true
      }
    ],
    "locale": {
      "en_US": "My NPC!"
    },
    "values": {
      "head": 0,
      "chest": 10,
      "legs": 10,
      "hairstyle": 0,
      "haircolor": 0,
      "chestdecal": 39,
      "headcolor": 0,
      "lefthand": 0,
      "righthand": 0,
      "eyebrowstyle": 0,
      "eyesstyle": 31,
      "mouthstyle": 3
    }
  }
]
```

```json
[
  {
    "id": "my-mod:mission",
    "type": "mission",
    "action": "add",
    "tasks": [
      {
        "type": "Smash",
        "target": 4712,
        "count": 10,
        "group": [
          6351,
          8088,
          8089,
          9744
        ],
        "icon": "ASSET:ICON:assets/mission.dds",
        "locale": {
          "en_US": "Smash 10 Stromlings!"
        }
      }
    ],
    "locale": {
      "en_US": "My Mission!"
    },
    "values": {
      "icon": "ASSET:ICON:assets/mission.dds",
      "defined_type": "Location",
      "defined_subtype": "Avant Gardens",
      "offer_objectID": "my-mod:npc",
      "target_objectID": "my-mod:npc",
      "reward_currency": 50,
      "LegoScore": 10,
      "isChoiceReward": false,
      "reward_item1": "my-mod:item",
      "reward_item1_count": 1,
      "isMission": true
    }
  }
]
```
Note that missions are work in progress.
