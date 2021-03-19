using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerUnitSlots : MonoBehaviour
{
    public int playerMaxUnits;
    public int[] playerCurrentUnits;
    public GameObject[] unitsPlayer1;
    public GameObject[] unitsPlayer2;
    public GameObject[] unitsPlayer3;
    public GameObject[] unitsPlayer4;

    public TextMeshProUGUI unitSlotsText;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            unitSlotsText = GameObject.FindGameObjectWithTag(" ").GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        
    }

    public void BuyUnit(int player)
    {
        playerCurrentUnits[player - 1] -= 1;
        UpdateUnitSlotText(player);
    }

    public void SellUnit(int player)
    {
        playerCurrentUnits[player - 1] += 1;
        UpdateUnitSlotText(player);
    }

    public void UpdateUnitSlotText(int player)
    {
        unitSlotsText.text = "Unit Slots Lefts: " + playerCurrentUnits[player - 1].ToString() + "/" + playerMaxUnits.ToString();
    }
}