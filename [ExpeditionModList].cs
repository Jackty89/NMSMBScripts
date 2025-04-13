//=============================================================================

public class ExpeditionModList : cmk.NMS.Script.ModClass
{
     protected override void Execute()
     {
        bool enableCustomModsGalore                                 = true;
        bool runSandXonly                                           = true;
        bool balancedInventory                                      = true;
        bool noShipStart                                            = false;
        bool uninstallExtraTech                                     = false;

        Script<AddDerelictFreighterLootToStore>().IsExecutable      = true;
        Script<AddExpeditionTech>().IsExecutable                    = false;
        Script<AddNewFoods>().IsExecutable                          = false;
        Script<AtlasOrbWordoRama>().IsExecutable                    = true;

        Script<BasePartsDeluxe>().IsExecutable                      = !noShipStart; // included in NoShipStart
        Script<BurnBabyBurn>().IsExecutable                         = !enableCustomModsGalore; // CMG also adds incinerator
        Script<CheapPetSlots>().IsExecutable                        = true;
		Script<ClaimExpeditionShipsForFree>().IsExecutable          = true;
		Script<CleanMultiplayer>().IsExecutable                     = true;
        Script<CraftableAlienToken>().IsExecutable                  = false;
        Script<CraftableWiringLoom>().IsExecutable                  = false;
        Script<CraftableEmergencySignalScanner>().IsExecutable      = false;
    	Script<CraftableModules>().IsExecutable                     = false;
        Script<CraftableModulesPersonal>().IsExecutable             = true;
		
        Script<CraftableUpgradeMods_OLD>().IsExecutable             = false;
        Script<CraftableUpgradeModsSandXonly_OLD>().IsExecutable    = false;

        var CraftableUpgradeMods = Script<CraftableUpgradeMods>();
        CraftableUpgradeMods.IsExecutable                           = !runSandXonly;
        CraftableUpgradeMods.RecipeCostPriceMultiplier              = 1; // make into a float

        var CraftableUpgradeModsSandXonly = Script<CraftableUpgradeModsSandXonly>();
        CraftableUpgradeModsSandXonly.IsExecutable                  = runSandXonly;
        CraftableUpgradeModsSandXonly.RecipeCostPriceMultiplier     = 1;
        
        
        var CustomModsGalore = Script<CustomModsGalore>();
        CustomModsGalore.IsExecutable                               = enableCustomModsGalore;
        if (runSandXonly)
        {
            CustomModsGalore.MinProcModLimit                        = 4;
            CustomModsGalore.RecipeCostPriceMultiplier              = 1;
        }

        Script<CustomDebugOptions>().IsExecutable                   = false;
        Script<CustomDescriptions>().IsExecutable                   = false;

        var  DerelictSpeedIncrease = Script<DerelictSpeedIncrease>();
        DerelictSpeedIncrease.IsExecutable                          = true;
        DerelictSpeedIncrease.SpeedMultiplier                       = 0.5f;

        var EqualPlantTimers = Script<EqualPlantTimers>();
        EqualPlantTimers.IsExecutable                               = true;
        EqualPlantTimers.HarvestAmount                              = 250;
        EqualPlantTimers.PlantTimer                                 = 3600; // time in seconds => 60 min

        var ExocraftRechargeRate = Script<ExocraftRechargeRate>();
        ExocraftRechargeRate.IsExecutable                           = true;
        ExocraftRechargeRate.RechargeRate                           = 15f;

        Script<ExtendedExocraftAndShipScanner>().IsExecutable       = true;
        Script<FishingSpeed>().IsExecutable       					= true;
        var FrigateTimerReduction = Script<FrigateTimerReduction>();
        FrigateTimerReduction.IsExecutable                          = true;
        FrigateTimerReduction.Multiplier                            = 0.1f;
        Script<FuelEconomy>().IsExecutable                          = true;
        Script<GalaxyMapUpgrade>().IsExecutable                     = false;

        //Inventory Edits
        Script<InventoryRebalance>().IsExecutable                   = balancedInventory;
        Script<InventoryUnbalance>().IsExecutable                   = false;

        Script<KeepTalkingChef>().IsExecutable                      = true;

        var LearnMoreWords = Script<LearnMoreWords>();
        LearnMoreWords.IsExecutable                                 = true;
        LearnMoreWords.AddWordsTotal                                = 20;
        LearnMoreWords.PercentageChance                             = 100;
        
        var LivingShipReducedTimer = Script<LivingShipReducedTimer>();
        LivingShipReducedTimer.IsExecutable                         = true;
        LivingShipReducedTimer.Multiplier                           = 0.001f;

        Script<MaxUpgradeFreighterSlotAllClasses>().IsExecutable    = true;
        Script<MaxUpgradeFreighterSlotAllClasses48>().IsExecutable  = false;
        Script<MoreAndCheaperStarMaps>().IsExecutable               = true;

        var MoreSalvageData = Script<MoreSalvageData>();
        MoreSalvageData.IsExecutable                                = true;
        MoreSalvageData.Min                                         = 5;
        MoreSalvageData.Max                                         = 15;

        Script<NoLadderAutoGrab>().IsExecutable                     = true;
        Script<NoPortalCharge>().IsExecutable                       = true;
        
        Script<NoAtmoNoDustAndFog>().IsExecutable                   = true;
        Script<NoShipStart>().IsExecutable                          = noShipStart;
        Script<PickUpGeoBays>().IsExecutable                        = !noShipStart; // this is already included in NoShipStart

        var PirateTimerRedux = Script<PirateTimerRedux>();
        PirateTimerRedux.IsExecutable                               = true;
        PirateTimerRedux.Multiplier                                 = 3;

        Script<QuickSilverRewards>().IsExecutable                   = false;
        
        Script<RealisticTimers>().IsExecutable                      = false;

        Script<ReducedPulseSpeedLines>().IsExecutable               = true;
        Script<RepeatInventoryExpansion>().IsExecutable             = true;

        //SettlementTimerReduction Edits
        var SettlementTimerReduction = Script<SettlementTimerReduction>();
        SettlementTimerReduction.IsExecutable                       = true;
        SettlementTimerReduction.Multiplier                         = 0.25f;  // 25% of vanilla value

        Script<ShipStore>().IsExecutable                            = false;
        Script<ShipStoreV2>().IsExecutable                          = true;
        Script<ShipStoreV3_WIP>().IsExecutable                      = false;


        // CoreMissionEdits might not be necessary, DEBUG options edits work just fine

        var SlotMaster = Script<SlotMaster>();
        SlotMaster.IsExecutable                                     = true;
        SlotMaster.ImproveShip                                      = false;
        SlotMaster.ImproveWeapon                                    = false;
        SlotMaster.ImproveVehicle                                   = false; // Already in unique exocrafts
        SlotMaster.ImproveAlien                                     = true;
        SlotMaster.ImproveInventory                                 = false;
        SlotMaster.ImproveFreighter                                 = false;
        
        Script<SuperUpgradeModuleOptions>().IsExecutable            = true;
        Script<SupportPackets>().IsExecutable                       = true;

        Script<SustainAbility>().IsExecutable                       = true;
        Script<TaintedMetalCrafting>().IsExecutable                 = true;
        Script<TurretsDoDamage>().IsExecutable                      = true;
        
        var UninstallCoreWeapons = Script<UninstallCoreWeapons>();
        UninstallCoreWeapons.IsExecutable                           = true;
        UninstallCoreWeapons.UninstallExtra                         = uninstallExtraTech;
        
        Script<UniqueExocrafts>().IsExecutable                      = true;
        Script<UniqueSpaceShips>().IsExecutable                     = true;
        Script<InstantActions>().IsExecutable                       = true;
        Script<InstantTextDisplay>().IsExecutable                   = true;

        var InstantScan = Script<InstantScan>();
        InstantScan.IsExecutable                                    = true;
        InstantScan.ScanTime                                        = 0f;

        Script<SpawnRateForClasses>().IsExecutable                  = false; // has effect on Seed value so won't use
        
        var FastRefiners = Script<FastRefiners>();
        FastRefiners.IsExecutable                                   = true;
        FastRefiners.TimeToMake                                     = 1f;
        
		Script<AntiOphidiophobia>().IsExecutable                    = false;
    }

    //..............PickUpGeoBaysAndHarvesters.............................................
}

//=============================================================================
