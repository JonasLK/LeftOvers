using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPriest : Unit
{
    public int priestTotalHealth;

    public int priestFirstHealAmount = 50;
    public float priestFirstHealRange = 1f;
    public int priestSecondHealAmount = 25;
    public float priestSecondHealRange = 2f;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
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
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
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
        print("Attacking - 1");

        foreach (GameObject target in targets)
        {
            print("Attacking - 2");

            if (allyTarget = target)
            {
                print("Attacking - 3");

                allyTarget.GetComponent<Unit>().GetHealed(attackDamage);

                attacking = false;
            }
        }
    }

    public override void SetStats()
    {
        totalHealth = priestTotalHealth;
        base.SetStats();
    }

    public override void Death()
    {
        //play priest death animation
        base.Death();
    }
}
