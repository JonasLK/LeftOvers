using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArcher : Unit
{
    public int archerTotalHealth;

    public int archerFirstAttackDamage;
    public int archerSecondAttackDamage;

    public UnitHealthBar worldHealthBar;
    public UnitHealthBar localHealthBar;
    public void Start()
    {
        SetStats();
        UnitStart();
        worldHealthBar.SetMaxHealth(archerTotalHealth);
        localHealthBar.SetMaxHealth(archerTotalHealth);

        firstAttackDamage = archerFirstAttackDamage;
        secondAttackDamage = archerSecondAttackDamage;
    }

    public override void TakeDamage(int enemyAttackDamage)
    {
        base.TakeDamage(enemyAttackDamage);
        worldHealthBar.SetHealth(currentHealth);
        localHealthBar.SetHealth(currentHealth);
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
