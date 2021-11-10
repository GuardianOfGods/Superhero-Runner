using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Prefabs")] 
    public Road MainRoadPrefab;
    public PlayerController PlayerPrefab;
    [Header("Level Attributes")]
    public LevelState LevelState;
    public Road MainRoad;
    public PlayerController Player;
    public BossController Boss;

    public void Start()
    {
        LevelState = LevelState.Running;
    }

    public void GenerateMap()
    {
        Utility.Clear(transform);
        MainRoad = Instantiate(MainRoadPrefab, transform);
        Player = Instantiate(PlayerPrefab, transform);
    }
}

public enum LevelState
{
    Running,
    FinalCombat,
}
