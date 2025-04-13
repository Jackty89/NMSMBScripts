//=============================================================================
// Author: Jackty89
//=============================================================================


public class ShipStoreV3_WIP : cmk.NMS.Script.ModClass
{
	readonly private int Total_Seeds_Per_Class = 10;
	readonly private int Total_Classes = 4;
	readonly private float Price_Multiplier = 1;

	private List<Tuple<string, LanguageId, string, string>> Custom_Language_Desccription_Strings = new List<Tuple<string,LanguageId, string, string>>
	{
		new("CL_BFREIGH", LanguageId.English, "H.G. Corp. Freighter", "H.G. Corp. Spacecraft Dynamics Freighter"),
		new("CL_BHAUL", LanguageId.English, "H.G. Corp. Hauler Ship", "H.G. Corp. Spacecraft Dynamics Hauler"),
		new("CL_BEXPLO", LanguageId.English, "H.G. Corp. Explorer Ship", "H.G. Corp. Spacecraft Dynamics Explorer"),
		new("CL_BSOLAR", LanguageId.English, "H.G. Corp. Solar Ship", "H.G. Corp. Spacecraft Dynamics Solar"),
		new("CL_BFIGHT", LanguageId.English, "H.G. Corp. Fighter Ship", "H.G. Corp. Spacecraft Dynamics Fighter"),
		new("CL_BSHUT", LanguageId.English, "H.G. Corp. Shuttle Ship", "H.G. Corp. Spacecraft Dynamics Shuttle"),
		new("CL_BROYAL", LanguageId.English, "H.G. Corp. Exotic Ship", "H.G. Corp. Spacecraft Dynamics Exotic"),
		new("CL_BALIEN", LanguageId.English, "H.G. Corp. Alien Ship", "H.G. Corp. Spacecraft Dynamics Bioship"),
		new("CL_BROBOT", LanguageId.English, "H.G. Corp. Sentinel Ship", "H.G. Corp. Spacecraft Dynamics Sentinel"),
		new("CL_STORE", LanguageId.English, "H.G. Corp. Spacecraft Dynamics", "Spacecraft constucted by H.G. Corp."),

		new("CL_BFRIGC", LanguageId.English, "H.G. Corp. Combat Frigate", "H.G. Corp. Spacecraft Dynamics Frigate"),
		new("CL_BFRIGE", LanguageId.English, "H.G. Corp. Exploration Frigate", "H.G. Corp. Spacecraft Dynamics Frigate"),
		new("CL_BFRIGM", LanguageId.English, "H.G. Corp. Mining Frigate", "H.G. Corp. Spacecraft Dynamics Frigate"),
		new("CL_BFRIGD", LanguageId.English, "H.G. Corp. Deep Space Frigate", "H.G. Corp. Spacecraft Dynamics Frigate"),
		new("CL_BFRIGN", LanguageId.English, "H.G. Corp. Normandy Frigate", "H.G. Corp. Spacecraft Dynamics Frigate"),
		new("CL_BFRIGG", LanguageId.English, "H.G. Corp. Ghost Frigate", "H.G. Corp. Spacecraft Dynamics Frigate"),
	};
	protected ShipClassEnum[] Ship_Types = new[] {
		ShipClassEnum.Freighter, // Does work (partially, only C class for now and needs reload of save to take effect)
		ShipClassEnum.Dropship,
		ShipClassEnum.Shuttle,
		ShipClassEnum.Fighter,
		ShipClassEnum.Royal,
		ShipClassEnum.Scientific,
		ShipClassEnum.Sail,
		ShipClassEnum.Robot,
		ShipClassEnum.Alien
	};

	////Maybe add frigate(s) too S13 or Normandy?
	protected FrigateClassEnum[] Frigate_types = new[] {
		FrigateClassEnum.Combat,
		FrigateClassEnum.Exploration,
		FrigateClassEnum.Mining,
		FrigateClassEnum.DeepSpaceCommon,
		FrigateClassEnum.Normandy,
		FrigateClassEnum.GhostShip
	};

