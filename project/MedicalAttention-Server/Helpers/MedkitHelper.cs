using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;

namespace MedicalAttentionServer.Helpers;

public static class MedkitHelper
{
    public static void ApplyBaseMedkitSettings(
        TemplateItem item,
        dynamic configSection)
    {
        item.Properties!.MaxHpResource = configSection.hpResource;
        item.Properties!.MedUseTime = 1;
        item.Properties!.HpResourceRate = configSection.hpResourceRate;
    }

    public static void ApplyBleedFix(
        TemplateItem item,
        DamageEffectType type,
        int duration,
        int cost,
        int hpMin,
        int hpMax)
    {
        item.Properties!.EffectsDamage![type] = new EffectsDamageProperties
        {
            Delay = 0,
            Duration = duration,
            FadeOut = 0,
            Cost = cost,
            HealthPenaltyMin = hpMin,
            HealthPenaltyMax = hpMax
        };
    }

    public static void ApplyBuff(
        TemplateItem item,
        string buffId,
        Action<string> pushBuff)
    {
        pushBuff(buffId);
        item.Properties!.StimulatorBuffs = buffId;
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

}
