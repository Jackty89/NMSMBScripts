//=============================================================================

public class FrigateTimerReduction : cmk.NMS.Script.ModClass
{
    public float  Multiplier = 0.1f;
    protected override void Execute()
    {
        GcFleetGlobals();
    }

    protected void GcFleetGlobals()
    {
        var mbin = ExtractMbin<GcFleetGlobals>("GCFLEETGLOBALS.GLOBAL.MBIN");

        mbin.TimeTakenForExpeditionEvent_Easy = (int)(Multiplier * mbin.TimeTakenForExpeditionEvent_Easy);
        mbin.TimeTakenForExpeditionEvent      = (int)(Multiplier * mbin.TimeTakenForExpeditionEvent);
    }
}