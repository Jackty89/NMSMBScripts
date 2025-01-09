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
	List<LanguageString> Language_String_List = new List<LanguageString> ();

	readonly QualityEnum[] QualityEnums = {
		QualityEnum.Normal,
		QualityEnum.Rare,
		QualityEnum.Epic,
		QualityEnum.Legendary
	};
	protected class LanguageString
	{
		public LanguageId Id;
		public string Language_Base;
		public string Name;
		public string Description;
		public string Subtitle;
	}
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
		public string LanguageBase;
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
			LanguageBase = "ROCK_TECH1",
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
			LanguageBase = "ROCK_TECH2",
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
			LanguageBase = "ROCK_TECH3",
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
			LanguageBase = "MINI_TECH1",
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
			LanguageBase = "HYPER_BEYOND",
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
			LanguageBase = "FATSGUN",
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
			LanguageBase = "HEATSGUN",
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
			LanguageBase = "HEATSLASER",
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
			LanguageBase = "HEATSHOT",
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
			LanguageBase = "SUPERSHOT",
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
		new CustomUpgradeTech {
			BaseTechID = "UT_COLD",
			NewTechID = "UT_COLD2",
			RequiredTech = "",
			LanguageBase = "COLDR",
			FragmentCost = 500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTCOLD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_ColdDrain, 1.5f, 2),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("COLD1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Substance("YELLOW2", 120)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_COLD",
			NewTechID = "UT_COLD3",
			RequiredTech = "",
			LanguageBase = "COLDR",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTCOLD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_ColdDrain, 2, 3),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("COLD1", 1000),
				TechnologyRequirement.Substance("ASTEROID1", 500),
				TechnologyRequirement.Substance("YELLOW2", 500)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_COLD",
			NewTechID = "UT_COLD4",
			RequiredTech = "",
			LanguageBase = "COLDR",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTCOLD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_ColdDrain, 2, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("COLD1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Product("FARMPROD4", 1)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_HOT",
			NewTechID = "UT_HEAT2",
			RequiredTech = "",
			LanguageBase = "HEATR",
			FragmentCost = 500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTHEAT.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_HeatDrain, 1.5f, 2),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("HOT1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Substance("YELLOW2", 120)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_HOT",
			NewTechID = "UT_HEAT3",
			RequiredTech = "",
			LanguageBase = "HEATR",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTHEAT.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_HeatDrain, 2, 3),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("HOT1", 1000),
				TechnologyRequirement.Substance("ASTEROID1", 500),
				TechnologyRequirement.Substance("YELLOW2", 500)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_HOT",
			NewTechID = "UT_HEAT4",
			RequiredTech = "",
			LanguageBase = "HEATR",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTHEAT.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_HeatDrain, 2, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("HOT1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Product("SALVAGE_TECH5", 1)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_TOX",
			NewTechID = "UT_TOXIC2",
			RequiredTech = "",
			LanguageBase = "TOXICR",
			FragmentCost = 500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTTOXIC.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_ToxDrain, 1.5f, 2),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("TOXIC1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Substance("YELLOW2", 120)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_TOX",
			NewTechID = "UT_TOXIC3",
			RequiredTech = "",
			LanguageBase = "TOXICR",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTTOXIC.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_ToxDrain, 2, 3),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("TOXIC1", 1000),
				TechnologyRequirement.Substance("ASTEROID1", 500),
				TechnologyRequirement.Substance("YELLOW2", 500)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_TOX",
			NewTechID = "UT_TOXIC4",
			RequiredTech = "",
			LanguageBase = "TOXICR",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTTOXIC.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_ToxDrain, 2, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("TOXIC1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Product("OXY_CRAFT", 1)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_RAD",
			NewTechID = "UT_RAD2",
			RequiredTech = "",
			LanguageBase = "RADR",
			FragmentCost = 500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTRADS.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_RadDrain, 1.5f, 2),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("RADIO1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Substance("YELLOW2", 120)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_RAD",
			NewTechID = "UT_RAD3",
			RequiredTech = "",
			LanguageBase = "RADR",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTRADS.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_RadDrain, 2, 3),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("RADIO1", 1000),
				TechnologyRequirement.Substance("ASTEROID1", 500),
				TechnologyRequirement.Substance("YELLOW2", 500)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_RAD",
			NewTechID = "UT_RAD4",
			RequiredTech = "",
			LanguageBase = "RADR",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.PROTECTRADS.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_RadDrain, 2, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("RADIO1", 300),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Product("WATER_CRAFT", 1)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_WATER",
			NewTechID = "UT_WATER3",
			RequiredTech = "",
			LanguageBase = "WATERR",
			FragmentCost = 1000,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.HELMET.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_WaterDrain, 2, 3),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("YELLOW2", 150),
				TechnologyRequirement.Substance("ASTEROID1", 120),
				TechnologyRequirement.Product("JELLY", 50)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "UT_WATER",
			NewTechID = "UT_WATER4",
			RequiredTech = "",
			LanguageBase = "WATERR",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/RENDER.HELMET.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Suit_Protection_WaterDrain, 5, 4),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Substance("ASTEROID1", 500),
				TechnologyRequirement.Product("VENTGEM", 100),
				TechnologyRequirement.Product("PRODFUEL2", 100)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "MECH_ARMY_R_ARM",
			NewTechID = "UT_EXOFLAME",
			RequiredTech = "",
			LanguageBase = "EXOFLAME",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/VEHICLE/RENDER.MECH.ARMY.RARM.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Vehicle_GunDamage, 3, 3),
				StatsBonus.Create(StatsTypeEnum.Vehicle_GunHeatTime, 0.75f, 1),
				StatsBonus.Create(StatsTypeEnum.Vehicle_GunRate, 0.08f, 1),
				StatsBonus.Create(StatsTypeEnum.Weapon_FireDOT, 1, 4),
				StatsBonus.Create(StatsTypeEnum.Weapon_FireDOT_Duration, 3, 4),
				StatsBonus.Create(StatsTypeEnum.Weapon_FireDOT_DPS, 25, 1),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("GRENFUEL1", 3),
				TechnologyRequirement.Product("FUEL2", 60),
				TechnologyRequirement.Product("TECH_COMP", 2)
			}
		},
		new CustomUpgradeTech {
			BaseTechID = "MECH_ARMY_L_ARM",
			NewTechID = "UT_EXOSTUN",
			RequiredTech = "",
			LanguageBase = "EXOSTUN",
			FragmentCost = 2500,
			TechnologyRarity = TechnologyRarityEnum.VeryRare,
			TechnologyCategory = GcTechnologyCategory.TechnologyCategoryEnum.Suit,
			FileName = "TEXTURES/UI/FRONTEND/ICONS/TECHNOLOGY/VEHICLE/RENDER.STUNDAMAGEMOD.DDS",
			StatBonuses = new List<GcStatsBonus>()
			{
				StatsBonus.Create(StatsTypeEnum.Vehicle_GunDamage, 20, 3),
				StatsBonus.Create(StatsTypeEnum.Vehicle_GunHeatTime, 0.5f, 1),
				StatsBonus.Create(StatsTypeEnum.Vehicle_GunRate, 0.5f, 1),
			},
			Requirements = new List<GcTechnologyRequirement>(){
				TechnologyRequirement.Product("POWERCELL", 2),
				TechnologyRequirement.Product("CASING", 5),
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
		public string ProcTechName;
		public string LanguageBase;
		public string LanguageBaseProcOverride;
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
			ProcTechName = "UP_SHIPGUN",
			LanguageBase = "ROCKPROC",
			LanguageBaseProcOverride = "PRROCK",
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
			ProcTechName = "UP_SHOT",
			LanguageBase = "FLAME",
			LanguageBaseProcOverride = "",
			TradeData = "WeapTechSpecialist",
			StatBonuses = new List<GcProceduralTechnologyStatLevel>() {
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
			ProcTechName = "UP_LIFEBOOST",
			LanguageBase = "ENERGY",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_COLDPROT",
			LanguageBase = "PRCOLD",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_HOTPROT",
			LanguageBase = "PRHEAT",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_TOX",
			LanguageBase = "PRTOXIC",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_RAD",
			LanguageBase = "PRRAD",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_SHIELDBOOST",
			LanguageBase = "SUITSHIELD",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_SHOT",
			LanguageBase = "SHOT",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_JETBOOST",
			LanguageBase = "AIRJET",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_JETBOOST",
			LanguageBase = "WATJET",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_JETBOOST",
			LanguageBase = "DRIFT",
			LanguageBaseProcOverride = "",
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
			ProcTechName = "UP_BOOST",
			LanguageBase = "MECHBOOST",
			LanguageBaseProcOverride = "",
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
		FillLanguageList();
		AddLanguageStrings();
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
		AddToUnlockableItemTree();
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

	}


	protected void FillLanguageList()
	{
		Language_String_List = new List<LanguageString>()
		{
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "FATSGUN",
				Name = "Ship Laser Amplifier",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will amplify your ship laser.",
				Subtitle = "Thick laser"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "ROCK_TECH1",
				Name = "Extended Rocket Tubes",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will increase the capacity on your rocket tubes.",
				Subtitle = "Extended Rocket Tubes"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "ROCK_TECH2",
				Name = "Rocket Cooling vents",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will assist in venting the heat from your rocket tubes.",
				Subtitle = "Rocket Cooling vents"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "ROCK_TECH3",
				Name = "High Yield Rockets",
				Description = @"This new technology upgrade engineered by the engineers at H.G. Corp. will amplify your the yield on your rockets.&#xA;
					&lt;SPECIAL&gt;As a wise woman once said&lt;&gt; &lt;TECHNOLOGY&gt;EXPLOSION&lt;&gt;.&#xA;
					&lt;SPECIAL&gt;Be warned that the explosion radius will affect everyone inside of it. You have been warned.&lt;&gt;",
				Subtitle = "High Yield Rockets"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "MINI_TECH1",
				Name = "HE Rounds",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. adds explosive filler to your Infraknife rounds.",
				Subtitle = "HE Rounds"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "HYPER_BEYOND",
				Name = "Overchared HyperDrive",
				Description = @"This new technology upgrade engineered by the engineers at H.G. Corp. has pushed the hyperdrive to the extreme.&#xA;
					This hyperdrive will let you shoot for the stars,...Just make sure you do not crash into them.",
				Subtitle = "To Infinity And Beyond"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "SUPERSHOT",
				Name = "Positron Ejector OverCharger",
				Description = @"This new technology upgrade engineered by the engineers at H.G. Corp. has improved various elements on your Positron Ejector.&#xA;
					Queue: Rip and Tear, Warning might be addictive.",
				Subtitle = "Positron Ejector OverCharger"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "HEATSHOT",
				Name = "Positron Ejector Cooling Solution",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will assist in venting the heat from your Positron Ejector.",
				Subtitle = "Positron Ejector Cooling Solution"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "HEATSLASER",
				Name = "Phase Beam Coollant",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will assist in venting the heat from your Phase Beam .",
				Subtitle = "Phase Beam Coollant"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "HEATSGUN",
				Name = "Photon Cannon space vents",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will assist in venting the heat from your Photon Cannon.",
				Subtitle = "Photon Cannon space vents"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "ROCKPROC",
				Name = "H.G. Corp. Procedural Rocket Launcher Module",
				Description = @"H.G. Corp. Procedural Rocket Launcher Module.&#xA;
					These modules have the possibiliy of certain metrics on your Rocket Launcher.&#xA;
					It can potentially increase Damage, Radius, Number of Rockets, Decrease Cooldown and Increase Dispersion.",
				Subtitle = "H.G. Corp. Procedural Rocket Launcher Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "FLAME",
				Name = "H.G. Corp. Procedural Incinerator Module",
				Description = @"H.G. Corp. Procedural Flamer Module.&#xA;
					These modules come with improvements to your Incinerator.&#xA;
					It can potentially increase the Amount of fire, firerate add a damage over time effect and increase damage over time duration.",
				Subtitle = "H.G. Corp. Procedural Incinerator Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "ENERGY",
				Name = "H.G. Corp. Procedural Hazard Module",
				Description = @"H.G. Corp. Procedural hazard Module.&#xA;
					These modules will drastically increase your Suit Energy and Suit Energy Regeneration.",
				Subtitle = "H.G. Corp. Procedural Hazard Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRCOLD",
				Name = "H.G. Corp. Procedural Cold Protection Module",
				Description = @"H.G. Corp. Procedural Cold Protection.&#xA;
					These modules will drastically improve your survibility in cold Biomes.&#xA;
					The modules are enhanced with Reduced Cold Drain, Reduced Cold Damage and Cold Resistance.&#xA;
					Toghether with Protection against freezing colds it will assist in reducing the wailing of your suit protection assistant.&#xA;
					The cold never bothered me anyway.",
				Subtitle = "H.G. Corp. Procedural Cold Protection Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRHEAT",
				Name = "H.G. Corp. Procedural Heat Protection Module",
				Description = @"H.G. Corp. Procedural Heat Protection.&#xA;
					These modules will drastically improve your survibility in hot Biomes.&#xA;
					The modules are enhanced with Reduced Heat Drain, Reduced Heat Damage and Heat Resistance.&#xA;
					Toghether with Protection against scortching heat it will assist in reducing the wailing of your suit protection assistant.&#xA;
					I guess drilling to the core of the planet is now possible.",
				Subtitle = "H.G. Corp. Procedural Heat Protection Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRTOXIC",
				Name = "H.G. Corp. Procedural Toxic Protection Module",
				Description = @"H.G. Corp. Procedural Toxic Protection.&#xA;
					These modules will drastically improve your survibility in Toxic Biomes.&#xA;
					The modules are enhanced with Reduced Toxic Drain, Reduced Toxic Damage and Toxic Resistance.&#xA;
					Toghether with Protection against toxic toxins it will assist in reducing the wailing of your suit protection assistant.",
				Subtitle = "H.G. Corp. Procedural Toxic Protection Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRRAD",
				Name = "H.G. Corp. Procedural Radiation Protection Module",
				Description = @"H.G. Corp. Procedural Radiation Protection.&#xA;
					These modules will drastically improve your survibility in Radioactive Biomes.&#xA;
					The modules are enhanced with Reduced Radiation Drain, Reduced Radiation Damage and Radiation Resistance.&#xA;
					Toghether with Protection against radioactive radiation it will assist in reducing the wailing of your suit protection assistant.&#xA;
					Wandering the wastelands will be a breeze for you now.",
				Subtitle = "H.G. Corp. Procedural Radiation Protection Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "SUITSHIELD",
				Name = "H.G. Corp. Procedural Suit Shield Module",
				Description = @"H.G. Corp. Procedural shield Module.&#xA;
					Suit shield module that increases armour and suit structural integrity.&#xA;
					This technological masterpiece will add armour and structural integrity to your suit to what was before thought impossible",
				Subtitle = "H.G. Corp. Procedural Suit Shield Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "SHOT",
				Name = "H.G. Corp. Procedural Scatter-blaster Module",
				Description = @"H.G. Corp. Procedural Scatter Blaster Module.&#xA;
					This Module improves the Scatter-blaster damage and also adds  redirection to the shots.&#xA;
					As never seen before these new modules bring some boune to the party and some demon slaying capabilties.",
				Subtitle = "H.G. Corp. Procedural Scatter-blaster Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "AIRJET",
				Name = "H.G. Corp. Procedural Jetpack Module",
				Description = @"H.G. Corp. Procedural Jetpack Module.&#xA;
					These modules enhances your Ignition, Refill rate as well as total capacity of the fuel tanks.&#xA;
					Your ability to soar the skies will be drastically enhanced, just do not fly to close to the sun.",
				Subtitle = "H.G. Corp. Procedural Jetpack Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "WATJET",
				Name = "H.G. Corp. Procedural Dive Jetpack Module",
				Description = @"H.G. Corp. Procedural Jetpack Module.&#xA;
					These modules enhances your Ignition, Refill rate as well as total capacity of the fuel tanks.&#xA;
					Now you can dive at impecable speeds.",
				Subtitle = "H.G. Corp. Procedural Dive Jetpack Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "DRIFT",
				Name = "H.G. Corp. Procedural Drift Wheels",
				Description = @"H.G. Corp. Procedural Drift wheels.&#xA;
					These upgrade modules descrease the grip your tires have.&#xA;
					Especially usefull when the eurobeat kicks in. Just be aware of windy planets, your exocraft may or may not... drift away",
				Subtitle = "H.G. Corp. Procedural Drift Wheels"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "MECHBOOST",
				Name = "H.G. Corp. Procedural Mech Boost Module",
				Description = @"H.G. Corp. Procedural Mech Boost Module.&#xA;
					These upgrade modules will drastically improve your Minotaur boost capacity.&#xA;
					These will make you wonder, were the clouds always that close?&#xA;
					The modules improve Boost tanks and Boost Speed",
				Subtitle = "Procedural Mech Boost Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "COLDR",
				Name = "H.G. Corp. Suit Cold Resistance Shield",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will increase your suit Cold Resistance.",
				Subtitle = "H.G. Corp. Suit Cold Resistance Shield"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "RADR",
				Name = "H.G. Corp. Suit Radiation Resistance Shield",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will increase your suit Radiation Resistance.",
				Subtitle = "H.G. Corp. Suit Radiation Resistance Shield"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "HEATR",
				Name = "H.G. Corp. Suit Heat Resistance Shield",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will increase your suit Heat Resistance.",
				Subtitle = "H.G. Corp. Suit Heat Resistance Shield"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "TOXICR",
				Name = "H.G. Corp. Suit Cold Toxic Shield",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will increase your suit Toxic Resistance.",
				Subtitle = "H.G. Corp. Suit Toxic Resistance Shield"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "WATERR",
				Name = "H.G. Corp. Suit Oxygen Rebreather",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will increase the ability to swim underwater for extended periods.",
				Subtitle = "H.G. Corp. Suit Oxygen Rebreather"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "WATERG",
				Name = "H.G. Corp. Suit Gills",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. will add the ability to swim underwater for intraveller periods of time.",
				Subtitle = "H.G. Corp. Suit Gills"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRROCK1",
				Name = "Rocket Launcher Module",
				Description = @"A &lt;TRADEABLE&gt;moderate&lt;&gt; upgrade for the &lt;TECHNOLOGY&gt;Starship Rocket Launcher&lt;&gt;. Use &lt;VAL_ON&gt;&lt;IMG&gt;FE_ALT1&lt;&gt;&lt;&gt; to begin upgrade &lt;VAL_ON&gt;installation process&lt;&gt;.&#xA;&#xA;The module is flexible, and exact upgrade statistics are &lt;SPECIAL&gt;unknown&lt;&gt; until installation is complete.&#xA;&#xA;Potential improvements include: &lt;STELLAR&gt;damage&lt;&gt;, &lt;STELLAR&gt;fire rate&lt;&gt; and &lt;STELLAR&gt;overheat times&lt;&gt;.",
				Subtitle = ""
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRROCK2",
				Name = "Rocket Launcher Module",
				Description = @"A &lt;TECHNOLOGY&gt;significant&lt;&gt; upgrade for the &lt;TECHNOLOGY&gt;Starship Rocket Launcher&lt;&gt;. Use &lt;VAL_ON&gt;&lt;IMG&gt;FE_ALT1&lt;&gt;&lt;&gt; to begin upgrade &lt;VAL_ON&gt;installation process&lt;&gt;.&#xA;&#xA;The module is flexible, and exact upgrade statistics are &lt;SPECIAL&gt;unknown&lt;&gt; until installation is complete.&#xA;&#xA;Potential improvements include: &lt;STELLAR&gt;damage&lt;&gt;, &lt;STELLAR&gt;fire rate&lt;&gt; and &lt;STELLAR&gt;overheat times&lt;&gt;.",
				Subtitle = "Rocket Launcher Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRROCK3",
				Name = "Rocket Launcher Module",
				Description = @"An &lt;SPECIAL&gt;extremely powerful&lt;&gt; upgrade for the &lt;TECHNOLOGY&gt;Starship Rocket Launcher&lt;&gt;. Use &lt;VAL_ON&gt;&lt;IMG&gt;FE_ALT1&lt;&gt;&lt;&gt; to begin upgrade &lt;VAL_ON&gt;installation process&lt;&gt;.&#xA;&#xA;The module is flexible, and exact upgrade statistics are &lt;SPECIAL&gt;unknown&lt;&gt; until installation is complete.&#xA;&#xA;Potential improvements include: &lt;STELLAR&gt;damage&lt;&gt;, &lt;STELLAR&gt;fire rate&lt;&gt; and &lt;STELLAR&gt;overheat times&lt;&gt;.",
				Subtitle = ""
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "PRROCK4",
				Name = "Rocket Launcher Module",
				Description = @"A &lt;COMMODITY&gt;supremely powerful&lt;&gt; upgrade for the &lt;TECHNOLOGY&gt;Starship Rocket Launcher&lt;&gt;. Use &lt;VAL_ON&gt;&lt;IMG&gt;FE_ALT1&lt;&gt;&lt;&gt; to begin upgrade &lt;VAL_ON&gt;installation process&lt;&gt;.&#xA;&#xA;The module is flexible, and exact upgrade statistics are &lt;SPECIAL&gt;unknown&lt;&gt; until installation is complete.&#xA;&#xA;Potential improvements include: &lt;STELLAR&gt;damage&lt;&gt;, &lt;STELLAR&gt;fire rate&lt;&gt; and &lt;STELLAR&gt;overheat times&lt;&gt;.",
				Subtitle = ""
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "EXOFLAME",
				Name = "H.G. Corp. Exocraft Flamer",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. now extend your exocraft arsenal with the Liquidator Flamer.",
				Subtitle = "H.G. Corp. Exocraft Flamer"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "EXOSTUN",
				Name = "H.G. Corp. Exocraft Stun Cannon",
				Description = "This new technology upgrade engineered by the engineers at H.G. Corp. now extend your exocraft arsenal with the Liquidator Stun Cannon.",
				Subtitle = "H.G. Corp. Exocraft Stun Cannon"
			}
		};
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

			string description_id = customTech.LanguageBase + "_DESC";
			string name_id = customTech.LanguageBase + "_NAME";
			string name_lc_id = customTech.LanguageBase + "_NAME_LC";
			string sub_id = customTech.LanguageBase + "_SUB";

			tech.Name = name_id;
			tech.NameLower = name_lc_id; 
			tech.Description = description_id;
			tech.Subtitle = sub_id;

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

	protected void CreateCustomProceduralMods()
	{
		var Prod_mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN");
		var Proc_mbin = ExtractMbin<GcProceduralTechnologyTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPROCEDURALTECHNOLOGYTABLE.MBIN");
		var Reality_mbin = ExtractMbin<GcRealityManagerData>("METADATA/REALITY/DEFAULTREALITY.MBIN");

		foreach (CustomProcMod Mod in CustomProceduralMods)
		{
			int baseForClassMulitplier = 0;
			string classOfTech = "";
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

			string description_id = Mod.LanguageBase + "_DESC";
			string name_id = Mod.LanguageBase + "_NAME";
			string name_lc_id = Mod.LanguageBase + "_NAME_LC";
			string sub_id = Mod.LanguageBase + "_SUB";

			string newTradeData = Mod.TradeData;
			string newProcgenName = Mod.ProcTechName;
			string newProcGenBase = Mod.LanguageBaseProcOverride;
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
				baseForClassMulitplier = i;
				classOfTech = Classes[i-1];

				if( highestClassNo < 3) {
					baseForClassMulitplier = i +1;
					classOfTech = Classes[i];
				}

				string copyTech = baseTechName + i.ToString();
				string copyDeployTech = baseDeployString;
				if( !staticDeploy )
					copyDeployTech = baseDeployString + i.ToString();

				string newTechID = newTechName + i.ToString();
				string newTechDeployID = newTechDeployName.Replace("UPC_", "UPC_" + classOfTech).ToUpper() + "_" + classOfTech;

				float multiplier = 1 + (baseForClassMulitplier * newMultiplierPerRank);

				if (newMinStats < newMaxStats)
					newMinStats++;
 
				// Log.AddInformation($"Print copyDeployTech = {copyDeployTech}");
				var proc = CloneMbin(Proc_mbin.Table.Find(PROC => PROC.ID == copyDeployTech));

				proc.Name = newProcgenName;
				proc.ID = newTechDeployID;
				if ( newProcGenBase != "") {
					proc.NameLower = newProcGenBase + i + "_NAME_LC";
					proc.Description = newProcGenBase + i + "_DESC";
				}

				proc.Template = newTemplate;
				proc.NumStatsMin = newMinStats;
				proc.NumStatsMax = newMinStats;
				if( staticDeploy )
					proc.Quality = QualityEnums[i-1];

				proc.StatLevels.Clear();

				foreach( var statLevel in newStatBonuses) {
					Log.AddInformation($"Print {statLevel.Stat.StatsType}");
					float multipliedValMin = statLevel.ValueMin * multiplier;
					float multipliedValMax = statLevel.ValueMax * multiplier;
					Log.AddInformation($"Print {statLevel.ValueMin} * {multiplier} = {multipliedValMin}");
					Log.AddInformation($"Print {statLevel.ValueMax} * {multiplier} = {multipliedValMax}");
					proc.StatLevels.Add(
						ProceduralTechnologyStatLevel.Create(
							statLevel.Stat.StatsType,
							(statLevel.ValueMin * multiplier),
							(statLevel.ValueMax * multiplier),
							statLevel.WeightingCurve.WeightingCurve,
							statLevel.AlwaysChoose)
					);
				}
				Proc_mbin.Table.Add(proc);

				// Create custum products for the tech
				// Log.AddInformation($"Print copyTech = {copyTech}");

				var prod = CloneMbin(Prod_mbin.Table.Find(PROD => PROD.ID == copyTech));

				prod.ID = newTechID;
				prod.Name = name_id;
				prod.NameLower = name_lc_id;
				prod.Description = description_id;
				prod.Subtitle = sub_id;
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
	protected void AddToUnlockableItemTree()
	{
		var mbin = ExtractMbin<GcUnlockableTrees>("METADATA/REALITY/TABLES/UNLOCKABLEITEMTREES.MBIN");
		var shipTree = mbin.Trees[(int)GcUnlockableItemTreeGroups.UnlockableItemTreeEnum.ShipTech];
		var weapTree = mbin.Trees[(int)UnlockableItemTreeEnum.WeapTech];
		var suitTree = mbin.Trees[(int)UnlockableItemTreeEnum.SuitTech];
		var exoTree = mbin.Trees[(int)UnlockableItemTreeEnum.ExocraftTech];

		var ship_guns = shipTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "SHIPGUN1");
		var ship_hyper_drive = shipTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "HYPERDRIVE");

		var weap_bolt = weapTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "BOLT");
		var weap_grenade = weap_bolt.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "GRENADE");

		var suit_protect = suitTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "PROTECT");

		var exo_laser = exoTree.Trees[0].Root.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "VEHICLE_LASER");

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
		var resonator = ship_infra.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_SHIPMINI");		
		resonator.Children.Add(new GcUnlockableItemTreeNode
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

		var cold = suit_protect.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_COLD");
		cold.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_COLD2",
			Children = new()
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_COLD3",
					Children = new()
					{
						new GcUnlockableItemTreeNode
						{
							Unlockable = "UT_COLD4",
							Children = new()
						}
					}
				}
			}
		});

		var hot = suit_protect.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_HOT");
		hot.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_HEAT2",
			Children = new()
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_HEAT3",
					Children = new()
					{
						new GcUnlockableItemTreeNode
						{
							Unlockable = "UT_HEAT4",
							Children = new()
						}
					}
				}
			}
		});

		var tox = suit_protect.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_TOX");
		tox.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_TOXIC2",
			Children = new()
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_TOXIC3",
					Children = new()
					{
						new GcUnlockableItemTreeNode
						{
							Unlockable = "UT_TOXIC4",
							Children = new()
						}
					}
				}
			}
		});

		var rad = suit_protect.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_RAD");
		rad.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_RAD2",
			Children = new()
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_RAD3",
					Children = new()
					{
						new GcUnlockableItemTreeNode
						{
							Unlockable = "UT_RAD4",
							Children = new()
						}
					}
				}
			}
		});

		var water = suit_protect.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "UT_WATER");
		water.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_WATER3",
			Children = new()
			{
				new GcUnlockableItemTreeNode
				{
					Unlockable = "UT_WATER4",
					Children = new()
				}
			}
		});

		var exolaser1 = exo_laser.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "VEHICLE_LASER1");
		exolaser1.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_EXOFLAME",
			Children = new()
		});
		var exogun = exo_laser.Children.Find(UNLOCKABLE => UNLOCKABLE.Unlockable == "VEHICLE_GUN");
		exogun.Children.Add(new GcUnlockableItemTreeNode {
			Unlockable = "UT_EXOSTUN",
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

	protected void AddLanguageStrings()
	{
		foreach( LanguageString language_string_item in Language_String_List ) {
			string description_id = language_string_item.Language_Base + "_DESC";
			string name_id = language_string_item.Language_Base + "_NAME";
			string name_lc_id = language_string_item.Language_Base + "_NAME_LC";
			string sub_id = language_string_item.Language_Base + "_SUB";

			SetLanguageText(language_string_item.Id, description_id, language_string_item.Description);
			SetLanguageText(language_string_item.Id, name_id, language_string_item.Name);
			SetLanguageText(language_string_item.Id, name_lc_id, language_string_item.Name);
			SetLanguageText(language_string_item.Id, sub_id, language_string_item.Subtitle);

		}
	}
}
