using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFighter : MonoBehaviour
{
    public float totalHealth;
    private float currentHealth;
    public float attackDamage;

    void Start()
    {
        currentHealth = totalHealth;
    }

    void Update()
    {

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

    void TakeDamage(float enemyAttackDamage)
    {
        currentHealth -= enemyAttackDamage;

        //damage taken animation

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        print("oh no i died");
        //death animation
        Destroy(gameObject, 3f);
    }
}
