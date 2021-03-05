using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTracker : MonoBehaviour
{
    public TextMeshProUGUI turnDisplay;
    public int playerTurn;
    public int playerAmount;
    public List<GameObject> team1Unit;
    public List<GameObject> team2Unit;
    public List<GameObject> team3Unit;
    public List<GameObject> team4Unit;

    public void Start()
    {
        UpdateTurnDisplay();
    }

    public void AddToListList(GameObject gameObjectToAdd)
    {
        if(gameObjectToAdd.GetComponent<TestPlayerMovement>().teamNumber == 1)
        {
            team1Unit.Add(gameObjectToAdd);
        }
        else if(gameObjectToAdd.GetComponent<TestPlayerMovement>().teamNumber == 2)
        {
            team2Unit.Add(gameObjectToAdd);
        }
        else if(gameObjectToAdd.GetComponent<TestPlayerMovement>().teamNumber == 3)
        {
            team3Unit.Add(gameObjectToAdd);
        }
        else if(gameObjectToAdd.GetComponent<TestPlayerMovement>().teamNumber == 4)
        {
            team4Unit.Add(gameObjectToAdd);
        }
    }

    public void EndTurn()
    {

        if (playerTurn == 1)
        {
            ResetTeam(team1Unit);
        }
        else if (playerTurn == 2)
        {
            ResetTeam(team2Unit);
        }
        else if (playerTurn == 3)
        {
            ResetTeam(team3Unit);
        }
        else if (playerTurn == 4)
        {
            ResetTeam(team4Unit);
        }

        playerTurn++;
        if (playerTurn > playerAmount)
        {
            playerTurn = 1;
        }
        UpdateTurnDisplay();
    }

    public void ResetTeam(List<GameObject> playerTeam)
    {
        foreach (GameObject playerUnit in playerTeam)
        {
            playerUnit.GetComponent<TestPlayerMovement>().ResetCharacter();
        }
    }

    public void UpdateTurnDisplay()
    {
        turnDisplay.text = "Turn: player " + playerTurn.ToString();
    }
}
