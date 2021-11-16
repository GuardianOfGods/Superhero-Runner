using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObject/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Range(.1f,1f)] public float DurationPopup = .5f;
    [Range(1,1000)] public int DiamondPerGather = 10;
    
    
    public bool EnableAds;
    public bool EnableTest;
    public List<Level> Levels;
}
