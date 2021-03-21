using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNumber;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void SelectSceneToLoad(int sceneToLoad)
    {
        sceneNumber = sceneToLoad;
    }
}