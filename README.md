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

<!-- ABOUT THE PROJECT -->
## 📋 About The Project
Type: Server Mod</br>
Disclaimer: **This mod is provided _as-is_ with _no guarantee_ of support.**

Fully enhanced medical supplies to aid in your neverending quest to escape from the region known as Tarkov. This mod increases HP of medical items, the duration of positive health effects, and adds additional healing properties to some medical items.

All med kits have the option to be configured to enable a "Heal over time" function. This takes precedence over the typical healing function and instead enables your PMC or Player SCAV to heal over time while playing the game. This feature can be used for long term healing, but you can also still use any med kits for standard healing that do not have the feature enabled.</br>

### 🔨 Built With
|Type      | Icon                                                        | Link                                       |
|:--------:| :---------------------------------------------------------: | :----------------------------------------: |
| Language | <img src="./images/icons/CS.svg" width="48">                | [C# Documentation][CSharp-url]             |
| IDE      | <img src="./images/icons/VisualStudio-Dark.svg" width="48"> | [Visual Studio Website][VisualStudio-url]  |

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>

<!-- GETTING STARTED -->
## 🎮 Getting Started
This section will explain how to install and use this mod.

### Prerequisites
EFT and SPT are required to use this mod.

### Installation
_For the purpose of these directions, "[SPT]" represents your SPT folder path._

Start by downloading the mod from the [Releases](https://github.com/jbs4bmx/MedicalAttention/releases) page.

Follow these steps to install and configure the mod:
  1. Extract the contents of the zip file into the root of your [SPT] folder.
     - That's the same location as "EscapeFromTarkov.exe".
  2. Edit the Config to adjust the values to your liking.
  3. Start SPT.Server.exe and wait until it fully loads.
  4. Start SPT.Launcher.exe.
  5. Now you can launch the game and profit.

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>

<!-- CONFIGURATION EXAMPLES -->
## ⚙ Configuration
Medical Supplies are customizable by editing the included config.json file. The customizable options have been greatly increased to allow for more targeted amplification of medical items. You can enable modification on one or more items and further modify those items affects to your liking.</br>
```jsonc
{
    // __Med Kits________________________________________________________________________
    "Ai2": {
        // Soviet AI-2 Medkit
        "Enable": true,
        "hpResource": 250,
        "hpResourceRate": 20,
        "Duration": 180,
        "AddStopLightBleeding": true,
        "AddStopHeavyBleeding": true,
        "HealOverTime": false
    },
    "Car": {
        // Swiss Safe 2-in-1 First Aid Kit (Car Medkit)
        "Enable": true,
        "hpResource": 500,
        "hpResourceRate": 40,
        "Duration": 180,
        "AddStopHeavyBleeding": true,
        "HealOverTime": false
    },
    "Salewa": {
        // SALEWA - First Aid Kit Waterproof
        "Enable": true,
        "hpResource": 1000,
        "hpResourceRate": 50,
        "Duration": 180,
        "AddFixFracture": true,
        "AddFixBlackedLimb": true,
        "HealOverTime": false
    },
    "Ifak": {
        // Individual First Aid Kit (IFAK)
        "Enable": true,
        "hpResource": 1000,
        "hpResourceRate": 100,
        "Duration": 180,
        "AddFixFracture": true,
        "AddFixBlackedLimb": true,
        "HealOverTime": false
    },
    "Sanitar": {
        // Sanitar's AFAK
        "Enable": true,
        "hpResource": 2000,
        "hpResourceRate": 5,
        "Duration": 15,
        "AddStopLightBleeding": true,
        "AddStopHeavyBleeding": true,
        "AddFixFracture": true,
        "HealOverTime": false
    },
    "Afak": {
        // Advanced Individual First Aid Kit (AFAK)
        "Enable": true,
        "hpResource": 1500,
        "hpResourceRate": 100,
        "Duration": 180,
        "AddFixFracture": true,
        "AddFixBlackedLimb": true,
        "HealOverTime": false
    },
    "Grizzly": {
        // Sportsman Series Grizzly Medical Kit
        "Enable": true,
        "hpResource": 5000,
        "hpResourceRate": 125,
        "Duration": 180,
        "AddFixBlackedLimb": true,
        "HealOverTime": false
    },

    // __Pills___________________________________________________________________________
    "Analgin": {
        // Analgin (Actually illegal to purchase in real life!)
        "Enable": true,
        "hpResource": 24,
        "Duration": 360,
        "AddRadExposureFix": true
    },
    "Augmentin": {
        // Augmentin Anti-Biotics
        "Enable": true,
        "hpResource": 45,
        "Duration": 360,
        "AddRadExposureFix": true
    },
    "Ibuprofen": {
        // Ibuprofen
        "Enable": true,
        "hpResource": 90,
        "Duration": 360,
        "AddRadExposureFix": true
    },

    // __Bandages________________________________________________________________________
    "Aseptic": {
        // Medpride Conforming Stretch Gauze
        "Enable": true,
        "hpResource": 8,
        "AddStopHeavyBleeding": true
    },
    "Army": {
        // Russian Individual dressing bag PPI AB-3
        "Enable": true,
        "hpResource": 4,
        "AddStopHeavyBleeding": true
    },

    // __Splints_________________________________________________________________________
    "Splint": {
        // EVERLIT Survival 36 Inch Splint
        "Enable": true,
        "hpResource": 8
    },
    "AluminumSplint": {
        // Archer Medtech Universal First Aid Splint - Moldable Aluminum
        "Enable": true,
        "hpResource": 8
    },

    // __Topicals________________________________________________________________________
    "Vaseline": {
        // Norka Vaseline cosmetic "Mink"
        "Enable": true,
        "hpResource": 10,
        "Duration": 360,
        "EnergyBurn": -2,
        "HydrationBurn": -2,
        "AddRadExposureFix": true
    },
    "GoldenStarBalm": {
        // Golden Star Balm
        "Enable": true,
        "hpResource": 10,
        "Duration": 360,
        "EnergyBurn": -2,
        "EnableHydrationBurn": true,
        "HydrationBurn": -2,
        "AddRadExposureFix": true
    },

    // __Surgical Kits___________________________________________________________________
    "CMSSurgicalKit": {
        // Tactical Surgical and Suture Kit
        "Enable": true,
        "hpResource": 10,
        "AddStopLightBleeding": true,
        "AddStopHeavyBleeding": true,
        "AddFixFracture": true
    },
    "SanitarSurgicalKit": {
        // Also based on the Tactical Surgical and Suture Kit
        "Enable": true,
        "hpResource": 8,
        "AddStopLightBleeding": true,
        "AddStopHeavyBleeding": true,
        "AddFixFracture": true
    },
    "Surv12FieldSurgicalKit": {
        // 12 Survivors First Aid Rollup Kit
        "Enable": true,
        "hpResource": 12,
        "AddStopLightBleeding": true,
        "AddStopHeavyBleeding": true,
        "AddFixFracture": true
    },

    // __Tourniquets_____________________________________________________________________
    "Esmarch": {
        // Blood Loss Arterial Bleeding Rubber Band (aka Soviet Pink Tourniquet Esmarch)
        "Enable": true,
        "hpResource": 5,
        "AddStopLightBleeding": true
    },
    "CalokB": {
        // Celox V12090 Blood Clotting Granule Applicator and Plunger
        "Enable": true,
        "hpResource": 5,
        "AddStopLightBleeding": true
    },
    "Cat": {
        // North American Rescue NAR CAT Tourniquet
        "Enable": true,
        "hpResource": 5,
        "AddStopLightBleeding": true
    },

    // __Injectors_______________________________________________________________________
    "AllInjectors": {
        "Enable": true,
        "Uses": 4
    },
    "Morphine": {
        // Morphine Injector
        "Duration": 360,
        "HydrationBurn": -2,
        "EnergyBurn": -2
    },
    "Sj1": {
        // Combat Stimulant Injector SJ1 TGLabs
    },
    "eTGchange": {
        // Regenerative Stimulant Injector eTG-change
        "Duration": 360
    },
    "Sj6": {
        // Combat Stimulant Injector SJ6 TGLabs
    },
    "Sj9": {
        // Combat Stimulant Injector SJ9 TGLabs
    },
    "Propital": {
        // Propital
        "Duration": 360
    },
    "Zagustin": {
        // Hemostatic Drug Zagustin
        "Duration": 360
    },
    "Adrenaline": {
        // Adrenaline Injector
        "Duration": 360
    },
    "Meldonin": {
        // Meldonin
    },
    "Ahf1m": {
        // AHF1-M
    },
    "bTG": {
        // 3-(b-TG)
    },
    "Norepinephrine": {
        // L1 (Norepinephrine)
        "Duration": 360
    },
    "p22": {
        // P22
    },
    "Obdolbos": {
        // Cocktail "Oldolbos"
    },
    "Mule": {
        // M.U.L.E. stimulator
    },
    "xTG12": {
        // Antidote xTG-12
    },
    "Obdolbos2": {
        // Obdolbos 2
    },
    "Sj12": {
        // SJ12 TGLabs
    },
    "Perfotoran": {
        // Perfotoran (Blue Blood)
        "Duration": 360
    },
    "Trimadol": {
        // Trimadol
        "Duration": 360
    },
    "Pnb": {
        // PNB
        "Duration": 360
    },
    "a2bTG": {
        // 2A2-(b-TG)
    }
}
```

### ⚠ Mod FAQ
**Q: Where do I report bugs found with the current version of the mod?** <br>
A: You can report bugs for the current version of this mod on the [MA Mod Page](https://hub.sp-tarkov.com/files/file/255-medical-attention/).

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>

<!-- ROADMAP -->
## 🚗 Roadmap
- [✅] Add Changelog
- [✅] Add Heal-Over-Time option to medkits.
- [✅] Update to support SPT 4.0.0+
- [✅] Optimize code
- [✅] Fix issues transposing config values to game values.
- [❓] Add more customization options.

Suggest changes or report issues [here](https://github.com/jbs4bmx/MedicalAttention/issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>

<!-- CONTRIBUTING -->
## 🚧 Contributing
Contributions are welcome and appreciated.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push the branch
5. Open a pull request

If you’d like to support development, you can also buy me a coffee:

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/X8X611JH15)

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>



<!-- LICENSE -->
## 🪧 License
Distributed under the MIT License. See `LICENSE` or `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>



<!-- ACKNOWLEDGMENTS -->
## 👍 Acknowledgments
Contributors:
None yet.

<p align="right">(<a href="#readme-top">back to top</a>)</p></br></br>

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
[CSharp-url]: https://learn.microsoft.com/en-us/dotnet/csharp/
[VisualStudio-url]: https://visualstudio.microsoft.com/
