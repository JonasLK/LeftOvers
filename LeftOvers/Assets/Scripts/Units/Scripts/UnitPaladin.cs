using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPaladin : Unit
{
    public int paladinTotalHealth = 250;

    public int paladinFirstAttackDamage;
    public float paladinFirstAttackRange;

    public int paladinHolyHealAmount = 40;
    public int paladinHolyDamageBuffAmount = 20;
    public bool paladinHolyDamageBuff;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(paladinTotalHealth);
        localHealthBar.SetMaxHealth(paladinTotalHealth);

        firstAttackDamage = paladinFirstAttackDamage;
        firstAttackRange = paladinFirstAttackRange;

        paladinHolyDamageBuff = false;
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
    }

    public override void SecondAttackSelect()
    {
        print("SecondAttackSelect");

        HolyLightAbility();
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

                if (paladinHolyDamageBuff == true)
                {
                    attackDamage += paladinHolyDamageBuffAmount;

                    enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);
                }
                else
                {
                    enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);
                }

                GetComponent<TestTileCalculator>().ShowMovementRange();

                paladinHolyDamageBuff = false;
                attacking = false;
            }
        }
    }

    public void HolyLightAbility()
    {
        currentHealth += paladinHolyHealAmount;

        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }

        paladinHolyDamageBuff = true;
    }

    public override void SetStats()
    {
        totalHealth = paladinTotalHealth;
        base.SetStats();
    }

    public override void Death()
    {
        //play paladin death animation
        base.Death();
    }
}

