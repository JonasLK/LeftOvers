using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    public GameObject unitSelector;

    public void Start()
    {
        unitSelector = GameObject.FindGameObjectWithTag("UnitSelector");
    }
    public void SellUnit()
    {
        unitSelector.GetComponent<UnitSelect>().moneyLeft += 1;
        Destroy(gameObject);
    }
}
