using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;

    public int attackDamage;
    public float attackRange;

    public int firstAttackDamage = 50;
    public float firstAttackRange = 2f;
    public int secondAttackDamage = 25;
    public float secondAttackRange = 4f;

    public float bleedLevel;

    public bool isBleeding;

    public int bleedDamage;

    [HideInInspector] public bool attacking;

    public float movementRange = 2f;

    public int unitTeamColor;

    public bool unitSelected;

    public Button firstAttackButton;
    public Button secondAttackButton;

    public float damageTextStaysUpForSeconds;

    public int lastDamageAmount;

    public Text damageText;

    public GameObject damagePanel;

    public GameObject panel;

    public GameObject attackRangeDisplay;

    private GameObject clickedUnit;

    public List<GameObject> targets = new List<GameObject>();

    public Vector3 unitLocation;

    [HideInInspector] public TestPlayerMovement ownTestPlayerMovement;

    [HideInInspector] public TestTileCalculator testTileCalculator;

    [HideInInspector]public TurnTracker turnTracker;

    public void UnitStart()
    {
        unitSelected = false;
        ownTestPlayerMovement = gameObject.GetComponent<TestPlayerMovement>();
        turnTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurnTracker>();

        //firstAttackButton.onClick.AddListener(FirstAttackSelect);
        //secondAttackButton.onClick.AddListener(SecondAttackSelect);

        attacking = false;

        bleedLevel = 0;

        isBleeding = false;
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

        OpenPanel();
    }

    public void OpenPanel()
    {
        print("OpenPanel - 1");

        if (panel != null && turnTracker.gameStarted == true)
        {
            print("OpenPanel - 2");

            panel.SetActive(!panel.activeSelf);
        }
    }

    public virtual void FirstAttackSelect()
    {
        print("FirstAttackSelect");

        attackDamage = firstAttackDamage;
        attackRange = firstAttackRange;
        attacking = true;
        OpenPanel();
        CheckIfInRange(attackRange);
    }

    public virtual void SecondAttackSelect()
    {
        print("SecondAttackSelect");

        attackDamage = secondAttackDamage;
        attackRange = secondAttackRange;
        attacking = true;
        OpenPanel();
        CheckIfInRange(attackRange);
    }

    public virtual void CheckIfInRange(float attackRange)
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

                    GetComponent<TestTileCalculator>().ShowMovementRange();
                }
            }
        }
    }

    public void RangeDisplay()
    {
        print("AttackRangeDisplay - 1");

        if (attackRangeDisplay != null && turnTracker.gameStarted == true)
        {
            print("AttackRangeDisplay - 2");

            panel.SetActive(!panel.activeSelf);
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

                GetComponent<TestTileCalculator>().ShowMovementRange();

                attacking = false;
            }
        }
    }

    public virtual void CancelAttack()
    {
        GetComponent<TestTileCalculator>().ShowMovementRange();

        attacking = false;
    }

    public virtual void SetStats()
    {
        currentHealth = totalHealth;
    }

    public void GetHealed(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
    }

    public void ApplyBleeding(float bleedLvl)
    {
        if (bleedLevel > 0)
        {
            bleedLevel += bleedLvl;
        }

        if (bleedLevel == 0)
        {
            bleedLevel = bleedLvl;
        }

        isBleeding = true;
    }

    public void BleedDamageDeal()
    {
        TakeDamage(bleedDamage);

        bleedLevel -= 1;

        if(bleedLevel == 0)
        {
            isBleeding = false;
        }
    }

    public virtual void TakeDamage(int enemyAttackDamage)
    {
        print("TakeDamage");

        lastDamageAmount = enemyAttackDamage;

        DamagePanel();

        currentHealth -= enemyAttackDamage;

        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    public void DamagePanel()
    {
        damagePanel.SetActive(!panel.activeSelf);

        damageText.text = "" + lastDamageAmount;

        DoAfterTime(damageTextStaysUpForSeconds);
    }

    IEnumerator DoAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        damagePanel.SetActive(!panel.activeSelf);
    }

    public virtual void Death()
    {
        print("Death");
        if(ownTestPlayerMovement.teamNumber == 1)
        {
            turnTracker.team1Unit.Remove(gameObject);
        }else if (ownTestPlayerMovement.teamNumber == 2)
        {
            turnTracker.team2Unit.Remove(gameObject);
        }
        else if(ownTestPlayerMovement.teamNumber == 3)
        {
            turnTracker.team3Unit.Remove(gameObject);
        }else if (ownTestPlayerMovement.teamNumber == 4)
        {
            turnTracker.team4Unit.Remove(gameObject);
        }

        turnTracker.CheckForWin();
        Destroy(gameObject/*, 3f*/);
    }
}