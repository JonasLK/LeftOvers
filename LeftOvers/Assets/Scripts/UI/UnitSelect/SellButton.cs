using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour
{

    public GameObject gameObjectToRemove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellUnit()
    {
        GameManager.playerUnitSlots.SellUnit(gameObjectToRemove);
        Destroy(gameObject);
    }
}