using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public GameObject mainMenu;

    public static bool map1;
    public static bool map2;

    public GameObject map1Info;
    public GameObject map2Info;
    public void SelectMap1()
    {
        map1 = true;
        map2 = false;
        map1Info.SetActive(true);
        map2Info.SetActive(false);
    }
    public void SelectMap2()
    {
        map2 = true;
        map1 = false;
        map2Info.SetActive(true);
        map1Info.SetActive(false);
    }

    public void LoadMap()
    {
        if(map1 == true)
        {
            SceneManager.LoadScene(2);
            ResetSelection();
        }
        if(map2 == true)
        {
            SceneManager.LoadScene(3);
            ResetSelection();
        }
    }

    public void Confirm()
    {
        SceneManager.LoadScene(1);
    }
    public void ResetSelection()
    {
        map1 = false;
        map2 = false;
    }
    public void Back()
    {
        ResetSelection();
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
