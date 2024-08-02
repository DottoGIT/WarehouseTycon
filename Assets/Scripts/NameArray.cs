using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NameArray
{
    static string[] maleNames = { 
        "Liam",
        "Noah",
        "Olivier",
        "Elijah",
        "William",
        "James",
        "Benjamin",
        "Lucas",
        "Henry",
        "Alexander"
    };

    static string[] femaleNames = {
        "Olivia",
        "Emma",
        "Ava",
        "Charlotte",
        "Sophia",
        "Amelia",
        "Isabella",
        "Mia",
        "Evelyn",
        "Harper"
    };

    public static string getRandomName(bool isMale)
    {
        string name = "";
        if (isMale) name = maleNames[Random.Range(0,maleNames.Length)];
        else name = femaleNames[Random.Range(0, femaleNames.Length)];

        return name;
    }
}
