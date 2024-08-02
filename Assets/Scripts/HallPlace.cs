using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallPlace : MonoBehaviour
{
    public PlaceType myType;
    [SerializeField] private StandingSpot[] StandingSpots = null;

    void Start()
    {
        switch(myType)
        {
            case PlaceType.Work: 
                HallManager.instance.WorkPlaces.Add(this);
                break;
            case PlaceType.Rest:
                HallManager.instance.RestPlaces.Add(this);
                break;
        }
    }

    public bool HasFreeSpots()
    {
        foreach (var spot in StandingSpots)
        {
            if (spot.isOccupied == false)
                return true;
        }
        return false;
    }
    public StandingSpot GetFreeSpot()
    {
        foreach (var spot in StandingSpots)
        {
            if (spot.isOccupied == false)
            {
                return spot;
            }
        }
        Debug.LogError("I returned occupied spot!!! " + gameObject.name);
        return null;
    }
}
