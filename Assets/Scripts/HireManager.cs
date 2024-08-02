using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HireManager : MonoBehaviour
{
    public static HireManager instance;

    private void Awake()
    {
        instance = this;
    }

    int workerIndex = 0;
    public Color green;
    public Color yellow;
    public Color red;
    public GameObject EmptyEmployeePrefab;
    public GameObject EmployeePrefab;
    public GameObject OwnedEmployeePrefab;
    public GameObject ScrollArea;
    public GameObject fullMark;
    public TextMeshProUGUI txtOverallCost;
    public TextMeshProUGUI txtWorkerCounter;

    public UIEmployee[] AvailableWorkers = null;
    public List<EmployeeStats> HiredWorkers = new List<EmployeeStats>();

    [HideInInspector] public UIEmployee clickedEmployee = null;
    [HideInInspector] public AbstractOwnedEmployee clickedOwnedEmployee = null;

    private void Update()
    {
        LookForFullIcon();
    }

    public void SwitchEmployees()
    {
        if (clickedEmployee != null && clickedOwnedEmployee != null)
        {
            clickedEmployee.myStats.id = workerIndex;
            workerIndex++;
            HiredWorkers.Add(clickedEmployee.myStats);

            WorkersManager.instance.SpawnWorker(clickedEmployee.myStats);

            if (clickedOwnedEmployee.myID >= 0)
            {
                WorkersManager.instance.KillWorker(HiredWorkers[clickedOwnedEmployee.myID].id);
                HiredWorkers.RemoveAt(clickedOwnedEmployee.myID);
            }
            SetOnCoolDown(clickedEmployee.Id);

            clickedOwnedEmployee = null;
            clickedEmployee = null;
            UpdateEmployees();
        }
    }

    private void Start()
    {
        UpdateEmployees();
    }

    void LookForFullIcon()
    {
        for(int i = 0; i < AvailableWorkers.Length; i++)
        {
            if(AvailableWorkers[i].isOnCooldown)
            {
                fullMark.SetActive(false);
                return;
            }
            fullMark.SetActive(true);
        }
    }

    public void UpdateEmployees()
    {
        foreach (Transform child in ScrollArea.transform)
        {
            Destroy(child.gameObject);
        }

        int emptyToAdd = HallManager.instance.GetMaxWorkers() - HiredWorkers.Count;

        for (int i = 0; i < emptyToAdd; i++)
        {
            Instantiate(EmptyEmployeePrefab, ScrollArea.transform);
        }

        int index = 0;
        int overallCost = 0;
        foreach (var worker in HiredWorkers)
        {
            GameObject obj = Instantiate(OwnedEmployeePrefab, ScrollArea.transform);
            obj.GetComponent<UIOwnedEmployee>().myStats = worker;
            obj.GetComponent<UIOwnedEmployee>().myID = index;
            overallCost += worker.cost;
            obj.GetComponent<UIOwnedEmployee>().UpdateStats();
            

            index++;
        }

        txtOverallCost.text = overallCost.ToString() + "$/h";
        txtWorkerCounter.text = HiredWorkers.Count.ToString() + "/" + HallManager.instance.GetMaxWorkers().ToString();

        int height = HallManager.instance.GetMaxWorkers() * 22;

        RectTransform rect = ScrollArea.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(50, height);

    }

    public void SetOnCoolDown(int id)
    {
        UIEmployee emp = AvailableWorkers[id];
        emp.setOnCooldownMode();
        emp.RefreshStats();
        StartCoroutine(EmployeeCoolDown(emp));
    }

    IEnumerator EmployeeCoolDown(UIEmployee emp)
    {
        while(emp.CooldownWait <= HallManager.instance.employeeCooldown)
        {
            emp.CooldownWait += Time.deltaTime;
            emp.InterestAnchor.transform.localScale = new Vector3(1-(float) emp.CooldownWait/HallManager.instance.employeeCooldown ,1,1);

            if (1 - (float)emp.CooldownWait / HallManager.instance.employeeCooldown < 0.33f) emp.InterestBar.color = green;
            else if (1 - (float)emp.CooldownWait / HallManager.instance.employeeCooldown < 0.66f) emp.InterestBar.color = yellow;
            else emp.InterestBar.color = red;

            yield return null;
        }

        emp.setOnActiveMode();
    }
}
