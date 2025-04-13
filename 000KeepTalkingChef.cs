//=============================================================================
// Author: Jackty89
//=============================================================================

public class KeepTalkingChef : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		var mbin = ExtractMbin<GcAlienPuzzleTable>("METADATA/REALITY/TABLES/NMS_DIALOG_GCALIENPUZZLETABLE.MBIN");
		string [] id_list = {"?CHEF_JUDGE1", "?CHEF_JUDGE2", "?CHEF_JUDGE3"};
		foreach (string id in id_list)
		{
			var allOptions = mbin.Table.FindAll(ID => ID.Id == id);
			foreach(var options in allOptions)
			{
				foreach(var option in options.Options)
				{
					Log.Information($"option.Name = {option.Name}");
					Log.Information($"option.Cost = {option.Cost}");
					if(option.Cost == "C_NEXUSCHEF1" || option.Cost == "C_NEXUSCHEF2" || option.Cost == "C_NEXUSCHEF3")
					{
						Log.Information($"option.KeepOpen = {option.KeepOpen}");
						option.KeepOpen = true;
					}
				}
			}
		}
		
	}
}

//=============================================================================
