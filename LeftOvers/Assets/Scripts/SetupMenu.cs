using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupMenu : MonoBehaviour
{
    public float buttons;

    public float buttonsLeft;
    public bool setupActive;
    public bool setupComplete;

    public GameObject turnButton;

    public GameObject[] unitButtons;

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;

    void Start()
    {

        buttonsLeft = 5;
        setupComplete = false;

        unitButtons = GameObject.FindGameObjectsWithTag("UnitButtons");
        foreach (GameObject player1Button in unitButtons)
        {
            buttonsLeft += 1;
        }
    }
    void Update()
    {
        if (buttonsLeft <= 6)
        {
            turnButton.SetActive(true);
            playerOne.SetActive(false);
            playerTwo.SetActive(false);
            playerThree.SetActive(false);

            //gameplay?
        }

        if(setupActive == true)
        {
            //kan alleen units plaatsen
        }
        else
        {
            //gameplay
        }
    }

    public void Player1()
    {
        playerOne.SetActive(true);
        playerTwo.SetActive(false);
        playerThree.SetActive(false);
    }
    public void Player2()
    {
        playerTwo.SetActive(true);
        playerThree.SetActive(false);
        playerOne.SetActive(false);
    }
    public void Player3()
    {
        playerThree.SetActive(true);
        playerTwo.SetActive(false);
        playerOne.SetActive(false);
    }
}
