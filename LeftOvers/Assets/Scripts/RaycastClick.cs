using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    public GameObject lastClickedUnit;

    void Update()
    {
        RaycastClicked();
    }

    public void RaycastClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Unit")
                {
                    if(lastClickedUnit == null)
                    {
                        lastClickedUnit = hit.transform.gameObject;
                    }
                    if (lastClickedUnit.GetComponent<Unit>().attacking == false)
                    {
                        lastClickedUnit = hit.transform.gameObject;
                        lastClickedUnit.GetComponent<Unit>().ClickOnUnit();
                    }
                    else
                    {
                        lastClickedUnit.GetComponent<Unit>().Attacking(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}
