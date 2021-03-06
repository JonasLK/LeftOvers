﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public bool gameStarted;
    public GameObject winScreen;

    [HideInInspector] public int mapToLoad;

    private bool fakeStart;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && fakeStart == false)
        {
            print("FakeStart");
            turnDisplay = GameObject.FindGameObjectWithTag("PlayerTurnDisplay").GetComponentInChildren<TextMeshProUGUI>();
            winScreen = GameObject.FindGameObjectWithTag("WinMenu");
            UpdateTurnDisplay();
            fakeStart = true;
        }
    }

    public void CheckForWin()
    {
        if(team2Unit.Count == 0 && team3Unit.Count == 0 && team4Unit.Count == 0)
        {
            winScreen.SetActive(true);
        }
        if (team1Unit.Count == 0 && team3Unit.Count == 0 && team4Unit.Count == 0)
        {
            winScreen.SetActive(true);
        }
        if (team1Unit.Count == 0 && team2Unit.Count == 0 && team4Unit.Count == 0)
        {
            winScreen.SetActive(true);
        }
        if (team1Unit.Count == 0 && team2Unit.Count == 0 && team3Unit.Count == 0)
        {
            winScreen.SetActive(true);
        }
    }

    public void AddToList(GameObject gameObjectToAdd)
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
        GameManager.raycastClick.ResetRaycastClicked();
    }

    public void ResetTeam(List<GameObject> playerTeam)
    {
        foreach (GameObject playerUnit in playerTeam)
        {
            playerUnit.GetComponent<TestPlayerMovement>().ResetCharacter();

            if (playerUnit.GetComponent<Unit>().isBleeding == true)
            {
                playerUnit.GetComponent<Unit>().BleedDamageDeal();
            }

            if (playerUnit.GetComponent<Unit>().isStunned == true)
            {
                playerUnit.GetComponent<Unit>().StunCounter();
            }

            playerUnit.GetComponent<Unit>().EnergyPerTurn();

            playerUnit.GetComponent<Unit>().CanAttack();
        }
    }

    public void UpdateTurnDisplay()
    {
        turnDisplay.text = "Turn: player " + playerTurn.ToString();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void DecidePlayerAmount(int playerCount)
    {
        playerAmount = playerCount;

        mapToLoad = playerCount;
    }
}