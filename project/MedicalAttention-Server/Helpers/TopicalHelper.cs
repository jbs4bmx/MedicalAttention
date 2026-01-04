using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;

namespace MedicalAttentionServer.Helpers;

public static class TopicalHelper
{
    /// <summary>
    /// Apply the base topical settings shared by Vaseline and Golden Star Balm.
    /// </summary>
    public static void ApplyBaseTopicalSettings(
        TemplateItem item,
        dynamic configSection)
    {
        item.Properties!.MaxHpResource = configSection.hpResource;
        item.Properties!.MedUseTime = 1;
    }

    /// <summary>
    /// Apply the pain suppression effect (usually 600 seconds).
    /// </summary>
    public static void ApplyPainSuppression(
        TemplateItem item,
        int duration)
    {
        item.Properties!.EffectsDamage![DamageEffectType.Pain] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0
        };
    }

    /// <summary>
    /// Apply hydration penalty (typically -2).
    /// </summary>
    public static void ApplyHydrationPenalty(
        TemplateItem item,
        int value)
    {
        item.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
        {
            Value = value
        };
    }

    /// <summary>
    /// Apply energy penalty (typically -2).
    /// </summary>
    public static void ApplyEnergyPenalty(
        TemplateItem item,
        int value)
    {
        item.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
        {
            Value = value
        };
    }

    /// <summary>
    /// Apply the radiation exposure fix (RadExposure → fully removed).
    /// </summary>
    public static void ApplyRadExposureFix(
        TemplateItem item,
        int cost = 30)
    {
        item.Properties!.EffectsDamage![DamageEffectType.RadExposure] = new EffectsDamageProperties
        {
            Cost = cost,
            Delay = 0,
            Duration = 0,
            FadeOut = 0,
            HealthPenaltyMin = 100,
            HealthPenaltyMax = 100
        };
    }
}
