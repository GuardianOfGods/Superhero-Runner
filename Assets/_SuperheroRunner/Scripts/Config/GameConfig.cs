using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObject/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("GD config")]
    public int CostUpgradeFirstLevel = 45;
    public int CostPerUpgradeLevel = 5;
    [Range(1,1000)] public int DiamondPerGather = 10;

    [Header("Dev config")]
    [Range(.1f,1f)] public float DurationPopup = .5f;
    
    public int GetCostToUpgradeLevel(int level)
    {
        return CostUpgradeFirstLevel + CostPerUpgradeLevel * level;
    }
}
