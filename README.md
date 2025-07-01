# Custom Map Cracker

Allows you to create custom .info file for Onwaard 1.7 custom maps

## Encrypt Instructions

Create a new json file containing this information
```json
{
    "Title": "",
    "Description": "",
    "DisplayProperties": {
        "hash": "<local>",
        "pub_name": "",
        "game_modes": [
            "4"
        ],
        "map_filesize": ,
        "unity_version": "2018.4.2f1",
        "sdk_version": "6"
    },
    "ThumbnailUrl": ""
}
```

Fill in `Title`, `Description`, `pub_name`, `map_filesize`, and `ThumbnailUrl` with the appropriate data
 - `pub_name` Should be your in game name
 - `game_modes` Must be the game modes your map supports as a list of strings, you can figure out what numbers coorespond to what modes in [*Game Modes*](#-Game-Modes)
 - `map_filesize` Should be the filesize of the `.content` file
 - `ThumbnailUrl` must point to a 512x256 image

Once the file is create you can run
```cmd
CustomMapCracker.exe encrypt info.json map_guid.info
```

Now you can rename the `.content` and `.info` files to start with the same [guid](https://guidgenerator.com/) for example  
```
9b2d0a48-1967-4308-8bfa-e6381e5274d1.content
9b2d0a48-1967-4308-8bfa-e6381e5274d1.info
```

# Game Modes

- Uplink = 1,
- Escort = 2,
- Tutorial = 3,
- FreeRoam = 4,
- SpecOps = 5,
- UplinkAssault = 6,
- GunGame = 7,
- OneInTheChamber = 8,
- Operations_Hunt = 10,
- Operations_Evac = 11,
- ShootingRange = 12

All maps must setup FreeRoam (4)  
A map with Uplink, Escort, and FreeRoam should have  
```
"game_modes": [
    "1",
    "2",
    "4"
]
```