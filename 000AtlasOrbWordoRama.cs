//=============================================================================
// Author: Jackty89
//=============================================================================


public class AtlasOrbWordoRama : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		var mbin_to_overwrite = ExtractMbin<TkAttachmentData>("MODELS/SPACE/ATLASSTATION/MODULARPARTS/INTERIOR/PATHORB/PATHORB_DUMMY/ENTITIES/ORBSTONE_DUMMY.ENTITY.MBIN");
		var mbin_to_copy_from = ExtractMbinNoCache<TkAttachmentData>("MODELS/SPACE/ATLASSTATION/MODULARPARTS/INTERIOR/PATHORB/PATHORB/ENTITIES/ORBSTONE_1.ENTITY.MBIN");
		var copy_components = mbin_to_copy_from.Components;

		mbin_to_overwrite.Components.Clear();
		mbin_to_overwrite.Components.AddRange(copy_components);
	}
}

