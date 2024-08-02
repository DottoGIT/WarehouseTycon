using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersManager : MonoBehaviour
{
    public static WorkersManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform spawnTransform;
    public GameObject workerPrefab;
    public List<Worker> workers;

    public void SpawnWorker(EmployeeStats stats)
    {
        GameObject obj = Instantiate(workerPrefab, spawnTransform);
        obj.GetComponent<Worker>().myStats = stats;
        workers.Add(obj.GetComponent<Worker>());
    }

    public void KillWorker(int id)
    {
        foreach (var worker in workers)
        {
            if(worker.myStats.id == id)
            {
                worker.Die();
                return;
            }
        }
    }

}
