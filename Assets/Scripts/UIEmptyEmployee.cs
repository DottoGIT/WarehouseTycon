using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEmptyEmployee : AbstractOwnedEmployee
{
    public override void OnClick()
    {
        myID = -1;
        HireManager.instance.clickedOwnedEmployee = this;
        base.OnClick();
    }
}
