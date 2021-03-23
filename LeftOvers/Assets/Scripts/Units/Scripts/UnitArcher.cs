using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArcher : Unit
{
    public int archerTotalHealth;
    public int archerTotalEnergy;

    public int archerFirstAttackDamage = 40;
    public float archerFirstAttackRange = 8;
    public int archerFirstAttackEnergyRequired;
    public int archerSecondAttackDamage = 30;
    public float archerSecondAttackRange = 6;
    public int archerSecondAttackEnergyRequired;

    public bool arrowUp;
    public bool arrowForward;

    public GameObject arrow;
    public Transform arrowStartLocation;

    public GameObject currentEnemy;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public void Start()
    {
        arrowForward = false;
        arrowUp = false;

        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(archerTotalHealth);
        localHealthBar.SetMaxHealth(archerTotalHealth);

        firstAttackDamage = archerFirstAttackDamage;
        firstAttackRange = archerFirstAttackRange;
        firstAttackEnergyRequired = archerFirstAttackEnergyRequired;
        secondAttackDamage = archerSecondAttackDamage;
        secondAttackRange = archerSecondAttackRange;
        secondAttackEnergyRequired = archerSecondAttackEnergyRequired;
    }

    public override void FirstAttackSelect()
    {
        base.FirstAttackSelect();

        arrowForward = true;
    }

    public override void SecondAttackSelect()
    {
        base.SecondAttackSelect();

        arrowUp = true;
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

                Instantiate(arrow, arrowStartLocation.transform.position, arrowStartLocation.transform.rotation);

                currentEnemy = enemyTarget;

                //enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);

                GetComponent<TestTileCalculator>().ShowMovementRange();

                attacking = false;
            }
        }
    }

    public override void SetStats()
    {
        totalHealth = archerTotalHealth;
        totalEnergy = archerTotalEnergy;
        base.SetStats();
    }

    public override void Death()
    {
        //play archer death animation
        base.Death();
    }
}
