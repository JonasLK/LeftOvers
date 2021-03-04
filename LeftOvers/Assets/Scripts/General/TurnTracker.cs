using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{
    public int playerTurn;
    public int playerAmount;
    public List<List<GameObject>> playerTeamPlayerUnit;


    public void AddToListList()
    {

    }

    public void EndTurn()
    {
        foreach (List<GameObject> playerTeam in playerTeamPlayerUnit)
        {
            if (playerTeam[0].GetComponent<TestPlayerMovement>().teamNumber == playerTurn)
            {
                foreach (GameObject playerUnit in playerTeam)
                {
                    playerUnit.GetComponent<TestPlayerMovement>().ResetCharacter();
                }
            }
        }

        playerTurn++;
        if (playerTurn > playerAmount)
        {
            playerTurn = 1;
        }
    }
}
