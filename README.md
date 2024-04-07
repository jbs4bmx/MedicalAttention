# Medical Attention
Fully enhanced medical supplies to aid in your neverending quest to escape from the region known as Tarkov. This mod increases HP of medical items, the duration of positive health effects, and adds additional healing properties to some medical items.


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


## Configuration
Medical Supplies are customizable by editing the included config.json file. The customizable options have been greatly increased to allow for more targeted amplification of medical items. You can enable modification on one or more items and further modify those items affects to your liking.


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
            // All custom injectors from mods. (Reserved for future update)
            // This setting is a WIP. It has not yet been tested. Do not use this setting for now.
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


### Enjoy!
