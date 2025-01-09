//=============================================================================
// Author: Jackty89
//=============================================================================

public class SupportPackets : cmk.NMS.Script.ModClass
{
	readonly GcInventoryType Product   = new GcInventoryType { InventoryType = InventoryTypeEnum.Product };
	readonly GcInventoryType Substance = new GcInventoryType { InventoryType = InventoryTypeEnum.Substance };

	protected class LanguageString
	{
		public LanguageId Id;
		public string LanguageBase;
		public string Name;
		public string Description;
		public string Subtitle;
	}

	protected class SupportPacket
	{
		public string ID;
		public int StackSize;
		public int Price;
		public int RecipeCost;
		public string IconPath;
		public string LanguageBase;
		public GcRewardTableItem RewardTableItem = new();
		public List<GcTechnologyRequirement> Requirements;
	}

	List<SupportPacket> SupportPacketList = new List<SupportPacket>(){};

	List<LanguageString> LanguageStringList = new List<LanguageString> ()
	{
		new LanguageString () {
			Id = LanguageId.English,
			LanguageBase = "HEALTH_PACK",
			Name = "Health Package",
			Description = "This health package engineered by the engineers at H.G. Corp. will restore you back to full health.",
			Subtitle = "Health Package"
		},
		new LanguageString () {
			Id = LanguageId.English,
			LanguageBase = "SHIELD_PACK",
			Name = "Shield Package",
			Description = "This shield package engineered by the engineers at H.G. Corp. will restore your shield back to full capacity.",
			Subtitle = "Shield Package"
		},
		new LanguageString () {
			Id = LanguageId.English,
			LanguageBase = "JET_BOOST_PACK",
			Name = "Jet Boost Package",
			Description = "This Jetboost package engineered by the engineers at H.G. Corp. will grant you a jetpack boost for &lt;TECHNOLOGY&gt; 600 seconds&lt;&gt;",
			Subtitle = "Jet Boost Package"
		},
		new LanguageString () {
			Id = LanguageId.English,
			LanguageBase = "HAZARD_PACK",
			Name = "Hazard Package",
			Description = "This Hazard package engineered by the engineers at H.G. Corp. will restore your hazard protection battery.",
			Subtitle = "Hazard Package"
		},
		new LanguageString () {
			Id = LanguageId.English,
			LanguageBase = "ENERGY_PACK",
			Name = "Energy Package",
			Description = "This energy package engineered by the engineers at H.G. Corp. will restore your lifesupport system.",
			Subtitle = "Energy Package"
		},
		new LanguageString () {
			Id = LanguageId.USEnglish,
			LanguageBase = "HEALTH_PACK",
			Name = "Health Package",
			Description = "This health package engineered by the engineers at H.G. Corp. will restore you back to full health.",
			Subtitle = "Health Package"
		},
		new LanguageString () {
			Id = LanguageId.USEnglish,
			LanguageBase = "SHIELD_PACK",
			Name = "Shield Package",
			Description = "This shield package engineered by the engineers at H.G. Corp. will restore your shield back to full capacity.",
			Subtitle = "Shield Package"
		},
		new LanguageString () {
			Id = LanguageId.USEnglish,
			LanguageBase = "JET_BOOST_PACK",
			Name = "Shield Package",
			Description = "This Jetboost package engineered by the engineers at H.G. Corp. will grant you a jetpack boost for &lt;TECHNOLOGY&gt; 600 seconds&lt;&gt;",
			Subtitle = "Shield Package"
		},
		new LanguageString () {
			Id = LanguageId.USEnglish,
			LanguageBase = "HAZARD_PACK",
			Name = "Hazard Package",
			Description = "This Hazard package engineered by the engineers at H.G. Corp. will restore your hazard protection battery.",
			Subtitle = "Hazard Package"
		},
		new LanguageString () {
			Id = LanguageId.USEnglish,
			LanguageBase = "ENERGY_PACK",
			Name = "Energy Package",
			Description = "This energy package engineered by the engineers at H.G. Corp. will restore your lifesupport system.",
			Subtitle = "Energy Package"
		}
	};
	
