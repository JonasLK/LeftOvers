using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    public GameObject lastClickedFriendlyUnit;

    private TurnTracker turnTracker;
    private TestSpawnUnit testSpawnUnit;

    public void Start()
    {
        turnTracker = GetComponent<TurnTracker>();
        testSpawnUnit = GetComponent<TestSpawnUnit>();
    }

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
                    if(hit.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber == turnTracker.playerTurn)
                    {
                        lastClickedFriendlyUnit = hit.transform.gameObject;
                        lastClickedFriendlyUnit.GetComponent<Unit>().ClickOnUnit();
                    }
                    else if(lastClickedFriendlyUnit.GetComponent<Unit>().attacking == true)
                    {
                        lastClickedFriendlyUnit.GetComponent<Unit>().Attacking(hit.transform.gameObject);
                    }
                }

                if (hit.transform.gameObject.tag == "tile")
                {
                    if(hit.transform.gameObject.GetComponent<TestTileCalculator>().teamStartTile == turnTracker.playerTurn && testSpawnUnit.placingUnit == true)
                    {
                        testSpawnUnit.SpawnUnit(hit.transform.gameObject.transform);
                    }
                }
            }
        }
    }
}
