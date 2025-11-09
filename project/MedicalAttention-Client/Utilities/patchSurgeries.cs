using Comfort.Common;
using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace MedicalAttention_Client.Utilities
{

    [HarmonyPatch(typeof(MovementContext), "CanWalk", MethodType.Getter)]
    public static class patchSurgeries
    {

        static bool Prefix(ref bool __result, MovementContext __instance)
        {
            if (MedsPlugin.dontStopForSurgery.Value)
            {
                // Allow walking while using meds or healing
                __result = true;
                return false; // Skip the original method execution
            }
            return true;
        }
    }
}
