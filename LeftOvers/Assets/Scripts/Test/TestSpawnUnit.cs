using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnUnit : MonoBehaviour
{
    public bool placingUnit;
    public GameObject toSpawnUnit;
    public GameObject justSpawnedUnit;
    public GameObject button;

    public TurnTracker turnTracker;
    public RaycastClick raycastClick;

    void Start()
    {
        turnTracker = GetComponent<TurnTracker>();
        raycastClick = GetComponent<RaycastClick>();
    }

    void Update()
    {
        
    }

    public void SpawnUnit(Transform tileLocation)
    {
        print("spawn");
        turnTracker.AddToListList(Instantiate(toSpawnUnit, tileLocation.position, Quaternion.identity));
        placingUnit = false;
        DestroyButton();
    }

    public void PlacingUnits(GameObject unitToSpawn)
    {
        print("place");
        //show placeable tiles
        toSpawnUnit = unitToSpawn;
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
