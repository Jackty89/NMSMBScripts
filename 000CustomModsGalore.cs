//=============================================================================
// Author: Jackty89
//=============================================================================

public class CustomModsGalore : cmk.NMS.Script.ModClass
{
	public int MinProcModLimit = 1;
	public int RecipeCostPriceMultiplier = 1;

	readonly string CostTypeNanite = "NANITES";
	readonly string ShipRootTech = "SHIPJUMP1";
	readonly string SuitRootTech = "ENERGY";
	readonly string WeaponRootTech = "LASER";
	readonly string ExoRootTech = "VEHICLE_ENGINE";
	//readonly string FreighterRootTech = "FRIGATE_FUEL_1";
	//readonly string FactoryTreeTech = "PRODFUEL2";
	readonly string[] Classes = { "C", "B", "A", "S" };

	readonly QualityEnum[] QualityEnums = {
		QualityEnum.Normal,
		QualityEnum.Rare,
		QualityEnum.Epic,
		QualityEnum.Legendary
	};

	readonly Tuple <LanguageId , string, string>[] CustomLangNameStrings = new Tuple<LanguageId, string, string>[]
	{
		//Place Holder name strings
		new (LanguageId.English, "CL_WEAP_NAME", "Custom weapon module"),
		new (LanguageId.English, "CL_JET_NAME", "Custom jetpack module"),
		new (LanguageId.English, "CL_SHIP_NAME", "Custom ship module"),
		new (LanguageId.English, "CL_SHIELD_NAME", "Custom shield module"),
		//Custom names
		new (LanguageId.English, "CL_MECHBOOST_NAME", "Procedural Mech Boost Module"),
		new (LanguageId.English, "CL_AIRJET_NAME", "Procedural Jetpack Module"),
		new (LanguageId.English, "CL_WATJET_NAME", "Procedural Dive Jetpack Module"),
		new (LanguageId.English, "CL_COLD_NAME", "Procedural Cold Protection Module"),
		new (LanguageId.English, "CL_HEAT_NAME", "Procedural Heat Protection Module"),
		new (LanguageId.English, "CL_TOXIC_NAME", "Procedural Toxic Protection Module"),
		new (LanguageId.English, "CL_RAD_NAME", "Procedural Radiation Protection Module"),
		new (LanguageId.English, "CL_SHIPROT_NAME", "Procedural Suit Shield Module"),
		new (LanguageId.English, "CL_SHOT_NAME", "Procedural Scatter-blaster Module"),
		new (LanguageId.English, "CL_FLAME_NAME", "Procedural Flamer Module"),
		new (LanguageId.English, "CL_ROCKPROC_NAME", "Procedural Rocket Module"),
		new (LanguageId.English, "CL_ENERGY_NAME", "Procedural Hazard Module"),
		new (LanguageId.English, "CL_DRIFT_NAME", "Procedural Drift Wheels"),

		new (LanguageId.English, "CL_FATSGUN_NAME", "Ship Laser Amplifier"),
		new (LanguageId.English, "CL_ROCK_TECH1", "Large Missle Tubes"),
		new (LanguageId.English, "CL_ROCK_TECH2", "Missile Cooling vents"),
		new (LanguageId.English, "CL_ROCK_TECH3", "High Yield Missles"),
		new (LanguageId.English, "CL_MINI_TECH1", "HE Rounds"),
		new (LanguageId.English, "CL_HYPER_NAME", "To Infinity And Beyond"),
		new (LanguageId.English, "CL_HEATLASER_NAME", "Phase Beam Coollant"),
		new (LanguageId.English, "CL_HEATGUN_NAME", "Photon Cannon space vents"),
		new (LanguageId.English, "CL_HEATSHOT_NAME", "Positron Ejector Cooling Solution"),
		new (LanguageId.English, "CL_SUPERSHOT_NAME", "Positron Ejector OverCharger"),

		new (LanguageId.English, "CL_FRIEND_NAME", "FRIENDFire BobbleHead"),
	};
	readonly Tuple<LanguageId, string, string>[] CustomLangDescStrings = new Tuple<LanguageId, string, string>[]
	{
		new (LanguageId.English, "CL_WEAP_DESC", "A Procedural custom weapon module"),
		new (LanguageId.English, "CL_JET_DESC", "A Procedural custom Jetpack module"),
		new (LanguageId.English, "CL_SHIELD_DESC", "A Procedural custom shield module"),
		new (LanguageId.English, "CL_SHIP_DESC", "A Procedural custom ship module"),

		new (LanguageId.English, "CL_MECHBOOST_DESC", "Procedural Mech Boost Module" +
			"\nThese will make you wonder, were the clouds always that close?" +
			"\nThe modules improve Boost tanks and Boost Speed" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_DRIFT_DESC", "Procedural Drift wheels." +
			"\nEspecially usefull when the eurobeat kicks in. Just be aware of windy planets, your exocraft may or may not... get picked up" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_AIRJET_DESC", "Procedural Jetpack Module" +
			"\nThis modules will enhance your ability to soar the skies, by enhancing Ignition, Refill rate as well as your tanks total capacity" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_WATJET_DESC", "Procedural Jetpack Module" +
			"\nThis modules will enhance your ability to dive at impecable speeds, by enhancing Ignition, Refill rate as well as your tanks total capacity" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_SHOT_DESC", "Procedural Scatter Blaster Module" +
			"\nNot seen before these new modules bring some bouncy to the party and of course some additional damage" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_SHIPROT_DESC", "Procedural shield Module" +
			"This technological masterpiece will ad armour and health beyond what has seen before" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_FLAME_DESC", "Procedural Flamer Module\nThese modules has the possibiliy of increase certain elements for your flamer." +
			"\nIt can potentially increase the Amount of fire, Rate of fire add DOT effect and increase DOT duration." +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_ROCKPROC_DESC", "Procedural rocket Module\nThese modules has the possibiliy of increase certain elements for you shiprockets." +
			"\nIt can potentially increase Damage, Radius, Number of Rockets, Decrease Cooldown and lastely Increase Despersion." +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_ENERGY_DESC", "Procedural hazard Module." +
			"\nThese modules will drastically increase your Suit Energy and Suit Energy Regen." +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_PRCOLD_DESC", "Procedural Cold Protection" +
			"\nProtection against freezing cold. These modules will drastically improve your survibility and shut the damn suit to recharge your technology" +
			"\nThe modules bring Reduced Cold Drain, Reduced damage against the Cold and Increase your Cold Resistance. The cold never bothered me anyway." +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_PRHEAT_DESC", "Procedural Heat Protection" +
			"\nProtection against scortching heat. These modules will drastically improve your survibility and shut the damn suit to recharge your technology" +
			"\nThe modules bring Reduced Heat Drain, Reduced damage against the Heat and Increase your Heat Resistance. I guess drilling to the core of the planet is now possible" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_PRTOXIC_DESC", "Procedural Toxic Protection" +
			"\nProtection against toxic toxins. These modules will drastically improve your survibility and shut the damn suit to recharge your technology" +
			"\nThe modules bring Reduced Toxic Drain, Reduced damage against the Toxins and Increase your Toxicity Resistance. No spiderman for you" +
			"\nThis technology was manufactured by H.G. Corp"),
		new (LanguageId.English, "CL_PRRAD_DESC", "Procedural Radiation Protection" +
			"\nProtection against radioactive radiations. These modules will drastically improve your survibility and shut the damn suit to recharge your technology" +
			"\nThe modules bring Reduced Radition Drain, Reduced damage against Raditaions and Increase your Radiation Resistance. Take that Fallout." +
			"\nThis technology was manufactured by H.G. Corp"),

		new (LanguageId.English, "CL_ROCK_DESC1", "These rocket pods hold more rockets, this might affect accuracry"),
		new (LanguageId.English, "CL_ROCK_DESC2", "Cooling vents to missile tubes. Improves fire rate cooldown and more"),
		new (LanguageId.English, "CL_ROCK_DESC3", "Increases blast radius. As a wise woman once said, and I quote \'EXPLOSION\'" +
			"\nJust make sure to not be caught by it"),
		new (LanguageId.English, "CL_MINI_DESC1", "Blast rounds. When the brrrt needs more oompf"),
		new (LanguageId.English, "CL_HYPER_DESC", "This hyperdrive will let you shoot for the stars,..." +
			"\nJust make sure you don't crash into them"),
		new (LanguageId.English, "CL_FATSGUN_DESC", "If you ever thought, hey why are the laser projectiles so small, think no futher"),
		new (LanguageId.English, "CL_HEATLASER_DESC", "Cools down your Phase Bean should now last quite a bit longer"),
		new (LanguageId.English, "CL_HEATGUN_DESC", "Will keep your Photon Cannon from overheating"),
		new (LanguageId.English, "CL_HEATSHOT_DESC", "Cools down Positron Ejector, should in theory offer you more shots"),
		new (LanguageId.English, "CL_SUPERSHOT_DESC", "Positron Ejector OverCharger modules will let you you turn up a certain song\n" +
			"Queue: Rip and Tear, Warning might be addictive")
	};