	protected InventoryClassEnum[] Classes = new[] {
		InventoryClassEnum.C,
		InventoryClassEnum.B,
		InventoryClassEnum.A,
		InventoryClassEnum.S
	};
	protected override void Execute()
	{
		switch( Total_Classes ) {
			case 3:
				Classes = new[] {
					InventoryClassEnum.B,
					InventoryClassEnum.A,
					InventoryClassEnum.S
				};
				break;
			case 2:
				Classes = new[] {
					InventoryClassEnum.A,
					InventoryClassEnum.S
				};
				break;
			case 1:
				Classes = new[] {
					InventoryClassEnum.S
				};
				break;
			default:
				Classes = new[] {
					InventoryClassEnum.C,
					InventoryClassEnum.B,
					InventoryClassEnum.A,
					InventoryClassEnum.S
				};
				break;
		}

		Generate_Ships();
		AddNewLanguageString();
	}

	//protected void Generate_Frigates()
	//{
	//	Random random = new Random();
	//	List<GcInventoryBaseStatEntry> ship_stats = new List<GcInventoryBaseStatEntry>();
	//	List<GcProductData> consumable_products = new List<GcProductData>();
	//	List<GcConsumableItem> consumables = new List<GcConsumableItem>();
	//	List<GcGenericRewardTableEntry> generic_rewards = new List<GcGenericRewardTableEntry>();
	//	List<GcRewardTableItem> ships_per_class = new List<GcRewardTableItem>();

	//	var product_mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN", false, false);
	//	var consumable_mbin = ExtractMbin<GcConsumableItemTable>("METADATA/REALITY/TABLES/CONSUMABLEITEMTABLE.MBIN", false, false);
	//	var reward_mbin = ExtractMbin<GcRewardTable>("METADATA/REALITY/TABLES/REWARDTABLE.MBIN", false, false);
	//	var realitymanagerdata_mbin = ExtractMbin<GcRealityManagerData>("METADATA/REALITY/DEFAULTREALITY.MBIN", false, false).TradeSettings;

	//	GcRewardTableItem buy_ship_reward = CloneMbin(reward_mbin.InteractionTable.Find(ID => ID.Id == "R_BUY_SHIP").List.List[0]);

	//	foreach( FrigateClassEnum frigate_type in Frigate_types ) {
	//		var frigate_stats = GetFrigateData(frigate_type);
	//		foreach( InventoryClassEnum frigate_class in Classes ) {

	//			ships_per_class.Clear();

	//			//(shiptype, shipmodel, shipclass, price, langString)
	//			var data = GetFrigateData(frigate_type, frigate_class);
	//			string frigate_type_from_data = data.Item1;
	//			string frigate_model_from_data = data.Item2;
	//			string frigate_class_from_data = data.Item3;
	//			int frigate_price_from_data = data.Item4;
	//			string frigate_languagestring_from_data = data.Item5;
	//			string reward_name = data.Item1.ToUpper() + "_" + frigate_class;

	//			consumable_products.Add(CreateCustomConsumableProducts(reward_name, frigate_price_from_data, frigate_languagestring_from_data, frigate_class_from_data));
	//			consumables.Add(CreateCustomConsumable(reward_name));
	//			realitymanagerdata_mbin.SpaceStation.AlwaysPresentProducts.Add(reward_name);

	//			for( int i = 1; i <= Total_Seeds_Per_Class; i++ ) {
	//				if( Cancel.IsCancellationRequested ) break;
	//				var seed = random.NextInt64();
	//				int slot_number = random.Next(20, 48);

	//				ships_per_class.Add(CreateNewShip("CL_STORE_DESC", seed, frigate_type, frigate_class, frigate_model_from_data, slot_number, GetShipTechnologies(frigate_type), frigate_stats));
	//			}
	//			generic_rewards.Add(CrateNewShipRewards(reward_name, ships_per_class, buy_ship_reward));
	//		}
	//	}

