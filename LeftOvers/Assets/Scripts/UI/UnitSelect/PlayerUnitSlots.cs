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

    void Start()
    {
        if(unitSlotsText != null)
        {
            UpdateUnitSlotText();
        }
    }

    void Update()
    {
        
    }

    public void BuyUnit(GameObject boughtUnit)
    {
        if(currentPlayerSelect == 1)
        {
            unitsPlayer1.Add(boughtUnit);
        }else if (currentPlayerSelect == 2)
        {
            unitsPlayer2.Add(boughtUnit);
        }else if (currentPlayerSelect == 3)
        {
            unitsPlayer3.Add(boughtUnit);
        }else if (currentPlayerSelect == 4)
        {
            unitsPlayer4.Add(boughtUnit);
        }

        justSpawnedButton = Instantiate(buttonToInstanciate, new Vector3(0f, 0f, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("UnitSell").transform);

        playerCurrentUnits[currentPlayerSelect - 1] -= 1;
        UpdateUnitSlotText();
    }

    public void SellUnit()
    {
        playerCurrentUnits[currentPlayerSelect - 1] += 1;
        UpdateUnitSlotText();
    }

    public void UpdateUnitSlotText()
    {
        unitSlotsText.text = "Unit Slots Lefts: " + playerCurrentUnits[currentPlayerSelect - 1].ToString() + "/" + playerMaxUnits.ToString();
    }

    public void SetCurrentPlayer(int playerNumber)
    {
        currentPlayerSelect = playerNumber;
    }
}