using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRogue : Unit
{
    public int rogueTotalHealth;

    public int rogueFirstAttackDamage;
    public float rogueFirstAttackRange;
    public int rogueSecondAttackDamage;
    public float rogueSecondAttackRange;

    public bool bleedAttack;
    public float giveBleedLevel;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(rogueTotalHealth);
        localHealthBar.SetMaxHealth(rogueTotalHealth);

        firstAttackDamage = rogueFirstAttackDamage;
        firstAttackRange = rogueFirstAttackRange;
        secondAttackDamage = rogueSecondAttackDamage;
        secondAttackRange = rogueSecondAttackRange;

        bleedAttack = false;
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
    }

    public override void SecondAttackSelect()
    {
        bleedAttack = true;

        base.SecondAttackSelect();
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
                    enemyTarget.GetComponent<Unit>().IsBleeding(giveBleedLevel);

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
    }

    public override void SetStats()
    {
        totalHealth = rogueTotalHealth;
        base.SetStats();
    }

    public override void Death()
    {
        //play rogue death animation
        base.Death();
    }
}

