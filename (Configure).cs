//=============================================================================
// Author: Jackty89
//=============================================================================

public class Global : cmk.NMS.Script.ModClass
{
    protected override void Execute()
    {
    	int choice = 1;
        switch (choice)
        {
            case 1:
                Execute<ExpeditionModList>();
                break;
            default:
                Execute<ModTest>();
                break;
        }
    }
}

//=============================================================================
