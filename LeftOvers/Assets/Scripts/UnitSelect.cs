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

    public float fighterCount;
    public float mageCount;
    public float archerCount;
    public float prietsCount;
    public float paladinCount;
    public float rogueCount;

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
        gameObject.GetComponent<UnitCount>().fighters = fighterCount;
        gameObject.GetComponent<UnitCount>().mages = mageCount;
        gameObject.GetComponent<UnitCount>().archers = archerCount;
        gameObject.GetComponent<UnitCount>().priests = prietsCount;
        gameObject.GetComponent<UnitCount>().paladins = paladinCount;
        gameObject.GetComponent<UnitCount>().rogues = rogueCount;
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
