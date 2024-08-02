using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker : MonoBehaviour, IInteractable
{
    [SerializeField] WorkerStance myStance;

    float stamina = 100;
    public EmployeeStats myStats = null;

    NavMeshAgent myNav;
    StandingSpot mySpot;

    private void Start()
    {
        myNav = GetComponent<NavMeshAgent>();
        myStance = WorkerStance.Waiting;
    }

    private void Update()
    {
        /// STAMINA MANAGEMENT ///
        if (myStance == WorkerStance.Working)
        {
            stamina -= (11 - myStats.stamina) * Time.deltaTime;
            if (stamina < 0) stamina = 0;
        }
        else if (myStance == WorkerStance.Resting)
        {
            stamina += myStats.stamina * Time.deltaTime;
            if (stamina > 100) stamina = 100;
        }

        if (myStance != WorkerStance.Going)
        {
            if (stamina <= 0)
            {
                GoRest();
            }
            if (stamina >= 100 && myStance != WorkerStance.Working)
            {
                GoWork();
            }
        }
    }

    void GoRest()
    {
        FreeMySpot();
        myStance = WorkerStance.Going;
        HallPlace restToGo = HallManager.instance.GetFreeRestPlace();

        mySpot = restToGo.GetFreeSpot();
        myNav.SetDestination(mySpot.GetPosition());
        mySpot.isOccupied = true;
    }
    void GoWork()
    {
        if (HallManager.instance.GetFreeWorkPlace() == null) return;

        FreeMySpot();
        myStance = WorkerStance.Going;
        HallPlace workToGo = HallManager.instance.GetFreeWorkPlace();

        mySpot = workToGo.GetFreeSpot();
        myNav.SetDestination(mySpot.GetPosition());
        mySpot.isOccupied = true;

    }
    void FreeMySpot()
    {
        if(mySpot != null)
        {
            mySpot.isOccupied = false;
            mySpot = null;
        }
    }

    public void Die()
    {
        FreeMySpot();
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("RestPlace") && myNav.remainingDistance == 0)
        {
            myStance = WorkerStance.Resting;
        }
        if (other.CompareTag("WorkPlace") && myNav.remainingDistance == 0)
        {
            myStance = WorkerStance.Working;
        }
    }

    public void Selected()
    {
        throw new System.NotImplementedException();
    }

    public void HighLight()
    {
        Debug.Log("Hello");
    }
}
