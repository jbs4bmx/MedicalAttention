using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace MedicalAttention.Utilities
{
    internal class patchMeds : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MovementContext), nameof(MovementContext.SetPhysicalCondition));
        }

        [PatchPrefix]
        static bool Prefix(EPhysicalCondition medCheck, ref bool __result)
        {
            if (medCheck == EPhysicalCondition.UsingMeds && MedsPlugin.sprintWithMeds.Value)
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
