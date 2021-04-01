using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTracker : MonoBehaviour
{
    public float player1Units;
    public float player2Units;
    public float player3Units;
    public float player4Units;

    public bool twoPlayers;
    public bool threePlayers;
    public bool fourPlayers;

    public GameObject winMenu;
    public TMP_Text playerOneWon;
    public TMP_Text playerTwoWon;
    public TMP_Text playerThreeWon;
    public TMP_Text playerFourWon;

    private void Start()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        foreach (GameObject unit in units)
        {
            if (gameObject.GetComponent<Unit>().unitTeamColor == 1)
            {
                player1Units++;
            }
            if (gameObject.GetComponent<Unit>().unitTeamColor == 2)
            {
                player2Units++;
            }
            if (gameObject.GetComponent<Unit>().unitTeamColor == 3)
            {
                player3Units++;
            }
            if (gameObject.GetComponent<Unit>().unitTeamColor == 4)
            {
                player4Units++;
            }
        }
    }

    void Update()
    {
        if(twoPlayers == true)
        {
            if(player1Units <= 0)
            {
                //player2won
                winMenu.SetActive(true);
                playerTwoWon.enabled = true;
            }
            if (player2Units <= 0)
            {
                //player1won
                winMenu.SetActive(true);
                playerOneWon.enabled = true;
            }
        }
        if(threePlayers == true)
        {
            if(player1Units <= 0 && player2Units <= 0)
            {
                //player3won
                winMenu.SetActive(true);
                playerThreeWon.enabled = true;
            }
            if(player1Units <= 0 && player3Units <= 0)
            {
                //player2won
                winMenu.SetActive(true);
                playerTwoWon.enabled = true;
            }
            if(player2Units <= 0 && player3Units <= 0)
            {
                //player1won
                winMenu.SetActive(true);
                playerOneWon.enabled = true;
            }
        }
        if(fourPlayers == true)
        {
            if(player1Units <= 0 && player2Units <= 0 && player3Units <= 0)
            {
                //player4won
                winMenu.SetActive(true);
                playerFourWon.enabled = true;
            }
            if (player1Units <= 0 && player2Units <= 0 && player4Units <= 0)
            {
                //player3won
                winMenu.SetActive(true);
                playerThreeWon.enabled = true;
            }
            if (player1Units <= 0 && player3Units <= 0 && player4Units <= 0)
            {
                //player2won
                winMenu.SetActive(true);
                playerTwoWon.enabled = true;
            }
            if (player2Units <= 0 && player3Units <= 0 && player4Units <= 0)
            {
                //player1won
                winMenu.SetActive(true);
                playerOneWon.enabled = true;
            }
        }
    }
}