	//	product_mbin.Table.AddRange(consumable_products);
	//	consumable_mbin.Table.AddRange(consumables);
	//	reward_mbin.GenericTable.AddRange(generic_rewards);
	//}

	//protected (string, string, string, int, string) GetFrigateData( FrigateClassEnum frigate_type, InventoryClassEnum friagate_class )
	//{
	//	string frigate_class_string = "";
	//	string frigate_type_string = "";
	//	string frigate_model = "";
	//	string custom_language_string = "";
	//	int price = 0;
	//	int base_price = 0;
	//	int price_multiplier = 0;

	//	string [] frigate_models = new []
	//	{
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/COMBATFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/DIPLOMATICFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/GHOSTSHIPFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/INDUSTRIALFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/LIVINGFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/NORMANDYFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/SCIENCEFRIGATE.SCENE.MBIN",
	//		"MODELS/COMMON/SPACECRAFT/FRIGATES/SUPPORTFRIGATE.SCENE.MBIN"
	//	};

	//	switch( frigate_type ) {
	//		case FrigateClassEnum.Combat:
	//			frigate_type_string = "ComFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/FRIGATES/COMBATFRIGATE.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGC";
	//			break;
	//		case FrigateClassEnum.Exploration:
	//			frigate_type_string = "ExpFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/FRIGATES/DIPLOMATICFRIGATE.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGE";
	//			break;
	//		case FrigateClassEnum.Mining:
	//			frigate_type_string = "MinFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/FRIGATES/INDUSTRIALFRIGATE.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGM";
	//			break;
	//		case FrigateClassEnum.DeepSpaceCommon:
	//			frigate_type_string = "DeepFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/DROPSHIPS/DROPSHIP_PROC.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGD";
	//			break;
	//		case FrigateClassEnum.Normandy:
	//			frigate_type_string = "NorFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/DROPSHIPS/DROPSHIP_PROC.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGN";
	//			break;
	//		case FrigateClassEnum.GhostShip:
	//			frigate_type_string = "GhostFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/DROPSHIPS/DROPSHIP_PROC.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGG";
	//			break;
	//		default:
	//			frigate_type_string = "ComFrig";
	//			frigate_model = "MODELS/COMMON/SPACECRAFT/DROPSHIPS/DROPSHIP_PROC.SCENE.MBIN";
	//			base_price = (int)(250000 * Price_Multiplier);
	//			custom_language_string = "CL_BFRIGC";
	//			break;
	//	}

	//	switch( friagate_class ) {
	//		case InventoryClassEnum.C:
	//			frigate_class_string = "C";
	//			price_multiplier = 1;
	//			break;
	//		case InventoryClassEnum.B:
	//			frigate_class_string = "B";
	//			price_multiplier = 2;
	//			break;
	//		case InventoryClassEnum.A:
	//			frigate_class_string = "A";
	//			price_multiplier = 3;
	//			break;
	//		case InventoryClassEnum.S:
	//			frigate_class_string = "S";
	//			price_multiplier = 4;
	//			break;
	//		default:
	//			frigate_class_string = "S";
	//			price_multiplier = 4;
	//			break;
	//	}
	//	price = base_price * price_multiplier;

	//	return (frigate_type_string, frigate_model, frigate_class_string, price, custom_language_string);
	//}



