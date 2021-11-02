using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObject/GameConfig")]
public class GameConfig : ScriptableObject
{
    public float DurationPopup = .5f;
    public bool EnableAds;
    public bool EnableTest;
    public List<Level> Levels;
}
