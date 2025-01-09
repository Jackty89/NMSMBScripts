//=============================================================================
// Author: Jackty89
//=============================================================================

public class SuperUpgradeModuleOptions : cmk.NMS.Script.ModClass
{
	readonly int Ship_Inv_Slot = 10;
	readonly int Weap_Inv_Slot = 10;
	readonly int Suit_Inv_Slot = 10;
	protected class LanguageString
	{
		public LanguageId Id;
		public string Language_Base;
		public string Name;
		public string Description;
		public string Subtitle;
	}

	protected class Super_Upgrade_Module
	{
		public string ID;
		public int Stack_Size;
		public int Price;
		public string Icon_Path;
		public string Language_Base;
		public GcRewardTableItem RewardTable_Item = new();
	}

	List<Super_Upgrade_Module> Super_Upgrade_Module_List = new List<Super_Upgrade_Module>();
	List<LanguageString> Language_String_List = new List<LanguageString> ();

	protected override void Execute()
	{
		FillLists();
		AddLanguageStrings();
		foreach( Super_Upgrade_Module Super_Upgrade_Module in Super_Upgrade_Module_List ) {
			AddProducts(Super_Upgrade_Module);
			AddConsumables(Super_Upgrade_Module);
			AddRewards(Super_Upgrade_Module);
			AddToStore(Super_Upgrade_Module);
		};
	}
	protected void FillLists()
	{
		Super_Upgrade_Module_List = new List<Super_Upgrade_Module>(){
			new Super_Upgrade_Module
			{
				ID = "UP_WEAPON",
				Stack_Size = 10,
				Price = 10000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.COUNTERFIRE.DDS",
				Language_Base = "CL_UPWEAP",
				RewardTable_Item = RewardTableItem.WeaponClassUpgrade()
			},
			new Super_Upgrade_Module
			{
				ID = "UP_SHIP_B",
				Stack_Size = 10,
				Price = 25000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.MILESTONE.1.DDS",
				Language_Base = "CL_UPSHIPB",
				RewardTable_Item = RewardTableItem.ShipClassUpgrade(INVENTORYCLASS: InventoryClassEnum.B)
			},
			new Super_Upgrade_Module
			{
				ID = "UP_SHIP_A",
				Stack_Size = 10,
				Price = 50000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.MILESTONE.2.DDS",
				Language_Base = "CL_UPSHIPA",
				RewardTable_Item = RewardTableItem.ShipClassUpgrade(INVENTORYCLASS: InventoryClassEnum.A)
			},
			new Super_Upgrade_Module
			{
				ID = "UP_SHIP_S",
				Stack_Size = 10,
				Price = 75000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.MILESTONE.3.DDS",
				Language_Base = "CL_UPSHIPS",
				RewardTable_Item = RewardTableItem.ShipClassUpgrade(INVENTORYCLASS: InventoryClassEnum.S)
			},
			new Super_Upgrade_Module
			{
				ID = "UP_INV_SHIP",
				Stack_Size = 10,
				Price = 20000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.RESEARCH.SHIP.DDS",
				Language_Base = "CL_UPINVSHIP",
				RewardTable_Item = RewardTableItem.MultiSpecificItems(SPECIFIC_ITEMS: new List<GcMultiSpecificItemEntry> ()
					{
						RewardTableItem.MultiSpecificItemEntry(
							AMOUNT: Ship_Inv_Slot,
							MULTIPLE_ITEM_REWARD_TYPE: MultiItemRewardTypeEnum.InventorySlotShip
						)
					}
				)
			},
			new Super_Upgrade_Module
			{
				ID = "UP_INV_SUIT",
				Stack_Size = 10,
				Price = 20000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.RESEARCH.EXOSUIT.DDS",
				Language_Base = "CL_UPINVSUIT",
				RewardTable_Item = RewardTableItem.MultiSpecificItems(SPECIFIC_ITEMS: new List<GcMultiSpecificItemEntry> ()
					{
						RewardTableItem.MultiSpecificItemEntry(
							AMOUNT: Suit_Inv_Slot,
							MULTIPLE_ITEM_REWARD_TYPE: MultiItemRewardTypeEnum.InventorySlot
						)
					}
				)
			},
			new Super_Upgrade_Module
			{
				ID = "UP_INV_WEAP",
				Stack_Size = 10,
				Price = 5000000,
				Icon_Path = "TEXTURES/UI/FRONTEND/ICONS/EXPEDITION/PATCH.RESEARCH.MULITTOOL.DDS",
				Language_Base = "CL_UPINVWEAP",
				RewardTable_Item = RewardTableItem.MultiSpecificItems(SPECIFIC_ITEMS: new List<GcMultiSpecificItemEntry> ()
					{
						RewardTableItem.MultiSpecificItemEntry(
							AMOUNT: Weap_Inv_Slot,
							MULTIPLE_ITEM_REWARD_TYPE: MultiItemRewardTypeEnum.InventorySlotWeapon
						)
					}
				)
			},
		};
		//Language strings
		Language_String_List = new List<LanguageString> ()
		{
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPWEAP",
				Name = "Weapon Class Upgrade Module",
				Description = "This weapon module created by the engineers of H.G. Corp. will let you upgrade your weapon's class.",
				Subtitle = "Weapon Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPSHIPB",
				Name = "Ship B-Class Upgrade Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you upgrade your ship's class",
				Subtitle = "Ship B-Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPSHIPA",
				Name = "Ship A-Class Upgrade Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you upgrade your ship's class",
				Subtitle = "Ship A-Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPSHIPS",
				Name = "Ship S-Class Upgrade Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you upgrade your ship's class",
				Subtitle = "Ship S-Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPINVSHIP",
				Name = "Ship Inventory Expansion Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you expand your ship slots.&#xA;This will add " + Ship_Inv_Slot + " slots onto your ship cargo capacity.",
				Subtitle = "Ship Inventory Expansion Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPINVSUIT",
				Name = "Suit Inventory Expansion Module",
				Description = "This suit module created by the engineers of H.G. Corp. will let you expand your suit slots.&#xA;This will add " + Suit_Inv_Slot + " slots onto your suit cargo capacity.",
				Subtitle = "Suit Inventory Expansion Module"
			},
			new LanguageString () {
				Id = LanguageId.English,
				Language_Base = "CL_UPINVWEAP",
				Name = "Weapon Inventory Expansion Module",
				Description = "This weapon module created by the engineers of H.G. Corp. will let you expand your weapon slots.&#xA;This will add " + Weap_Inv_Slot + " slots for your current weapon.",
				Subtitle = "Weapon Inventory Expansion Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPWEAP",
				Name = "Weapon Class Upgrade Module",
				Description = "This weapon module created by the engineers of H.G. Corp. will let you upgrade your weapon's class.",
				Subtitle = "Weapon Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPSHIPB",
				Name = "Ship B-Class Upgrade Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you upgrade your ship's class",
				Subtitle = "Ship B-Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPSHIPA",
				Name = "Ship A-Class Upgrade Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you upgrade your ship's class",
				Subtitle = "Ship A-Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPSHIPS",
				Name = "Ship S-Class Upgrade Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you upgrade your ship's class",
				Subtitle = "Ship S-Class Upgrade Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPINVSHIP",
				Name = "Ship Inventory Expansion Module",
				Description = "This ship module created by the engineers of H.G. Corp. will let you expand your ship slots.&#xA;This will add " + Ship_Inv_Slot + " slots onto your ship cargo capacity.",
				Subtitle = "Ship Inventory Expansion Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPINVSUIT",
				Name = "Suit Inventory Expansion Module",
				Description = "This suit module created by the engineers of H.G. Corp. will let you expand your suit slots.&#xA;This will add " + Suit_Inv_Slot + " slots onto your suit cargo capacity.",
				Subtitle = "Suit Inventory Expansion Module"
			},
			new LanguageString () {
				Id = LanguageId.USEnglish,
				Language_Base = "CL_UPINVWEAP",
				Name = "Weapon Inventory Expansion Module",
				Description = "This weapon module created by the engineers of H.G. Corp. will let you expand your weapon slots.&#xA;This will add " + Weap_Inv_Slot + " slots for your current weapon.",
				Subtitle = "Weapon Inventory Expansion Module"
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPWEAP",
				Name = "Модуль улучшения класса мультитула",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам повысить класс вашего мультитула.",
				Subtitle = "Этот модуль, созданный инженерами H.G. Corp., позволит вам повысить класс вашего мультитула."
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPSHIPB",
				Name = "Модуль улучшения звездолета B-класса",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам повысить класс вашего звездолета до B-класса.",
				Subtitle = "Повышает класс вашего звездолета до B-класса."
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPSHIPA",
				Name = "Модуль улучшения звездолета A-класса",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам повысить класс вашего звездолета до A-класса.",
				Subtitle = "Повышает класс вашего звездолета до A-класса."
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPSHIPS",
				Name = "Модуль улучшения звездолета S-класса",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам повысить класс вашего звездолета до S-класса.",
				Subtitle = "Повышает класс вашего звездолета до S-класса."
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPINVSHIP",
				Name = "Модуль расширения инвентаря звездолета",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам расширить слоты вашего звездолета. Модуль добавит " + Ship_Inv_Slot + " слотов к вашему звездолету.",
				Subtitle = "Этот модуль, созданный инженерами H.G. Corp., позволит вам расширить слоты вашего звездолета."
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPINVSUIT",
				Name = "Модуль расширения инвентаря экзокостюма",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам расширить слоты вашего костюма. Модуль добавит " + Suit_Inv_Slot + " слотов к вашему костюму.",
				Subtitle = "Этот модуль, созданный инженерами H.G. Corp., позволит вам расширить слоты вашего костюма."
			},
			new LanguageString () {
				Id = LanguageId.Russian,
				Language_Base = "CL_UPINVWEAP",
				Name = "Модуль расширения инвентаря мультитула",
				Description = "Этот модуль, созданный инженерами H.G. Corp., позволит вам расширить слоты вашего мультитула. Модуль добавит " + Weap_Inv_Slot + " слотов к вашему мультитулу.",
				Subtitle = "Этот модуль, созданный инженерами H.G. Corp., позволит вам расширить слоты вашего мультитула."
			},
		};
	}

	protected void AddProducts( Super_Upgrade_Module Super_Upgrade_Module )
	{
		var mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN");
		var custom_product = CloneMbin(mbin.Table.Find(PROD => PROD.ID == "SENTINEL_LOOT"));
		custom_product.ID = Super_Upgrade_Module.ID;
		custom_product.Icon.Filename = Super_Upgrade_Module.Icon_Path;

		custom_product.Name = Super_Upgrade_Module.Language_Base + "_NAME";
		custom_product.NameLower = Super_Upgrade_Module.Language_Base + "_NAME_LC";
		custom_product.Description = Super_Upgrade_Module.Language_Base + "_DESC";
		custom_product.Subtitle = Super_Upgrade_Module.Language_Base + "_SUB";
		
		custom_product.Cost.BuyBaseMarkup = 0;
		custom_product.Cost.BuyBaseMarkup = 0;
		custom_product.Cost.BuyMarkupMod = 0;
		custom_product.Cost.HighPriceMod = 0;
		custom_product.Cost.LowPriceMod = 0;
		custom_product.Cost.SpaceStationMarkup = 0;
		custom_product.BaseValue = Super_Upgrade_Module.Price;
		
		custom_product.Consumable = true;
		mbin.Table.Add(custom_product);
	}

	protected void AddConsumables( Super_Upgrade_Module Super_Upgrade_Module )
	{
		var mbin = ExtractMbin<GcConsumableItemTable>("METADATA/REALITY/TABLES/CONSUMABLEITEMTABLE.MBIN");
		var custom_consumable = CloneMbin(mbin.Table.Find(CONS => CONS.ID == "SENTINEL_LOOT"));
		custom_consumable.ID = Super_Upgrade_Module.ID;
		custom_consumable.RewardID = "R_" + Super_Upgrade_Module.ID;
		mbin.Table.Add(custom_consumable);
	}

	protected void AddRewards( Super_Upgrade_Module Super_Upgrade_Module )
	{
		var mbin = ExtractMbin<GcRewardTable>("METADATA/REALITY/TABLES/REWARDTABLE.MBIN"); ;
		var custom_reward = CloneMbin(mbin.DestructionTable.Find(REW => REW.Id == "DE_SENT_LOOT"));
		custom_reward.Id = "R_" + Super_Upgrade_Module.ID;
		custom_reward.List.List.Clear();
		custom_reward.List.List.Add(Super_Upgrade_Module.RewardTable_Item);
		mbin.GenericTable.Add(custom_reward);
	}

	protected void AddToStore( Super_Upgrade_Module Super_Upgrade_Module )
	{
		var mbin = ExtractMbin<GcRealityManagerData>("METADATA/REALITY/DEFAULTREALITY.MBIN");
		mbin.TradeSettings.SpaceStation.AlwaysPresentProducts.Add(Super_Upgrade_Module.ID);
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

//=============================================================================
