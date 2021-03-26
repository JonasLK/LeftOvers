using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRogue : Unit
{
    public int rogueTotalHealth = 120;
    public int rogueTotalEnergy = 160;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public UnitEnergyBar energyBar;

    public int rogueFirstAttackDamage = 70;
    public float rogueFirstAttackRange = 2;
    public int rogueFirstAttackEnergyRequired = 40;
    public int rogueSecondAttackDamage = 20;
    public float rogueSecondAttackRange = 2;
    public int rogueSecondAttackEnergyRequired = 60;

    public bool bleedAttack;
    public float giveBleedLevel = 2;
    public int bleedDmg = 25;

    //General Section - Mostly used for setting stats.

    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(rogueTotalHealth);
        localHealthBar.SetMaxHealth(rogueTotalHealth);

        firstAttackDamage = rogueFirstAttackDamage;
        firstAttackRange = rogueFirstAttackRange;
        firstAttackEnergyRequired = rogueFirstAttackEnergyRequired;
        secondAttackDamage = rogueSecondAttackDamage;
        secondAttackRange = rogueSecondAttackRange;
        secondAttackEnergyRequired = rogueSecondAttackEnergyRequired;

        bleedDamage = bleedDmg;
        bleedAttack = false;
    }

    public override void SetStats()
    {
        totalHealth = rogueTotalHealth;
        totalEnergy = rogueTotalEnergy;
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
        bleedAttack = true;

        base.SecondAttackSelect();

        energyBar.SetEnergy(currentEnergy);
    }

    public override void Attacking(GameObject enemyTarget)
    {
        print("Attacking - 1");

        foreach (GameObject target in targets)
        {
            print("Attacking - 2");

            if (enemyTarget = target)
            {
                print("Attacking - 3");

                enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);

                GetComponent<TestTileCalculator>().ShowMovementRange();

                if (bleedAttack == true)
                {
                    enemyTarget.GetComponent<Unit>().ApplyBleeding(giveBleedLevel);

                    bleedAttack = false;
                }

                attacking = false;
            }
        }
    }

    public override void CancelAttack()
    {
        bleedAttack = false;

        base.CancelAttack();

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
        //play rogue death animation
        base.Death();
    }
}

