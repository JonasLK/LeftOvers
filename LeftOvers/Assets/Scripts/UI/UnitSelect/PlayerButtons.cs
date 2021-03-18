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

    public void ClickButton(string playerNumberString)
    {
        counter = 0;
        foreach (GameObject playerButton in playerButtons)
        {
            if(counter < turnTracker.playerAmount)
            {
                playerButton.SetActive(true);
            }

            counter += 1;
        }
        playerSelectText.text = "Player " + playerNumberString;
        gameObject.SetActive(false);
    }
}
