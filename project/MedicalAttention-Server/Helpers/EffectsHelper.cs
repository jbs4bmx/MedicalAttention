using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;

namespace MedicalAttentionServer.Helpers;

public static class EffectsHelper
{
    // Damage Effects
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

    public static void ApplyLightBleedFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpPenaltyMin,
        int hpPenaltyMax)
    {
        item.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpPenaltyMin,
            HealthPenaltyMax = hpPenaltyMax
        };
    }

    public static void ApplyHeavyBleedFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpPenaltyMin,
        int hpPenaltyMax)
    {
        item.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpPenaltyMin,
            HealthPenaltyMax = hpPenaltyMax
        };
    }

    public static void ApplyFractureFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpPenaltyMin,
        int hpPenaltyMax)
    {
        item.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpPenaltyMin,
            HealthPenaltyMax = hpPenaltyMax
        };
    }

    public static void ApplyDestroyedPartFix(
        TemplateItem item,
        int duration,
        int cost,
        int hpPenaltyMin,
        int hpPenaltyMax)
    {
        item.Properties!.EffectsDamage![DamageEffectType.DestroyedPart] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpPenaltyMin,
            HealthPenaltyMax = hpPenaltyMax
        };
    }


    // Health Effects
    public static void ApplyEnergyBonus(
        TemplateItem item,
        int value)
    {
        item.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
        {
            Value = value
        };
    }

    public static void ApplyHydrationPenalty(
        TemplateItem item,
        int value)
    {
        item.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
        {
            Value = value
        };
    }

    public static void ApplyEnergyEffect(
        TemplateItem item,
        int value)
    {
        item.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
        {
            Value = value
        };
    }
}