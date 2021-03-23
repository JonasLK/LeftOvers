using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static TurnTracker turnTracker;
    public static TestSpawnUnit testSpawnUnit;
    public static PlayerUnitSlots playerUnitSlots;
    public static RaycastClick raycastClick;

    void Start()
    {
        gameManager = this;
        turnTracker = GetComponent<TurnTracker>();
        testSpawnUnit = GetComponent<TestSpawnUnit>();
        playerUnitSlots = GetComponent<PlayerUnitSlots>();
        raycastClick = GetComponent<RaycastClick>();
    }
}
