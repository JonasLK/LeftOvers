using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileCalculator : MonoBehaviour
{
    public bool firstTile;
    public bool traversable;
    public int resetValue;
    public int movementDistance;
    public List<GameObject> surroundingTiles;

    private TestTileCalculator testTileCalculator;

    public void Start()
    {
        movementDistance = resetValue;
    }

    private void OnMouseDown()
    {
        CalculateHexagonDistance();
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
        }
        foreach (GameObject tile in surroundingTiles)
        {
            testTileCalculator = tile.GetComponent<TestTileCalculator>();
            if(testTileCalculator.movementDistance > movementDistance + 1)
            {
                testTileCalculator.movementDistance = movementDistance + 1;
            }
        }

        foreach (GameObject tile in surroundingTiles)
        {
            testTileCalculator = tile.GetComponent<TestTileCalculator>();
            if(testTileCalculator.movementDistance == movementDistance + 1)
            testTileCalculator.CalculateHexagonDistance();
        }
        firstTile = false;
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
