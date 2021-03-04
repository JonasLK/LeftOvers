﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : Unit
{
    public int fighterTotalHealth;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(fighterTotalHealth);
        localHealthBar.SetMaxHealth(fighterTotalHealth);
    }

    //This can be used to test if the healthbar works.
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
    }

    public override void SetStats()
    {
        totalHealth = fighterTotalHealth;
        base.SetStats();
    }

    public override void Death()
    {
        //play fighter death animation
        base.Death();
    }
}
