using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingSpot : MonoBehaviour
{
    public bool isOccupied = false;
    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
