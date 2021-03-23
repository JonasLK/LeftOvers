using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : Unit
{
    public int fighterTotalHealth;
    public int fighterTotalEnergy;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(fighterTotalHealth);
        localHealthBar.SetMaxHealth(fighterTotalHealth);
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
        totalEnergy = fighterTotalEnergy;
        base.SetStats();
    }

    public override void Death()
    {
        //play fighter death animation
        base.Death();
    }
}
