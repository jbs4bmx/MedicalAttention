<a id="readme-top"></a>
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/jbs4bmx/MedicalAttention">
    <img src="./images/MABanner.png" alt="logo" width="640" height="320">
  </a>

  <h3 align="center">Medical Attention</h3>

  <p align="center">Modification of pain killers, med kits, surgical kits, splints, bandages, balms, and injectors.<br /></p>

  [![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X611JH15)
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
      <a href="#configuration">Configuration</a>
      <ul>
        <li><a href="#mod-faq">Mod FAQ</a></li>
      </ul>
    </li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Type: Server Mod</br>
Disclaimer: **This mod is provided _as-is_ with _no guarantee_ of support.**

Fully enhanced medical supplies to aid in your neverending quest to escape from the region known as Tarkov. This mod increases HP of medical items, the duration of positive health effects, and adds additional healing properties to some medical items.

All med kits have the option to be configured to enable a "Heal over time" function. This takes precedence over the typical healing function and instead enables your PMC or Player SCAV to heal over time while playing the game. This feature can be used for long term healing, but you can also still use any med kits for standard healing that do not have the feature enabled.</br></br>

**List of items that currently are able to, or can be configured to, repair a blacked out body part.**</br>
_Table updated for version 380.0.2 and newer._
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
</br></br>

**Notice**</br>
There is one caveat to using this mod after enabling "fix fractures" and/or "fix destroyed parts" on Salewa, IFAK, AFAK, Sanitar's IFAK, or Grizzly medkits...
  * When healing fractures or destroyed parts with enhanced med kits, your character cannot move.
    * It is a side-effect of adding the "surgical kit"-like feature to med kits.
    * Take cover to heal if you have this feature enabled!
<br><br>

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With
| Frameworks/Libraries                                      | Name         | Link                                       |
| :-------------------------------------------------------: | :----------: | :----------------------------------------: |
| <img src="./images/icons/TypeScript.svg" width="48">      | `TypeScript` | [TypeScript Website][TypeScript-url]       |

|                         IDEs                                |      Name       | Link                                      |
| :---------------------------------------------------------: | :-------------: | :---------------------------------------: |
| <img src="./images/icons/VSCodium-Dark.svg" width="48">     | `VSCodium`      | [VSCodium Website][Vscodium-url]          |

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started
This section will explain how to install and use this mod.

### Prerequisites
EFT and SPT are required to use this mod.

### Installation
_For the purpose of these directions, "[SPT]" represents your SPT folder path._

Start by downloading the mod from the [Releases](https://github.com/jbs4bmx/MedicalAttention/releases) page.

Follow these steps to install and configure the mod:
  1. Extract the contents of the zip file into the root of your [SPT] folder.
     - That's the same location as "SPT.Server.exe" and "SPT.Launcher.exe".
  2. Edit the Config to adjust the values to your liking.
  3. Start SPT.Server.exe and wait until it fully loads.
  4. Start SPT.Launcher.exe.
  5. Now you can launch the game and profit.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONFIGURATION EXAMPLES -->
## Configuration
Medical Supplies are customizable by editing the included config.json file. The customizable options have been greatly increased to allow for more targeted amplification of medical items. You can enable modification on one or more items and further modify those items affects to your liking.</br>
```jsonc
{
    "ArmorCoverage": {
        // Customize Holtzman Shield armor protection areas.
        // This value must be true or false.
        "Head": true,
        "Neck": true,
        "Eyes": true,
        "Ears": true,
        "Jaw": true,
        "Arms": true,
        "Front": true,
        "Back": true,
        "Sides": true,
        "Pelvis": true,
        "Buttocks": true,
        "Legs": true
    },
    "ArmorAmount": {
        // Customize Holtzman Shield armor durability level.
        // This must be a whole number ranging from 1-9999999.
        "Durability": 100000
    },
    "Resources": {
        // Customize Holtzman Shield item properties.
        "ArmorClass": "10",
        "ArmorMaterial": "Ceramic",
        "ArmorType": "Heavy",
        "ItemWeight": 0.01,

        // This is the amount of protection from bright lights.
        // This must be any number value between 0 and 1 (e.g., 0, 0.25, 0.5, 0.8, 1, etc.)
        "BlindnessProtection": 1,

        // I recommend keeping this at or below 100
        // This must be a whole number ranging from 1-2000.
        "RepairCost": 100,

        // Customize trader (Ragman) properties
        "traderPrice": 1000,
        "traderLoyaltyLevel": 1
    },
    "PreFab": {
        // If more than one is set to 'true', then PreFab will revert to default (Evasion).
        "Evasion": true,
        "Alpha": false,
        "DeadSkul": false,
        "TrainHard": false,
        "TwitchRivals": false,
        "Bear": false,
        "Kiba": false,
        "Labs": false,
        "RFArmy": false,
        "TerraGroup": false,
        "Untar": false,
        "USEC": false,
        "Blue": false,
        "Green": false,
        "Red": false,
        "White": false,
        "Yellow": false,
        "Unheard": false,
        "Arena": false,
        // The following item(s) is(are) not yet part of the game. (WIP - Ignore for now.)
        "BlackDivision": false
    },
    "GodMode": {
        // Disable damage dealt by blunt force trauma.
        "BluntForce": true,

        // (WIP) Disable damage from projectile penetration of armor.
        // This value is a work in progress and is not currently implemented in this mod. - Please ignore for now.
        "Penetration": false
    },
    "Blacklist": {
        // Set to 'true' to disable item spawning on PMC or Scav bots, or to remove from global loot pools.
        "pmc": false,
        "scav": false,
        "globalLoot": false
    }
}
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Mod FAQ
**Q: Where do I report bugs found with the current version of the mod?** <br>
A: You can report bugs for the current version of this mod on the [MA Mod Page](https://hub.sp-tarkov.com/files/file/255-medical-attention/).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap
- [X] Add Changelog
- [ ] Add function to CMS and Surv12 to heal blacked thorax/head.
- [X] Add Heal-Over-Time option to medkits.
- [ ] Update/balance values of topicals and pills.

Suggest changes or view/report issues [here](https://github.com/jbs4bmx/MedicalAttention/issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing
Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

You can also buy me a coffee! (This is not required, but I greatly appreciate any support provided.)</br>
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X611JH15)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License
Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments
Contributors:
None yet.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- Repository Metrics -->
[contributors-shield]: https://img.shields.io/github/contributors/jbs4bmx/MedicalAttention.svg?style=for-the-badge
[contributors-url]: https://github.com/jbs4bmx/MedicalAttention/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/jbs4bmx/MedicalAttention.svg?style=for-the-badge
[forks-url]: https://github.com/jbs4bmx/MedicalAttention/network/members
[stars-shield]: https://img.shields.io/github/stars/jbs4bmx/MedicalAttention.svg?style=for-the-badge
[stars-url]: https://github.com/jbs4bmx/MedicalAttention/stargazers
[issues-shield]: https://img.shields.io/github/issues/jbs4bmx/MedicalAttention.svg?style=for-the-badge
[issues-url]: https://github.com/jbs4bmx/MedicalAttention/issues
[license-shield]: https://img.shields.io/github/license/jbs4bmx/MedicalAttention.svg?style=for-the-badge
[license-url]: https://github.com/jbs4bmx/MedicalAttention/blob/master/LICENSE.txt



<!-- Framwork/Library URLs -->
[TypeScript-url]: https://www.typescriptlang.org/
[Vscodium-url]: https://vscodium.com/
