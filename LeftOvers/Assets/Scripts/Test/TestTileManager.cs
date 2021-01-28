using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTileManager : MonoBehaviour
{
    public List<GameObject> tiles;

    void Start()
    {
        foreach(GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            tiles.Add(tile);
        }
    }

    void Update()
    {
        
    }

    public void DrawMovementRange(int movementRange)
    {
        foreach(GameObject tile in tiles)
        {
            if(tile.GetComponent<TestTileCalculator>().movementDistance > movementRange)
            {
                //make red?

            }
            else
            {
                //make green?

            }
        }
    }

    public void ResetDrawnMovementRange()
    {
        //turn back to original color?
    }
}