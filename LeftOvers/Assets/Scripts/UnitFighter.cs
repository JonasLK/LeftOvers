using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : Unit
{
    public float fighterTotalHealth;
    public void Start()
    {
        SetStats();   
    }

    public override void SetStats()
    {
        totalHealth = fighterTotalHealth;
        base.SetStats();
    }
}
