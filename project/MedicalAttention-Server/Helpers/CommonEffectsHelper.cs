using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;

namespace MedicalAttentionServer.Helpers;

public static class CommonEffectsHelper
{
    /// <summary>
    /// Apply a hydration penalty (negative value).
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
    /// Apply an energy penalty or bonus.
    /// </summary>
    public static void ApplyEnergyEffect(
        TemplateItem item,
        int value)
    {
        item.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
        {
            Value = value
        };
    }

    /// <summary>
    /// Apply pain suppression for a given duration.
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
