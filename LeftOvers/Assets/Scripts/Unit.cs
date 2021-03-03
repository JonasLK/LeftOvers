using System.Collections;
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

    void Start()
    {
        SetStats();

        unitSelected = false;
        ownTestPlayerMovement = GetComponent<TestPlayerMovement>();

        firstAttackButton.onClick.AddListener(FirstAttackSelect);
        secondAttackButton.onClick.AddListener(SecondAttackSelect);

        healthBar.SetMaxHealth(fighterTotalHealth);
    }

    void Update()
    {
        if (attacking == true && Input.GetMouseButtonDown(1))
        {
            CancelAttack();
        }
    }

    public void ClickOnUnit()
    {
        OpenPanel();
    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;

            panel.SetActive(!isActive);
        }
    }

    public void FirstAttackSelect()
    {
        attackDamage = firstAttackDamage;
        attacking = true;
        CheckIfInRange(firstAttackRange);
    }

    public void SecondAttackSelect()
    {
        attackDamage = secondAttackDamage;
        attacking = true;
        CheckIfInRange(secondAttackRange);
    }

    public void CheckIfInRange(float attackRange)
    {
        unitLocation = transform.position;
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(unitLocation, attackRange);
        foreach (Collider c in hitColliders)
        {
            if (c.transform.gameObject.tag == "Unit")
            {
                if(c.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber != ownTestPlayerMovement.teamNumber)
                {
                    targets.Add(c.transform.gameObject);
                }
            }
        }
    }

    public virtual void Attacking(GameObject enemyTarget)
    {
        foreach(GameObject target in targets)
        {
            if(enemyTarget = target)
            {
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
        currentHealth -= enemyAttackDamage;

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        print("oh no i died");
        Destroy(gameObject, 3f);
    }
}
