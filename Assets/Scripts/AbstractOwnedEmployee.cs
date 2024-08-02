using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractOwnedEmployee : MonoBehaviour
{
    public EmployeeStats myStats = null;
    public int myID = -1;

    public virtual void OnClick()
    {
        HireManager.instance.SwitchEmployees();
    }
}
