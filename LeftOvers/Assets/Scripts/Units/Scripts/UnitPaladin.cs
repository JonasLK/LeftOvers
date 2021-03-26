using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPaladin : Unit
{
    public int paladinTotalHealth = 200;
    public int paladinTotalEnergy = 100;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public UnitEnergyBar energyBar;

    public int paladinFirstAttackDamage = 40;
    public float paladinFirstAttackRange = 2;
    public int paladinFirstAttackEnergyRequired = 40;

    public int paladinHealAmount = 40;
    public int paladinDamageBuff = 20;
    public int paladinDamageBuffDefault = 20;
    public bool paladinBuff;
    public int paladinHolyLightEnergyRequired = 50;

    //General Section - Mostly used for setting stats.

    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(paladinTotalHealth);
        localHealthBar.SetMaxHealth(paladinTotalHealth);

        firstAttackDamage = paladinFirstAttackDamage;
        firstAttackRange = paladinFirstAttackRange;
        firstAttackEnergyRequired = paladinFirstAttackEnergyRequired;
        secondAttackEnergyRequired = paladinHolyLightEnergyRequired;

        paladinBuff = false;
    }
    
    public override void SetStats()
    {
        totalHealth = paladinTotalHealth;
        totalEnergy = paladinTotalEnergy;
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
        print("SecondAttackSelect");

        EnergyManagement();

        HolyLightAbility();

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

                if (paladinBuff == true)
                {
                    attackDamage += paladinDamageBuff;

                    enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);
                }
                else
                {
                    enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);
                }

                GetComponent<TestTileCalculator>().ShowMovementRange();

                paladinDamageBuff = paladinDamageBuffDefault;
                paladinBuff = false;
                attacking = false;

                energyBar.SetEnergy(currentEnergy);
            }
        }
    }

    public void HolyLightAbility()
    {
        currentHealth += paladinHealAmount;

        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }

        if (paladinBuff == true)
        {
            paladinDamageBuff += paladinDamageBuffDefault;
        }

        paladinBuff = true;
    }

    public override void CancelAttack()
    {
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
        //play paladin death animation
        base.Death();
    }
}

