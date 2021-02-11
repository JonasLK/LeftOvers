using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{
    public int playerTurn;
    public int playerAmount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndTurn()
    {
        playerTurn++;
        if (playerTurn > playerAmount)
        {
            playerTurn = 1;
        }
    }
}
