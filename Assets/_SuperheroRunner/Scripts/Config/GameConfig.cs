using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObject/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("GD config")] 
    public int DiamondWinValueNormal=35;
    public int DiamondWinValueSpecial=50;
    public int CostUpgradeFirstLevel = 45;
    public int CostPerUpgradeLevel = 5;
    public int CostUpgradeFirstPower = 75;
    public int CostPerUpgradePower = 15;
    [Range(1,1000)] public int DiamondPerGather = 10;

    [Header("Dev config")]
    [Range(.1f,1f)] public float DurationPopup = .5f;
    
    public int GetCostToUpgradeLevel(int level)
    {
        return CostUpgradeFirstLevel + CostPerUpgradeLevel * level;
    }
    
    public int GetCostToUpgradePower(int power)
    {
        return CostUpgradeFirstPower + CostPerUpgradePower * power;
    }
}
