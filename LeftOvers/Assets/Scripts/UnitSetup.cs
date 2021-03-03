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
                Instantiate(fighterButton, gameObject.transform);
            }
            for (int i = 0; i < archers; i++)
            {
                Instantiate(archerButton, gameObject.transform);
            }
            for (int i = 0; i < mages; i++)
            {
                Instantiate(mageButton, gameObject.transform);
            }
            for (int i = 0; i < priests; i++)
            {
                Instantiate(priestButton, gameObject.transform);
            }
            for (int i = 0; i < paladins; i++)
            {
                Instantiate(paladinButton, gameObject.transform);
            }
            for (int i = 0; i < rogues; i++)
            {
                Instantiate(rogueButton, gameObject.transform);
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
                Instantiate(fighterButton, gameObject.transform);
            }
            for (int i = 0; i < archers; i++)
            {
                Instantiate(archerButton, gameObject.transform);
            }
            for (int i = 0; i < mages; i++)
            {
                Instantiate(mageButton, gameObject.transform);
            }
            for (int i = 0; i < priests; i++)
            {
                Instantiate(priestButton, gameObject.transform);
            }
            for (int i = 0; i < paladins; i++)
            {
                Instantiate(paladinButton, gameObject.transform);
            }
            for (int i = 0; i < rogues; i++)
            {
                Instantiate(rogueButton, gameObject.transform);
            }
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
                Instantiate(fighterButton, gameObject.transform);
            }
            for (int i = 0; i < archers; i++)
            {
                Instantiate(archerButton, gameObject.transform);
            }
            for (int i = 0; i < mages; i++)
            {
                Instantiate(mageButton, gameObject.transform);
            }
            for (int i = 0; i < priests; i++)
            {
                Instantiate(priestButton, gameObject.transform);
            }
            for (int i = 0; i < paladins; i++)
            {
                Instantiate(paladinButton, gameObject.transform);
            }
            for (int i = 0; i < rogues; i++)
            {
                Instantiate(rogueButton, gameObject.transform);
            }
        }
    }


    void Update()
    {
        
    }
}
