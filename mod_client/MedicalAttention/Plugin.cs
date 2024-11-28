using BepInEx;
using BepInEx.Configuration;
using MedicalAttention.Utilities;
using System;
using static MedicalAttention.Utilities.VersionChecker;

namespace MedicalAttention
{
    [BepInPlugin("com.jbs4bmx.MedicalAttention", "MedicalAttention", "310.0.1")]
    public class MedsPlugin : BaseUnityPlugin
    {
        public const int TarkovVersion = 33420;
        public static ConfigEntry<bool> dontStopForSurgery;
        public static ConfigEntry<bool> sprintWithMeds;

        private void Awake()
        {
            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }

            dontStopForSurgery = Config.Bind<bool>(
                "Config",
                "Walk while performing surgery.",
                true,
                new ConfigDescription
                (
                    "Player can walk while performing surgery.",
                    null,
                    new ConfigurationManagerAttributes
                    {
                        Order = 2,
                    }
                )
                
            );

            sprintWithMeds = Config.Bind<bool>(
                "Config",
                "Run while using meds.",
                true,
                new ConfigDescription
                (
                    "Player can run while using meds.",
                    null,
                    new ConfigurationManagerAttributes
                    {
                        Order = 2,
                    }
                )
            );

            new patchMeds().Enable();
            new patchSurgeries().Enable();
        }
    }
}
