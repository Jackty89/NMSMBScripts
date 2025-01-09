//=============================================================================
// Author: Jackty89
//=============================================================================

public class NoPortalCharge : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		var mbin                 = ExtractMbin<TkAttachmentData>("MODELS/PLANETS/BIOMES/COMMON/BUILDINGS/PORTAL/PORTAL/ENTITIES/BUTTON.ENTITY.MBIN");
		var item                 = mbin.Components[4].Template as GcMaintenanceComponentData;
		item.AutoCompleteOnStart = true;
	}

	//...........................................................
}

//=============================================================================
