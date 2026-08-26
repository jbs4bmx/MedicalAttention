using MedicalAttentionServer.Helpers;
using SPTarkov.Common.Logger;
using SPTarkov.Server.Core.Helpers.Server;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Spt.Tables;
using System.Reflection;

namespace MedicalAttentionServer.Patches
{
    public static class PatchMedkits
    {
        public static void ApplyPatches(SptLogger<MedServer> logger, TemplateTable templateTable, GlobalTable globalTable, ItemConfig itemConfig, ModHelper modHelper)
        {
            var pathToMod = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var medConfig = modHelper.GetJsonDataFromFile<ModConfig>(pathToMod, "config.jsonc");
            if (medConfig is null)
            {
                logger.Warning("Medkits config not found - skipping medkit patches");
                return;
            }

            // ~~ MEDKITS ~~
            if (medConfig.Ai2!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_AI2) is TemplateItem aiItem)
            {
                logger.Info("Updating AI-2 Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(aiItem, medConfig.Ai2);

                if (medConfig.Ai2.AddStopLightBleeding == true)
                {
                    MedkitHelper.ApplyBleedFix(
                        aiItem,
                        DamageEffectType.LightBleeding,
                        medConfig.Ai2.Duration,
                        30,
                        100,
                        100);
                }

                if (medConfig.Ai2.AddStopHeavyBleeding == true)
                {
                    MedkitHelper.ApplyBleedFix(
                        aiItem,
                        DamageEffectType.HeavyBleeding,
                        medConfig.Ai2.Duration,
                        30,
                        100,
                        100);
                }

                if (medConfig.Ai2.HealOverTime == true)
                    BuffHelper.ApplyBuff(aiItem, "Ai2Buff", templateTable, globalTable);
            }

            if (medConfig.Car!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_CAR_FIRST_AID_KIT) is TemplateItem carItem)
            {
                logger.Info("Updating CAR Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(carItem, medConfig.Car);

                if (medConfig.Car.AddStopHeavyBleeding == true)
                {
                    MedkitHelper.ApplyBleedFix(
                        carItem,
                        DamageEffectType.HeavyBleeding,
                        medConfig.Car.Duration,
                        30,
                        100,
                        100);
                }

                if (medConfig.Car.HealOverTime == true)
                {
                    BuffHelper.ApplyBuff(carItem, "CarBuff", templateTable, globalTable);
                }
            }

            if (medConfig.Salewa!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_SALEWA_FIRST_AID_KIT) is TemplateItem salewaItem)
            {
                logger.Info("Updating Salewa Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(salewaItem, medConfig.Salewa);

                if (medConfig.Salewa.AddFixFracture == true)
                {
                    MedkitHelper.ApplyFractureFix(
                        salewaItem,
                        medConfig.Salewa.Duration,
                        50,
                        100,
                        100);
                }

                if (medConfig.Salewa.AddFixBlackedLimb == true)
                {
                    MedkitHelper.ApplyDestroyedPartFix(
                        salewaItem,
                        medConfig.Salewa.Duration,
                        50,
                        50,
                        75);
                }

                if (medConfig.Salewa.HealOverTime == true)
                {
                    BuffHelper.ApplyBuff(salewaItem, "SalewaBuff", templateTable, globalTable);
                }
            }

            if (medConfig.Ifak!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_IFAK_INDIVIDUAL_FIRST_AID_KIT) is TemplateItem ifakItem)
            {
                logger.Info("Updating IFAK Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(ifakItem, medConfig.Ifak);

                if (medConfig.Ifak.AddFixFracture == true)
                {
                    MedkitHelper.ApplyFractureFix(
                        ifakItem,
                        medConfig.Ifak.Duration,
                        50,
                        100,
                        100);
                }

                if (medConfig.Ifak.AddFixBlackedLimb == true)
                {
                    MedkitHelper.ApplyDestroyedPartFix(
                        ifakItem,
                        medConfig.Ifak.Duration,
                        50,
                        75,
                        100);
                }

                if (medConfig.Ifak.HealOverTime == true)
                {
                    BuffHelper.ApplyBuff(ifakItem, "IfakBuff", templateTable, globalTable);
                }
            }

            if (medConfig.Sanitar!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_SANITARS_FIRST_AID_KIT) is TemplateItem sanitarItem)
            {
                logger.Info("Updating Sanitar Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(sanitarItem, medConfig.Sanitar);
                ItemResizeHelper.ResizeItem(sanitarItem, itemConfig, "1x1");

                if (medConfig.Sanitar.AddStopLightBleeding == true)
                {
                    MedkitHelper.ApplyBleedFix(
                        sanitarItem,
                        DamageEffectType.LightBleeding,
                        medConfig.Sanitar.Duration,
                        30,
                        10,
                        50);
                }

                if (medConfig.Sanitar.AddStopHeavyBleeding == true)
                {
                    MedkitHelper.ApplyBleedFix(
                        sanitarItem,
                        DamageEffectType.HeavyBleeding,
                        medConfig.Sanitar.Duration,
                        30,
                        10,
                        50);
                }

                if (medConfig.Sanitar.AddFixFracture == true)
                {
                    MedkitHelper.ApplyFractureFix(
                        sanitarItem,
                        medConfig.Sanitar.Duration,
                        50,
                        20,
                        60);
                }

                if (medConfig.Sanitar.HealOverTime == true)
                {
                    BuffHelper.ApplyBuff(sanitarItem, "SanitarBuff", templateTable, globalTable);
                }
            }

            if (medConfig.Afak!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_AFAK_TACTICAL_INDIVIDUAL_FIRST_AID_KIT) is TemplateItem afakItem)
            {
                logger.Info("Updating AFAK Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(afakItem, medConfig.Afak);

                if (medConfig.Afak.AddFixFracture == true)
                {
                    MedkitHelper.ApplyFractureFix(
                        afakItem,
                        medConfig.Afak.Duration,
                        50,
                        100,
                        100);
                }

                if (medConfig.Afak.AddFixBlackedLimb == true)
                {
                    MedkitHelper.ApplyDestroyedPartFix(
                        afakItem,
                        medConfig.Afak.Duration,
                        50,
                        100,
                        100);
                }

                if (medConfig.Afak.HealOverTime == true)
                {
                    BuffHelper.ApplyBuff(afakItem, "AfakBuff", templateTable, globalTable);
                }
            }

            if (medConfig.Grizzly!.Enable == true && templateTable.Items.GetValueOrDefault(ItemTpl.MEDKIT_GRIZZLY_MEDICAL_KIT) is TemplateItem grizzlyItem)
            {
                logger.Info("Updating Grizzly Medkit properties...");
                MedkitHelper.ApplyBaseMedkitSettings(grizzlyItem, medConfig.Grizzly);

                if (medConfig.Grizzly.AddFixBlackedLimb == true)
                {
                    MedkitHelper.ApplyDestroyedPartFix(
                        grizzlyItem,
                        medConfig.Grizzly.Duration,
                        50,
                        80,
                        100);
                }

                if (medConfig.Grizzly.HealOverTime == true)
                {
                    BuffHelper.ApplyBuff(grizzlyItem, "GrizzlyBuff", templateTable, globalTable);
                }
            }
        }
    }
}
