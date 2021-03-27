using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerButtons : MonoBehaviour
{
    public GameObject[] playerButtons;
    public GameObject[] playerUnitSelects;

    public TextMeshProUGUI playerSelectText;

    private int Counter;

    void Update()
    {
        
    }

    public void ClickButton(int playerNumberString)
    {
        Counter = 1;
        foreach (GameObject playerButton in playerButtons)
        {
            if(Counter == playerNumberString)
            {
                playerSelectText.text = "Player " + playerNumberString.ToString() + " units:";
                playerButton.SetActive(false);
            }
            else if(Counter <= GameManager.turnTracker.playerAmount)
            {
                playerButton.SetActive(true);
            }
            else
            {
                playerButton.SetActive(false);
            }

            Counter += 1;
        }

        Counter = 1;
        foreach (GameObject playerCanvas in playerUnitSelects)
        {
            if (Counter == playerNumberString)
            {
                playerCanvas.SetActive(true);
            }
            else if (Counter <= GameManager.turnTracker.playerAmount)
            {
                playerCanvas.SetActive(false);
            }
            else
            {
                playerCanvas.SetActive(false);
            }

            Counter += 1;
        }
    }
}
