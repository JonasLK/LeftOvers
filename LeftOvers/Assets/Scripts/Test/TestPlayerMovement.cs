using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public int teamNumber;
    public GameObject tileBellow;
    private TestTileCalculator testTileCalculator;

    public bool moveAble;
    bool moving;

    public int movement;
    public int movementLeft;
    public Transform moveTo;
    public float speed;

    public bool actionAvailable;

    public GameObject[] tiles;

    void Start()
    {
        movementLeft = movement;
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        moveAble = false;
    }


    public void MoveToTile()
    {
        if(moveAble == true)
        {
            if (GameManager.raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().movementDistance <= movementLeft && GameManager.raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().untraversable == false && GameManager.raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().occupied == false)
            {
                moveTo = GameManager.raycastClick.lastClickedTile.transform;
                moving = true;

                movementLeft -= GameManager.raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().movementDistance;

                tileBellow.GetComponent<TestTileCalculator>().occupied = false;
                GameManager.raycastClick.lastClickedFriendlyUnit.transform.position = moveTo.position;
                //transform.Translate(moveTo.transform.position * Time.deltaTime * speed);
                if (tileBellow == moveTo.gameObject)
                {
                    moving = false;
                    tileBellow.transform.gameObject.GetComponent<TestTileCalculator>().occupied = true;
                }
            }
        }
    }

    //call after every turn
    public void ResetCharacter()
    {
        movementLeft = movement;
        actionAvailable = true;
    }

    public void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == "Tile")
        {
            tileBellow = o.gameObject;
        }
    }

    public void OnClickUnit()
    {
        if (teamNumber == GameManager.turnTracker.playerTurn)
        {
            if (testTileCalculator != tileBellow.GetComponent<TestTileCalculator>())
            {
                testTileCalculator = tileBellow.GetComponent<TestTileCalculator>();
            }
            testTileCalculator.firstTile = true;
            testTileCalculator.ResetHexagonDistance();
            testTileCalculator.CalculateHexagonDistance();

            foreach (GameObject tile in tiles)
            {
                if (tile.GetComponent<TestTileCalculator>().movementDistance <= movementLeft)
                {
                    tile.GetComponent<TestTileCalculator>().ShowMovementRange();
                }
            }
        }
    }
}