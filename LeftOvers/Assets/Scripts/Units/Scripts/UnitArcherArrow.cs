using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitArcherArrow : UnitArcher
{
    public float arrowSpeed;

    public bool arrowGoDown;

    new void Start()
    {
        arrowGoDown = false;
    }

    void Update()
    {
        ArrowMovement();
    }

    public void ArrowMovement()
    {
        if (arrowForward == true)
        {
            ArrowMove();

            LookAt();
        }

        if (arrowUp == true)
        {
            ArrowMove();

            if (arrowGoDown == false)
            {
                ArrowMoveUp();
            }

            StartCoroutine(ExecuteAfterTime(3));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        arrowGoDown = true;

        LookAt();
    }

    public void ArrowMove()
    {
        transform.position += transform.forward * Time.deltaTime * arrowSpeed;
    }

    public void ArrowMoveUp()
    {
        transform.position += transform.up * Time.deltaTime * arrowSpeed;
    }

    public void LookAt()
    {
        transform.LookAt(transform.position + currentEnemy.transform.forward);
    }

    private void OnCollisionEnter(Collision col)
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

        arrowForward = false;
        arrowUp = false;
    }
}
