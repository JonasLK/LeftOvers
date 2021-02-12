using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseMenuButtons;
    public GameObject settingsMenu;
    public bool pauseMenuOpen;
    public bool settingsMenuOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (pauseMenuOpen == false)
            {
                OpenPauseMenu();
                pauseMenuOpen = true;
            }
            else if (settingsMenuOpen == true)
            {
                settingsMenu.SetActive(false);
                pauseMenuButtons.SetActive(true);
                ClosingSettings();
            }
            else
            {
                ClosePauseMenu();
                pauseMenuOpen = false;
            }
        }
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void OpeningSettings()
    {
        settingsMenuOpen = true;
    }

    public void ClosingSettings()
    {
        settingsMenuOpen = false;
    }
}