	protected void Generate_Ships()
	{
		Random random = new Random();
		List<GcInventoryBaseStatEntry> ship_stats = new List<GcInventoryBaseStatEntry>();
		List<GcProductData> consumable_products = new List<GcProductData>();
		List<GcConsumableItem> consumables = new List<GcConsumableItem>();
		List<GcGenericRewardTableEntry> generic_rewards = new List<GcGenericRewardTableEntry>();

		List<GcRewardTableItem> ships_per_class = new List<GcRewardTableItem>();

		var product_mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN", false);
		var consumable_mbin = ExtractMbin<GcConsumableItemTable>("METADATA/REALITY/TABLES/CONSUMABLEITEMTABLE.MBIN", false);
		var reward_mbin = ExtractMbin<GcRewardTable>("METADATA/REALITY/TABLES/REWARDTABLE.MBIN", false);
		var realitymanagerdata_mbin = ExtractMbin<GcRealityManagerData>("METADATA/REALITY/DEFAULTREALITY.MBIN", false).TradeSettings;

		GcRewardTableItem buy_ship_reward = CloneMbin(reward_mbin.InteractionTable.Find(ID => ID.Id == "R_BUY_SHIP").List.List[0]);
		bool freighter_has_been_add = false;

		foreach( ShipClassEnum ship_type in Ship_Types ) {
			ship_stats =  GetShipStats(ship_type);
			foreach( InventoryClassEnum ship_class in Classes ) {

				var current_ship_class = ship_class;

				ships_per_class.Clear();
				//For now freighter can only be C class (CustomDebugOptions from HG)
				if( ship_type == ShipClassEnum.Freighter && ship_class != InventoryClassEnum.C )
					continue;
				//For now freighter C only even when S only is selected see comments above
				if( ship_type == ShipClassEnum.Freighter && Classes.Length < 4 && !freighter_has_been_add )
					current_ship_class = InventoryClassEnum.C;
				freighter_has_been_add = true;
				if( (ship_type == ShipClassEnum.Royal || ship_type == ShipClassEnum.Alien) && ship_class != InventoryClassEnum.S )
					continue;
				//(shiptype, shipmodel, shipclass, price, langString)
				var data = GetShipData(ship_type, current_ship_class); // ship data scen for freighter is not randomized per seed but only per class
				string ship_type_from_data = data.Item1;
				string ship_model_from_data = data.Item2;
				string ship_class_from_data = data.Item3;
				int ship_price_from_data = data.Item4;
				string ship_languagestring_from_data = data.Item5;
				string reward_name = ship_type_from_data.ToUpper() + "_" + current_ship_class;

				consumable_products.Add(CreateCustomConsumableProducts(reward_name, ship_price_from_data, ship_languagestring_from_data, ship_class_from_data));
				consumables.Add(CreateCustomConsumable(reward_name));
				realitymanagerdata_mbin.SpaceStation.AlwaysPresentProducts.Add(reward_name);

				for( int i = 1; i <= Total_Seeds_Per_Class; i++ ) {
					if( Cancel.IsCancellationRequested ) break;
					ulong seed = (ulong)random.NextInt64();
					int slot_number = random.Next(20, 48);

					ships_per_class.Add(CreateNewShip("CL_STORE_DESC", seed, ship_type, current_ship_class, ship_model_from_data, slot_number, GetShipTechnologies(ship_type), ship_stats));
				}
				generic_rewards.Add(CrateNewShipRewards(reward_name, ships_per_class, buy_ship_reward));
			}
		}

		product_mbin.Table.AddRange(consumable_products);
		consumable_mbin.Table.AddRange(consumables);
		reward_mbin.GenericTable.AddRange(generic_rewards);
	}

