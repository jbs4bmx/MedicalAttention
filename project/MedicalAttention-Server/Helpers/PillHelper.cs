using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;

namespace MedicalAttentionServer.Helpers;

public static class PillHelper
{
    /// <summary>
    /// Apply the common pill settings shared by Analgin, Augmentin, Ibuprofen.
    /// </summary>
    public static void ApplyBasePillSettings(
        TemplateItem item,
        dynamic configSection)
    {
        item.Properties!.MaxHpResource = configSection.hpResource;
        item.Properties!.MedUseTime = 1;
    }

    /// <summary>
    /// Apply the standard hydration penalty (usually -2).
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
    /// Apply the standard energy bonus (usually +15).
    /// </summary>
    public static void ApplyEnergyBonus(
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
