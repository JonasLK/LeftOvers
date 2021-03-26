using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : Unit
{
    public int fighterTotalHealth = 160;
    public int fighterTotalEnergy = 100;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public UnitEnergyBar energyBar;

    public int fighterFirstAttackDamage = 50;
    public float fighterFirstAttackRange = 2;
    public int fighterFirstAttackEnergyRequired = 40;
    public int fighterSecondAttackDamage = 20;
    public float fighterSecondAttackRange = 4;
    public int fighterSecondAttackEnergyRequired = 40;

    public float stunLength = 2;
    public bool stunAttack;

    //General Section - Mostly used for setting stats.

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

    //Attack Section - Everything to do with Attacking enemy Units.

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

    //Health Section - Everything to do with taking damage, getting healed and dying.

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
