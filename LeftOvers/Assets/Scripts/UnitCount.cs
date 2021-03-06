﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCount : MonoBehaviour
{
    public GameObject winTrackerObject;

    public static bool player3;
    public bool player3Enabled;

    public float fighters;
    public float archers;
    public float mages;
    public float priests;
    public float paladins;
    public float rogues;

    public float fighters2;
    public float archers2;
    public float mages2;
    public float priests2;
    public float paladins2;
    public float rogues2;

    public float fighters3;
    public float archers3;
    public float mages3;
    public float priests3;
    public float paladins3;
    public float rogues3;

    public static float fighterCount;
    public static float archerCount;
    public static float mageCount;
    public static float priestCount;
    public static float paladinCount;
    public static float rogueCount;

    public static float fighterCount2;
    public static float archerCount2;
    public static float mageCount2;
    public static float priestCount2;
    public static float paladinCount2;
    public static float rogueCount2;

    public static float fighterCount3;
    public static float archerCount3;
    public static float mageCount3;
    public static float priestCount3;
    public static float paladinCount3;
    public static float rogueCount3;

    private void Start()
    {

    }


    public void SaveCount()
    {
        fighterCount = fighters;
        archerCount = archers;
        mageCount = mages;
        priestCount = priests;
        paladinCount = paladins;
        rogueCount = rogues;

        fighterCount2 = fighters2;
        archerCount2 = archers2;
        mageCount2 = mages2;
        priestCount2 = priests2;
        paladinCount2 = paladins2;
        rogueCount2 = rogues2;

        fighterCount3 = fighters3;
        archerCount3 = archers3;
        mageCount3 = mages3;
        priestCount3 = priests3;
        paladinCount3 = paladins3;
        rogueCount3 = rogues3;
    }
    public void SetupReady()
    {
        fighters = fighterCount;
        archers = archerCount;
        mages = mageCount;
        priests = priestCount;
        paladins = paladinCount;
        rogues = rogueCount;

        fighters2 = fighterCount2;
        archers2 = archerCount2;
        mages2 = mageCount2;
        priests2 = priestCount2;
        paladins2 = paladinCount2;
        rogues2 = rogueCount2;

        fighters3 = fighterCount3;
        archers3 = archerCount3;
        mages3 = mageCount3;
        priests3 = priestCount3;
        paladins3 = paladinCount3;
        rogues3 = rogueCount3;

        player3Enabled = player3;
    }

    public void ResetUnits() 
    { 

    }
    public void ActivateWinTracker()
    {
        winTrackerObject.SetActive(true);
    }

    public void EnablePlayer3()
    {
        player3 = true;
    }
}
