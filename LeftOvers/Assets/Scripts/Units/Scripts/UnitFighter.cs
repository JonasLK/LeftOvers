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

    public int fighterFirstAttackDamage = 40;
    public float fighterFirstAttackRange = 8;
    public int fighterFirstAttackEnergyRequired;
    public int fighterSecondAttackDamage = 30;
    public float fighterSecondAttackRange = 6;
    public int fighterSecondAttackEnergyRequired;

    public float stunLength;
    public bool stunAttack;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(fighterTotalHealth);
        localHealthBar.SetMaxHealth(fighterTotalHealth);
        energyBar.SetMaxEnergy(fighterTotalEnergy);

        firstAttackDamage = fighterFirstAttackDamage;
        firstAttackRange = fighterFirstAttackRange;
        firstAttackEnergyRequired = fighterFirstAttackEnergyRequired;
        secondAttackDamage = fighterSecondAttackDamage;
        secondAttackRange = fighterSecondAttackRange;
        secondAttackEnergyRequired = fighterSecondAttackEnergyRequired;

        stunAttack = false;
    }

    public override void SetStats()
    {
        totalHealth = fighterTotalHealth;
        totalEnergy = fighterTotalEnergy;
        base.SetStats();
    }

    public override void FirstAttackSelect()
    {
        base.FirstAttackSelect();

        energyBar.SetEnergy(currentEnergy);
    }

    public override void SecondAttackSelect()
    {
        base.SecondAttackSelect();

        stunAttack = true;

        energyBar.SetEnergy(currentEnergy);
    }
    public override void Attacking(GameObject enemyTarget)
    {
        base.Attacking(enemyTarget);

        if(stunAttack == true)
        {
            enemyTarget.GetComponent<Unit>().ApplyStun(stunLength);

            stunAttack = false;
        }
    }
    public override void CancelAttack()
    {
        base.CancelAttack();

        stunAttack = false;

        energyBar.SetEnergy(currentEnergy);
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
    }

    public override void Death()
    {
        //play fighter death animation
        base.Death();
    }
}
