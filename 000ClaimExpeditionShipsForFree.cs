//=============================================================================
// Author: Jackty89
//=============================================================================

public class ClaimExpeditionShipsForFree : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		//Can be found with regex in NMSMB RS_S.*_SHIP
		var ship_id_regex = "RS_S*_SHIP".CreateRegex();
		//List<string> ship_id_array = new List<string>(){ "RS_S1_SHIP", "RS_S9_SHIP",  "RS_S12_SHIP", "RS_S13_SHIP"};
		var mbin = ExtractMbin<GcRewardTable>("METADATA/REALITY/TABLES/REWARDTABLE.MBIN");

		var ListGcGenericRewardTableEntry_t = typeof(List<GcGenericRewardTableEntry>);
		foreach( var field in mbin.GetType().GetFields() ) {

			if( field.FieldType != ListGcGenericRewardTableEntry_t ) continue;
			var reward_table_entry_list = field.GetValue(mbin) as List<GcGenericRewardTableEntry>;

			var reward_item = reward_table_entry_list.FindFirst(REWARD => ship_id_regex.IsMatch(REWARD.Id));
			if( reward_item != null ) {
				var ship = reward_item.List.List[0].Reward as GcRewardSpecificShip;
				ship.CostAmount = 0;
				ship.CostCurrency.Currency = CurrencyEnum.Units;
			}
		}
	}
}