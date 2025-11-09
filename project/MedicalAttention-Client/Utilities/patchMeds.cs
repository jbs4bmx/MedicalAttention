using Comfort.Common;
using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace MedicalAttention_Client.Utilities
{
    [HarmonyPatch(typeof(MovementContext), "CanSprint", MethodType.Getter)]
    public static class patchMeds
    {
        
        static bool Prefix(ref bool __result, MovementContext __instance)
        {
            if (MedsPlugin.sprintWithMeds.Value)
            {
                // Allow sprinting while using meds or healing
                __result = !__instance.PhysicalConditionIs(EPhysicalCondition.SprintDisabled) && (__instance.PhysicalConditionIs(EPhysicalCondition.UsingMeds) || __instance.PhysicalConditionIs(EPhysicalCondition.HealingLegs) || __instance.PhysicalConditionIs(EPhysicalCondition.OnPainkillers) || (!__instance.PhysicalConditionIs(EPhysicalCondition.RightLegDamaged) && !__instance.PhysicalConditionIs(EPhysicalCondition.LeftLegDamaged)));
                return false; // Skip the original method execution
            }
            return true;   
        }
    }
}
