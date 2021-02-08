using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : MonoBehaviour
{
    public float totalHealth;
    private float currentHealth;
    public float attackDamage;
    public float enemyAttackDamage;

    void Start()
    {
        currentHealth = totalHealth;
    }

    void Update()
    {
        isDead();
        TakeDamage();
    }

    public bool isDead()
    {
        if (currentHealth <= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /**
    public bool CheckIfInRange()
    {
        if ()
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    void Attacking()
    {
        if (CheckIfInRange())
        {
            //slap the shit outta them
        }
    }
    **/

    void TakeDamage()
    {
        if (isDead())
        {
            Death();
            return;
        }

        currentHealth -= enemyAttackDamage;
        //damage taken animation
    }

    void Death()
    {
        print("oh no i died");
        //death animation
        Destroy(gameObject, 3f);
    }
}
