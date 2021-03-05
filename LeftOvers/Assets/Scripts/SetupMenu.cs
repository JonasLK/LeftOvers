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
    public GameObject setupInterface;

    public GameObject[] unitButtons;
    public GameObject[] units;

    public GameObject playerOne;
    public GameObject playerOneBox;
    public GameObject playerTwo;
    public GameObject playerTwoBox;
    public GameObject playerThree;
    public GameObject playerThreeBox;

    public GameObject gameMaster;
    public GameObject playerThreeButton;
    void Start()
    {
        turnButton.SetActive(false);
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
        if (gameMaster.GetComponent<UnitCount>().player3Enabled == true)
        {
            playerThreeButton.SetActive(true);
        }

        if (playerOneBox.transform.childCount == 0 && playerTwoBox.transform.childCount == 0 && playerThreeBox.transform.childCount == 0)
        {
            units = GameObject.FindGameObjectsWithTag("Unit");
            foreach(GameObject unit in units)
            {
                unit.GetComponent<TestPlayerMovement>().moveAble = true;
            }

            turnButton.SetActive(true);
            setupInterface.SetActive(false);
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
