using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerButtons : MonoBehaviour
{
    public GameObject[] playerButtons;

    public TextMeshProUGUI playerSelectText;

    private int counter;
    private TurnTracker turnTracker;

    void Start()
    {
        turnTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurnTracker>();
    }

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
            else if(counter <= turnTracker.playerAmount)
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
