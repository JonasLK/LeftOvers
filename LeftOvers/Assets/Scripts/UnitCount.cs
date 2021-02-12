using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCount : MonoBehaviour
{
    public GameObject[] fighters;
    GameObject[] archers;
    GameObject[] mages;
    GameObject[] priests;
    GameObject[] paladins;
    GameObject[] rogues;

    public static float fighterCount;
    public static float archerCount;
    public static float mageCount;
    public static float priestCount;
    public static float paladinCount;
    public static float rogueCount;

    public float fighterss;

    public void Start()
    {

    }
    public void ConfirmUnits()
    {
        fighters = GameObject.FindGameObjectsWithTag("FighterUnit");
        foreach (GameObject fighter in fighters)
        {
            fighterCount += 1;
        }
        archers = GameObject.FindGameObjectsWithTag("ArcherUnit");
        foreach (GameObject archer in archers)
        {
            archerCount += 1;
        }
        mages = GameObject.FindGameObjectsWithTag("mageUnit");
        foreach (GameObject mage in mages)
        {
            mageCount += 1;
        }
        priests = GameObject.FindGameObjectsWithTag("priestUnit");
        foreach (GameObject priest in priests)
        {
            priestCount += 1;
        }
        paladins = GameObject.FindGameObjectsWithTag("paladinUnit");
        foreach (GameObject paladin in paladins)
        {
            paladinCount += 1;
        }
        rogues = GameObject.FindGameObjectsWithTag("rogueUnit");
        foreach (GameObject rogue in rogues)
        {
            rogueCount += 1;
        }
    }
}
