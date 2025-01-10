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
        static bool Prefix(EPhysicalCondition c, ref bool __result)
        {
            if (c == EPhysicalCondition.UsingMeds && MedsPlugin.sprintWithMeds.Value)
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
