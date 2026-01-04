using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;

namespace MedicalAttentionServer.Helpers;

public static class BandageHelper
{
    /// <summary>
    /// Apply the base bandage settings shared by Aseptic and Army bandages.
    /// </summary>
    public static void ApplyBaseBandageSettings(
        TemplateItem item,
        dynamic configSection)
    {
        item.Properties!.MaxHpResource = configSection.hpResource;
        item.Properties!.MedUseTime = 1;
    }

    /// <summary>
    /// Apply the heavy bleeding stop effect.
    /// </summary>
    public static void ApplyHeavyBleedFix(
        TemplateItem item,
        int duration = 60,
        int cost = 30,
        int hpMin = 100,
        int hpMax = 100)
    {
        item.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpMin,
            HealthPenaltyMax = hpMax
        };
    }
}
