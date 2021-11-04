using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Data
{
    #region GAME_DATA

    public static int CurrentLevel
    {
        get { return GetInt(Constant.INDEX_LEVEL_CURRENT, 1); }

        set
        {
            SetInt(Constant.INDEX_LEVEL_CURRENT, value);
            EventController.CurrentLevelChanged?.Invoke();
        }
    }

    #endregion
    
    #region SOUND_DATA

    public static bool SoundState
    {
        get => GetBool(Constant.SOUND_STATE, true);
        set => SetBool(Constant.SOUND_STATE, value);
    }

    public static bool MusicState
    {
        get => GetBool(Constant.MUSIC_STATE, true);
        set => SetBool(Constant.MUSIC_STATE, value);
    }

    public static bool VibrateState
    {
        get => GetBool(Constant.VIBRATE_STATE, false);
        set => SetBool(Constant.VIBRATE_STATE, value);
    }

    #endregion

    #region TIMER_DATA

    public static bool IsClaimedDailyReward()
    {
        if (LastDailyRewardClaim == "") return false;
        return (int) (DateTime.Now - DateTime.Parse(Data.LastDailyRewardClaim)).TotalDays == 0;
    }

    public static string DateTimeStart
    {
        get => GetString(Constant.DATE_TIME_START, "");
        set => SetString(Constant.DATE_TIME_START, value);
    }

    public static int TotalPlayedDays =>
        (int) (DateTime.Now - DateTime.Parse(DateTimeStart)).TotalDays + 1;

    public static int DailyRewardDayIndex => (TotalPlayedDays - 1) % 7 + 1;

    public static string LastDailyRewardClaim
    {
        get => GetString(Constant.LAST_DAILY_REWARD_CLAIM, "");
        set => SetString(Constant.LAST_DAILY_REWARD_CLAIM, value);
    }

    #endregion

    #region PLAYER_DATA
    
    public static int CoinTotal
    {
        get => GetInt(Constant.COIN_TOTAL, 0);
        set
        {
            SetInt(Constant.COIN_TOTAL, value);
            EventController.CoinTotalChanged?.Invoke();
        }
    }

    public static int ProgressAmount
    {
        get => GetInt(Constant.PROGRESS_AMOUNT, 0);
        set => SetInt(Constant.PROGRESS_AMOUNT, value);
    }

    public static int CurrentEquipedSkin
    {
        get => GetInt(Constant.CURRENT_EQUIPED_SKIN, 0);

        set
        {
            SetInt(Constant.CURRENT_EQUIPED_SKIN, value);
            EventController.CurrentEquipedSkinChanged?.Invoke();
        }
    }

    #endregion

    #region SKIN_DATA

    public static string IdSkinCheckUnlocked = "";

    public static bool IsSkinUnlocked
    {
        get => GetBool(IdSkinCheckUnlocked, false);
        set => SetBool(IdSkinCheckUnlocked, value);
    }

    #endregion

    #region IAP_DATA

    public static string IdIAPCheckUnlocked = "";

    public static bool IsIAPUnlocked
    {
        get => GetBool(IdIAPCheckUnlocked, false);
        set => SetBool(IdIAPCheckUnlocked, value);
    }

    #endregion
}

public static partial class Data
{
    private static bool GetBool(string key, bool defaultValue = false) =>
        PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;

    private static void SetBool(string id, bool value) => PlayerPrefs.SetInt(id, value ? 1 : 0);

    private static int GetInt(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
    private static void SetInt(string id, int value) => PlayerPrefs.SetInt(id, value);

    private static string GetString(string key, string defaultValue) => PlayerPrefs.GetString(key, defaultValue);
    private static void SetString(string id, string value) => PlayerPrefs.SetString(id, value);
}