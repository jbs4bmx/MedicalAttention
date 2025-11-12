using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Eft.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Path = System.IO.Path;

namespace MedicalAttention_Server;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.jbs4bmx.medicalattention";
    public override string Name { get; init; } = "MedicalAttention";
    public override string Author { get; init; } = "jbs4bmx";
    public override List<string>? Contributors { get; init; }
    public override SemanticVersioning.Version Version { get; init; } = new("4.0.1");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
    public override string License { get; init; } = "MIT";
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class MedServer(
    ISptLogger<MedServer> logger,
    DatabaseService databaseService,
    ConfigServer configServer,
    ItemHelper itemHelper,
    ModHelper modHelper) : IOnLoad
{
    public Task OnLoad()
    {
        var pathToMod = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());
        var medConfig = modHelper.GetJsonDataFromFile<ModConfig>(pathToMod, "config.jsonc");
        var helper = itemHelper;
        var itemConfig = configServer.GetConfig<ItemConfig>();
        var tables = databaseService.GetTables();
        var items = databaseService.GetItems();

        List<string> locationsMin = new List<string> {
            "laboratory",
            "Interchange",
            "ReservBase",
            "TarkovStreets",
            "Sandbox"
        };

        List<string> locationsMax = new List<string> {
            "laboratory",
            "Interchange",
            "Shoreline",
            "ReservBase",
            "factory4_day",
            "factory4_night",
            "bigmap",
            "Woods",
            "TarkovStreets",
            "Sandbox"
        };

        List<string> injectorList = new List<string> {
            "544fb3f34bdc2d03748b456a",
            "5c0e530286f7747fa1419862",
            "5c0e531286f7747fa54205c2",
            "5c0e531d86f7747fa23f4d42",
            "5c0e533786f7747fa23f4d47",
            "5c0e534186f7747fa1419867",
            "5c10c8fd86f7743d7d706df3",
            "5ed515c8d380ab312177c0fa",
            "5ed515e03a40a50460332579",
            "5ed515ece452db0eb56fc028",
            "5ed515f6915ec335206e4152",
            "5ed5160a87bb8443d10680b5",
            "5ed51652f6c34d2cc26336a1",
            "5ed5166ad380ab312177c100",
            "5fca138c2a7b221b2852a5c6",
            "5fca13ca637ee0341a484f46",
            "637b60c3b7afa97bfc3d7001",
            "637b612fb7afa97bfc3d7005",
            "637b6179104668754b72f8f5",
            "637b620db7afa97bfc3d7009",
            "637b6251104668754b72f8f9",
            "66507eabf5ddb0818b085b68",
            "648c1a965043c4052a4f8505"
        };

        List<string> parentList = new List<string> {
            "5448f3a14bdc2d27728b4569",
            "5448f3a64bdc2d60728b456a"
        };

        // ~~ MEDKITS ~~
        if (medConfig.Ai2!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_AI2) is TemplateItem aiItem)
        {
            logger.Info("Updating AI-2 Medkit properties...");
            aiItem.Properties!.MaxHpResource = medConfig.Ai2!.hpResource;
            aiItem.Properties!.MedUseTime = 1;
            aiItem.Properties!.HpResourceRate = medConfig.Ai2!.hpResourceRate;
            if (medConfig.Ai2!.AddStopLightBleeding == true)
            {
                aiItem.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Ai2!.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Ai2!.AddStopHeavyBleeding == true)
            {
                aiItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Ai2!.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Ai2!.HealOverTime == true)
            {
                this.PushBuff("Ai2Buff");
                aiItem.Properties!.StimulatorBuffs = "Ai2Buff";
            }
        }


        if (medConfig.Car!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_CAR_FIRST_AID_KIT) is TemplateItem carItem)
        {
            logger.Info("Updating CAR Medkit properties...");
            carItem.Properties!.MaxHpResource = medConfig.Car!.hpResource;
            carItem.Properties!.MedUseTime = 1;
            carItem.Properties!.HpResourceRate = medConfig.Car!.hpResourceRate;
            if (medConfig.Car!.AddStopHeavyBleeding == true)
            {
                carItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Car!.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Car!.HealOverTime == true)
            {
                this.PushBuff("CarBuff");
                carItem.Properties!.StimulatorBuffs = "CarBuff";
            }
        }

        if (medConfig.Salewa!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_SALEWA_FIRST_AID_KIT) is TemplateItem salewaItem)
        {
            logger.Info("Updating Salewa Medkit properties...");
            salewaItem.Properties!.MaxHpResource = medConfig.Salewa!.hpResource;
            salewaItem.Properties!.MedUseTime = 1;
            salewaItem.Properties!.HpResourceRate = medConfig.Salewa!.hpResourceRate;
            if (medConfig.Salewa!.AddFixFracture == true)
            {
                salewaItem.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Salewa?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Salewa!.AddFixBlackedLimb == true)
            {
                salewaItem.Properties!.EffectsDamage![DamageEffectType.DestroyedPart] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Salewa?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Salewa!.HealOverTime == true)
            {
                this.PushBuff("SalewaBuff");
                salewaItem.Properties!.StimulatorBuffs = "SalewaBuff";
            }
        }

        if (medConfig.Ifak!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_IFAK_INDIVIDUAL_FIRST_AID_KIT) is TemplateItem ifakItem)
        {
            logger.Info("Updating IFAK Medkit properties...");
            ifakItem.Properties!.MaxHpResource = medConfig.Ifak!.hpResource;
            ifakItem.Properties!.MedUseTime = 1;
            ifakItem.Properties!.HpResourceRate = medConfig.Ifak!.hpResourceRate;
            if (medConfig.Ifak!.AddFixFracture == true)
            {
                ifakItem.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Ifak?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Ifak!.AddFixBlackedLimb == true)
            {
                ifakItem.Properties!.EffectsDamage![DamageEffectType.DestroyedPart] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Ifak?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Ifak!.HealOverTime == true)
            {
                this.PushBuff("IfakBuff");
                ifakItem.Properties!.StimulatorBuffs = "IfakBuff";
            }
        }

        if (medConfig.Sanitar!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_SANITARS_FIRST_AID_KIT) is TemplateItem sanitarItem)
        {
            logger.Info("Updating Sanitar Medkit properties...");
            sanitarItem.Properties!.MaxHpResource = medConfig.Sanitar!.hpResource;
            sanitarItem.Properties!.MedUseTime = 1;
            sanitarItem.Properties!.HpResourceRate = medConfig.Sanitar!.hpResourceRate;
            helper.ResizeItem(sanitarItem, itemConfig, "1x1");
            if (medConfig.Sanitar!.AddStopLightBleeding == true)
            {
                sanitarItem.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Sanitar!.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Sanitar!.AddStopHeavyBleeding == true)
            {
                sanitarItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Sanitar?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Sanitar!.AddFixFracture == true)
            {
                sanitarItem.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Sanitar?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Sanitar!.HealOverTime == true)
            {
                this.PushBuff("SanitarBuff");
                sanitarItem.Properties!.StimulatorBuffs = "SanitarBuff";
            }
        }

        if (medConfig.Afak!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_AFAK_TACTICAL_INDIVIDUAL_FIRST_AID_KIT) is TemplateItem afakItem)
        {
            logger.Info("Updating AFAK Medkit properties...");
            afakItem.Properties!.MaxHpResource = medConfig.Afak!.hpResource;
            afakItem.Properties!.MedUseTime = 1;
            afakItem.Properties!.HpResourceRate = medConfig.Afak!.hpResourceRate;
            if (medConfig.Afak!.AddFixFracture == true)
            {
                afakItem.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Afak?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Afak!.AddFixBlackedLimb == true)
            {
                afakItem.Properties!.EffectsDamage![DamageEffectType.DestroyedPart] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Afak?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Afak!.HealOverTime == true)
            {
                this.PushBuff("AfakBuff");
                afakItem.Properties!.StimulatorBuffs = "AfakBuff";
            }
        }

        if (medConfig.Grizzly!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDKIT_GRIZZLY_MEDICAL_KIT) is TemplateItem grizzlyItem)
        {
            logger.Info("Updating Grizzly Medkit properties...");
            grizzlyItem.Properties!.MaxHpResource = medConfig.Grizzly!.hpResource;
            grizzlyItem.Properties!.MedUseTime = 1;
            grizzlyItem.Properties!.HpResourceRate = medConfig.Grizzly!.hpResourceRate;
            if (medConfig.Grizzly!.AddFixBlackedLimb == true)
            {
                grizzlyItem.Properties!.EffectsDamage![DamageEffectType.DestroyedPart] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = medConfig.Grizzly?.Duration,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Grizzly!.HealOverTime == true)
            {
                this.PushBuff("GrizzlyBuff");
                grizzlyItem.Properties!.StimulatorBuffs = "GrizzlyBuff";
            }
        }

        // ~~ PILLS ~~
        if (medConfig.Analgin!.Enable == true && items.GetValueOrDefault(ItemTpl.DRUGS_ANALGIN_PAINKILLERS) is TemplateItem analginItem)
        {
            logger.Info("Updating Analgin Pill properties...");
            analginItem.Properties!.MaxHpResource = medConfig.Analgin!.hpResource;
            analginItem.Properties!.MedUseTime = 1;
            if (medConfig.Analgin!.AddEnergyIncrease == true)
            {
                analginItem.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
                {
                    Value = 15
                };
            }
            analginItem.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
            {
                Value = -2
            };
            if (medConfig.Analgin!.AddRadExposureFix == true)
            {
                analginItem.Properties!.EffectsDamage![DamageEffectType.RadExposure] = new EffectsDamageProperties
                {
                    Cost = 30,
                    Delay = 0,
                    Duration = 0,
                    FadeOut = 0,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        if (medConfig.Augmentin!.Enable == true && items.GetValueOrDefault(ItemTpl.DRUGS_AUGMENTIN_ANTIBIOTIC_PILLS) is TemplateItem augmentinItem)
        {
            logger.Info("Updating Augmentin Pill properties...");
            augmentinItem.Properties!.MaxHpResource = medConfig.Augmentin!.hpResource;
            augmentinItem.Properties!.MedUseTime = 1;
            augmentinItem.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
            {
                Value = 15
            };
            augmentinItem.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
            {
                Value = -2
            };
            if (medConfig.Augmentin!.AddRadExposureFix == true)
            {
                augmentinItem.Properties!.EffectsDamage![DamageEffectType.RadExposure] = new EffectsDamageProperties
                {
                    Cost = 30,
                    Delay = 0,
                    Duration = 0,
                    FadeOut = 0,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        if (medConfig.Ibuprofen!.Enable == true && items.GetValueOrDefault(ItemTpl.DRUGS_IBUPROFEN_PAINKILLERS) is TemplateItem ibuprofenItem)
        {
            logger.Info("Updating Ibuprofen Pill properties...");
            ibuprofenItem.Properties!.MaxHpResource = medConfig.Ibuprofen!.hpResource;
            ibuprofenItem.Properties!.MedUseTime = 1;
            ibuprofenItem.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
            {
                Value = 15
            };
            ibuprofenItem.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
            {
                Value = -2
            };
            if (medConfig.Ibuprofen!.AddRadExposureFix == true)
            {
                ibuprofenItem.Properties!.EffectsDamage![DamageEffectType.RadExposure] = new EffectsDamageProperties
                {
                    Cost = 30,
                    Delay = 0,
                    Duration = 0,
                    FadeOut = 0,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        // ~~ BANDAGES ~~
        if (medConfig.Aseptic!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_ASEPTIC_BANDAGE) is TemplateItem asepticItem)
        {
            logger.Info("Updating Aseptic Bandage properties...");
            asepticItem.Properties!.MaxHpResource = medConfig.Aseptic!.hpResource;
            asepticItem.Properties!.MedUseTime = 1;
            if (medConfig.Aseptic!.AddStopHeavyBleeding == true)
            {
                asepticItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        if (medConfig.Army!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_ARMY_BANDAGE) is TemplateItem armyItem)
        {
            logger.Info("Updating Army Bandage properties...");
            armyItem.Properties!.MaxHpResource = medConfig.Army!.hpResource;
            armyItem.Properties!.MedUseTime = 1;
            if (medConfig.Army!.AddStopHeavyBleeding == true)
            {
                armyItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        // ~~ SPLINTS ~~
        if (medConfig.Splint!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_IMMOBILIZING_SPLINT) is TemplateItem splintItem)
        {
            logger.Info("Updating Splint properties...");
            splintItem.Properties!.MaxHpResource = medConfig.Splint!.hpResource;
            splintItem.Properties!.MedUseTime = 1;
        }

        if (medConfig.AluminumSplint!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_ALUMINUM_SPLINT) is TemplateItem aluminumSplintItem)
        {
            logger.Info("Updating Aluminum Splint properties...");
            aluminumSplintItem.Properties!.MaxHpResource = medConfig.AluminumSplint!.hpResource;
            aluminumSplintItem.Properties!.MedUseTime = 1;
        }

        // ~~ TOPICALS ~~
        if (medConfig.Vaseline!.Enable == true && items.GetValueOrDefault(ItemTpl.DRUGS_VASELINE_BALM) is TemplateItem vaselineItem)
        {
            logger.Info("Updating Vaseline properties...");
            vaselineItem.Properties!.MaxHpResource = medConfig.Vaseline!.hpResource;
            vaselineItem.Properties!.MedUseTime = 1;
            vaselineItem.Properties!.EffectsDamage![DamageEffectType.Pain] = new EffectsDamageProperties
            {
                Delay = 0,
                Duration = 600,
                FadeOut = 0
            };
            vaselineItem.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
            {
                Value = -2
            };
            vaselineItem.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
            {
                Value = -2
            };
            if (medConfig.Vaseline!.AddRadExposureFix == true)
            {
                vaselineItem.Properties!.EffectsDamage![DamageEffectType.RadExposure] = new EffectsDamageProperties
                {
                    Cost = 30,
                    Delay = 0,
                    Duration = 0,
                    FadeOut = 0,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        if (medConfig.GoldenStarBalm!.Enable == true && items.GetValueOrDefault(ItemTpl.DRUGS_GOLDEN_STAR_BALM) is TemplateItem goldenStarBalmItem)
        {
            logger.Info("Updating Golden Star Balm properties...");
            goldenStarBalmItem.Properties!.MaxHpResource = medConfig.GoldenStarBalm!.hpResource;
            goldenStarBalmItem.Properties!.MedUseTime = 1;
            goldenStarBalmItem.Properties!.EffectsDamage![DamageEffectType.Pain] = new EffectsDamageProperties
            {
                Delay = 0,
                Duration = 600,
                FadeOut = 0
            };
            goldenStarBalmItem.Properties!.EffectsHealth![HealthFactor.Energy] = new EffectsHealthProperties
            {
                Value = -2
            };
            goldenStarBalmItem.Properties!.EffectsHealth![HealthFactor.Hydration] = new EffectsHealthProperties
            {
                Value = -2
            };
            if (medConfig.GoldenStarBalm!.AddRadExposureFix == true)
            {
                goldenStarBalmItem.Properties!.EffectsDamage![DamageEffectType.RadExposure] = new EffectsDamageProperties
                {
                    Cost = 30,
                    Delay = 0,
                    Duration = 0,
                    FadeOut = 0,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        // ~~ SURGICAL KITS ~~
        if (medConfig.CMSSurgicalKit!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_CMS_SURGICAL_KIT) is TemplateItem cmsSurgicalKitItem)
        {
            logger.Info("Updating CMS Surgical Kit properties...");
            cmsSurgicalKitItem.Properties!.MaxHpResource = medConfig.CMSSurgicalKit!.hpResource;
            cmsSurgicalKitItem.Properties!.MedUseTime = 1;
            if (medConfig.CMSSurgicalKit!.AddStopLightBleeding == true)
            {
                cmsSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.CMSSurgicalKit!.AddStopHeavyBleeding == true)
            {
                cmsSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.CMSSurgicalKit!.AddFixFracture == true)
            {
                cmsSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        if (medConfig.SanitarSurgicalKit!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_SANITAR_KIT) is TemplateItem sanitarSurgicalKitItem)
        {
            logger.Info("Updating Sanitar Surgical Kit properties...");
            sanitarSurgicalKitItem.Properties!.MaxHpResource = medConfig.SanitarSurgicalKit!.hpResource;
            sanitarSurgicalKitItem.Properties!.MedUseTime = 1;
            helper.ResizeItem(sanitarSurgicalKitItem, itemConfig, "2x1");
            if (medConfig.SanitarSurgicalKit!.AddStopLightBleeding == true)
            {
                sanitarSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.SanitarSurgicalKit!.AddStopHeavyBleeding == true)
            {
                sanitarSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.SanitarSurgicalKit!.AddFixFracture == true)
            {
                sanitarSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.Fracture] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        if (medConfig.Surv12FieldSurgicalKit!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_SURV12_FIELD_SURGICAL_KIT) is TemplateItem surv12FieldSurgicalKitItem)
        {
            logger.Info("Updating Surv-12 Field Surgical Kit properties...");
            surv12FieldSurgicalKitItem.Properties!.MaxHpResource = medConfig.Surv12FieldSurgicalKit!.hpResource;
            surv12FieldSurgicalKitItem.Properties!.MedUseTime = 1;
            if (medConfig.Surv12FieldSurgicalKit!.AddStopLightBleeding == true)
            {
                surv12FieldSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.LightBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
            if (medConfig.Surv12FieldSurgicalKit!.AddStopHeavyBleeding == true)
            {
                surv12FieldSurgicalKitItem.Properties!.EffectsDamage![DamageEffectType.HeavyBleeding] = new EffectsDamageProperties
                {
                    Delay = 0,
                    Duration = 60,
                    FadeOut = 0,
                    Cost = 30,
                    HealthPenaltyMin = 0,
                    HealthPenaltyMax = 0
                };
            }
        }

        // ~~ TOURNIQUETS ~~
        if (medConfig.Esmarch!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_ESMARCH_TOURNIQUET) is TemplateItem esmarchItem)
        {
            logger.Info("Updating Esmarch Tourniquet properties...");
            esmarchItem.Properties!.MaxHpResource = medConfig.Esmarch!.hpResource;
            esmarchItem.Properties!.MedUseTime = 1;
        }

        if (medConfig.CalokB!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_CALOKB_HEMOSTATIC_APPLICATOR) is TemplateItem calokBItem)
        {
            logger.Info("Updating Calok-B Tourniquet properties...");
            calokBItem.Properties!.MaxHpResource = medConfig.CalokB!.hpResource;
            calokBItem.Properties!.MedUseTime = 1;
        }

        if (medConfig.Cat!.Enable == true && items.GetValueOrDefault(ItemTpl.MEDICAL_CAT_HEMOSTATIC_TOURNIQUET) is TemplateItem catItem)
        {
            logger.Info("Updating CAT Tourniquet properties...");
            catItem.Properties!.MaxHpResource = medConfig.Cat.hpResource;
            catItem.Properties!.MedUseTime = 1;
        }

        // ~~ INJECTORS ~~

        //EditGlobals();

        logger.Success("Finished Editing Database!");
        return Task.CompletedTask;
    }

    private void EditGlobals()
    {
        // Let's edit settings in the GLOBALS file (database/globals.json)
        var globals = databaseService.GetGlobals();

        globals.Configuration.SavagePlayCooldown = 1;
        var ragfairSettings = globals.Configuration.RagFair;
        ragfairSettings.MinUserLevel = 1;
        foreach (var offerCountSettings in ragfairSettings.MaxActiveOfferCount)
        {
            offerCountSettings.Count = 20;
        }
    }

    private void PushBuff(string buffName)
    {
        var modPath = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());
        var buffFilePath = Path.Combine(modPath, "BuffGlobals.json");

        var buffJson = File.ReadAllText(buffFilePath);
        var buffNode = (JsonNode.Parse(buffJson)?["buffs"]?[buffName]) ??
            throw new InvalidOperationException($"Buff '{buffName}' not found in BuffGlobals.json");
        var globals = databaseService.GetGlobals();
        var stimulator = globals?.Configuration?.Health?.Effects?.Stimulator;
        var buffs = stimulator?.Buffs;

        if (buffs != null && !buffs.ContainsKey(buffName))
        {
            //var buffData = JsonSerializer.Deserialize<object>(buffNode.ToJsonString());
            //buffs.Add(buffName, (IEnumerable<SPTarkov.Server.Core.Models.Eft.Common.Buff>)buffData!);
            var buffData = JsonSerializer.Deserialize<List<Buff>>(buffNode.ToJsonString());
            buffs.Add(buffName, buffData!);
        }
    }
}

public static class ItemHelperExtensions
{
    public static void ResizeItem(this ItemHelper helper, TemplateItem item, ItemConfig itemConfig, string newSize)
    {
        if (item?.Properties == null)
            return;

        var sizeParts = newSize.Split('x');
        if (sizeParts.Length == 2 &&
            int.TryParse(sizeParts[0], out int width) &&
            int.TryParse(sizeParts[1], out int height))
        {
            var propertiesType = item.Properties.GetType();
            var widthProp = propertiesType.GetProperty("Width");
            var heightProp = propertiesType.GetProperty("Height");
            if (widthProp != null && heightProp != null)
            {
                widthProp.SetValue(item.Properties, width);
                heightProp.SetValue(item.Properties, height);
            }
        }
    }
}

public class ModConfig
{
    public ModAi2? Ai2 { get; set; }
    public ModCar? Car { get; set; }
    public ModSalewa? Salewa { get; set; }
    public ModIfak? Ifak { get; set; }
    public ModSanitar? Sanitar { get; set; }
    public ModAfak? Afak { get; set; }
    public ModGrizzly? Grizzly { get; set; }
    public ModAnalgin? Analgin { get; set; }
    public ModAugmentin? Augmentin { get; set; }
    public ModIbuprofen? Ibuprofen { get; set; }
    public ModAseptic? Aseptic { get; set; }
    public ModArmy? Army { get; set; }
    public ModSplint? Splint { get; set; }
    public ModAluminumSplint? AluminumSplint { get; set; }
    public ModVaseline? Vaseline { get; set; }
    public ModGoldenStarBalm? GoldenStarBalm { get; set; }
    public ModCMSSurgicalKit? CMSSurgicalKit { get; set; }
    public ModSanitarSurgicalKit? SanitarSurgicalKit { get; set; }
    public ModSurv12FieldSurgicalKit? Surv12FieldSurgicalKit { get; set; }
    public ModEsmarch? Esmarch { get; set; }
    public ModCalokB? CalokB { get; set; }
    public ModCat? Cat { get; set; }
    public ModMorphine? Morphine { get; set; }
    public ModSj1? Sj1 { get; set; }
    public ModeTGchange? eTGchange { get; set; }
    public ModSj6? Sj6 { get; set; }
    public ModSj9? Sj9 { get; set; }
    public ModPropital? Propital { get; set; }
    public ModZagustin? Zagustin { get; set; }
    public ModAdrenaline? Adrenaline { get; set; }
    public ModMeldonin? Meldonin { get; set; }
    public ModAhf1m? Ahf1m { get; set; }
    public ModbTG? bTG { get; set; }
    public ModNorepinephrine? Norepinephrine { get; set; }
    public Modp22? p22 { get; set; }
    public ModObdolbos? Obdolbos { get; set; }
    public ModMule? Mule { get; set; }
    public ModxTG12? xTG12 { get; set; }
    public ModObdolbos2? Obdolbos2 { get; set; }
    public ModSj12? Sj12 { get; set; }
    public ModPerfotoran? Perfotoran { get; set; }
    public ModTrimadol? Trimadol { get; set; }
    public ModPnb? Pnb { get; set; }
    public Moda2bTG? a2bTG { get; set; }
    public ModEbudal? Ebudal { get; set; }
    public ModModInjectors? ModInjectors { get; set; }
}

public class ModAi2
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddStopLightBleeding { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModCar
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModSalewa
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddFixFracture { get; set; }
    public bool AddFixBlackedLimb { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModIfak
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddFixFracture { get; set; }
    public bool AddFixBlackedLimb { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModSanitar
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddStopLightBleeding { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
    public bool AddFixFracture { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModAfak
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddFixFracture { get; set; }
    public bool AddFixBlackedLimb { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModGrizzly
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int hpResourceRate { get; set; }
    public int Duration { get; set; }
    public bool AddFixBlackedLimb { get; set; }
    public bool HealOverTime { get; set; }
    public int HealOverTimeDuration { get; set; }
}

public class ModAnalgin
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
    public bool AddEnergyIncrease { get; set; }
    public int EnergyIncrease { get; set; }
    public int HydrationBurn { get; set; }
    public bool AddRadExposureFix { get; set; }
}

public class ModAugmentin
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
    public int EnergyIncrease { get; set; }
    public int HydrationBurn { get; set; }
    public bool AddRadExposureFix { get; set; }
}

public class ModIbuprofen
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
    public bool AddEnergyIncrease { get; set; }
    public int EnergyIncrease { get; set; }
    public int HydrationBurn { get; set; }
    public bool AddRadExposureFix { get; set; }
}

public class ModAseptic
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
}

public class ModArmy
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
}

public class ModSplint
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModAluminumSplint
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModVaseline
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
    public int EnergyBurn { get; set; }
    public int HydrationBurn { get; set; }
    public bool AddRadExposureFix { get; set; }
}

public class ModGoldenStarBalm
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
    public int EnergyBurn { get; set; }
    public bool EnableHydrationBurn { get; set; }
    public int HydrationBurn { get; set; }
    public bool AddRadExposureFix { get; set; }
}

public class ModCMSSurgicalKit
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopLightBleeding { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
    public bool AddFixFracture { get; set; }
}

public class ModSanitarSurgicalKit
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopLightBleeding { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
    public bool AddFixFracture { get; set; }
}

public class ModSurv12FieldSurgicalKit
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopLightBleeding { get; set; }
    public bool AddStopHeavyBleeding { get; set; }
}

public class ModEsmarch
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopLightBleeding { get; set; }
}

public class ModCalokB
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopLightBleeding { get; set; }
}

public class ModCat
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public bool AddStopLightBleeding { get; set; }
}

public class ModMorphine
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
    public int HydrationBurn { get; set; }
    public int EnergyBurn { get; set; }
}

public class ModSj1
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModeTGchange
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModSj6
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModSj9
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModPropital
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModZagustin
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModAdrenaline
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModMeldonin
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModAhf1m
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModbTG
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModNorepinephrine
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class Modp22
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModObdolbos
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModMule
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModxTG12
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModObdolbos2
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModSj12
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModPerfotoran
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModTrimadol
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModPnb
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class Moda2bTG
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}

public class ModEbudal
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
    public int Duration { get; set; }
}

public class ModModInjectors
{
    public bool Enable { get; set; }
    public int hpResource { get; set; }
}