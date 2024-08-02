using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIOwnedEmployee : AbstractOwnedEmployee
{
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtCost;
    public GameObject barSpeed;
    public GameObject barStamina;
    public GameObject barDiscipline;

    public void UpdateStats()
    {
        txtName.text = myStats.name;
        txtCost.text = myStats.cost.ToString() + "$";
        barSpeed.transform.localScale = new Vector3((float)myStats.speed / 10, 1, 1);
        barStamina.transform.localScale = new Vector3((float)myStats.stamina / 10, 1, 1);
        barDiscipline.transform.localScale = new Vector3((float)myStats.discipline / 10, 1, 1);
    }

    public override void OnClick()
    {
        HireManager.instance.clickedOwnedEmployee = this;
        base.OnClick();
    }

    public void OnFire()
    {
        WorkersManager.instance.KillWorker(myStats.id);
        HireManager.instance.HiredWorkers.RemoveAt(myID);
        HireManager.instance.UpdateEmployees();
    }
}
