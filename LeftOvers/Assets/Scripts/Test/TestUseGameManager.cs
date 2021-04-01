﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUseGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameManager.turnTracker.gameStarted = true;
    }

    public void UseTurnTrackerEndTurn()
    {
        GameManager.turnTracker.EndTurn();
    }

    public void UseTestSpawnUnitPlacingUnit()
    {
        GameManager.testSpawnUnit.PlacingUnits();
    }

    public void UseTestSpawnUnitSelectButtonToDestroy(GameObject buttonToDestroy)
    {
        GameManager.testSpawnUnit.SelectButtonToDestroy(buttonToDestroy);
    }
}
