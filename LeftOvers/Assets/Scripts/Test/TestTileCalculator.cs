using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileCalculator : MonoBehaviour
{
    public bool firstTile;
    public bool untraversable;
    public bool occupied;
    public int resetValue;
    public int movementDistance;
    public int teamStartTile;
    public List<GameObject> surroundingTiles;

    private TestTileCalculator testTileCalculator;

    public void Start()
    {
        movementDistance = resetValue;
    }

    public void SendTile(GameObject sentTile, GameObject triggerToTurnOff)
    {
        surroundingTiles.Add(sentTile);
        triggerToTurnOff.SetActive(false);
    }

    public void CalculateHexagonDistance()
    {
        if(firstTile == true)
        {
            movementDistance = 0;
            firstTile = false;
        }
        foreach (GameObject tile in surroundingTiles)
        {
            testTileCalculator = tile.GetComponent<TestTileCalculator>();
            if(testTileCalculator.untraversable == false)
            {
                if(testTileCalculator.movementDistance > movementDistance + 1)
                {
                    testTileCalculator.movementDistance = movementDistance + 1;
                }
            }
        }

        foreach (GameObject tile in surroundingTiles)
        {
            testTileCalculator = tile.GetComponent<TestTileCalculator>();
            if (testTileCalculator.untraversable == false)
            {
                if (testTileCalculator.movementDistance == movementDistance + 1)
                    testTileCalculator.CalculateHexagonDistance();
            }
        }
    }

    public void ResetHexagonDistance()
    {
        foreach (GameObject tile in surroundingTiles)
        {
            testTileCalculator = tile.GetComponent<TestTileCalculator>();
            if (testTileCalculator.movementDistance != resetValue)
            {
                movementDistance = resetValue;
                testTileCalculator.ResetHexagonDistance();
            }
        }
    }
}
