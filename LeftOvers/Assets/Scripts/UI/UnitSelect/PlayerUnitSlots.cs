using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerUnitSlots : MonoBehaviour
{
    public GameObject buttonToInstanciate;
    public int currentPlayerSelect;
    public int playerMaxUnits;
    public int[] playerCurrentUnits;
    public List<GameObject> unitsPlayer1;
    public List<GameObject> unitsPlayer2;
    public List<GameObject> unitsPlayer3;
    public List<GameObject> unitsPlayer4;

    public TextMeshProUGUI unitSlotsText;

    private GameObject justSpawnedButton;

    private int forEachCounter;
    private GameObject buttonToEdit;

    private bool fakeStart;

    void Start()
    {
        if(unitSlotsText != null)
        {
            UpdateUnitSlotText();
        }

        print("Start");
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && fakeStart == false)
        {
            print("Start not scene 0");
            PrepareButtonsToSpawn();
            fakeStart = true;
        }
    }

    public void BuyUnit(GameObject boughtUnit)
    {
        justSpawnedButton = Instantiate(buttonToInstanciate, new Vector3(0f, 0f, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("UnitSell").transform);
        justSpawnedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell " + boughtUnit.GetComponent<UnitTransferToScene>().className;
        justSpawnedButton.GetComponent<SellButton>().gameObjectToRemove = boughtUnit;

        if (currentPlayerSelect == 1)
        {
            boughtUnit.GetComponent<UnitTransferToScene>().teamNumber = currentPlayerSelect;
            unitsPlayer1.Add(boughtUnit);
        }
        else if (currentPlayerSelect == 2)
        {
            boughtUnit.GetComponent<UnitTransferToScene>().teamNumber = currentPlayerSelect;
            unitsPlayer2.Add(boughtUnit);
        }else if (currentPlayerSelect == 3)
        {
            boughtUnit.GetComponent<UnitTransferToScene>().teamNumber = currentPlayerSelect;
            unitsPlayer3.Add(boughtUnit);
        }else if (currentPlayerSelect == 4)
        {
            boughtUnit.GetComponent<UnitTransferToScene>().teamNumber = currentPlayerSelect;
            unitsPlayer4.Add(boughtUnit);
        }

        playerCurrentUnits[currentPlayerSelect - 1] -= 1;
        UpdateUnitSlotText();
    }

    public void SellUnit(GameObject boughtUnit)
    {
        if (currentPlayerSelect == 1)
        {
            unitsPlayer1.Remove(boughtUnit);
        }
        else if (currentPlayerSelect == 2)
        {
            unitsPlayer2.Remove(boughtUnit);
        }
        else if (currentPlayerSelect == 3)
        {
            unitsPlayer3.Remove(boughtUnit);
        }
        else if (currentPlayerSelect == 4)
        {
            unitsPlayer4.Remove(boughtUnit);
        }

        playerCurrentUnits[currentPlayerSelect - 1] += 1;
        UpdateUnitSlotText();
    }

    public void UpdateUnitSlotText()
    {
        unitSlotsText.text = "Unit Slots Left: " + playerCurrentUnits[currentPlayerSelect - 1].ToString() + "/" + playerMaxUnits.ToString();
    }

    public void SetCurrentPlayer(int playerNumber)
    {
        currentPlayerSelect = playerNumber;
        UpdateUnitSlotText();
    }

    public void PrepareButtonsToSpawn()
    {
        foreach(GameObject transfer in unitsPlayer1)
        {
            buttonToEdit = GameManager.unitSpawnList.unitSpawnUis[0].GetComponent<UnitSpawnList>().unitSpawnUis[forEachCounter];
            buttonToEdit.GetComponentInChildren<TextMeshProUGUI>().text = "Place " + transfer.GetComponent<UnitTransferToScene>().className;
            buttonToEdit.GetComponent<SpawnUnitButton>().unitToSpawn = transfer.GetComponent<UnitTransferToScene>().gameObjectToSpawn;

            forEachCounter += 1;
        }
        forEachCounter = 0;

        foreach (GameObject transfer in unitsPlayer2)
        {
            buttonToEdit = GameManager.unitSpawnList.unitSpawnUis[0].GetComponent<UnitSpawnList>().unitSpawnUis[forEachCounter];
            buttonToEdit.GetComponentInChildren<TextMeshProUGUI>().text = "Place " + transfer.GetComponent<UnitTransferToScene>().className;
            buttonToEdit.GetComponent<SpawnUnitButton>().unitToSpawn = transfer.GetComponent<UnitTransferToScene>().gameObjectToSpawn;

            forEachCounter += 1;
        }
        forEachCounter = 0;

        if(GameManager.turnTracker.playerAmount > 2)
        {
            foreach (GameObject transfer in unitsPlayer3)
            {
                buttonToEdit = GameManager.unitSpawnList.unitSpawnUis[0].GetComponent<UnitSpawnList>().unitSpawnUis[forEachCounter];
                buttonToEdit.GetComponentInChildren<TextMeshProUGUI>().text = "Place " + transfer.GetComponent<UnitTransferToScene>().className;
                buttonToEdit.GetComponent<SpawnUnitButton>().unitToSpawn = transfer.GetComponent<UnitTransferToScene>().gameObjectToSpawn;

                forEachCounter += 1;
            }
            forEachCounter = 0;

            if (GameManager.turnTracker.playerAmount > 3)
            {
                foreach (GameObject transfer in unitsPlayer4)
                {
                    buttonToEdit = GameManager.unitSpawnList.unitSpawnUis[0].GetComponent<UnitSpawnList>().unitSpawnUis[forEachCounter];
                    buttonToEdit.GetComponentInChildren<TextMeshProUGUI>().text = "Place " + transfer.GetComponent<UnitTransferToScene>().className;
                    buttonToEdit.GetComponent<SpawnUnitButton>().unitToSpawn = transfer.GetComponent<UnitTransferToScene>().gameObjectToSpawn;

                    forEachCounter += 1;
                }
                forEachCounter = 0;
            }
        }
    }
}