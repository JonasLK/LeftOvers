using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileSender : MonoBehaviour
{
    public void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.tag == "Tile")
        {
            gameObject.GetComponentInParent<TestTileCalculator>().SendTile(o.gameObject, gameObject);
        }
    }
}
