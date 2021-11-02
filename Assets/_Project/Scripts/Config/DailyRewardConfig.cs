using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardConfig", menuName = "ScriptableObject/DailyRewardConfig")]
public class DailyRewardConfig : ScriptableObject
{
    public List<DailyRewardData> DailyRewardDatas;
}

[Serializable]
public class DailyRewardData
{
    public DailyRewardType DailyRewardType;
    public Sprite Icon;
    public Vector2 PrefixSizeIcon;
    public SkinData Skin;
    public int Value;
}

