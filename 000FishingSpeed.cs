//=============================================================================

public class FishingSpeed : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		var mbin = ExtractMbin<GcFishingGlobals>(
			"GCFISHINGGLOBALS.GLOBAL.MBIN"
		);
		 mbin.ChaseTimes[(int)GcFishSize.FishSizeEnum.Small]= 0.1f;
		 mbin.ChaseTimes[(int)GcFishSize.FishSizeEnum.Medium]= 0.1f;
		 mbin.ChaseTimes[(int)GcFishSize.FishSizeEnum.Large]= 0.1f;
		 mbin.ChaseTimes[(int)GcFishSize.FishSizeEnum.ExtraLarge]= 0.1f;
		 
		 mbin.FishCatchAfterBiteTime = 10;
		 mbin.LandTimeBegin = 0.05f;
		 mbin.LandTimeEnd = 0.25f;
		 mbin.LineNibbleSag = 1;
		 mbin.MinWaitTime = 0.5f;
		 mbin.LineNibbleSag = 1;
	}

	//...........................................................
}

//=============================================================================
