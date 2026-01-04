# 🔄 MEDICAL ATTENTION FULL CHANGE LOG 🔄

## 🚧 03 January, 2026 - 4.0.3 (For SPT 4.0.0+)
This release includes a major internal refactor of MedicalAttention, focused on stability, consistency, and long‑term maintainability. Several long‑standing issues reported by users have been resolved as a result of this rewrite.
  - Major Improvements
     - Fully modularized medical item logic using dedicated helper classes.
     - Unified and consistent handling of medkits, pills, bandages, splints, topicals, surgical kits, tourniquets, and stimulators.
     - Greatly improved maintainability, auditability, and future‑proofing.

  - Dynamic Stimulator Handling
     - Replaced hard‑coded stim lists with automatic detection based on the **Stimulator** parent category.
     - Morphine (the only stim under the **Drugs** parent) is now explicitly included.
     - Removed per‑stim `MaxHpResource` assignments — all stims now use the global `AllInjectors.Uses` value.
     - Fully supports modded stimulators without requiring manual TPL updates.

  - Corrected Medical Effect Logic
     - Standardized application of:
       - Light bleeding fixes
       - Heavy bleeding fixes
       - Fracture fixes
       - Destroyed limb fixes
     - Ensures consistent behavior across all medkits and surgical kits.

  - Config Cleanup & Validation
     - Removed unused config sections (`Ebudal`, `ModInjectors`).
     - Added missing config fields (e.g., `AddFixFracture` for Surv12 surgical kit).
     - Ensured all config options map directly to helper methods.

  - Helper Method Fixes
     - Added missing helper methods:
       - `ApplyFractureFix`
       - `ApplyDestroyedPartFix`
       - `ItemResizeHelper.ResizeItem`
     - Eliminated all missing‑method errors and restored intended functionality.

  - Stability & Predictability
     - Fixed several silent failure points from previous versions.
     - Improved null‑safety and item property validation.
     - Ensured all item modifications only occur when explicitly enabled in config.

  - Logging & Diagnostics
     - Added clear logging for every item type updated.
     - Improved visibility into stim detection and configuration application.

  - Future‑Proofing
     - Dynamic detection ensures compatibility with:
       - New SPT medical items
       - Modded stimulators
       - Database changes in future SPT releases

## 🚧 09 November, 2025 - 4.0.0 (For SPT 4.0.0+)
Update - Add support for SPT 4.0.0+ and EFT 0.16.9.0.40087</br>
Update - Convert mod code base to C# for new C# server.

## 🚧 27 November, 2024 - 310.0.1 (For SPT 3.10.0+)
Update - Support SPT 3.10+.

## 🚧 XX August, 2024 - 395.0.2 (For SPT 3.9.0+)
Add - Add heal-over-time function to medkits.</br>
Update - Update configuration file with new values.

## 🚧 12 July, 2024 - 390.0.1 (For SPT 3.9.0+)
Update - Enable all medical changes by default. (Now just plug and play!)


# 🗒 Other Notes
Previous versions unavailable.