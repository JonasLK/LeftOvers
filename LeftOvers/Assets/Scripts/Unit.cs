using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float totalHealth;
    public float currentHealth;
    public float attackDamage;
    public float attackRange;
    public float movementSpeed;

    void Start()
    {
        currentHealth = totalHealth;
    }

    void Update()
    {
        //Physics.OverlapSphere
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
