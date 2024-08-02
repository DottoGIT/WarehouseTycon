using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallManager : MonoBehaviour
{
    public static HallManager instance;
    
    private void Awake()
    {
        instance = this;
    }

    public int employeeCooldown;

    public List<HallPlace> WorkPlaces;
    public List<HallPlace> RestPlaces;

    public int GetMaxWorkers()
    {
        int maxWorkers = 0;

        StandingSpot[] standingSpots = FindObjectsOfType<StandingSpot>();
        foreach (var spot in standingSpots)
        {
            if (spot.gameObject.CompareTag("RestPlace")) maxWorkers++;
        }

        return maxWorkers;
    }


    public WorkPlace GetFreeWorkPlace()
    {
        foreach (var place in WorkPlaces)
        {
            if (place.HasFreeSpots())
            {
                return place as WorkPlace;
            }
        }
        return null;
    }

    public RestPlace GetFreeRestPlace()
    {
        foreach (var place in RestPlaces)
        {
            if (place.HasFreeSpots())
            {
                return place as RestPlace;
            }
        }
        Debug.LogError("More employees than possible " + gameObject.name);
        return null;
    }

}
