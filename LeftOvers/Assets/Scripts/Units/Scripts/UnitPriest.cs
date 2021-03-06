﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPriest : Unit
{
    public int priestTotalHealth = 100;
    public int priestTotalEnergy = 100;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public UnitEnergyBar energyBar;

    public int priestFirstHealAmount = 50;
    public float priestFirstHealRange = 2f;
    public int priestFirstHealEnergyRequired = 40;
    public int priestSecondHealAmount = 80;
    public float priestSecondHealRange = 6f;
    public int priestSecondHealEnergyRequired = 100;

    //General Section - Mostly used for setting stats.

    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(priestTotalHealth);
        localHealthBar.SetMaxHealth(priestTotalHealth);

        firstAttackDamage = priestFirstHealAmount;
        secondAttackDamage = priestSecondHealAmount;
        firstAttackRange = priestFirstHealRange;
        secondAttackRange = priestSecondHealRange;
        firstAttackEnergyRequired = priestFirstHealEnergyRequired;
        secondAttackEnergyRequired = priestSecondHealEnergyRequired;
    }

    public override void SetStats()
    {
        totalHealth = priestTotalHealth;
        totalEnergy = priestTotalEnergy;
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

        energyBar.SetEnergy(currentEnergy);
    }

    public override void CheckIfInRange(float attackRange)
    {
        print("Priest CheckIfInRange - 1");

        unitLocation = transform.position;
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(unitLocation, attackRange);
        foreach (Collider c in hitColliders)
        {
            print("Priest CheckIfInRange - 2");

            if (c.transform.gameObject.tag == "Unit")
            {
                print("Priest CheckIfInRange - 3");

                if (c.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber == ownTestPlayerMovement.teamNumber)
                {
                    print("Priest CheckIfInRange - 4");

                    targets.Add(c.transform.gameObject);
                }
            }
        }
    }

    public override void Attacking(GameObject allyTarget)
    {
        print("Priest Healing - 1");

        foreach (GameObject target in targets)
        {
            print("Priest Healing - 2");

            if (allyTarget = target)
            {
                print("Priest Healing - 3");

                allyTarget.GetComponent<Unit>().GetHealed(attackDamage);

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
        //play priest death animation
        base.Death();
    }
}
