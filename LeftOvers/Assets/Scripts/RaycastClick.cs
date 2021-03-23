using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    public GameObject lastClickedFriendlyUnit;
    public GameObject lastClickedTile;

    private TestTileCalculator testTileCalculator;

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
                    if (hit.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber == GameManager.turnTracker.playerTurn)
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
                    lastClickedTile = hit.transform.gameObject;
                    if(GameManager.turnTracker.gameStarted == false)
                    {
                        print("tile1");
                        testTileCalculator = lastClickedTile.GetComponent<TestTileCalculator>();
                        if (testTileCalculator.teamStartTile == GameManager.turnTracker.playerTurn && GameManager.testSpawnUnit.placingUnit == true && testTileCalculator.untraversable == false && testTileCalculator.occupied == false)
                        {
                            print("tile");
                            GameManager.testSpawnUnit.SpawnUnit(hit.transform.gameObject.transform);
                        }
                    }
                    else 
                    {
                        lastClickedFriendlyUnit.GetComponent<TestPlayerMovement>().MoveToTile();
                    }
                }
            }
        }
    }

    public void ResetRaycastClicked()
    {
        lastClickedFriendlyUnit = null;
        lastClickedTile = null;
    }
}
