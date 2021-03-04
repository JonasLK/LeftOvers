﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;

    public int attackDamage;

    public int firstAttackDamage = 50;
    public float firstAttackRange = 1f;
    public int secondAttackDamage = 25;
    public float secondAttackRange = 2f;

    [HideInInspector] public bool attacking;

    public float movementRange = 2f;

    public int unitTeamColor;

    public bool unitSelected;

    public Button firstAttackButton;
    public Button secondAttackButton;

    public GameObject panel;

    private GameObject clickedUnit;

    public List<GameObject> targets = new List<GameObject>();

    public Vector3 unitLocation;

    private TestPlayerMovement ownTestPlayerMovement;

    private TurnTracker turnTracker;

    void Start()
    {
        SetStats();

        unitSelected = false;
        ownTestPlayerMovement = GetComponent<TestPlayerMovement>();
        turnTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurnTracker>();

        //firstAttackButton.onClick.AddListener(FirstAttackSelect);
        //secondAttackButton.onClick.AddListener(SecondAttackSelect);

        attacking = false;
    }

    void Update()
    {
        if (attacking == true && Input.GetMouseButtonDown(1))
        {
            print("CancelAttack");

            CancelAttack();
        }
    }

    public void ClickOnUnit()
    {
        print("ClickOnUnit - 1");

        if (turnTracker.playerTurn == ownTestPlayerMovement.teamNumber)
        {
            print("ClickOnUnit - 2");

            OpenPanel();
        }
    }

    public void OpenPanel()
    {
        print("OpenPanel - 1");

        if (panel != null)
        {
            print("OpenPanel - 2");

            bool isActive = panel.activeSelf;

            panel.SetActive(!isActive);
        }
    }

    public void FirstAttackSelect()
    {
        print("FirstAttackSelect");

        attackDamage = firstAttackDamage;
        attacking = true;
        OpenPanel();
        CheckIfInRange(firstAttackRange);
    }

    public void SecondAttackSelect()
    {
        print("SecondAttackSelect");

        attackDamage = secondAttackDamage;
        attacking = true;
        OpenPanel();
        CheckIfInRange(secondAttackRange);
    }

    public void CheckIfInRange(float attackRange)
    {
        print("CheckIfInRange - 1");

        unitLocation = transform.position;
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(unitLocation, attackRange);
        foreach (Collider c in hitColliders)
        {
            print("CheckIfInRange - 2");

            if (c.transform.gameObject.tag == "Unit")
            {
                print("CheckIfInRange - 3");

                if (c.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber != ownTestPlayerMovement.teamNumber)
                {
                    print("CheckIfInRange - 4");

                    targets.Add(c.transform.gameObject);
                }
            }
        }
    }

    public virtual void Attacking(GameObject enemyTarget)
    {
        print("Attacking - 1");

        foreach (GameObject target in targets)
        {
            print("Attacking - 2");

            if (enemyTarget = target)
            {
                print("Attacking - 3");

                enemyTarget.GetComponent<Unit>().TakeDamage(attackDamage);

                attacking = false;
            }
        }
    }

    public void CancelAttack()
    {
        attacking = false;
    }

    public virtual void SetStats()
    {
        currentHealth = totalHealth;
    }

    public virtual void TakeDamage(int enemyAttackDamage)
    {
        print("TakeDamage");

        currentHealth -= enemyAttackDamage;

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        print("Death");

        Destroy(gameObject, 3f);
    }
}
