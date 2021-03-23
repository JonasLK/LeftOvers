using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        gameObject.GetComponentInParent<UnitCount>().ResetUnits();
        GameManager.turnTracker.Destroy();
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
