using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTracker : MonoBehaviour
{
    public float player1Units;
    public float player2Units;
    public float player3Units;
    public float player4Units;

    private void Start()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        foreach (GameObject unit in units)
        {
            if (gameObject.GetComponent<Unit>().unitTeamColor == 1)
            {
                player1Units++;
            }
            if (gameObject.GetComponent<Unit>().unitTeamColor == 2)
            {
                player2Units++;
            }
            if (gameObject.GetComponent<Unit>().unitTeamColor == 3)
            {
                player3Units++;
            }
            if (gameObject.GetComponent<Unit>().unitTeamColor == 4)
            {
                player4Units++;
            }
        }
    }

    void Update()
    {
        if(player1Units <= 0)
        {
            //player1won
        }
        if (player2Units <= 0)
        {

        }
        if (player3Units <= 0)
        {

        }
        if (player4Units <= 0)
        {

        }
    }
}
