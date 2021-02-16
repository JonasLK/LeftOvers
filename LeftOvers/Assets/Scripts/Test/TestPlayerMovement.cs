using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public int teamNumber;
    public GameObject tileBellow;
    private TestTileCalculator testTileCalculator;
    private TurnTracker turnTracker;

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
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }


    void Update()
    {
        if(teamNumber == turnTracker.playerTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.gameObject.tag == "Tile")
                    {
                        if(hit.transform.gameObject.GetComponent<TestTileCalculator>().movementDistance <= movementLeft)
                        {
                            moveTo = hit.transform;
                            moving = true;

                            movementLeft -= hit.transform.gameObject.GetComponent<TestTileCalculator>().movementDistance;
                        }
                    }
                }
            }


            //moving
            if(moving == true)
            {

                gameObject.transform.position = moveTo.position;
                //transform.Translate(moveTo.transform.position * Time.deltaTime * speed);
                if(tileBellow == moveTo.gameObject)
                {
                    moving = false;
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

    public void OnMouseDown()
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