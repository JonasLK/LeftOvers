using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    public GameObject lastClickedUnit;

    void Start()
    {

    }

    void Update()
    {
        RaycastClicked();
    }

    public void RaycastClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("0");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                print("1");
                if (hit.transform.gameObject.tag == "Unit")
                {
                    print("2");
                    if (lastClickedUnit.GetComponent<Unit>().attacking == false)
                    {
                        print("3");
                        lastClickedUnit = hit.transform.gameObject;
                        lastClickedUnit.GetComponent<Unit>().ClickOnUnit();
                    }
                    else
                    {
                        print("4");
                        lastClickedUnit.GetComponent<Unit>().Attacking(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}
