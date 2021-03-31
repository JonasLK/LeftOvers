using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static TurnTracker turnTracker;
    public static TestSpawnUnit testSpawnUnit;
    public static PlayerUnitSlots playerUnitSlots;
    public static RaycastClick raycastClick;
    public static UnitSpawnList unitSpawnList;

    private bool fakeStart;

    void Start()
    {
        gameManager = this;
        turnTracker = GetComponent<TurnTracker>();
        testSpawnUnit = GetComponent<TestSpawnUnit>();
        playerUnitSlots = GetComponent<PlayerUnitSlots>();
        raycastClick = GetComponent<RaycastClick>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && fakeStart == false)
        {
            unitSpawnList = GameObject.FindGameObjectWithTag("UnitSpawn").GetComponent<UnitSpawnList>();
            fakeStart = true;
        }
    }
}
