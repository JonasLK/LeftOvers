using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float totalHealth = 100f;
    public float currentHealth;
    public float attackDamage = 50f;
    public float attackRange = 1f;
    public float movementRange = 2f;

    public List<Unit> targets = new List<Unit>();

    public Vector3 unitLocation;

    void Start()
    {
        
    }

    void Update()
    {
        //Physics.OverlapSphere
    }


    public void CheckIfInRange()
    {
        unitLocation = transform.position;
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(unitLocation, attackRange);
        foreach (Collider c in hitColliders)
        {
            if (c.transform.gameObject.tag == "Unit")
            {
                targets.Add(c.transform.gameObject.GetComponent<Unit>());
            }
        }
    }
    
    public virtual void Attacking()
    {
        print("im gonna punch you now");
    }

    public virtual void SetStats()
    {
        currentHealth = totalHealth;
    }

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
