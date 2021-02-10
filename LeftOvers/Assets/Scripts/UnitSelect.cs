using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelect : MonoBehaviour
{
    public GameObject unitPanel;
    public Button fighterButton;
    public Button mageButton;
    public Button archerButton;
    public Button priestButton;
    public Button paladinButton;
    public Button rogueButton;

    bool canBuyFighter;
    bool canBuyMage;
    bool canBuyArcher;
    bool canBuyPriest;
    bool canBuyPaladin;
    bool canBuyRogue;

    void Start()
    {
        canBuyFighter = true;
        canBuyMage = true;
        canBuyArcher = true;
        canBuyPaladin = true;
        canBuyRogue = true;
        canBuyPriest = true;
    }


    void Update()
    {

    }



    //Buy Unit
    public void BuyFighter()
    {
        if(canBuyFighter == true)
        {
            Instantiate(fighterButton, unitPanel.transform);
        }
    }

    public void BuyMage()
    {
        if (canBuyMage == true)
        {
            Instantiate(mageButton, unitPanel.transform);
        }
    }

    public void BuyArcher()
    {
        if(canBuyArcher == true)
        {
            Instantiate(archerButton, unitPanel.transform);
        }
    }

    public void BuyPriest()
    {
        if(canBuyPriest == true)
        {
            Instantiate(priestButton, unitPanel.transform);
        }
    }

    public void BuyPaladin()
    {
        if(canBuyPaladin == true)
        {
            Instantiate(paladinButton, unitPanel.transform);
        }
    }

    public void BuyRogue()
    {
        if(canBuyRogue == true)
        {
            Instantiate(rogueButton, unitPanel.transform);
        }
    }
}
