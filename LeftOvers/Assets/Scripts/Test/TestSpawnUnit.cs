using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnUnit : MonoBehaviour
{
    public bool placingUnit;
    public GameObject unitToSpawn;
    public GameObject justSpawnedUnit;
    public GameObject button;

    public RaycastClick raycastClick;

    void Start()
    {
        raycastClick = GetComponent<RaycastClick>();
    }

    void Update()
    {
        
    }

    public void SpawnUnit(Transform tileLocation)
    {
        print("spawn");
        GameManager.turnTracker.AddToList(Instantiate(unitToSpawn, tileLocation.position, Quaternion.identity));
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
