using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using MedicalAttention_Client.Utilities;
using System;
using static MedicalAttention_Client.Utilities.VersionChecker;

namespace MedicalAttention_Client
{
    [BepInPlugin("com.jbs4bmx.MedicalAttention", "MedicalAttention", "4.0.2")]
    [BepInDependency("com.SPT.core", "4.0.0")]
    public class MedsPlugin : BaseUnityPlugin
    {
        public const int TarkovVersion = 40087;
        public static ConfigEntry<bool> dontStopForSurgery;
        public static ConfigEntry<bool> sprintWithMeds;

        private void Awake()
        {
            var harmony = new Harmony("com.jbs4bmx.MedicalAttention");

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

            harmony.PatchAll();
        }
    }
}
