using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnUnit : MonoBehaviour
{
    public bool placingUnit;
    public GameObject unitToInstanciate;
    public GameObject justSpawnedUnit;
    public GameObject button;

    public void SpawnUnit(Transform tileLocation)
    {
        print("spawn");
        GameManager.turnTracker.AddToList(Instantiate(unitToInstanciate, tileLocation.position, Quaternion.identity));
        placingUnit = false;
        DestroyButton();
    }

    public void PlacingUnits()
    {
        placingUnit = true;
    }

    public void DestroyButton()
    {
        Destroy(button);
    }

    public void SelectButtonToDestroy(GameObject buttonToDestroy)
    {
        button = buttonToDestroy;
    }
}
