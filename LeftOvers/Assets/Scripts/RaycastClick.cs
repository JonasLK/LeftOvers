using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    public GameObject lastClickedFriendlyUnit;

    private TurnTracker turnTracker;
    private TestSpawnUnit testSpawnUnit;
    private TestTileCalculator testTileCalculator;

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
                print("anoes");
                if (hit.transform.gameObject.tag == "Unit")
                {
                    print("anoes1");
                    if (hit.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber == turnTracker.playerTurn)
                    {
                        print("anoes2");
                        if (lastClickedFriendlyUnit != null && hit.transform.gameObject != lastClickedFriendlyUnit)
                        {
                            lastClickedFriendlyUnit.GetComponent<Unit>().OpenPanel();
                        }
                        lastClickedFriendlyUnit = hit.transform.gameObject;
                        lastClickedFriendlyUnit.GetComponent<Unit>().ClickOnUnit();
                        lastClickedFriendlyUnit.GetComponent<TestPlayerMovement>().OnClickUnit();
                        print(lastClickedFriendlyUnit);
                    }
                    else if(lastClickedFriendlyUnit.GetComponent<Unit>().attacking == true)
                    {
                        lastClickedFriendlyUnit.GetComponent<Unit>().Attacking(hit.transform.gameObject);
                    }
                }

                if (hit.transform.gameObject.tag == "Tile")
                {
                    print("tile1");
                    testTileCalculator = hit.transform.gameObject.GetComponent<TestTileCalculator>();
                    if (testTileCalculator.teamStartTile == turnTracker.playerTurn && testSpawnUnit.placingUnit == true && testTileCalculator.untraversable == false && testTileCalculator.occupied == false)
                    {
                        print("tile");
                        testSpawnUnit.SpawnUnit(hit.transform.gameObject.transform);
                    }
                }
            }
        }
    }
}
