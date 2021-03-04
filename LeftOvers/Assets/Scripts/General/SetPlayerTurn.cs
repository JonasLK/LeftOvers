using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerTurn : MonoBehaviour
{
    public TurnTracker turnTracker;

    void Start()
    {
        turnTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurnTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerTurnVoid(int teamTurnToSet)
    {
        turnTracker.playerTurn = teamTurnToSet;
    }
}