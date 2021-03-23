using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerButtons : MonoBehaviour
{
    public GameObject[] playerButtons;

    public TextMeshProUGUI playerSelectText;

    private int counter;

    void Update()
    {
        
    }

    public void ClickButton(int playerNumberString)
    {
        counter = 1;
        foreach (GameObject playerButton in playerButtons)
        {
            if(counter == playerNumberString)
            {
                 playerSelectText.text = "Player " + playerNumberString.ToString() + " units:";
                playerButton.SetActive(false);
            }
            else if(counter <= GameManager.turnTracker.playerAmount)
            {
                playerButton.SetActive(true);
            }
            else
            {
                playerButton.SetActive(false);
            }

            counter += 1;
        }
    }
}