	protected class CustomTemplate
	{
		public string TemplateBaseID;
		public string TemplateID;
		public string RequiredTech;
		public string IconFileName;
		public string Group;
		public StatsTypeEnum StatsType;
	}
	List<CustomTemplate> CustomTemplates = new List<CustomTemplate>()
	{
		new CustomTemplate{
			TemplateBaseID = "T_SHIPGUN",
			TemplateID = "TC_SHIPROCKETS",
			RequiredTech = "SHIPROCKETS",
			IconFileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.ROCKETMOD.DDS",
			Group = "SHIP_ROCKETS_NAME_L",
			StatsType = StatsTypeEnum.Ship_Weapons_Rockets
		},
		new CustomTemplate{
			TemplateBaseID = "T_BOLT",
			TemplateID = "TC_FLAME",
			RequiredTech = "FLAME",
			IconFileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.FLAMETHROWER.DDS",
			Group = "FLAMETHROW_NAME_L",
			StatsType = StatsTypeEnum.Weapon_Flame
		},
		new CustomTemplate{
			TemplateBaseID = "T_HAZ",
			TemplateID = "TC_HAZ",
			RequiredTech = "",
			IconFileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTGENERICMOD.DDS",
			Group = "UI_HAZARD_NAME_CORE_L",
			StatsType = StatsTypeEnum.Suit_Protection
		}
	};
	//====================================================================
	protected class CustomUpgradeTech
	{
		public string BaseTechID;
		public string NewTechID;
		public string RequiredTech;
		public string Name;
		public string Description;
		public int FragmentCost;
		public TechnologyRarityEnum TechnologyRarity;
		public GcTechnologyCategory.TechnologyCategoryEnum TechnologyCategory;
		public string FileName;
		public List<GcStatsBonus> StatBonuses;
		public List<GcTechnologyRequirement> Requirements;

	}
	List<CustomUpgradeTech> CustomTechnology = new List<CustomUpgradeTech>(){
		new CustomUpgradeTech{
			BaseTechID = "UT_ROCKETS", //from what tech we will we copy as base
			NewTechID = "UT_ROCKETS_MISS",
			RequiredTech = "SHIPROCKETS", 
			Name = "CL_ROCK_TECH1",
			Description = "CL_ROCK_DESC2",
			FragmentCost = 400,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.ROCKET.DDS",
			StatBonuses = new List<GcStatsBonus>() {
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_BulletsPerShot, 3, 2),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Dispersion, 7, 1),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("RED2", 100),
				TechnologyRequirement.Product("GRENFUEL1", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_ROCKETS",
			NewTechID = "UT_ROCKETS_COOL",
			RequiredTech = "SHIPROCKETS",
			Name = "CL_ROCK_TECH2",
			Description = "CL_ROCK_DESC2",
			FragmentCost = 600,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.ROCKET.DDS",
			StatBonuses = new List<GcStatsBonus>() {
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_HeatTime, 1.5f, 3),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_CoolTime, 1.3f, 3),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Rate, 1.25f, 3)
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("GREEN2", 100),
				TechnologyRequirement.Product("GRENFUEL1", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_ROCKETS",
			NewTechID = "UT_ROCKETS_BLAS",
			RequiredTech = "SHIPROCKETS", 
			Name = "CL_ROCK_TECH3", 
			Description = "CL_ROCK_DESC3", 
			FragmentCost = 800,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.ROCKET.DDS",
			StatBonuses = new List<GcStatsBonus>() {
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Damage_Radius, 5, 4)
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("BLUE2", 100),
				TechnologyRequirement.Product("GRENFUEL1", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_SHIPMINI",
			NewTechID = "UT_INFRA_BLAS",
			RequiredTech = "SHIPMINIGUN", 
			Name = "CL_MINI_TECH1", 
			Description = "CL_MINI_DESC1", 
			FragmentCost = 500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PHOTONACCELMOD.DDS",
			StatBonuses = new List<GcStatsBonus>() 
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Damage_Radius, 10, 3)
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("BLUE2", 100),
				TechnologyRequirement.Product("GRENFUEL1", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_QUICKWARP",
			NewTechID = "UT_HYPER_BEYOND",
			RequiredTech = "HYPERDRIVE",
			Name = "CL_HYPER_NAME",
			Description = "CL_HYPER_DESC",
			FragmentCost = 25000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.HYPERDRIVEMOD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Hyperdrive_JumpDistance, 100000, 4)
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("BLUE2", 100),
				TechnologyRequirement.Product("HYPERFUEL2", 100)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_SHIPGUN",
			NewTechID = "UT_FATSGUN",
			RequiredTech = "SHIPGUN1",
			Name = "CL_FATSGUN_NAME",
			Description = "CL_FATSGUN_DESC",
			FragmentCost = 500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.SHIPPROJECTILE1MOD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Scale, 2.5f, 4),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Damage_Radius, 2.5f, 4)
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("BLUE2", 100),
				TechnologyRequirement.Product("JELLY", 100)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_SHIPGUN",
			NewTechID = "UT_HEAT_SGUN",
			RequiredTech = "SHIPGUN1",
			Name = "CL_HEATGUN_NAME",
			Description = "CL_HEATGUN_DESC",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.SHIPBLOB.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_HeatTime, 0.8f, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Product("COMPOUND3", 10),
				TechnologyRequirement.Product("COMPOUND6", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_SHIPLAS",
			NewTechID = "UT_HEAT_SLASER",
			RequiredTech = "SHIPLASER",
			Name = "CL_HEATLASER_NAME",
			Description = "CL_HEATLASER_DESC",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.SOULLASER.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Lasers_HeatTime, 0.8f, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Product("COMPOUND3", 10),
				TechnologyRequirement.Product("COMPOUND6", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_SHIPSHOT",
			NewTechID = "UT_HEAT_SHOT",
			RequiredTech = "SHIPSHOTGUN",
			Name = "CL_HEATSHOT_NAME",
			Description = "CL_HEATSHOT_DESC",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PHOTONBLASTMOD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_HeatTime, 0.8f, 4),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_CoolTime, 0.8f, 4)
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Product("COMPOUND3", 10),
				TechnologyRequirement.Product("COMPOUND6", 10)
			}
		},
		new CustomUpgradeTech{
			BaseTechID = "UT_SHIPSHOT",
			NewTechID = "UT_SUPER_SHOT",
			RequiredTech = "SHIPSHOTGUN",
			Name = "CL_SUPERSHOT_NAME",
			Description = "CL_SUPERSHOT_DESC",
			FragmentCost = 25000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.AllShipsExceptAlien,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PHOTONBLASTMOD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_BulletsPerShot, 50, 4),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Range, 10, 4),
				StatsBonus.Create(StatsTypeEnum.Ship_Weapons_Guns_Dispersion, 1.5f, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("TECH_COMP", 5),
				TechnologyRequirement.Substance("BLUE2", 500),
				TechnologyRequirement.Product("COMPOUND4", 10)
			}
		},
	};
	//====================================================================
	protected class CustomProcMod
	{
		public string BaseTechID; //from what tech we will we copy as base
		public string BaseDeploy;
		public bool StaticDeloy;
		public string NewTechID;
		public string TemplateName;
		public int HighestClassNo;
		public int lowestClassNo;
		public int MinStats;
		public int MaxStats;
		public float MultiplierPerRank;
		public string IconFileName;
		public string Name;
		public string ProcName;
		public string Description;
		public string TradeData;
		public List<GcProceduralTechnologyStatLevel> StatBonuses;
	}
	List<CustomProcMod> CustomProceduralMods = new List<CustomProcMod>() {
		new CustomProcMod {
			BaseTechID = "U_SHIPGUN",
			BaseDeploy = "UP_SGUN",
			NewTechID = "UC_ROCKET",
			TemplateName = "TC_SHIPROCKETS",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 1,
			MaxStats = 4,
			MultiplierPerRank = 0.2f,
			IconFileName = "GRENADE.DDS",
			Name = "CL_ROCKPROC_NAME",
			ProcName = "UP_SHIPSHOT",
			Description = "CL_ROCKPROC_DESC",
			TradeData = "ShipTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Ship_Weapons_Guns_Damage, 1000, 2500, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Ship_Weapons_Guns_Damage_Radius, 0.9f, 1.1f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Ship_Weapons_Guns_BulletsPerShot, 4, 5, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Ship_Weapons_Guns_CoolTime, 0.5f, 0.8f, WeightingCurveEnum.MaxIsRare, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Ship_Weapons_Guns_Dispersion, 1.15f, 1.4f, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_BOLT",
			BaseDeploy = "UP_BOLT",
			NewTechID = "UC_FLAME",
			TemplateName = "TC_FLAME",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 1,
			MaxStats = 4,
			MultiplierPerRank = 0.2f,
			IconFileName = "HEAT.DDS",
			Name = "CL_FLAME_NAME",
			ProcName = "UP_SHOT",
			Description = "CL_FLAME_DESC",
			TradeData = "WeapTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_Projectile_BulletsPerShot, 0.5f, 0.75f, WeightingCurveEnum.MaxIsRare, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_Projectile_Damage, 1.1f, 2.5f, WeightingCurveEnum.MaxIsRare, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_Projectile_Rate, 1.25f, 1.5f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_FireDOT_DPS, 10, 15, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_FireDOT_Duration, 5, 10, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_ENERGY",
			BaseDeploy = "UP_ENGY",
			StaticDeloy = false,
			NewTechID = "UC_ENGY",
			TemplateName = "T_ENERGY",
			HighestClassNo = 3,
			lowestClassNo = 1,
			MinStats = 2,
			MaxStats = 2,
			MultiplierPerRank = 0.3f,
			IconFileName = "LIFESUPPORT.DDS",
			Name = "CL_ENERGY_NAME",
			ProcName = "UP_LIFEBOOST",
			Description = "CL_ENERGY_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Energy, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Energy_Regen, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
			}
		},
		new CustomProcMod {
			BaseTechID = "U_COLDPROT",
			BaseDeploy = "UP_COLD",
			StaticDeloy = false,
			NewTechID = "UC_COLD",
			TemplateName = "T_COLDPROT",
			HighestClassNo = 3,
			lowestClassNo = 1,
			MinStats = 3,
			MaxStats = 3,
			MultiplierPerRank = 0.3f,
			IconFileName = "COLD.DDS",
			Name = "CL_COLD_NAME",
			ProcName = "UP_COLDPROT",
			Description = "CL_PRCOLD_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_Cold, 400, 500, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_DamageReduce_Cold, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_ColdDrain, 2, 5, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_HOTPROT",
			BaseDeploy = "UP_HOT",
			StaticDeloy = false,
			NewTechID = "UC_HEAT",
			TemplateName = "T_HOTPROT",
			HighestClassNo = 3,
			lowestClassNo = 1,
			MinStats = 3,
			MaxStats = 3,
			MultiplierPerRank = 0.3f,
			IconFileName = "HEAT.DDS",
			Name = "CL_HEAT_NAME",
			ProcName = "UP_HOTPROT",
			Description = "CL_PRHEAT_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_Heat, 400, 500, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_DamageReduce_Heat, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_HeatDrain, 2, 5, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_TOX",
			BaseDeploy = "UP_TOX",
			StaticDeloy = false,
			NewTechID = "UC_TOXIC",
			TemplateName = "T_TOX",
			HighestClassNo = 3,
			lowestClassNo = 1,
			MinStats = 3,
			MaxStats = 3,
			MultiplierPerRank = 0.3f,
			IconFileName = "TOXIC.DDS",
			Name = "CL_TOXIC_NAME",
			ProcName = "UP_TOXPROT",
			Description = "CL_PRTOXIC_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_Radiation, 400, 500, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_DamageReduce_Radiation, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_RadDrain, 2, 5, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_RAD",
			BaseDeploy = "UP_RAD",
			StaticDeloy = false,
			NewTechID = "UC_RAD",
			TemplateName = "T_RAD",
			HighestClassNo = 3,
			lowestClassNo = 1,
			MinStats = 3,
			MaxStats = 3,
			MultiplierPerRank = 0.3f,
			IconFileName = "RADIOACTIVE.DDS",
			Name = "CL_RAD_NAME",
			ProcName = "UP_RADPROT",
			Description = "CL_PRRAD_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_Toxic, 400, 500, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_DamageReduce_Toxic, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_ToxDrain, 2, 5, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_SHIELDBOOST",
			BaseDeploy = "UP_SHLD",
			StaticDeloy = false,
			NewTechID = "UC_SHLD",
			TemplateName = "T_SHIELD",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 2,
			MaxStats = 2,
			MultiplierPerRank = 0.25f,
			IconFileName = "HEALTH.DDS",
			Name = "CL_SHIPROT_NAME",
			ProcName = "UP_SHIELDBOOST",
			Description = "CL_SHIPROT_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Armour_Shield_Strength, 0.5f, 1, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Armour_Health, 50, 50, WeightingCurveEnum.MaxIsUncommon, true),
			}
		},
		new CustomProcMod {
			BaseTechID = "U_SHOTGUN",
			BaseDeploy = "UP_SHOT",
			StaticDeloy = false,
			NewTechID = "UC_SHOT",
			TemplateName = "T_SHOTGUN",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 1,
			MaxStats = 3,
			MultiplierPerRank = 0.2f,
			IconFileName = "SHOTGUN.DDS",
			Name = "CL_SHOT_NAME",
			ProcName = "UP_SHOT",
			Description = "CL_SHOT_DESC",
			TradeData = "WeapTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_Projectile_BulletsPerShot, 0.5f, 0.75f, WeightingCurveEnum.MaxIsRare, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_Projectile_Damage, 8, 10, WeightingCurveEnum.MaxIsRare, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Weapon_Projectile_Bounce, 5, 10, WeightingCurveEnum.MaxIsUncommon, true)
			}
		},
		new CustomProcMod {
			BaseTechID = "U_JETBOOST",
			BaseDeploy = "UP_JET",
			StaticDeloy = false,
			NewTechID = "UC_JET",
			TemplateName = "T_JET",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 2,
			MaxStats = 4,
			MultiplierPerRank = 0.25f,
			IconFileName = "JETPACK.DDS",
			Name = "CL_AIRJET_NAME",
			ProcName = "UP_JETBOOST",
			Description = "CL_AIRJET_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Jetpack_Refill, 1.75f, 3f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Jetpack_Tank, 5, 10, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Jetpack_Ignition, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
			}
		},
		new CustomProcMod {
			BaseTechID = "U_JETBOOST",
			BaseDeploy = "UP_JET",
			StaticDeloy = false,
			NewTechID = "UC_WJET",
			TemplateName = "T_JET",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 1,
			MaxStats = 2,
			MultiplierPerRank = 0.25f,
			IconFileName = "JETPACK.DDS",
			Name = "CL_WATJET_NAME",
			ProcName = "UP_WATERJET",
			Description = "CL_WATJET_DESC",
			TradeData = "SuitTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Jetpack_WaterEfficiency, 5, 25, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Suit_Protection_WaterDrain, 1.5f, 2.5f, WeightingCurveEnum.MaxIsUncommon, true),
			}
		},
		new CustomProcMod {
			BaseTechID = "U_EXOBOOST",
			BaseDeploy = "UP_BOOST",
			StaticDeloy = false,
			NewTechID = "UC_DRIFT",
			TemplateName = "T_BOOST",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 1,
			MaxStats = 3,
			MultiplierPerRank = 0.25f,
			IconFileName = "VEHICLEBOOST.DDS",
			Name = "CL_DRIFT_NAME",
			ProcName = "UP_JETBOOST",
			Description = "CL_DRIFT_DESC",
			TradeData = "VehicleTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Vehicle_SkidGrip, -0.05f, -0.1f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Vehicle_BoostTanks, 0.6f, 0.7f, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Vehicle_BoostSpeed, 0.75f, 0.95f, WeightingCurveEnum.MaxIsUncommon, true),
			}
		},
		new CustomProcMod {
			BaseTechID = "U_EXOBOOST",
			BaseDeploy = "UP_BOOST",
			StaticDeloy = false,
			NewTechID = "UC_EXOB",
			TemplateName = "T_BOOST",
			HighestClassNo = 4,
			lowestClassNo = 1,
			MinStats = 1,
			MaxStats = 3,
			MultiplierPerRank = 0.25f,
			IconFileName = "VEHICLEBOOST.DDS",
			Name = "CL_MECHBOOST_NAME",
			ProcName = "UP_JETBOOST",
			Description = "CL_MECHBOOST_DESC",
			TradeData = "VehicleTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Vehicle_BoostTanks, 2.5f, 5, WeightingCurveEnum.MaxIsUncommon, true),
				ProceduralTechnologyStatLevel.Create(StatsTypeEnum.Vehicle_BoostSpeed, 1, 2, WeightingCurveEnum.MaxIsUncommon, true)
			}
		}
	};
	//====================================================================
	protected class TreeExpansion
	{
		public GcUnlockableItemTreeGroups.UnlockableItemTreeEnum Tree;
		public string RootTech;
		public string CostType;
	}
	//====================================================================
	protected class CraftableUpgradeMod
	{
		public string UpgradeBase;
		public int HighestClassNo;
		public int LowestClassNo;
	}
	List<CraftableUpgradeMod> ShipMods = new List<CraftableUpgradeMod>() {
		new CraftableUpgradeMod { UpgradeBase = "UC_ROCKET", HighestClassNo = 4, LowestClassNo = 1 },
	};
	List<CraftableUpgradeMod> WeaponMods = new List<CraftableUpgradeMod>() {
		new CraftableUpgradeMod { UpgradeBase = "UC_FLAME", HighestClassNo = 4, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_SHOT", HighestClassNo = 4, LowestClassNo = 1 }
	};
	List<CraftableUpgradeMod> SuitMods = new List<CraftableUpgradeMod>() {
		new CraftableUpgradeMod { UpgradeBase = "UC_ENGY", HighestClassNo = 3, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_COLD", HighestClassNo = 3, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_HEAT", HighestClassNo = 3, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_TOXIC", HighestClassNo = 3, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_RAD", HighestClassNo = 3, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_SHLD", HighestClassNo = 4, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_JET", HighestClassNo = 4, LowestClassNo = 1 }

	};
	List<CraftableUpgradeMod> VehicleMods = new List<CraftableUpgradeMod>() {
		new CraftableUpgradeMod { UpgradeBase = "UC_DRIFT", HighestClassNo = 4, LowestClassNo = 1 },
		new CraftableUpgradeMod { UpgradeBase = "UC_EXOB", HighestClassNo = 4, LowestClassNo = 1 }
	};
	//====================================================================
	protected class RequirementPerClass
	{
		public GcTechnologyRequirement[] Materials = new GcTechnologyRequirement[3];
		public int Price;
	}

	readonly GcInventoryType Product = new GcInventoryType { InventoryType = InventoryTypeEnum.Product };
	readonly GcInventoryType Substance = new GcInventoryType { InventoryType = InventoryTypeEnum.Substance };

	protected RequirementPerClass[] Requirements;

	//====================================================================
	protected class Data
	{
		public TreeExpansion Tree;
		public List<List<CraftableUpgradeMod>> Mods;
	}
	//====================================================================
	protected override void Execute()
	{
		TreeExpansion ShipTreeExpansion = new TreeExpansion { Tree = UnlockableItemTreeEnum.ShipTech, CostType = CostTypeNanite, RootTech = ShipRootTech };
		TreeExpansion WeaponTreeExpansion = new TreeExpansion { Tree = UnlockableItemTreeEnum.WeapTech, CostType = CostTypeNanite, RootTech = WeaponRootTech };
		TreeExpansion ExoCraftTreeExpansion = new TreeExpansion { Tree = UnlockableItemTreeEnum.ExocraftTech, CostType = CostTypeNanite, RootTech = ExoRootTech };
		TreeExpansion SuitTreeExpansion = new TreeExpansion { Tree = UnlockableItemTreeEnum.SuitTech, CostType = CostTypeNanite, RootTech = SuitRootTech };

		FillRequirementsArray();

		Data[] AllModData = new[] {
			new Data { Tree = ShipTreeExpansion, Mods = new(){ ShipMods }},
			new Data { Tree = WeaponTreeExpansion, Mods = new(){ WeaponMods }},
			new Data { Tree = SuitTreeExpansion, Mods = new(){ SuitMods }},
			new Data { Tree = ExoCraftTreeExpansion, Mods = new(){ VehicleMods }},
		};
		CreateCustomTempates();
		CreateCustomTech();
		CreateCustomProceduralMods();
		GcUnlockableTrees();
		EditExistingTech();

		foreach (var ModData in AllModData)
		{
			TreeExpansion Expansion = ModData.Tree;
			List<List<CraftableUpgradeMod>> ListOfMods = ModData.Mods;
			foreach (var Mods in ListOfMods)
			{
				SetCraftabletoTrueAndAddRequirements(Mods);
				AddUnlockableTrees(Mods, Expansion);
			}
		}

		foreach (var LanguageData in CustomLangNameStrings)
		{
			LanguageId language = LanguageData.Item1;
			string languageID = LanguageData.Item2;
			string languageIDL = languageID + "_L"; 
			string languageString = LanguageData.Item3;
			string languageStringU = languageString.ToUpper();

			AddLanguageStrings(language, languageIDL, languageString);
			AddLanguageStrings(language, languageID, languageStringU);
		}

		foreach (var LanguageData in CustomLangDescStrings)
		{
			LanguageId language = LanguageData.Item1;
			string languageID = LanguageData.Item2;
			string languageString = LanguageData.Item3;

			AddLanguageStrings(language, languageID, languageString);
		}
	}

	protected void FillRequirementsArray()
	{
		Requirements = new []{
			//C-Class
			new RequirementPerClass{
				Materials = new [] {
					new GcTechnologyRequirement { ID = "EX_YELLOW", Type = Substance, Amount = 100},
					new GcTechnologyRequirement { ID = "TECH_COMP", Type = Product, Amount = 1 },
					new GcTechnologyRequirement { ID = "STELLAR2", Type = Substance, Amount = 500}
				},
				Price = 1000 * RecipeCostPriceMultiplier
			},
			//B-Class
			new RequirementPerClass{
				Materials = new [] {
					new GcTechnologyRequirement { ID = "EX_RED", Type = Substance, Amount = 200},
					new GcTechnologyRequirement { ID = "TECH_COMP", Type = Product, Amount = 2},
					new GcTechnologyRequirement { ID = "STELLAR2", Type = Substance, Amount = 500}
				},
				Price = 2500 * RecipeCostPriceMultiplier
			},
			//A-Class
			new RequirementPerClass{
				Materials = new [] {
					new GcTechnologyRequirement { ID = "EX_GREEN", Type = Substance, Amount = 300},
					new GcTechnologyRequirement { ID = "TECH_COMP", Type = Product, Amount = 3},
					new GcTechnologyRequirement { ID = "STELLAR2", Type = Substance, Amount = 500}
				},
				Price = 5000 * RecipeCostPriceMultiplier
			},
			//S-Class
			new RequirementPerClass{
				Materials = new [] {
					new GcTechnologyRequirement { ID = "EX_BLUE", Type = Substance, Amount = 500},
					new GcTechnologyRequirement { ID = "TECH_COMP", Type = Product, Amount = 5},
					new GcTechnologyRequirement { ID = "STELLAR2", Type = Substance, Amount = 500}
				},
				Price = 10000 * RecipeCostPriceMultiplier
			},
			//X-Class
			new RequirementPerClass{
				Materials = new [] {
					new GcTechnologyRequirement { ID = "EX_RED", Type = Substance, Amount = 300},
					new GcTechnologyRequirement { ID = "EX_BLUE", Type = Substance, Amount = 300},
					new GcTechnologyRequirement { ID = "TECH_COMP", Type = Product, Amount = 5}
				},
				Price = 5000 * RecipeCostPriceMultiplier
			}
		};
	}

	// This will add extra statbonus/re
	protected void EditExistingTech() 
	{
		var techMbin = ExtractMbin<GcTechnologyTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCTECHNOLOGYTABLE.MBIN");
		var shipRockets = techMbin.Table.Find(TECH => TECH.ID == "SHIPROCKETS");

		shipRockets.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Ship_Weapons_Guns_CoolTime).Bonus = 1;
		shipRockets.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Ship_Weapons_Guns_HeatTime).Bonus = 1;
		shipRockets.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Ship_Weapons_Guns_Dispersion).Bonus = 1;
		shipRockets.StatBonuses.Add(new() {
			Stat = new GcStatsTypes{ StatsType = StatsTypeEnum.Ship_Weapons_Guns_BulletsPerShot },
			Bonus = 1, 
			Level = 1
		});
 
		var addBounce = new GcStatsBonus { Stat = new GcStatsTypes { StatsType = StatsTypeEnum.Weapon_Projectile_Bounce }, Bonus = 2, Level = 3 };
		var moreProjectiles = new GcStatsBonus { Stat = new GcStatsTypes { StatsType = StatsTypeEnum.Weapon_Projectile }, Bonus = 1, Level = 1 };
		var addDot = new GcStatsBonus { Stat = new GcStatsTypes { StatsType = StatsTypeEnum.Weapon_FireDOT }, Bonus = 50, Level = 1 };
		var addDotDuratiom = new GcStatsBonus { Stat = new GcStatsTypes { StatsType = StatsTypeEnum.Weapon_FireDOT_Duration }, Bonus = 10, Level = 1 };
		var addDotDPS = new GcStatsBonus { Stat = new GcStatsTypes { StatsType = StatsTypeEnum.Weapon_FireDOT_DPS }, Bonus = 50, Level = 3 };

		var flame = techMbin.Table.Find(TECH => TECH.ID == "FLAME");
		flame.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Weapon_Projectile_Dispersion).Bonus = 15;
		flame.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Weapon_Projectile_Range).Bonus = 250;
		flame.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Weapon_Projectile_BulletsPerShot).Bonus = 5;
		flame.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Weapon_Projectile_Damage).Bonus = 100;
		flame.StatBonuses.Find(STAT => STAT.Stat.StatsType == StatsTypeEnum.Weapon_Projectile_Rate).Bonus = 12;

		flame.StatBonuses.Add(addBounce);
		flame.StatBonuses.Add(moreProjectiles);
		flame.StatBonuses.Add(addDot);
		flame.StatBonuses.Add(addDotDPS);
		flame.StatBonuses.Add(addDotDuratiom);

	}

	protected void CreateCustomTempates()
	{
		var techMbin = ExtractMbin<GcTechnologyTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCTECHNOLOGYTABLE.MBIN");

		foreach (var customTemplate in CustomTemplates)
		{
			var template = CloneMbin(techMbin.Table.Find(TECH => TECH.ID == customTemplate.TemplateBaseID));
			template.ID = customTemplate.TemplateID;
			template.Group = customTemplate.Group;
			template.RequiredTech = customTemplate.RequiredTech;
			template.Icon.Filename = customTemplate.IconFileName;
			template.BaseStat.StatsType = customTemplate.StatsType;
			techMbin.Table.Add(template);
		}
	}
	protected void CreateCustomTech()
	{
		var mbin = ExtractMbin<GcTechnologyTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCTECHNOLOGYTABLE.MBIN");

		foreach (var customTech in CustomTechnology)
		{
			var tech = CloneMbin(mbin.Table.Find(TECH => TECH.ID == customTech.BaseTechID)); // clone Large Rocket Tubes
			tech.ID = customTech.NewTechID;
 
			tech.Name = customTech.Name;
			tech.NameLower = customTech.Name +"_L";
 
			tech.Description = customTech.Description;
			tech.RequiredTech = customTech.RequiredTech;
			tech.Rarity.TechnologyRarity = customTech.TechnologyRarity;
			tech.TechShopRarity.TechnologyRarity = customTech.TechnologyRarity;
			tech.FragmentCost = customTech.FragmentCost;
			tech.Category.TechnologyCategory = customTech.TechnologyCategory;
			tech.Icon.Filename = customTech.FileName;
 
			tech.Requirements.Clear();
			foreach (var requirement in customTech.Requirements)
			{
				tech.Requirements.Add(requirement);
			}

			tech.StatBonuses.Clear();
			foreach (var statBonus in customTech.StatBonuses)
			{
				tech.StatBonuses.Add(statBonus);
			}
			mbin.Table.Add(tech);
		}
	}
	//DONE
	protected void CreateCustomProceduralMods()
	{
		var Prod_mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN");
		var Proc_mbin = ExtractMbin<GcProceduralTechnologyTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPROCEDURALTECHNOLOGYTABLE.MBIN");
		var Reality_mbin = ExtractMbin<GcRealityManagerData>("METADATA/REALITY/DEFAULTREALITY.MBIN");

		foreach (CustomProcMod Mod in CustomProceduralMods)
		{
			string baseTechName = Mod.BaseTechID;
			string baseDeployString = Mod.BaseDeploy;
			bool staticDeploy = Mod.StaticDeloy;
			string newTechName = Mod.NewTechID;
			string newTechDeployName = Mod.NewTechID.Replace("UC_", "UPC_"); ;
			string newTemplate = Mod.TemplateName;
			int newMinStats = Mod.MinStats;
			int newMaxStats = Mod.MaxStats;
			float newMultiplierPerRank = Mod.MultiplierPerRank;
			string newIconFileName = Mod.IconFileName;
			string newName = Mod.Name;
			string newNameL = Mod.Name + "_L";
			string newDescription = Mod.Description;
			string newTradeData = Mod.TradeData;
			string newProcgenName = Mod.ProcName;
			List<GcProceduralTechnologyStatLevel> newStatBonuses = Mod.StatBonuses;

			int highestClassNo = Mod.HighestClassNo;
			int lowestClassNo = Mod.lowestClassNo;

			if( lowestClassNo != MinProcModLimit )
				lowestClassNo = MinProcModLimit;
			if( lowestClassNo > highestClassNo )
				lowestClassNo = highestClassNo;

			var field = Reality_mbin.TradeSettings.GetType().GetField(newTradeData);
			GcTradeData addTradePorduct = field.GetValue(Reality_mbin.TradeSettings) as GcTradeData;

			for (int i = lowestClassNo; i <= highestClassNo; i++)
			{ 
				string copyTech = baseTechName + i.ToString();
				string copyDeployTech = baseDeployString;
				if( !staticDeploy )
					copyDeployTech = baseDeployString + i.ToString();

				string newTechID = newTechName + i.ToString();
				string newTechDeployID = newTechDeployName.Replace("UPC_", "UPC_" + Classes[i-1]).ToUpper() + "_" + Classes[i-1];
				float multiplier = 1 + (newMultiplierPerRank * (i - 1));

				if (newMinStats < newMaxStats)
					newMinStats++;
 
				// Log.AddInformation($"Print copyDeployTech = {copyDeployTech}");
				var proc = CloneMbin(Proc_mbin.Table.Find(PROC => PROC.ID == copyDeployTech));
				proc.ID = newTechDeployID;
				proc.Name = newProcgenName;
				proc.NameLower = newNameL;
				proc.Description = newDescription;
				proc.Template = newTemplate;
				proc.NumStatsMin = newMinStats;
				proc.NumStatsMax = newMinStats;
				if( staticDeploy )
					proc.Quality = QualityEnums[i-1];

				proc.StatLevels.Clear();
				foreach (var statLevel in newStatBonuses)
				{
					statLevel.ValueMin *= multiplier;
					statLevel.ValueMax *= multiplier;
					proc.StatLevels.Add(statLevel);
				}
				Proc_mbin.Table.Add(proc);

				// Create custum products for the tech
				// Log.AddInformation($"Print copyTech = {copyTech}");

				var prod = CloneMbin(Prod_mbin.Table.Find(PROD => PROD.ID == copyTech));

				prod.ID = newTechID;
				prod.Name = newName;
				prod.NameLower = newNameL;
				prod.Description = newDescription;
				//0........................................................58 
				//TEXTURES/UI/FRONTEND/ICONS/U4PRODUCTS/PROCTECH/PROCTECH.B. LASER.DDS
				var iconFilePath = prod.Icon.Filename.Value.Substring(0, 58);
				prod.Icon.Filename = iconFilePath + newIconFileName;
				prod.DeploysInto = newTechDeployID;
				Prod_mbin.Table.Add(prod);
 
				addTradePorduct.OptionalProducts.AddUnique(newTechID);
			}
		}
	}
	protected void GcUnlockableTrees()
	{
		var mbin = ExtractMbin<GcUnlockableTrees>("METADATA/REALITY/TABLES/UNLOCKABLEITEMTREES.MBIN");
		var shipTree = mbin.Trees[(int)GcUnlockableItemTreeGroups.UnlockableItemTreeEnum.ShipTech];
		var weapTree = mbin.Trees[(int)UnlockableItemTreeEnum.WeapTech];

		var ship_guns = shipTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "SHIPGUN1");
		var ship_hyper_drive = shipTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "HYPERDRIVE");

		var weap_bolt = weapTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "BOLT");
		var weap_grenade = weap_bolt.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "GRENADE");

		var ship_rocket = ship_guns.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "SHIPROCKETS");
		ship_rocket.Children.Add(new GcUnlockableItemTreeNode
		{
			Unlockable = "UT_ROCKETS_MISS",
			Children = new() 
			{ 
				new GcUnlockableItemTreeNode 
				{ 
					Unlockable = "UT_ROCKETS_COOL",
					Children = new()
					{
						new GcUnlockableItemTreeNode
						{
							Unlockable = "UT_ROCKETS_BLAS",
							Children = new()
						}
					}
				} 
			}
		});

		var up_shipgun = ship_guns.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_SHIPGUN");
		up_shipgun.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_FATSGUN",
			Children = new() 
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_HEAT_SGUN",
					Children = new()
				}
			}
		});
		var ship_laser = ship_guns.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "SHIPLAS1");
		var up_laser = ship_laser.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_SHIPLAS");
		up_laser.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_HEAT_SLASER",
			Children = new()
		});

		var ship_shotgun = ship_guns.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "SHIPSHOTGUN");
		var up_ship_shotgun = ship_shotgun.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_SHIPSHOT");		
		up_ship_shotgun.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_HEAT_SHOT",
			Children = new()
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_SUPER_SHOT",
					Children = new()
				}
			}
		});

		var ship_infra = ship_guns.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "SHIPMINIGUN");
		ship_infra.Children.Add(new GcUnlockableItemTreeNode
		{
			Unlockable = "UT_INFRA_BLAS",
			Children = new()
		});

		var quick_warp = ship_hyper_drive.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_QUICKWARP");
		quick_warp.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_HYPER_BEYOND",
			Children = new()
		});

		weapTree.Trees[0].Root.Children.Insert(0, new GcUnlockableItemTreeNode
		{
			Unlockable = "FLAME",
			Children = new()
		});
	}
	protected void SetCraftabletoTrueAndAddRequirements(List<CraftableUpgradeMod> Mods)
	{
		var prod_mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN");

		foreach (var Mod in Mods)
		{
			string productBase = Mod.UpgradeBase;
			int highestClassNo = Mod.HighestClassNo;
			int lowestClassNo = Mod.LowestClassNo;

			if( lowestClassNo != MinProcModLimit )
				lowestClassNo = MinProcModLimit;
			if( lowestClassNo > highestClassNo )
				lowestClassNo = highestClassNo;

			if (Mod.HighestClassNo == 0)
			{
				var prod = prod_mbin.Table.Find(PROD => PROD.ID == productBase);
				RequirementPerClass classRequirement = Requirements[4];

				prod.IsCraftable = true;
				prod.Requirements.Clear();
				prod.Requirements.Add(classRequirement.Materials[0]);
				prod.Requirements.Add(classRequirement.Materials[1]);
				prod.Requirements.Add(classRequirement.Materials[2]);
				prod.RecipeCost = classRequirement.Price;
			}
			else
			{
				for (int i = lowestClassNo; i <= highestClassNo; i++)
				{
					string product = productBase + i.ToString();
					RequirementPerClass classRequirement = Requirements[i - 1];

					if( highestClassNo != 4 )
						classRequirement = Requirements[i];

					var prod = prod_mbin.Table.Find(PROD => PROD.ID == product);
					prod.IsCraftable = true;
					prod.Requirements.Clear();
					prod.Requirements.Add(classRequirement.Materials[0]);
					prod.Requirements.Add(classRequirement.Materials[1]);
					prod.Requirements.Add(classRequirement.Materials[2]);
					prod.RecipeCost = classRequirement.Price;
				}
			}
		}
	}
	protected void AddUnlockableTrees(List<CraftableUpgradeMod> Mods, TreeExpansion Expansion)
	{
		var Mbin = ExtractMbin<GcUnlockableTrees>("METADATA/REALITY/TABLES/UNLOCKABLEITEMTREES.MBIN");
		UnlockableItemTreeEnum ExTree = Expansion.Tree;
		string RootTech = Expansion.RootTech;
		string CostType = Expansion.CostType;

		var Tree = Mbin.Trees[(int)ExTree];
		string Title = Tree.Title;

		GcUnlockableItemTreeNode Root = new GcUnlockableItemTreeNode { Unlockable = RootTech, Children = new() };
		GcUnlockableItemTree ItemTree = new GcUnlockableItemTree { Title = Title, CostTypeID = CostType, Root = Root };
		//GcUnlockableItemTreeNode Parent = Root;

		Tree.Trees.Add(ItemTree);

		foreach (var Mod in Mods)
		{
			string productBase = Mod.UpgradeBase;
			int highestClassNo = Mod.HighestClassNo;
			int lowestClassNo = Mod.LowestClassNo;
 
			if (lowestClassNo != MinProcModLimit)
				lowestClassNo = MinProcModLimit;
			if( lowestClassNo > highestClassNo )
				lowestClassNo = highestClassNo;

			Root.Children.Add(CreateChildNode(productBase, lowestClassNo, highestClassNo));
		}
	}
	private GcUnlockableItemTreeNode CreateChildNode(string ProductBase, int CurrentNo, int HighestClassNo)
	{
		string Product = ProductBase + CurrentNo.ToString();
		GcUnlockableItemTreeNode Child = new GcUnlockableItemTreeNode
		{
			Unlockable = Product,
			Children = new()
		};

		if (CurrentNo != HighestClassNo)
		{
			Child.Children.Add(CreateChildNode(ProductBase, CurrentNo + 1, HighestClassNo));
		}

		return Child;
	}

	protected void AddLanguageStrings(LanguageId Language, string LanugageID, string LanugageString)
	{
		SetLanguageText(Language, LanugageID, LanugageString); 
	}
}
