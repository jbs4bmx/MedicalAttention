using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;

namespace MedicalAttentionServer.Helpers;

public static class SurgicalHelper
{
    /// <summary>
    /// Apply the base surgical kit settings shared by CMS, Surv12, and Sanitar Surgical Kit.
    /// </summary>
    public static void ApplyBaseSurgicalSettings(
        TemplateItem item,
        dynamic configSection)
    {
        item.Properties!.MaxHpResource = configSection.hpResource;
        item.Properties!.MedUseTime = 1;
    }

    /// <summary>
    /// Apply the light bleeding stop effect.
    /// </summary>
    public static void ApplyLightBleedFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpMin,
        int hpMax)
    {
        item.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpMin,
            HealthPenaltyMax = hpMax
        };
    }

    /// <summary>
    /// Apply the heavy bleeding stop effect.
    /// </summary>
    public static void ApplyHeavyBleedFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpMin,
        int hpMax)
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

    /// <summary>
    /// Apply the fracture fix effect.
    /// </summary>
    public static void ApplyFractureFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpMin,
        int hpMax)
    {
        item.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
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
