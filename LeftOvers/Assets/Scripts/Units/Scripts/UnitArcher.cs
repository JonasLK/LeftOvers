using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArcher : Unit
{
    public int archerTotalHealth = 120;
    public int archerTotalEnergy = 120;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public UnitEnergyBar energyBar;

    public int archerFirstAttackDamage = 40;
    public float archerFirstAttackRange = 8;
    public int archerFirstAttackEnergyRequired = 30;
    public int archerSecondAttackDamage = 40;
    public float archerSecondAttackRange = 6;
    public int archerSecondAttackEnergyRequired = 50;

    public bool arrowUp;
    public bool arrowForward;
    public GameObject arrow;
    public Transform arrowStartLocation;

    public GameObject currentEnemy;

    //General Section - Mostly used for setting stats.

    public void Start()
    {
        arrowForward = false;
        arrowUp = false;

        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(archerTotalHealth);
        localHealthBar.SetMaxHealth(archerTotalHealth);
        energyBar.SetMaxEnergy(archerTotalEnergy);

        firstAttackDamage = archerFirstAttackDamage;
        firstAttackRange = archerFirstAttackRange;
        firstAttackEnergyRequired = archerFirstAttackEnergyRequired;
        secondAttackDamage = archerSecondAttackDamage;
        secondAttackRange = archerSecondAttackRange;
        secondAttackEnergyRequired = archerSecondAttackEnergyRequired;
    }

    public override void SetStats()
    {
        totalHealth = archerTotalHealth;
        totalEnergy = archerTotalEnergy;
        base.SetStats();
    }

    //Attack Section - Everything to do with Attacking enemy Units.

    public override void FirstAttackSelect()
    {
        base.FirstAttackSelect();

        arrowForward = true;

        energyBar.SetEnergy(currentEnergy);
    }

    public override void SecondAttackSelect()
    {
        base.SecondAttackSelect();

        arrowUp = true;

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

                Instantiate(arrow, arrowStartLocation.transform.position, arrowStartLocation.transform.rotation);

                currentEnemy = enemyTarget;

                GetComponent<TestTileCalculator>().ShowMovementRange();

                attacking = false;
            }
        }
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
        //play archer death animation
        base.Death();
    }
}
