using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeStats
{
    public int id;
    public string name;
    public bool isMale;
    public int cost;
    public int speed;
    public int stamina;
    public int discipline;

    public void RandomizeStats()
    {
        if (Random.Range(0, 3) > 0) isMale = true;
        else isMale = false;
        name = NameArray.getRandomName(isMale);
        cost = Random.Range(5, 20);
        speed = Random.Range(1, 10);
        stamina = Random.Range(1, 10);
        discipline = Random.Range(1, 10);
    }
}
