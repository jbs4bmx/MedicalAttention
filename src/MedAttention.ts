/**
 *      Name: Medical Attention
 *   Version: 351.0.1
 * Copyright: jbs4bmx
 *    Update: [DMY] 07.03.2023
*/

import { DependencyContainer } from "tsyringe";
import { IMod } from "@spt-aki/models/external/mod";
import { ILogger } from "@spt-aki/models/spt/utils/ILogger";
import { DatabaseServer } from "@spt-aki/servers/DatabaseServer"


"use strict";

class healer implements IMod
{
	private pkg;

	public postDBLoad(container: DependencyContainer): void
	{
        const {AI2,CAR,SALEWA,IFAK,SANITAR,AFAK,GRIZZLY,PILLS,BANDAGES,SPLINTS,TOPICALS,SURGICALKITS,TOURNIQUETS,INJECTORS} = require('./config.json');
		const logger = container.resolve<ILogger>("WinstonLogger");
        const db = container.resolve<DatabaseServer>("DatabaseServer").getTables().templates.items;
		this.pkg = require("../package.json");

		let locationsMin = [
			"laboratory",
			"Interchange",
			"ReservBase"
		]
		let locationsMax = [
			"laboratory",
			"Interchange",
			"Shoreline",
			"ReservBase",
			"factory4_day",
			"factory4_night",
			"bigmap",
			"Woods"
		];

		for (let item in db)
		{
			let medItem = db[item];

			/** ============================== AI2 ======================================= */
			if (AI2.Enable === true) {
				//AI-2 Medkit
				if (medItem._id === "5755356824597772cb798962")
				{
					medItem._props.MaxHpResource = AI2.hpResource
					medItem._props.medUseTime = 1;
					medItem._props.hpResourceRate = AI2.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== CAR ======================================= */
			if (CAR.Enable === true) {
				//Car First Aid Kit
				if (medItem._id === "590c661e86f7741e566b646a")
				{
					medItem._props.MaxHpResource = CAR.hpResource;
					medItem._props.medUseTime = 3;
					medItem._props.hpResourceRate = CAR.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 50,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 75,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== SALEWA ==================================== */
			if (SALEWA.Enable === true) {
				//Salewa
				if (medItem._id === "544fb45d4bdc2dee738b4568")
				{
					medItem._props.MaxHpResource = SALEWA.hpResource;
					medItem._props.medUseTime = 3;
					medItem._props.hpResourceRate = SALEWA.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 50,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 75,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== IFAK ====================================== */
			if (IFAK.Enable === true) {
				//IFAK
				if (medItem._id === "590c678286f77426c9660122")
				{
					medItem._props.MaxHpResource = IFAK.hpResource;
					medItem._props.medUseTime = 1;
					medItem._props.hpResourceRate = IFAK.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 50,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					if (IFAK.fixFracture === true) {
						medItem._props.effects_damage.Fracture =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					if (IFAK.fixDestroyedPart === true) {
						medItem._props.effects_damage.DestroyedPart =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 75,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== SANITAR =================================== */
			if (SANITAR.Enable === true) {
				//Sanitar Medkit (IFAK)
				if (medItem._id === "5e99711486f7744bfc4af328")
				{
					medItem._props.Width = 1;
					medItem._props.Height = 1;
					medItem._props.MaxHpResource = SANITAR.hpResource;
					medItem._props.medUseTime = 1;
					medItem._props.hpResourceRate = SANITAR.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 50,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					if (SANITAR.fixFracture === true) {
						medItem._props.effects_damage.Fracture =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					if (SANITAR.fixDestroyedPart === true) {
						medItem._props.effects_damage.DestroyedPart =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 75,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== AFAK ====================================== */
			if (AFAK.Enable === true) {
				//AFAK
				if (medItem._id === "60098ad7c2240c0fe85c570a")
				{
					medItem._props.MaxHpResource = AFAK.hpResource;
					medItem._props.medUseTime = 1;
					medItem._props.hpResourceRate = AFAK.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 50,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					if (AFAK.fixFracture === true) {
						medItem._props.effects_damage.Fracture =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					if (AFAK.fixDestroyedPart === true) {
						medItem._props.effects_damage.DestroyedPart =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 25,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== GRIZZLY =================================== */
			if (GRIZZLY.Enable === true) {
				//Grizzly
				if (medItem._id === "590c657e86f77412b013051d")
				{
					medItem._props.MaxHpResource = GRIZZLY.hpResource;
					medItem._props.medUseTime = 5;
					medItem._props.hpResourceRate = GRIZZLY.hpResourceRate;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 30,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 50,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					if (GRIZZLY.fixFracture === true) {
						medItem._props.effects_damage.Fracture =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					if (GRIZZLY.fixDestroyedPart === true) {
						medItem._props.effects_damage.DestroyedPart =
						{
							"delay": 0,
							"duration": 0,
							"fadeOut": 0,
							"healthPenaltyMin": 100,
							"healthPenaltyMax": 100
						}
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 75,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== PILLS ===================================== */
			if(PILLS.Enable === true) {
				//Analgin Painkillers
				if (medItem._id === "544fb37f4bdc2dee738b4567")
				{
					medItem._props.MaxHpResource = PILLS.hpResource;
					medItem._props.medUseTime = 2;
					medItem._props.effects_health.Hydration =
					{
						"value": PILLS.HydrationBurn
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": PILLS.Duration,
						"fadeOut": 10
					};
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": PILLS.Duration,
						"fadeOut": 10
					};
				}

				//Augmentin Antibiotic Pills
				if (medItem._id === "590c695186f7741e566b64a2")
				{
					medItem._props.MaxHpResource = PILLS.hpResource;
					medItem._props.medUseTime = 5;
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": PILLS.Duration,
						"fadeOut": 10
					};
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": PILLS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_health.Energy =
					{
						"value": 15
					};
					medItem._props.effects_health.Hydration =
					{
						"value": PILLS.HydrationBurn
					};
					medItem._props.effects_damage.Intoxication =
					{
						"duration": 0,
						"fadeOut": 0
					};
				}

				//Ibuprofen Pills
				if (medItem._id === "5af0548586f7743a532b7e99")
				{
					medItem._props.MaxHpResource = PILLS.hpResource;
					medItem._props.effects_health.Hydration =
					{
						"value": PILLS.HydrationBurn
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": PILLS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": PILLS.Duration,
						"fadeOut": 5
					};
				}
			}

			/** ============================== BANDAGES ================================== */
			if (BANDAGES.Enable === true) {
				//Aseptic Bandage
				if (medItem._id === "544fb25a4bdc2dfb738b4567")
				{
					medItem._props.MaxHpResource = BANDAGES.hpResource;
					medItem._props.medUseTime = 2;
					medItem._props.hpResourceRate = 1;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}

				//Army Bandage
				if (medItem._id === "5751a25924597722c463c472")
				{
					medItem._props.MaxHpResource = BANDAGES.hpResource;
					medItem._props.medUseTime = 3;
					medItem._props.hpResourceRate = 1;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== SPLINTS =================================== */
			if (SPLINTS.Enable === true) {
				//Splint
				if (medItem._id === "544fb3364bdc2d34748b456a")
				{
					medItem._props.MaxHpResource = SPLINTS.hpResource;
					medItem._props.medUseTime = 1;
					medItem._props.effects_damage.Fracture =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
				}

				//Aluminum Splint
				if (medItem._id === "5af0454c86f7746bf20992e8")
				{
					medItem._props.MaxHpResource = SPLINTS.hpResource;
					medItem._props.medUseTime = 1;
					medItem._props.effects_damage.Fracture =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
				}
			}

			/** ============================== TOPICALS ================================== */
			if (TOPICALS.Enable === true) {
							//Vaseline
				if (medItem._id === "5755383e24597772cb798966")
				{
					medItem._props.MaxHpResource = TOPICALS.hpResource;
					medItem._props.medUseTime = 2;
					medItem._props.effects_health.Energy =
					{
						"value": 0
					};
					medItem._props.effects_health.Hydration =
					{
						"value": 0
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": TOPICALS.Duration,
						"fadeOut": 10
					};
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": TOPICALS.Duration,
						"fadeOut": 10
					};
				}

				//Golden Star Balm
				if (medItem._id === "5751a89d24597722aa0e8db0")
				{
					medItem._props.MaxHpResource = TOPICALS.hpResource;
					medItem._props.effects_health.Energy =
					{
						"value": 0
					};
					medItem._props.effects_health.Hydration =
					{
						"value": 0
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": TOPICALS.Duration,
						"fadeOut": 10
					};
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": TOPICALS.Duration,
						"fadeOut": 10
					};
				}
			}

			/** ============================== SURGICALKITS ============================== */
			if (SURGICALKITS.Enable === true) {
				//CMS Kit
				if (medItem._id === "5d02778e86f774203e7dedbe")
				{
					medItem._props.MaxHpResource = SURGICALKITS.hpResource;
					medItem._props.medUseTime = 8;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Fracture =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.DestroyedPart =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}

				//Sanitar Medical Surgical Kit
				if (medItem._id === "5e99735686f7744bfc4af32c")
				{
					medItem._props.Width = 1;
					medItem._props.Height = 1;
					medItem._props.MaxHpResource = SURGICALKITS.hpResource;
					medItem._props.medUseTime = 8;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Fracture =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.DestroyedPart =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}

				//Surv12 Field Surgical Kit
				if (medItem._id === "5d02797c86f774203f38e30a")
				{
					medItem._props.MaxHpResource = SURGICALKITS.hpResource;
					medItem._props.medUseTime = 12;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Fracture =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.DestroyedPart =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.RadExposure =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0,
						"cost": 1,
						"healthPenaltyMin": 100,
						"healthPenaltyMax": 100
					};
				}
			}

			/** ============================== TOURNIQUETS =============================== */
			if (TOURNIQUETS.Enable === true) {
				//Esmarch Tourniquet
				if (medItem._id === "5e831507ea0a7c419c2f9bd9")
				{
					medItem._props.MaxHpResource = TOURNIQUETS.hpResource;
					medItem._props.medUseTime = 3;
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
				}

				//Calok-B Hemostatic
				if (medItem._id === "5e8488fa988a8701445df1e4")
				{
					medItem._props.MaxHpResource = TOURNIQUETS.hpResource;
					medItem._props.medUseTime = 2;
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
				}

				//Hemostatic Tourniquet CAT
				if (medItem._id === "60098af40accd37ef2175f27")
				{
					medItem._props.MaxHpResource = TOURNIQUETS.hpResource;
					medItem._props.medUseTime = 2;
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": 0,
						"fadeOut": 0
					};
				}
			}

			/** ============================== INJECTORS ================================= */
			if (INJECTORS.Enable === true) {
				//Morphine Injector
				if (medItem._id === "544fb3f34bdc2d03748b456a")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.effects_health.Hydration =
					{
						"value": INJECTORS.HydrationBurn
					};
					medItem._props.effects_health.Energy =
					{
						"value": INJECTORS.EnergyBurn
					};
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 3
					};
				}

				//Combat Stimulant Injector SJ1 TGLabs
				if (medItem._id === "5c0e531286f7747fa54205c2")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
				}

				//Regenerative Stimulant Injector eTG-change
				if (medItem._id === "5c0e534186f7747fa1419867")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 0
					};
				}

				//Combat Stimulant Injector SJ6 TGLabs
				if (medItem._id === "5c0e531d86f7747fa23f4d42")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
				}

				//Combat Stimulant Injector SJ9 TGLabs
				if (medItem._id === "5fca13ca637ee0341a484f46")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
				}

				//Propital
				if (medItem._id === "5c0e530286f7747fa1419862")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 0
					};
				}

				//Hemostatic Drug Zagustin
				if (medItem._id === "5c0e533786f7747fa23f4d47")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
					medItem._props.effects_damage.LightBleeding =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_damage.HeavyBleeding =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
				}

				//Adrenaline Injector
				if (medItem._id === "5c10c8fd86f7743d7d706df3")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 0
					};
				}

				//Meldonin
				if (medItem._id === "5ed5160a87bb8443d10680b5")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
				}

				//AHF1-M
				if (medItem._id === "5ed515f6915ec335206e4152")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
				}

				//3-(b-TG)
				if (medItem._id === "5ed515c8d380ab312177c0fa")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
				}

				//L1 (Norepinephrine)
				if (medItem._id === "5ed515e03a40a50460332579")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
				}

				//P22
				if (medItem._id === "5ed515ece452db0eb56fc028")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
				}

				//Cocktail "Oldolbos"
				if (medItem._id === "5ed5166ad380ab312177c100")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
				}

				//M.U.L.E. stimulator
				if (medItem._id === "5ed51652f6c34d2cc26336a1")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMax;
				}

				//Antidote xTG-12
				if (medItem._id === "5fca138c2a7b221b2852a5c6")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
				}

				// Obdolbos 2
				if (medItem._id === "637b60c3b7afa97bfc3d7001")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
				}

				// SJ12 TGLabs
				if (medItem._id === "637b612fb7afa97bfc3d7005")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
				}

				// Perfotoran (Blue Blood)
				if (medItem._id === "637b6251104668754b72f8f9")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 0
					};
				}

				// Trimadol
				if (medItem._id === "637b620db7afa97bfc3d7009")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
					medItem._props.effects_damage.Pain =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 5
					};
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 0
					};
				}

				//PNB
				if (medItem._id === "637b6179104668754b72f8f5")
				{
					medItem._props.MaxHpResource = INJECTORS.hpResource;
					medItem._props.AllowSpawnOnLocations = locationsMin;
					medItem._props.effects_damage.Pain =
					medItem._props.effects_damage.Contusion =
					{
						"delay": 0,
						"duration": INJECTORS.Duration,
						"fadeOut": 0
					};
				}

			}
		}

		logger.info(`${this.pkg.author}-${this.pkg.name} v${this.pkg.version}: Cached Successfully`);
	}

}

module.exports = { mod: new healer() }