using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerTurn : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerTurnVoid(int teamTurnToSet)
    {
        GameManager.turnTracker.playerTurn = teamTurnToSet;
        GameManager.turnTracker.UpdateTurnDisplay();
    }
}