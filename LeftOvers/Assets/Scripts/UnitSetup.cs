using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetup : MonoBehaviour
{
    public bool player1;
    public bool player2;
    public bool player3;

    public float fighters;
    public float archers;
    public float mages;
    public float priests;
    public float paladins;
    public float rogues;

    public GameObject fighterButton;
    public GameObject archerButton;
    public GameObject mageButton;
    public GameObject priestButton;
    public GameObject paladinButton;
    public GameObject rogueButton;

    public GameObject fighterPrefab;
    public GameObject archerPrefab;
    public GameObject magePrefab;
    public GameObject priestPrefab;
    public GameObject paladinPrefab;
    public GameObject roguePrefab;

    public bool placeFighter;
    public bool placeArcher;
    public bool placeMage;
    public bool placePriest;
    public bool placePaladin;
    public bool placeRogue;

    public GameObject unitBox;
    public GameObject gameMaster;
    void Start()
    {
        gameMaster.GetComponent<UnitCount>().SetupReady();
        if (player1 == true)
        {
            fighters = gameMaster.GetComponent<UnitCount>().fighters;
            archers = gameMaster.GetComponent<UnitCount>().archers;
            mages = gameMaster.GetComponent<UnitCount>().mages;
            priests = gameMaster.GetComponent<UnitCount>().priests;
            paladins = gameMaster.GetComponent<UnitCount>().paladins;
            rogues = gameMaster.GetComponent<UnitCount>().rogues;

            for (int i = 0; i < fighters; i++)
            {
                Instantiate(fighterButton, unitBox.transform);
            }
            for (int i = 0; i < archers; i++)
            {
                Instantiate(archerButton, unitBox.transform);
            }
            for (int i = 0; i < mages; i++)
            {
                Instantiate(mageButton, unitBox.transform);
            }
            for (int i = 0; i < priests; i++)
            {
                Instantiate(priestButton, unitBox.transform);
            }
            for (int i = 0; i < paladins; i++)
            {
                Instantiate(paladinButton, unitBox.transform);
            }
            for (int i = 0; i < rogues; i++)
            {
                Instantiate(rogueButton, unitBox.transform);
            }
        }
        if (player2 == true)
        {
            fighters = gameMaster.GetComponent<UnitCount>().fighters2;
            archers = gameMaster.GetComponent<UnitCount>().archers2;
            mages = gameMaster.GetComponent<UnitCount>().mages2;
            priests = gameMaster.GetComponent<UnitCount>().priests2;
            paladins = gameMaster.GetComponent<UnitCount>().paladins2;
            rogues = gameMaster.GetComponent<UnitCount>().rogues2;

            for (int i = 0; i < fighters; i++)
            {
                Instantiate(fighterButton, unitBox.transform);
            }
            for (int i = 0; i < archers; i++)
            {
                Instantiate(archerButton, unitBox.transform);
            }
            for (int i = 0; i < mages; i++)
            {
                Instantiate(mageButton, unitBox.transform);
            }
            for (int i = 0; i < priests; i++)
            {
                Instantiate(priestButton, unitBox.transform);
            }
            for (int i = 0; i < paladins; i++)
            {
                Instantiate(paladinButton, unitBox.transform);
            }
            for (int i = 0; i < rogues; i++)
            {
                Instantiate(rogueButton, unitBox.transform);
            }

            gameObject.SetActive(false);
        }
        if (player3 == true)
        {
            fighters = gameMaster.GetComponent<UnitCount>().fighters3;
            archers = gameMaster.GetComponent<UnitCount>().archers3;
            mages = gameMaster.GetComponent<UnitCount>().mages3;
            priests = gameMaster.GetComponent<UnitCount>().priests3;
            paladins = gameMaster.GetComponent<UnitCount>().paladins3;
            rogues = gameMaster.GetComponent<UnitCount>().rogues3;

            for (int i = 0; i < fighters; i++)
            {
                Instantiate(fighterButton, unitBox.transform);
            }
            for (int i = 0; i < archers; i++)
            {
                Instantiate(archerButton, unitBox.transform);
            }
            for (int i = 0; i < mages; i++)
            {
                Instantiate(mageButton, unitBox.transform);
            }
            for (int i = 0; i < priests; i++)
            {
                Instantiate(priestButton, unitBox.transform);
            }
            for (int i = 0; i < paladins; i++)
            {
                Instantiate(paladinButton, unitBox.transform);
            }
            for (int i = 0; i < rogues; i++)
            {
                Instantiate(rogueButton, unitBox.transform);
            }

            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void PlaceFighter()
    {
        placeFighter = true;

        if (placeFighter == true)
        {
            
        }

        if(player1 == true)
        {

        }
    }
    public void PlaceArcher()
    {

    }
    public void PlaceMage()
    {

    }
    public void PlacePriest()
    {

    }
    public void PlacePaladin()
    {

    }
    public void PlaceRogue()
    {

    }
}
