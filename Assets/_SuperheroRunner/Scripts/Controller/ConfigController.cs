using System;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private SoundConfig soundConfig;
    [SerializeField] private DailyRewardConfig dailyRewardConfig;
    [SerializeField] private SkinConfig skinConfig;

    public static GameConfig Game;
    public static SoundConfig Sound;
    public static DailyRewardConfig DailyRewardConfig;
    public static SkinConfig SkinConfig;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Game = gameConfig;
        Sound = soundConfig;
        DailyRewardConfig = dailyRewardConfig;
        SkinConfig = skinConfig;

        if (Data.DateTimeStart == "")
        {
            Data.DateTimeStart = DateTime.Now.ToString();
            //SkinConfig.SkinDatas[0].IsUnlocked = true;
        }
    }
}