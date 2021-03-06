﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileCalculator : MonoBehaviour
{
    public bool showSpawnTiles;
    public bool spawnTile;
    public GameObject spawnIndicator;

    public bool firstTile;
    public bool untraversable;
    public bool occupied;
    public int resetValue;
    public int movementDistance;
    public int teamStartTile;
    public List<GameObject> surroundingTiles;

    public GameObject rangeDisplay;

    public TestTileCalculator testTileCalculator;

    public void Start()
    {
        movementDistance = resetValue;
    }

    public void SendTile(GameObject sentTile, GameObject triggerToTurnOff)
    {
        surroundingTiles.Add(sentTile);
        triggerToTurnOff.SetActive(false);
    }

    public virtual void CalculateHexagonDistance()
    {
        if (firstTile == true)
        {
            movementDistance = 0;
            firstTile = false;
        }
        foreach (GameObject tile in surroundingTiles)
        {
            testTileCalculator = tile.GetComponent<TestTileCalculator>();
            if (testTileCalculator.untraversable == false)
            {
                if (testTileCalculator.movementDistance > movementDistance + 1)
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

    public void ShowMovementRange()
    {
        rangeDisplay.SetActive(!rangeDisplay.activeSelf);
    }

    private void Update()
    {
        if (spawnTile == true && showSpawnTiles == true)
        {
            spawnIndicator.SetActive(true);
        }
        else
        {
            spawnIndicator.SetActive(false);
        }
    }
}
