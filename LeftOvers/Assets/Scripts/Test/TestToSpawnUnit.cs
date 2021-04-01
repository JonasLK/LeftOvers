using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestToSpawnUnit : MonoBehaviour
{
    public GameObject unitToSpawn;

    public void SendUnitToSpawn()
    {
        GameManager.testSpawnUnit.unitToInstanciate = unitToSpawn;
    }
}