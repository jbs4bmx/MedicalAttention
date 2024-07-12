# Medical Attention


## Description
Fully enhanced medical supplies to aid in your neverending quest to escape from the region known as Tarkov. This mod increases HP of medical items, the duration of positive health effects, and adds additional healing properties to some medical items.


## Credits
Author: jbs4bmx <br>
Contributors: sugonyak, ShadowXtrex


## Item Changes
Medical Items have been rebalanced as of v380.0.1
  * Sanitar's items have been debuffed to prevent him from healing too rapidly.
  * When configured for surgery, some med kits will perform better than others and may prevent loss of HP for the blacked out body part that they repair.
  * CMS and Surv12 surgery kits have been buffed to prevent most or all loss of HP for the blacked out body part that they repair.
  * All items have configurable HP/number of uses.
  * All items with lasting positive effects have configurable durations.


## List of items that currently are able to, or can be configured to, repair a blacked out body part.
Table updated for v380.0.2
| Item                     | Potential HP Loss (percent) |
|:-------------------------|:----------------------------|
| Salewa                   | Up to max of 30 %           |
| IFAK                     | Up to max of 20 %           |
| Sanitar's IFAK           | Guaranteed loss of 25-75%   |
| AFAK                     | 0 %                         |
| Grizzly                  | 0 %                         |
| CMS                      | Up to max of 10 %           |
| Sanitar's CMS            | Guaranteed loss of 10-70%   |
| Surv12 Field Surgery Kit | 0 %                         |


## Installation
### How to Install this Mod.
"[SPT]" = Your SPT folder path
   1. Extract the contents of the zip file into the root of your [SPT] folder.
      - That's the same location as "SPT.Server.exe" and "SPT.Launcher.exe".
   2. Edit the Config to adjust the values to your likeing.
   3. Start SPT.Server.exe and wait until it fully loads.
   4. Start SPT.Launcher.exe but do not launch the game.
   5. Run the cache cleaner found in the launcher's settings menu.
   6. Now you can launch the game and profit.

### Common Questions
   1. Where do I report bugs found with the current version of the mod?
      - You can report bugs for the current version of this mod here: [MA Mod Page](https://hub.sp-tarkov.com/files/file/255-medical-attention/).


## Configuration Guide
Edit '.\config.jsonc' file as desired. <br>
config.jsonc contents <br>
Medical Supplies are customizable by editing the included config.json file. The customizable options have been greatly increased to allow for more targeted amplification of medical items. You can enable modification on one or more items and further modify those items affects to your liking. <br> <br>
Examples of values found in "config.json"
```jsonc
{
    // Some examples of what you'll find in the config file. There are far more options than this.
    "MedKits":{
        "Ai2": {
            // Soviet AI-2 Medkit
            "Enable": false,
            "hpResource": 250,
            "hpResourceRate": 20,
            "Duration": 180,
            "AddStopLightBleeding": false,
            "AddStopHeavyBleeding": false
        },
        "Sanitar": {
            // Sanitar's AFAK
            "Enable": false,
            "ResizeTo1x1": false,
            "hpResource": 2000,
            "hpResourceRate": 5,
            "Duration": 15,
            "AddStopLightBleeding": false,
            "AddStopHeavyBleeding": false,
            "AddFixFracture": false
        }
    },
    "SurgicalKits": {
        "CMSSurgicalKit": {
            // Tactical Surgical and Suture Kit
            "Enable": false,
            "hpResource": 10,
            "AddStopLightBleeding": false,
            "AddStopHeavyBleeding": false,
            "AddFixFracture": false
        }
    },
    "Injectors": {
        "Morphine": {
            // Morphine Injector
            "Enable": false,
            "hpResource": 4,
            "Duration": 360,
            "HydrationBurn": -2,
            "EnergyBurn": -2
        },
        "Sj1": {
            // Combat Stimulant Injector SJ1 TGLabs
            "Enable": false,
            "hpResource": 4
        },
        "ModInjectors": {
            // All custom injectors from mods.
            // This setting is a WIP. It has not yet been tested.
            "Enable": false,
            "hpResource": 4
        }
    }
}
```


## Notice
There is one caveat to using this mod after enabling "fix fractures" and/or "fix destroyed parts" on Salewa, IFAK, AFAK, Sanitar's IFAK, or Grizzly medkits...

  * When healing fractures or destroyed parts with enhanced med kits, your character cannot move.
    * It is a side-effect of adding the "surgical kit"-like features to med kits.
    * Take cover to heal if you have these features enabled!


## Disclaimer
**This mod is provided _as-is_ with _no guarantee_ of support.**
