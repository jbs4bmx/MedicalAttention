using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace MedicalAttention.Utilities
{
    internal class patchSurgeries : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MovementContext), nameof(MovementContext.SetPhysicalCondition));
        }

        [PatchPrefix]
        static bool Prefix(EPhysicalCondition surgCheck, ref bool __result)
        {
            if (surgCheck == EPhysicalCondition.HealingLegs && MedsPlugin.dontStopForSurgery.Value)
            {
                __result = false;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