	protected (string, string, string, int, string) GetShipData( ShipClassEnum ship_type, InventoryClassEnum ship_class )
	{
		string ship_class_string = "";
		string ship_type_string = "";
		string ship_model = "";
		string custom_language_string = "";
		int price = 0;
		int base_price = 0;
		int price_multiplier = 0;
		Random random = new Random();
		int rand = random.Next(0,2);
		string [] freighter_models = new []
		{
			"MODELS/COMMON/SPACECRAFT/INDUSTRIAL/CAPITALFREIGHTER_PROC.SCENE.MBIN",
			"MODELS/COMMON/SPACECRAFT/INDUSTRIAL/FREIGHTER_PROC.SCENE.MBIN",
			"MODELS/COMMON/SPACECRAFT/INDUSTRIAL/FREIGHTERSMALL_PROC.SCENE.MBIN",
			"MODELS/COMMON/SPACECRAFT/INDUSTRIAL/FREIGHTERTINY_PROC.SCENE.MBIN"
		};

		switch( ship_type ) {
			case ShipClassEnum.Freighter:
				ship_type_string = "Freighter";
				ship_model = freighter_models[rand];
				base_price = (int)(25000000 * Price_Multiplier);
				custom_language_string = "CL_BFREIGH";
				break;
			case ShipClassEnum.Dropship:
				ship_type_string = "Dropship";
				ship_model = "MODELS/COMMON/SPACECRAFT/DROPSHIPS/DROPSHIP_PROC.SCENE.MBIN";
				base_price = (int)(2500000 * Price_Multiplier);
				custom_language_string = "CL_BHAUL";
				break;
			case ShipClassEnum.Shuttle:
				ship_type_string = "Shuttle";
				ship_model = "MODELS/COMMON/SPACECRAFT/SHUTTLE/SHUTTLE_PROC.SCENE.MBIN";
				base_price = (int)(1000000 * Price_Multiplier);
				custom_language_string = "CL_BSHUT";
				break;
			case ShipClassEnum.Fighter:
				ship_type_string = "Fighter";
				ship_model = "MODELS/COMMON/SPACECRAFT/FIGHTERS/FIGHTER_PROC.SCENE.MBIN";
				base_price = (int)(2500000 * Price_Multiplier);
				custom_language_string = "CL_BFIGHT";
				break;
			case ShipClassEnum.Royal:
				ship_type_string = "Royal";
				ship_model = "MODELS/COMMON/SPACECRAFT/S-CLASS/S-CLASS_PROC.SCENE.MBIN";
				base_price = (int)(5000000 * Price_Multiplier);
				custom_language_string = "CL_BROYAL";
				break;
			case ShipClassEnum.Scientific:
				ship_type_string = "Scientific";
				ship_model = "MODELS/COMMON/SPACECRAFT/SCIENTIFIC/SCIENTIFIC_PROC.SCENE.MBIN";
				base_price = (int)(1000000 * Price_Multiplier);
				custom_language_string = "CL_BEXPLO";
				break;
			case ShipClassEnum.Sail:
				ship_type_string = "Sail";
				ship_model = "MODELS/COMMON/SPACECRAFT/SAILSHIP/SAILSHIP_PROC.SCENE.MBIN";
				base_price = (int)(2000000 * Price_Multiplier);
				custom_language_string = "CL_BSOLAR";
				break;
			case ShipClassEnum.Alien:
				ship_type_string = "Alien";
				ship_model = "MODELS/COMMON/SPACECRAFT/S-CLASS/BIOPARTS/BIOSHIP_PROC.SCENE.MBIN";
				base_price = (int)(2500000 * Price_Multiplier);
				custom_language_string = "CL_BALIEN";
				break;
			case ShipClassEnum.Robot:
				ship_type_string = "Robot";
				ship_model = "MODELS/COMMON/SPACECRAFT/SENTINELSHIP/SENTINELSHIP_PROC.SCENE.MBIN";
				base_price = (int)(2500000 * Price_Multiplier);
				custom_language_string = "CL_BROBOT";
				break;
			default:
				ship_type_string = "Shuttle";
				ship_model = "MODELS/COMMON/SPACECRAFT/SHUTTLE/SHUTTLE_PROC.SCENE.MBIN";
				base_price = (int)(1000000 * Price_Multiplier);
				custom_language_string = "CL_BSHUT";
				break;
		}

		switch( ship_class ) {
			case InventoryClassEnum.C:
				ship_class_string = "C";
				price_multiplier = 1;
				break;
			case InventoryClassEnum.B:
				ship_class_string = "B";
				price_multiplier = 2;
				break;
			case InventoryClassEnum.A:
				ship_class_string = "A";
				price_multiplier = 4;
				break;
			case InventoryClassEnum.S:
				ship_class_string = "S";
				price_multiplier = 8;
				break;
			default:
				ship_class_string = "S";
				price_multiplier = 8;
				break;
		}
		price = base_price * price_multiplier;

		return (ship_type_string, ship_model, ship_class_string, price, custom_language_string);
	}

