# Medical Attention
Enhanced Medications. All meds, kits, injectors, and balms enhanced for your pleasure.

This is meant to be a replacement for SuperIFAK and SuperAFAK mods, however, you may still use those mods if you keep the IFAK and AFAK settings for this mod disabled. If you do not keep them disabled in this mod, the the three mods can conflict with one another and your server may not load and/or their functionality could be broken in game

HP resource values for all items are listed below...
Some items have extra features added but are not listed here. To see those changes, please review the code in src folder.

>Author  : jbs4bmx


### /* ========== CONFIGURABLE MEDICAL SUPPLIES ========== */
Medical Supplies are now customizable.
Edit .\src\config.json to change the HP Resource or functionality of Medical Supplies.

Example of config.json
```jsonc
{
    "AI2": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 250,          // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 50        // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
    },

    "CAR": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 500,          // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 70        // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
    },

    "SALEWA": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 1000,         // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 85        // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
    },

    "IFAK": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 900,          // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 50,       // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
        "fixFracture": true,        // Fix a broken limb. ('true' to enable : 'false' to disable)
        "fixDestroyedPart": true    // Fix a blacked out body part. ('true' to enable : 'false' to disable)
    },

    "SANITAR": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 5000,         // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 1         // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
        "fixFracture": true,        // Fix a broken limb. ('true' to enable : 'false' to disable)
        "fixDestroyedPart": true    // Fix a blacked out body part. ('true' to enable : 'false' to disable)
    },

    "AFAK": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 1200,         // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 60,       // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
        "fixFracture": true,        // Fix a broken limb. ('true' to enable : 'false' to disable)
        "fixDestroyedPart": true    // Fix a blacked out body part. ('true' to enable : 'false' to disable)
    },

    "GRIZZLY": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 5000,         // This is the amount of HP this item has. (Whole number only.)
        "hpResourceRate": 175,      // This is the rate of healing that will occur during a single use. This is not the actual amount that will be healed although a higher number will provide more healing during each use. (Whole number only.)
        "fixFracture": true,        // Fix a broken limb. ('true' to enable : 'false' to disable)
        "fixDestroyedPart": true    // Fix a blacked out body part. ('true' to enable : 'false' to disable)
    },

    "PILLS": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 24,           // This is the amount of HP this item has. (Whole number only.)
        "Duration": 360,            // This changes the duration of the buff measured in seconds.
        "HydrationBurn": -4         // This is the amount of hydration lost per cycle by using this item.
    },

    "BANDAGES": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 4             // This is the amount of HP this item has. (Whole number only.)
    },

    "SPLINTS": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 8             // This is the amount of HP this item has. (Whole number only.)
    },

    "TOPICALS": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 10,           // This is the amount of HP this item has. (Whole number only.)
        "Energy": 25,               // This is the amount of energy gained per cycle by using this item.
        "Hydration": 25,            // This is the amount of hydration gained per cycle by using this item.
        "Duration": 360             // This changes the duration of the buff. Measured in seconds.
    },

    "SURGICALKITS": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 10            // This is the amount of HP this item has. (Whole number only.)
    },

    "TOURNIQUETS": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 5             // This is the amount of HP this item has. (Whole number only.)
    },

    "INJECTORS": {
        "Enable": false,            // Enable or Disable modification of this item. ('true' to enable : 'false' to disable)
        "hpResource": 4,            // This is the amount of HP this item has. (Whole number only.)
        "Duration": 360,            // This changes the duration of the buff. Measured in seconds.
        "HydrationBurn": -4,        // This is the amount of hydration lost per cycle by using this item.
        "EnergyBurn": -4            // This is the amount of energy lost per cycle by using this item.
    }
}
```
#

### NOTICE
**WARNING** - There is one caveat to using this mod after enabling "fix fractures" and/or "fix destroyed body parts" on Ifak, Afak, Sanitar Med Kit, or Grizzly...
>When healing fractures or destroyed parts with enhanced med kits, your character cannot move.
>It is a side-effect of adding the "surgical kit"-like features to med kits.
>Take cover to heal if you have these features enabled!
#

### End
#