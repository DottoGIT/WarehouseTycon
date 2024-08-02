using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickManager : MonoBehaviour
{
    IInteractable focusOnObject;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform is IInteractable)
            {
                IInteractable obj = (IInteractable)hit.transform;
                obj.HighLight();
            }
        }
    }

}
