using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnUnit : MonoBehaviour
{
    public bool placingUnit;
    public GameObject toSpawnUnit;
    public GameObject justSpawnedUnit;

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
        Instantiate(toSpawnUnit, tileLocation.position, Quaternion.identity);
        placingUnit = false;
        //remove button
    }

    public void PlacingUnits(GameObject unitToSpawn)
    {
        //show placeable tiles
        toSpawnUnit = unitToSpawn;
        placingUnit = true;
    }
}