	protected List<GcInventoryElement> GetShipTechnologies( ShipClassEnum ship_type )
	{
		Random random = new Random();
		List<GcInventoryElement> ship_technologies = new List<GcInventoryElement>();
		string [] ship_weapons = new []
		{
			"SHIPGUN1",
			"SHIPLAS1",
			"SHIPMINIGUN",
			"SHIPPLASMA",
			"SHIPROCKETS",
			"SHIPSHOTGUN"
		};
		int rand = random.Next(4);
		switch( ship_type ) {
			case ShipClassEnum.Freighter:
				ship_technologies = new() {
					Inventory.Technology("F_HYPERDRIVE", 200, 200, 0),
				};
				break;
			case ShipClassEnum.Alien:
				ship_technologies = new() {
					Inventory.Technology("SHIPJUMP_ALIEN", 200, 200, 0),
					Inventory.Technology("SHIPGUN_ALIEN", 100, 100, 0),
					Inventory.Technology("SHIELD_ALIEN", 200, 200, 0),
					Inventory.Technology("SHIPLAS_ALIEN", 100, 100, 0),
					Inventory.Technology("LAUNCHER_ALIEN", 200, 200, 0),
					Inventory.Technology("WARP_ALIEN", 120, 120, 0)
				};
				break;
			case ShipClassEnum.Sail:
				ship_technologies = new() {
					Inventory.Technology("SHIPJUMP1", 200, 200, 0),
					Inventory.Technology("SOLAR_SAIL", 200, 200, 0),
					Inventory.Technology("SHIPSHIELD", 100, 100, 0),
					Inventory.Technology("LAUNCHER", 200, 200, 0),
					Inventory.Technology("HYPERDRIVE", 100, 100, 0),
					Inventory.Technology(ship_weapons[rand], 200, 200, 0)
				};
				break;
			case ShipClassEnum.Robot:
				ship_technologies = new() {
					Inventory.Technology("SHIPJUMP_ROBO", 200, 200, 0),
					Inventory.Technology("SHIPSHIELD_ROBO", 200, 200, 0),
					Inventory.Technology("LAUNCHER_ROBO", 100, 100, 0),
					Inventory.Technology("HYPERDRIVE_ROBO", 200, 200, 0),
					Inventory.Technology("LIFESUP_ROBO", 100, 100, 0),
					Inventory.Technology("SHIPGUN_ROBO", 200, 200, 0)
				};
				break;
			default:
				ship_technologies = new() {
					Inventory.Technology("SHIPJUMP1", 200, 200, 0),
					Inventory.Technology("SHIPSHIELD", 100, 100, 0),
					Inventory.Technology("LAUNCHER", 200, 200, 0),
					Inventory.Technology("HYPERDRIVE", 100, 100, 0),
					Inventory.Technology(ship_weapons[rand], 200, 200, 0)
				};
				break;
		}
		return ship_technologies;
	}

	protected List<GcInventoryBaseStatEntry> GetShipStats( ShipClassEnum ship_type )
	{
		List<GcInventoryBaseStatEntry> ship_stats = new List<GcInventoryBaseStatEntry>();
		switch( ship_type ) {
			case ShipClassEnum.Freighter:
				ship_stats = new() {
					InventoryBaseStat.Create("FREI_HYPERDRIVE"),
					InventoryBaseStat.Create("FREI_FLEET"),
				};
				break;
			case ShipClassEnum.Alien:
				ship_stats = new() {
					InventoryBaseStat.Create("SHIP_DAMAGE"),
					InventoryBaseStat.Create("SHIP_SHIELD"),
					InventoryBaseStat.Create("SHIP_HYPERDRIVE"),
					InventoryBaseStat.Create("ALIEN_SHIP")
				};
				break;
			case ShipClassEnum.Robot:
				ship_stats = new() {
					InventoryBaseStat.Create("SHIP_DAMAGE"),
					InventoryBaseStat.Create("SHIP_SHIELD"),
					InventoryBaseStat.Create("SHIP_HYPERDRIVE"),
					InventoryBaseStat.Create("ROBOT_SHIP")
				};
				break;
			default:
				ship_stats = new() {
					InventoryBaseStat.Create("SHIP_DAMAGE"),
					InventoryBaseStat.Create("SHIP_SHIELD"),
					InventoryBaseStat.Create("SHIP_HYPERDRIVE"),
				};
				break;
		}
		return ship_stats;
	}