	protected override void Execute()
	{
		FillList();
		AddLanguageStrings();
		foreach ( SupportPacket supportPacket in SupportPacketList )
		{
			AddProducts(supportPacket);
			AddConsumables(supportPacket);
			AddRewards(supportPacket);
			AddToStore(supportPacket);
		};
	}
	protected void FillList()
	{
		SupportPacketList = new List<SupportPacket>()
		{
			new SupportPacket
			{
				ID = "HEALTH_PACK",
				StackSize = 10,
				Price = 1500,
				RecipeCost = 2,
				IconPath = "TEXTURES/UI/HUD/ICONS/PICKUPS/PICKUP.HEALTH.DDS",
				LanguageBase = "HEALTH_PACK",
				RewardTableItem = RewardTableItem.Health(),
				Requirements = new List<GcTechnologyRequirement>{
					new GcTechnologyRequirement { ID = "MICROCHIP", Type = Product , Amount = 1},
					new GcTechnologyRequirement { ID = "ROBOT1", Type = Substance , Amount = 100},
					new GcTechnologyRequirement { ID = "FUEL2", Type = Substance, Amount = 500}
				}
			},
			new SupportPacket
			{
				ID = "SHIELD_PACK",
				StackSize = 10,
				Price = 1500,
				RecipeCost = 2,
				IconPath = "TEXTURES/UI/HUD/ICONS/PICKUPS/PICKUP.SHIELD.DDS",
				LanguageBase = "SHIELD_PACK",
				RewardTableItem = RewardTableItem.Shield(),
				Requirements = new List<GcTechnologyRequirement> {
					new GcTechnologyRequirement { ID = "MICROCHIP", Type = Product , Amount = 1},
					new GcTechnologyRequirement { ID = "ROBOT1", Type = Substance , Amount = 100},
					new GcTechnologyRequirement { ID = "FUEL2", Type = Substance, Amount = 500}
				}
			},
			new SupportPacket
			{
				ID = "JET_BOOST_PACK",
				StackSize = 10,
				Price = 1500,
				RecipeCost = 2,
				IconPath = "TEXTURES/UI/HUD/ICONS/PICKUPS/PICKUP.FUEL.DDS",
				LanguageBase = "JET_BOOST_PACK",
				RewardTableItem = RewardTableItem.JetPackBoost(DURATION: 600),
				Requirements = new List<GcTechnologyRequirement> {
					new GcTechnologyRequirement { ID = "MICROCHIP", Type = Product , Amount = 1},
					new GcTechnologyRequirement { ID = "ROBOT1", Type = Substance , Amount = 100},
					new GcTechnologyRequirement { ID = "FUEL2", Type = Substance, Amount = 500}
				}
			},
			new SupportPacket
			{
				ID = "HAZARD_PACK",
				StackSize = 10,
				Price = 1500,
				RecipeCost = 2,
				IconPath = "TEXTURES/UI/HUD/ICONS/PICKUPS/PICKUP.PROTECTION.DDS",
				LanguageBase = "HAZARD_PACK",
				RewardTableItem = RewardTableItem.Hazard(),
				Requirements = new List<GcTechnologyRequirement> {
					new GcTechnologyRequirement { ID = "MICROCHIP", Type = Product , Amount = 1},
					new GcTechnologyRequirement { ID = "ROBOT1", Type = Substance , Amount = 100},
					new GcTechnologyRequirement { ID = "FUEL2", Type = Substance, Amount = 500}
				}
			},
			new SupportPacket
			{
				ID = "ENERGY_PACK",
				StackSize = 10,
				Price = 1500,
				RecipeCost = 2,
				IconPath = "TEXTURES/UI/HUD/ICONS/PICKUPS/PICKUP.LIFESUPPORT.DDS",
				LanguageBase = "ENERGY_PACK",
				RewardTableItem = RewardTableItem.Energy(),
				Requirements = new List<GcTechnologyRequirement> {
					new GcTechnologyRequirement { ID = "MICROCHIP", Type = Product , Amount = 1},
					new GcTechnologyRequirement { ID = "ROBOT1", Type = Substance , Amount = 100},
					new GcTechnologyRequirement { ID = "FUEL2", Type = Substance, Amount = 500}
				}
			}
		};
	}

