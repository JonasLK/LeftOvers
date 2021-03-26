using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;

    public int totalEnergy = 100;
    public int currentEnergy;

    public int energyRequired;

    public int lastEnergyTaken;

    public int energyPerTurn;

    public int attackDamage;
    public float attackRange;

    public int firstAttackDamage = 50;
    public float firstAttackRange = 2f;
    public int firstAttackEnergyRequired = 5;
    public int secondAttackDamage = 25;
    public float secondAttackRange = 4f;
    public int secondAttackEnergyRequired = 8;

    public float bleedLevel;

    public bool isBleeding;

    public int bleedDamage;

    [HideInInspector] public bool attacking;

    [HideInInspector] public bool canAttack;

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

    public void UnitStart()
    {
        unitSelected = false;
        ownTestPlayerMovement = GetComponent<TestPlayerMovement>();

        //firstAttackButton.onClick.AddListener(FirstAttackSelect);
        //secondAttackButton.onClick.AddListener(SecondAttackSelect);

        attacking = false;

        bleedLevel = 0;

        isBleeding = false;

        canAttack = true;
    }

    void Update()
    {
        if (attacking == true && Input.GetMouseButtonDown(1))
        {
            print("CancelAttack");

            CancelAttack();
        }
    }

    public void CanAttack()
    {
        canAttack = true;
    }

    public void ClickOnUnit()
    {
        print("ClickOnUnit - 1");

        OpenPanel();
    }

    public void OpenPanel()
    {
        print("OpenPanel - 1");

        if (panel != null && GameManager.turnTracker.gameStarted == true)
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

        EnergyManagement();

        attacking = true;
        OpenPanel();
        CheckIfInRange(attackRange);
    }

    public virtual void SecondAttackSelect()
    {
        print("SecondAttackSelect");

        attackDamage = secondAttackDamage;
        attackRange = secondAttackRange;

        EnergyManagement();

        attacking = true;
        OpenPanel();
        CheckIfInRange(attackRange);
    }

    public void EnergyManagement()
    {
        if (currentEnergy < energyRequired)
        {
            return;
        }
        if (currentEnergy >= energyRequired)
        {
            currentEnergy -= energyRequired;

            lastEnergyTaken = energyRequired;
        }
    }

    public void EnergyPerTurn()
    {
        currentEnergy += energyPerTurn;

        if (currentEnergy > totalEnergy)
        {
            currentEnergy = totalEnergy;
        }
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

        if (attackRangeDisplay != null && GameManager.turnTracker.gameStarted == true)
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

                canAttack = false;

                attacking = false;
            }
        }
    }

    public virtual void CancelAttack()
    {
        GetComponent<TestTileCalculator>().ShowMovementRange();

        lastEnergyTaken += currentEnergy;

        if(currentEnergy > totalEnergy)
        {
            currentEnergy = totalEnergy;
        }

        attacking = false;
    }

    public virtual void SetStats()
    {
        currentHealth = totalHealth;
        currentEnergy = totalEnergy;
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

        damageText.text = lastDamageAmount.ToString();

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
            GameManager.turnTracker.team1Unit.Remove(gameObject);
        }else if (ownTestPlayerMovement.teamNumber == 2)
        {
            GameManager.turnTracker.team2Unit.Remove(gameObject);
        }
        else if(ownTestPlayerMovement.teamNumber == 3)
        {
            GameManager.turnTracker.team3Unit.Remove(gameObject);
        }else if (ownTestPlayerMovement.teamNumber == 4)
        {
            GameManager.turnTracker.team4Unit.Remove(gameObject);
        }

        GameManager.turnTracker.CheckForWin();
        Destroy(gameObject/*, 3f*/);
    }
}