	protected GcProductData CreateCustomConsumableProducts( string product_name, int price, string custom_language_name, string ship_class )
	{
		var prod_mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN", false);
		var new_consumable_product = CloneMbin(prod_mbin.Table.Find(PRODUCT => PRODUCT.ID == "SENTINEL_LOOT"));
		//change to SHIP_GOLD? this will require to remove GiveRewardOnSpecialPurchase
		
		new_consumable_product.ID = product_name;
		new_consumable_product.Name = custom_language_name.ToUpper() + "_NAME";
		new_consumable_product.NameLower = custom_language_name.ToUpper() + "_NAME_L";
		new_consumable_product.Description = custom_language_name.ToUpper() + "_DESC";
		new_consumable_product.Subtitle = custom_language_name.ToUpper() + "_DESC";
		new_consumable_product.Icon.Filename = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.SHIPCLASS" + ship_class.ToUpper() + ".DDS";
		new_consumable_product.BaseValue = price;

		new_consumable_product.CraftAmountMultiplier = 1;
		new_consumable_product.StackMultiplier = 1;
		new_consumable_product.EggModifierIngredient = false;
		new_consumable_product.PinObjective = "";
		
		new_consumable_product.Cost.SpaceStationMarkup = 0;
		new_consumable_product.Cost.LowPriceMod = 0;
		new_consumable_product.Cost.HighPriceMod = 0;
		new_consumable_product.Cost.BuyBaseMarkup = 0;
		new_consumable_product.Cost.BuyMarkupMod = 0;

		return new_consumable_product;
	}

	protected GcConsumableItem CreateCustomConsumable( string product_name )
	{
		var cons_mbin = ExtractMbin<GcConsumableItemTable>("METADATA/REALITY/TABLES/CONSUMABLEITEMTABLE.MBIN", false);
		var new_consumable = CloneMbin(cons_mbin.Table.Find(CONSUMABLE => CONSUMABLE.ID == "SENTINEL_LOOT"));

		new_consumable.ID = product_name;
		new_consumable.RewardID = "R_" + product_name;
		new_consumable.CloseInventoryWhenUsed = true;
		return new_consumable;
	}

	protected GcRewardTableItem CreateNewShip( string ship_name, ulong ship_seed, ShipClassEnum ship_type, InventoryClassEnum ship_class, string ship_model, int ship_number_of_slots, List<GcInventoryElement> ship_technologies, List<GcInventoryBaseStatEntry> ship_stats )
	{
		var ship = RewardTableItem.SpecificShip(
			ship_name,
			ship_type,
			ship_class,
			ship_model,
			ship_seed,
			true,
			ship_number_of_slots,
			ship_technologies,
			ship_stats
		);
		return ship;
	}

	protected GcGenericRewardTableEntry CrateNewShipRewards( string reward_name, List<GcRewardTableItem> ships_per_class, GcRewardTableItem buy_ship_reward)
	{
		var entry = GenericRewardTableEntry.Create(
			"R_" + reward_name ,
			RewardChoiceEnum.Select,
			new(){}
		);
		entry.List.UseInventoryChoiceOverride = true;
		foreach( var ship in ships_per_class ) {
			entry.Add(ship);
		}
		return entry;
	}

	protected void AddNewLanguageString()
	{
		foreach( var language in Custom_Language_Desccription_Strings ) {
			SetLanguageText(language.Item2, language.Item1 + "_NAME", language.Item3.ToUpper());
			SetLanguageText(language.Item2, language.Item1 + "_NAME_L", language.Item3);
			SetLanguageText(language.Item2, language.Item1 + "_DESC", language.Item4);
		}
	}

}