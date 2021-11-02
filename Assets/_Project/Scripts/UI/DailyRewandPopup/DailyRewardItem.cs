using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardItem : MonoBehaviour
{
    [Range(1, 7)] public int DayIndex;
    public int CoinValue;

    public DailyRewardItemState DailyRewardItemState;
    public Image ItemBackground;
    public TextMeshProUGUI DailyText;
    public TextMeshProUGUI CoinText;
    public GameObject GreenTick;

    public void SetUp(int i)
    {
        SetUpData();
        SetupUI(i);
    }

    private void SetUpData()
    {
        // SET UP STATE
        if (Data.DailyRewardDayIndex > DayIndex)
        {
            DailyRewardItemState = DailyRewardItemState.Claimed;
        }
        else if (Data.DailyRewardDayIndex == DayIndex)
        {
            if (Data.IsClaimedDailyReward())
            {
                DailyRewardItemState = DailyRewardItemState.Claimed;
            }
            else
            {
                DailyRewardItemState = DailyRewardItemState.ReadyToClaim;
            }
        }
        else
        {
            DailyRewardItemState = DailyRewardItemState.NotClaim;
        }

        // SET UP GOLD
        CoinValue = ConfigController.DailyRewardConfig.DailyRewardDatas[DayIndex - 1].Value;
    }

    public void SetupUI(int i)
    {
        // CHANGE TEXT DAY
        DailyText.text = "DAY " + (Data.TotalPlayedDays - ((Data.TotalPlayedDays-1) % 7 +1) + i + 1);

        // CHANGE COIN TEXT
        if (CoinText != null)
        {
            CoinText.text = CoinValue.ToString();
        }

        // CHANGE COLOR
        switch (DailyRewardItemState)
        {
            case DailyRewardItemState.Claimed:
                ItemBackground.color = new Color32(229, 229, 229, 255);
                DailyText.color = new Color32(170, 135, 236, 255);
                CoinText.color = new Color32(170, 135, 236, 255);
                GreenTick.SetActive(true);
                break;
            case DailyRewardItemState.ReadyToClaim:
                ItemBackground.color = new Color32(35, 216, 39, 255);
                GreenTick.SetActive(false);
                break;
            case DailyRewardItemState.NotClaim:
                ItemBackground.color = new Color32(229, 206, 186, 255);
                GreenTick.SetActive(false);
                break;
        }
    }
}