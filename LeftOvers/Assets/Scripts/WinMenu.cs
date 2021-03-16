using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public TurnTracker turnTracker;

    void Start()
    {
        turnTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TurnTracker>();
    }


    void Update()
    {
        
    }

    public void MainMenu()
    {
        gameObject.GetComponentInParent<UnitCount>().ResetUnits();
        turnTracker.Destroy();
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
