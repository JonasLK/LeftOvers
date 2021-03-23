using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : Unit
{
    public int fighterTotalHealth;
    public int fighterTotalEnergy;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;

    public UnitEnergyBar energyBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(fighterTotalHealth);
        localHealthBar.SetMaxHealth(fighterTotalHealth);
        energyBar.SetMaxEnergy(fighterTotalEnergy);
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
    }

    public override void FirstAttackSelect()
    {
        base.FirstAttackSelect();

        energyBar.SetEnergy(currentEnergy);
    }

    public override void SecondAttackSelect()
    {
        base.SecondAttackSelect();

        energyBar.SetEnergy(currentEnergy);
    }

    public override void SetStats()
    {
        totalHealth = fighterTotalHealth;
        totalEnergy = fighterTotalEnergy;
        base.SetStats();
    }

    public override void CancelAttack()
    {
        base.CancelAttack();
        energyBar.SetEnergy(currentEnergy);
    }

    public override void Death()
    {
        //play fighter death animation
        base.Death();
    }
}