		protected void AddProducts( SupportPacket supportPacket )
	{
		var mbin = ExtractMbin<GcProductTable>("METADATA/REALITY/TABLES/NMS_REALITY_GCPRODUCTTABLE.MBIN");
		var custom_product = CloneMbin(mbin.Table.Find(PROD => PROD.ID == "SENTINEL_LOOT"));
		custom_product.ID = supportPacket.ID;
		custom_product.Icon.Filename = supportPacket.IconPath;

		custom_product.Name = supportPacket.LanguageBase + "_NAME";
		custom_product.NameLower = supportPacket.LanguageBase + "_NAME_LC";
		custom_product.Description = supportPacket.LanguageBase + "_DESC";
		custom_product.Subtitle = supportPacket.LanguageBase + "_SUB";
		
		custom_product.Cost.BuyBaseMarkup = 0;
		custom_product.Cost.BuyBaseMarkup = 0;
		custom_product.Cost.BuyMarkupMod = 0;
		custom_product.Cost.HighPriceMod = 0;
		custom_product.Cost.LowPriceMod = 0;
		custom_product.Cost.SpaceStationMarkup = 0;
		custom_product.BaseValue = supportPacket.Price;
		
		custom_product.RecipeCost = supportPacket.RecipeCost;
		custom_product.Requirements.Clear();
		custom_product.Requirements = supportPacket.Requirements;
		custom_product.Consumable = true;
		custom_product.IsCraftable = true;
		mbin.Table.Add(custom_product);

	}
	protected void AddConsumables( SupportPacket supportPacket )
	{
		var mbin = ExtractMbin<GcConsumableItemTable>("METADATA/REALITY/TABLES/CONSUMABLEITEMTABLE.MBIN");
		var custom_consumable = CloneMbin(mbin.Table.Find(CONS => CONS.ID == "SENTINEL_LOOT"));
		custom_consumable.ID = supportPacket.ID;
		custom_consumable.RewardID = "R_" + supportPacket.ID;
		mbin.Table.Add(custom_consumable);
	}
	protected void AddRewards(SupportPacket supportPacket)
	{
		var mbin = ExtractMbin<GcRewardTable>("METADATA/REALITY/TABLES/REWARDTABLE.MBIN"); ;
		var custom_reward = CloneMbin(mbin.DestructionTable.Find(REW => REW.Id == "DE_SENT_LOOT"));
		custom_reward.Id = "R_" + supportPacket.ID;
		custom_reward.List.List.Clear();
		custom_reward.List.List.Add(supportPacket.RewardTableItem);
		mbin.GenericTable.Add(custom_reward);
	}
	protected void AddToStore(SupportPacket supportPacket)
	{
		var mbin = ExtractMbin<GcRealityManagerData>("METADATA/REALITY/DEFAULTREALITY.MBIN");
		mbin.TradeSettings.SpaceStation.AlwaysPresentProducts.Add(supportPacket.ID);
	}

	protected void AddLanguageStrings()
	{
		foreach ( LanguageString language_string_item in LanguageStringList )
		{
			string description_id = language_string_item.LanguageBase + "_DESC";
			string name_id = language_string_item.LanguageBase + "_NAME";
			string name_lc_id = language_string_item.LanguageBase + "_NAME_LC";
			string sub_id = language_string_item.LanguageBase + "_SUB";

			SetLanguageText(language_string_item.Id, description_id, language_string_item.Description);
			SetLanguageText(language_string_item.Id, name_id, language_string_item.Name);
			SetLanguageText(language_string_item.Id, name_lc_id, language_string_item.Name);
			SetLanguageText(language_string_item.Id, sub_id, language_string_item.Subtitle);

		}
	}
}

//=============================================================================
