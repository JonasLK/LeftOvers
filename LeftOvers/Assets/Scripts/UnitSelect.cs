using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelect : MonoBehaviour
{
    public GameObject selectScreen;

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

    public float fighterCount;
    public float mageCount;
    public float archerCount;
    public float prietsCount;
    public float paladinCount;
    public float rogueCount;

    public bool player1;
    public bool player2;
    public bool player3;

    void Start()
    {
        moneyLeft = money;
        fighterCount = 0;
        mageCount = 0;
        archerCount = 0;
        prietsCount = 0;
        paladinCount = 0;
        rogueCount = 0;
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
            fighterCount += 1;
        }
    }

    public void BuyMage()
    {
        if (moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(mageButton, unitPanel.transform);
            mageCount += 1;
        }
    }

    public void BuyArcher()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(archerButton, unitPanel.transform);
            archerCount += 1;
        }
    }

    public void BuyPriest()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(priestButton, unitPanel.transform);
            prietsCount += 1;
        }
    }

    public void BuyPaladin()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(paladinButton, unitPanel.transform);
            paladinCount += 1;
        }
    }

    public void BuyRogue()
    {
        if(moneyLeft > 0)
        {
            moneyLeft -= 1;
            Instantiate(rogueButton, unitPanel.transform);
            rogueCount += 1;
        }
    }

    public void ConfirmUnits()
    {
        if(player1 == true)
        {
            selectScreen.GetComponent<UnitCount>().fighters = fighterCount;
            selectScreen.GetComponent<UnitCount>().mages = mageCount;
            selectScreen.GetComponent<UnitCount>().archers = archerCount;
            selectScreen.GetComponent<UnitCount>().priests = prietsCount;
            selectScreen.GetComponent<UnitCount>().paladins = paladinCount;
            selectScreen.GetComponent<UnitCount>().rogues = rogueCount;
        }
        if(player2 == true)
        {
            selectScreen.GetComponent<UnitCount>().fighters2 = fighterCount;
            selectScreen.GetComponent<UnitCount>().mages2 = mageCount;
            selectScreen.GetComponent<UnitCount>().archers2 = archerCount;
            selectScreen.GetComponent<UnitCount>().priests2 = prietsCount;
            selectScreen.GetComponent<UnitCount>().paladins2 = paladinCount;
            selectScreen.GetComponent<UnitCount>().rogues2 = rogueCount;
        }
        if(player3 == true)
        {
            selectScreen.GetComponent<UnitCount>().fighters3 = fighterCount;
            selectScreen.GetComponent<UnitCount>().mages3 = mageCount;
            selectScreen.GetComponent<UnitCount>().archers3 = archerCount;
            selectScreen.GetComponent<UnitCount>().priests3 = prietsCount;
            selectScreen.GetComponent<UnitCount>().paladins3 = paladinCount;
            selectScreen.GetComponent<UnitCount>().rogues3 = rogueCount;
            if(moneyLeft != 5)
            {
                selectScreen.GetComponent<UnitCount>().EnablePlayer3();
            }
        }
        selectScreen.GetComponent<UnitCount>().SaveCount();
    }

    public void SellFighter()
    {
        fighterCount -= 1;
    }
    public void SellMage()
    {
        mageCount -= 1;
    }
    public void SellArcher()
    {
        archerCount -= 1;
    }
    public void SellPriest()
    {
        prietsCount -= 1;
    }
    public void SellPaladin()
    {
        paladinCount -= 1;
    }
    public void SellRogue()
    {
        rogueCount -= 1;
    }
}
