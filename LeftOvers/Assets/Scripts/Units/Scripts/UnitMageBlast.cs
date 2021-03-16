using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMageBlast : UnitMage
{
    public float blastSpeed;
    public float blastRange;

    public bool friendlyFire;

    public int friendlyFireDamageReduction = 40;

    public Vector3 blastLocation;

    public GameObject explodeTargets;

    public List<GameObject> enemyTargets = new List<GameObject>();

    public List<GameObject> friendlyTargets = new List<GameObject>();

    new void Start()
    {
        friendlyFire = true;
    }
    void Update()
    {
        BlastMovement();
    }

    public void BlastMovement()
    {
        BlastMove();

        LookAt();
    }

    public void BlastMove()
    {
        transform.position += transform.forward * Time.deltaTime * blastSpeed;
    }

    public void LookAt()
    {
        transform.LookAt(transform.position + currentEnemy.transform.forward);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (normalBlast == true)
        {
            if (col.gameObject.tag != "Unit")
            {
                Destroy(gameObject);
            }

            if (col.gameObject.tag == "Unit")
            {
                currentEnemy.GetComponent<Unit>().TakeDamage(attackDamage);

                Destroy(gameObject);
            }

            normalBlast = false;
        }

        if (explosiveBlast == true)
        {
            if (col.gameObject.tag != "Unit")
            {
                print("Bolt Missed Target");

                Explode();

                Destroy(gameObject);
            }
            else if (col.gameObject.tag == "Unit")
            {
                print("Bolt Hit Target");

                Explode();

                Destroy(gameObject);
            }

            explosiveBlast = false;
        }
    }

    public void Explode()
    {
        //Particle Effects

        ExplodeRangeCheck();

        ExplodeDealDamage(explodeTargets);
    }

    public void ExplodeRangeCheck()
    {
        print("ExplodeRangeCheck - 1");

        blastLocation = transform.position;
        friendlyTargets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(blastLocation, blastRange);
        foreach (Collider e in hitColliders)
        {
            print("ExplodeRangeCheck - 2");

            if (e.transform.gameObject.tag == "Unit")
            {
                print("ExplodeRangeCheck - 3");

                if (e.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber != ownTestPlayerMovement.teamNumber)
                {
                    print("ExplodeRangeCheck - 4.1");

                    enemyTargets.Add(e.transform.gameObject);
                }

                if (e.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber == ownTestPlayerMovement.teamNumber)
                {
                    print("ExplodeRangeCheck - 4.2");

                    friendlyTargets.Add(e.transform.gameObject);
                }
            }
        }
    }

    public void ExplodeDealDamage(GameObject target)
    {
        foreach (GameObject eUnit in enemyTargets)
        {
            target = eUnit;

            target.GetComponent<Unit>().TakeDamage(attackDamage);
        }

        foreach(GameObject fUnit in friendlyTargets)
        {
            if (friendlyFire == true)
            {
                target = fUnit;

                attackDamage -= friendlyFireDamageReduction;

                target.GetComponent<Unit>().TakeDamage(attackDamage);
            }
        }
    }
}
