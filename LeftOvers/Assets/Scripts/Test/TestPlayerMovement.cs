using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public int teamNumber;
    public GameObject tileBellow;
    private TestTileCalculator testTileCalculator;
    private TurnTracker turnTracker;
    private RaycastClick raycastClick;

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
        turnTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurnTracker>();
        raycastClick = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RaycastClick>();
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        moveAble = false;
    }


    public void MoveToTile()
    {
        if(moveAble == true)
        {
            if (raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().movementDistance <= movementLeft && raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().untraversable == false && raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().occupied == false)
            {
                moveTo = raycastClick.lastClickedTile.transform;
                moving = true;

                movementLeft -= raycastClick.lastClickedTile.GetComponent<TestTileCalculator>().movementDistance;

                tileBellow.GetComponent<TestTileCalculator>().occupied = false;
                raycastClick.lastClickedFriendlyUnit.transform.position = moveTo.position;
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
        if (teamNumber == turnTracker.playerTurn)
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
                    tile.GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }
}