using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICommands : MonoBehaviour
{
    public GameObject HireWindow;

    public void OpenHireWindow()
    {
        HireWindow.SetActive(true);
    }
    public void CloseHireWindow()
    {
        HireManager.instance.clickedEmployee = null;
        HireManager.instance.clickedOwnedEmployee = null;
        HireWindow.SetActive(false);
    }

    void CloseAllWindows()
    {
        CloseHireWindow();
    }
}
