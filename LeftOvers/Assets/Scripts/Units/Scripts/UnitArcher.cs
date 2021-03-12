using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArcher : Unit
{
    public int archerTotalHealth;

    public int archerFirstAttackDamage;
    public int archerSecondAttackDamage;

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
        secondAttackDamage = archerSecondAttackDamage;
    }

    public override void FirstAttackSelect()
    {
        arrowForward = true;

        base.FirstAttackSelect();
    }

    public override void SecondAttackSelect()
    {
        arrowUp = true;

        base.SecondAttackSelect();
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

                attacking = false;
            }
        }
    }

    public override void SetStats()
    {
        totalHealth = archerTotalHealth;
        base.SetStats();
    }

    public override void Death()
    {
        //play archer death animation
        base.Death();
    }
}
