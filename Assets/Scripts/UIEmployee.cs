using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIEmployee : MonoBehaviour
{
    public int Id;
    [HideInInspector] public bool isOnCooldown { get; private set; }
    public float CooldownWait = 0;


    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtCost;
    public GameObject barSpeed;
    public GameObject barStamina;
    public GameObject barDiscipline;
    public GameObject Interest;
    public GameObject InterestAnchor;
    public RawImage InterestBar;
    public GameObject ActiveTab;

    public EmployeeStats myStats;

    private void Start()
    {
        RefreshStats();
        setOnActiveMode();
    }

    public void RefreshStats()
    {
        myStats = new EmployeeStats();
        myStats.RandomizeStats();

        txtName.text = myStats.name;
        txtCost.text = myStats.cost.ToString() + "$";
        barSpeed.transform.localScale = new Vector3((float)myStats.speed / 10, 1, 1);
        barStamina.transform.localScale = new Vector3((float)myStats.stamina / 10, 1, 1);
        barDiscipline.transform.localScale = new Vector3((float)myStats.discipline / 10, 1, 1);
    }

    public void OnClick()
    {
        if(isOnCooldown == false)
        {
            HireManager.instance.clickedEmployee = this;
            HireManager.instance.SwitchEmployees();
        }
    }
    public void OnFire()
    {
        HireManager.instance.SetOnCoolDown(Id);
    }

    public void setOnCooldownMode()
    {
        ActiveTab.SetActive(false);
        Interest.SetActive(true);
        isOnCooldown = true;
        CooldownWait = 0;
}
    public void setOnActiveMode()
    {
        ActiveTab.SetActive(true);
        Interest.SetActive(false);
        isOnCooldown = false;
        CooldownWait = 0;
    }
}
