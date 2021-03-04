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
            CancelAttack();
        }
    }

    public void ClickOnUnit()
    {
        if(turnTracker.playerTurn == ownTestPlayerMovement.teamNumber)
        {
            OpenPanel();
        }
        print("1");
    }

    public void OpenPanel()
    {
        if (panel != null)
        {
            print("2");
            bool isActive = panel.activeSelf;

            panel.SetActive(!isActive);
        }
    }

    public void FirstAttackSelect()
    {
        print("3,1");
        attackDamage = firstAttackDamage;
        attacking = true;
        OpenPanel();
        CheckIfInRange(firstAttackRange);
    }

    public void SecondAttackSelect()
    {
        print("3,2");
        attackDamage = secondAttackDamage;
        attacking = true;
        OpenPanel();
        CheckIfInRange(secondAttackRange);
    }

    public void CheckIfInRange(float attackRange)
    {
        print("4");
        unitLocation = transform.position;
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(unitLocation, attackRange);
        foreach (Collider c in hitColliders)
        {
            print("5");
            if (c.transform.gameObject.tag == "Unit")
            {
                print("6");
                if (c.transform.gameObject.GetComponent<TestPlayerMovement>().teamNumber != ownTestPlayerMovement.teamNumber)
                {
                    print("7");
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
