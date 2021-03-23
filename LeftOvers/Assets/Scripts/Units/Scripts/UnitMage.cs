using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMage : Unit
{
    public int mageTotalHealth = 80;
    public int mageTotalEnergy;

    public int mageFirstAttackDamage = 80;
    public float mageFirstAttackRange = 6;
    public int mageFirstAttackEnergyRequired;
    public int mageSecondAttackDamage = 80;
    public float mageSecondAttackRange = 6;
    public int mageSecondAttackEnergyRequired;

    public bool normalBlast;
    public bool explosiveBlast;

    public GameObject blast;
    public Transform blastStartLocation;

    public GameObject currentEnemy;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;

    public UnitEnergyBar energyBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(mageTotalHealth);
        localHealthBar.SetMaxHealth(mageTotalHealth);

        firstAttackDamage = mageFirstAttackDamage;
        firstAttackRange = mageFirstAttackRange;
        firstAttackEnergyRequired = mageFirstAttackEnergyRequired;
        secondAttackDamage = mageSecondAttackDamage;
        secondAttackRange = mageSecondAttackRange;
        secondAttackEnergyRequired = mageSecondAttackEnergyRequired;

        normalBlast = false;
        explosiveBlast = false;
    }

    public override void FirstAttackSelect()
    {
        normalBlast = true;

        base.FirstAttackSelect();

        energyBar.SetEnergy(currentEnergy);
    }

    public override void SecondAttackSelect()
    {
        explosiveBlast = true;

        base.SecondAttackSelect();

        energyBar.SetEnergy(currentEnergy);
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
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

                Instantiate(blast, blastStartLocation.transform.position, blastStartLocation.transform.rotation);

                currentEnemy = enemyTarget;

                GetComponent<TestTileCalculator>().ShowMovementRange();

                attacking = false;
            }
        }
    }

    public override void SetStats()
    {
        totalHealth = mageTotalHealth;
        totalEnergy = mageTotalEnergy;
        base.SetStats();
    }

    public override void CancelAttack()
    {
        base.CancelAttack();
        energyBar.SetEnergy(currentEnergy);
    }


    public override void Death()
    {
        //play mage death animation
        base.Death();
    }
}

