using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public GameObject tileBellow;
    private TestTileCalculator testTileCalculator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == "Tile")
        {
            tileBellow = o.gameObject;
        }
    }

    public void OnMouseDown()
    {
        if(testTileCalculator != tileBellow.GetComponent<TestTileCalculator>())
        {
            testTileCalculator = tileBellow.GetComponent<TestTileCalculator>();
        }
        testTileCalculator.firstTile = true;
        testTileCalculator.ResetHexagonDistance();
        testTileCalculator.CalculateHexagonDistance();
    }
}