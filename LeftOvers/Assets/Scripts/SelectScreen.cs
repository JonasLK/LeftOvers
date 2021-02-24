using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScreen : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public void Start()
    {
        player1.SetActive(true);
        player2.SetActive(false);
        player3.SetActive(false);
    }

    public void Player1()
    {
        player1.SetActive(true);
        player2.SetActive(false);
        player3.SetActive(false);
    }
    public void Player2()
    {
        player2.SetActive(true);
        player1.SetActive(false);
        player3.SetActive(false);
    }
    public void Player3()
    {
        player3.SetActive(true);
        player1.SetActive(false);
        player2.SetActive(false);
    }
}
