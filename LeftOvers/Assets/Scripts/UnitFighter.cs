using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : Unit
{
    public void Start()
    {
        SetStats();   
    }

    public override void SetStats()
    {
        totalHealth = 200f;
        base.SetStats();
    }
}
