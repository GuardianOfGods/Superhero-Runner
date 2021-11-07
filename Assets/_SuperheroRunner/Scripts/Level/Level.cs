using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelState LevelState;

    public PlayerController Player;
    public BossController Boss;
    
    public void Start()
    {
        Player = GetComponentInChildren<PlayerController>();
        Boss = GetComponentInChildren<BossController>();
        LevelState = LevelState.Running;
    }
}

public enum LevelState
{
    Running,
    FinalCombat,
}
