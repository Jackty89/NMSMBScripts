//=============================================================================
// Author: Jackty89
//=============================================================================
public class RepeatInventoryExpansion : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		var mbin = ExtractMbin<TkAttachmentData>("MODELS/PLANETS/BIOMES/COMMON/BUILDINGS/PARTS/COMMONPARTS/CRYOCHAMBER/ENTITIES/CRYOCHAMBERINTERACTION.ENTITY.MBIN");
		var interactionComp = mbin.Components[2].Template as GcInteractionComponentData;
		interactionComp.RepeatInteraction        = true;
		interactionComp.ReseedAfterRewardSuccess = true;

		var triggerComp = mbin.Components[4].Template as GcTriggerActionComponentData;
		triggerComp.States.RemoveAt(2);
	}
}
