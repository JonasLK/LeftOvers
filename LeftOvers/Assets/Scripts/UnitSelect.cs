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

    public float money;
    public float moneyLeft;

    public Text moneyText;
    public Text totalMoney;
    void Start()
    {
        moneyLeft = money;
    }

    void Update()
    {
        moneyText.text = "Units:" + moneyLeft.ToString() + "/";
        totalMoney.text = money.ToString();
    }

    //Buy Unit
    public void BuyFighter()
    {
        if (moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(fighterButton, unitPanel.transform);
        }
    }

    public void BuyMage()
    {
        if (moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(mageButton, unitPanel.transform);
        }
    }

    public void BuyArcher()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(archerButton, unitPanel.transform);
        }
    }

    public void BuyPriest()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(priestButton, unitPanel.transform);
        }
    }

    public void BuyPaladin()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(paladinButton, unitPanel.transform);
        }
    }

    public void BuyRogue()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(rogueButton, unitPanel.transform);
        }
    }
}
